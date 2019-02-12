using System;
using System.Collections.Generic;
using System.Linq;
using combit.ListLabel24.DataProviders;
using System.Data.OleDb;
using System.Data;
using System.Web.Configuration;
using combit.ListLabel24;
using System.Runtime.Caching;


namespace DataAccess
{
    static class CmbtSettings
    {
        public static int ArtkRecCount { get { return 20; } }
        public static LlLanguage Language { get { return LlLanguage.English; } }

        public static int MultiTabRecCount { get { return 5; } }

        public static List<string> UnlimitedRecordsList
        {
            get
            {
                return new List<string>() { "Customer list with sort order.srt", "Kundenliste mit Sortierung.lsr", "Crosstab with comparison of previous year.srt", "Kreuztabelle mit Vorjahresvergleich.lsr", "Conditional formatting and native aggregate functions.srt", "Bedingte Formatierung und native Aggregatsfunktionen.lsr" };
            }
        }

        public static List<string> IsEmployeeList
        {
            get
            {
                return new List<string>() { "Mixed portrait and landscape.srt", "Mischung von Hoch- und Querformat.lsr", "Crosstab.srt", "Kreuztabelle.lsr" };
            }
        }
    }


    public static class SampleData
    {
        public static DataProviderCollection CreateProviderCollection(string reportName, bool forDesign)
        {
            //DE: Caching der Daten
            //US: Caching Data
            ObjectCache cache = MemoryCache.Default;
            DataProviderCollection cachedCollection = (DataProviderCollection)cache.Get(reportName);
            if (!forDesign && cachedCollection != null)
            {
                return cachedCollection;
            }
            else
            {
                DataProviderCollection providerCollection = new DataProviderCollection();
                DataSet ds;
                if (DataAccess.CmbtSettings.UnlimitedRecordsList.Contains(reportName))
                {
                    ds = DataAccess.NorthWndDataSetHelper.CreateFullDataSet();
                }
                else
                {
                    ds = DataAccess.NorthWndDataSetHelper.CreateDataSet(DataAccess.CmbtSettings.IsEmployeeList.Contains(reportName));
                    DataSet gDs = LlDemoDataSources.GantDS();
                    providerCollection.Add(new AdoDataProvider(gDs));
                }
                providerCollection.Add(new AdoDataProvider(ds));
                CacheItemPolicy cachePolicy = new CacheItemPolicy
                {
                    AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(30.0)
                };
                cache.Add(reportName, providerCollection, cachePolicy);
                return (providerCollection);
            }
        }

    }

    class LlDemoDataSources
    {
        #region Gantt DB
        public static DataSet GantDS()
        {
            DataSet ds = new DataSet();

            List<string> TableNames;

            //get the tables for gantt
            TableNames = new List<string> { "Pollen", "Project", "ClimateData", "Venue", "SalesStages", "Sales", "Budget", "BusinessActivityTime", "Keyword" };
            OleDbConnection conn = new OleDbConnection(WebConfigurationManager.ConnectionStrings["Gantt"].ConnectionString);
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {

                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            foreach (string tableName in TableNames)
            {

                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(new OleDbCommand(String.Format("SELECT * FROM {0}", tableName), conn));
                DataTable dtData = new DataTable(tableName);
                dataAdapter.Fill(dtData);
                dtData.TableName = tableName;
                ds.Tables.Add(dtData);
            }


            object[] restrictions1 = new Object[] { null, null, null, null };
            DataTable table1 = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Foreign_Keys, restrictions1);

            //D: Relationen auslesen
            //US: Get relations
            foreach (DataRow dr in table1.Rows)
            {
                string childTable = dr["FK_TABLE_NAME"].ToString();
                string childCol = dr["FK_COLUMN_NAME"].ToString();
                // D:  Eltern = Primary
                //US: Parent = primary
                string parentTable = dr["PK_TABLE_NAME"].ToString();
                string parentCol = dr["PK_COLUMN_NAME"].ToString();
                string relationName = parentTable + "2" + childTable;

                //D: Beziehung zwischen den Tabellen definieren
                //US: Create the relationships between the tables
                ds.Relations.Add(new DataRelation(relationName, ds.Tables[parentTable].Columns[parentCol], ds.Tables[childTable].Columns[childCol]));
            }

            conn.Close();


            //D: Datumsangaben modernisieren
            //US: modernize dates
            try
            {

                int yearOffset = DateTime.Now.Year - 2010 + 15;

                Dictionary<string, List<string>> tablesWithDates = new Dictionary<string, List<string>>
                {
                    { "Project", new List<string> { "BeginDate" } },
                    { "Pollen", new List<string> { "PeriodBegin", "PeriodEnd" } }
                };

                foreach (string tableName in tablesWithDates.Keys)
                {
                    DataTable dtOrder = ds.Tables[tableName];

                    List<String> dateColumns = (List<string>)tablesWithDates[tableName];
                    foreach (string dateColumn in dateColumns)
                    {
                        dtOrder.Select().ToList<DataRow>().ForEach(r => r[dateColumn] = (r[dateColumn] != DBNull.Value) ? ((DateTime)r[dateColumn]).AddYears(yearOffset) : r[dateColumn]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ListLabelException(ex.ToString());
            }


            return ds;

        }
        #endregion

        #region Article /Item DB
        public static DataTable GetArticleDataTable(bool isLocalization, bool isInvoice = false)
        {
            //get the datasource for the article projects (standalone)
            DataTable dt = new DataTable();
            string tableName = string.Empty;
            OleDbConnection conn = new OleDbConnection(WebConfigurationManager.ConnectionStrings["Gantt"].ConnectionString);
            conn.Open();
            int requestedRows = CmbtSettings.ArtkRecCount;
            if (isLocalization)
            {
                tableName = "Item";
            }
            else
            {
                tableName = CmbtSettings.Language == LlLanguage.German ? "Artikel" : "Item";
            }


            int tableRows = CountTableRows(conn, tableName);//counted rows in table
            OleDbCommand cmd = null;
            OleDbDataReader reader = null;

            //check table is limited or multiplied
            if (requestedRows <= tableRows & !isInvoice)
            {
                cmd = new OleDbCommand("Select TOP " + CmbtSettings.ArtkRecCount.ToString() + " * from   " + tableName + " ", conn);
                reader = cmd.ExecuteReader();
                dt.Load(reader);
            }
            else
            {
                cmd = new OleDbCommand("Select * from " + tableName, conn);
                reader = cmd.ExecuteReader();
                dt.Load(reader);
                //multiple datatable
                MultipleDataTable(dt, requestedRows);
            }

            if (isLocalization)
            { dt.TableName = "Item"; }

            else
            { dt.TableName = CmbtSettings.Language == LlLanguage.German ? "Artikel" : "Item"; }

            return dt;
        }
        #endregion

        #region Helper Methods
        public static DataTable MultipleDataTable(DataTable dt, int requestedRows)
        {
            //function to multiple an datatable
            DataTable _dt = dt;
            int countRows = dt.Rows.Count;
            int _requestedRows = requestedRows - countRows;
            int counter = -1;
            for (int i = 0; i < _requestedRows; i++)
            {
                counter++;
                _dt.ImportRow(_dt.Rows[counter]);
                if (counter > countRows)
                    counter = 0;
            }

            return _dt;

        }
        public static int CountTableRows(OleDbConnection conn, string tableName)
        {
            ICloneable cloneable = (ICloneable)conn;
            string query = "SELECT COUNT(*) FROM " + tableName;
            int count = 0;
            try
            {
                using (OleDbConnection thisConnection = (OleDbConnection)cloneable.Clone())
                {
                    using (OleDbCommand cmdCount = new OleDbCommand(query, thisConnection))
                    {
                        if (thisConnection.State != ConnectionState.Open)
                            thisConnection.Open();
                        count = (int)cmdCount.ExecuteScalar();
                    }
                }
            }
            catch (OleDbException ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

            return count;
        }
        #endregion
    }


    public static class NorthWndDataSetHelper
    {
        #region Members
        private static DataTable dtCustomers;
        private static DataTable dtOrders;
        private static DataTable dtOrder_details;
        private static DataTable dtEmployees;
        private static DataTable dtShippers;
        private static bool IsEmployeeList;
        private static DataSet ds;
        private static OleDbConnection conn;
        private static int requestedRows;
        #endregion

        #region Public Methods
        //needed for extended sample
        public static DataSet CreateDataSet(bool isEmployeeList)
        {
            //D: DataSet Objekt erstellen
            //US: Create the DataSet object
            ds = new System.Data.DataSet();
            dtCustomers = new DataTable("Customers");
            dtEmployees = new DataTable("Employees");
            dtShippers = new DataTable("Shippers");
            dtOrders = new DataTable("Orders");
            dtOrder_details = new DataTable("Order Details");
            IsEmployeeList = isEmployeeList;
            string query;
            int tableRows = 0; //counted rows in table
            requestedRows = CmbtSettings.MultiTabRecCount;

            conn = new OleDbConnection(WebConfigurationManager.ConnectionStrings["NWind"].ConnectionString);
            conn.Open();

            //count rows from customer tabel
            tableRows = LlDemoDataSources.CountTableRows(conn, "Customers");

            object[] restrictions = new Object[] { null, null, null, "TABLE" };
            DataTable table = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, restrictions);

            //D: Durch alle Tabellen iterieren und in das DataSet aufnehmen
            //US: Iterate all tabels and add them to the DataSet
            foreach (DataRow dr in table.Rows)
            {
                string tableName = dr["Table_Name"].ToString();
                OleDbDataAdapter dataAdapter;

                //standardquery for all records
                query = "SELECT * FROM [" + tableName + "]";

                //check table is limited or multiplied
                if (requestedRows <= tableRows)
                {
                    switch (tableName)
                    {
                        case "Customers":
                            query = "SELECT TOP " + requestedRows + " * FROM [" + tableName + "]";
                            break;

                        default:
                            query = "SELECT * FROM [" + tableName + "]";
                            break;
                    }
                }
                dataAdapter = new OleDbDataAdapter(new OleDbCommand(query, conn));

                //fill datatables and dataset
                switch (tableName)
                {
                    case "Customers":
                        dataAdapter.Fill(dtCustomers);
                        dtCustomers.TableName = tableName;
                        ds.Tables.Add(dtCustomers);
                        break;

                    case "Shippers":
                        //fill the shippers (equals shipperid)
                        dataAdapter.Fill(dtShippers);
                        GetFilteredData("Shippers");
                        dtShippers.TableName = "Shippers";
                        ds.Tables.Add(dtShippers);
                        break;

                    case "Employees":
                        dataAdapter.Fill(dtEmployees);
                        //get all employees
                        if (!IsEmployeeList)
                        {
                            dtEmployees.TableName = "Employees";
                            ds.Tables.Add(dtEmployees);
                        }
                        break;

                    case "Orders":
                        dataAdapter.Fill(dtOrders);
                        //limited orders to available customers
                        GetFilteredData(tableName);
                        dtOrders.TableName = tableName;
                        ds.Tables.Add(dtOrders);

                        //fill the order details (equals OrderID)
                        GetFilteredData("Order Details");
                        dtOrder_details.TableName = "Order Details";
                        ds.Tables.Add(dtOrder_details);

                        //get filtered employees
                        if (IsEmployeeList)
                        {
                            //fill the Employees (equals EmployeeID)
                            GetFilteredData("Employees");
                            dtEmployees.TableName = "Employees";
                            ds.Tables.Add(dtEmployees);
                        }
                        break;

                    case "Order Details":
                        //get all orders
                        dataAdapter.Fill(dtOrder_details);
                        break;

                    default:
                        dataAdapter.FillSchema(ds, SchemaType.Source, tableName);
                        dataAdapter.Fill(ds, tableName);
                        break;
                }

            }


            object[] restrictions1 = new Object[] { null, null, null, null };
            DataTable table1 = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Foreign_Keys, restrictions1);

            //D: Relationen auslesen
            //US: Get relations
            foreach (DataRow dr in table1.Rows)
            {
                string childTable = dr["FK_TABLE_NAME"].ToString();
                string childCol = dr["FK_COLUMN_NAME"].ToString();
                // D:  Eltern = Primary
                //US: Parent = primary
                string parentTable = dr["PK_TABLE_NAME"].ToString();
                string parentCol = dr["PK_COLUMN_NAME"].ToString();
                string relationName = parentTable + "2" + childTable;

                //D: Beziehung zwischen den Tabellen definieren
                //US: Create the relationships between the tables
                ds.Relations.Add(new DataRelation(relationName, ds.Tables[parentTable].Columns[parentCol], ds.Tables[childTable].Columns[childCol]));
            }

            //D: Verbindung schliessen
            //US: Close connection
            conn.Close();
            ClearTables();

            //D: Datumsangaben modernisieren
            //US: modernize dates
            try
            {
                int yearOffset = DateTime.Now.Year - 2010 + 15;
                DataTable dtOrder = ds.Tables["Orders"];

                List<String> dateColumns = new List<string>() { "OrderDate", "RequiredDate", "ShippedDate" };
                foreach (string dateColumn in dateColumns)
                {
                    dtOrder.Select().ToList<DataRow>().ForEach(r => r[dateColumn] = (r[dateColumn] != DBNull.Value) ? ((DateTime)r[dateColumn]).AddYears(yearOffset) : r[dateColumn]);
                }
            }
            catch (Exception ex)
            {
                throw new ListLabelException(ex.ToString());
            }

            return (ds);
        }


        public static DataSet CreateFullDataSet()
        {
            DataSet ds = new System.Data.DataSet();

            //D: DataSet Objekt erstellen
            //US: Create the DataSet object
            conn = new OleDbConnection(WebConfigurationManager.ConnectionStrings["NWind"].ConnectionString);

            conn.Open();

            object[] restrictions = new Object[] { null, null, null, "TABLE" };
            DataTable table = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, restrictions);

            //D: Durch alle Tabellen iterieren und in das DataSet aufnehmen
            //US: Iterate all tabels and add them to the DataSet
            foreach (DataRow dr in table.Rows)
            {
                string tableName = dr["Table_Name"].ToString();
                OleDbDataAdapter dataAdapter;
                dataAdapter = new OleDbDataAdapter(new OleDbCommand("SELECT * FROM [" + tableName + "]", conn));

                dataAdapter.FillSchema(ds, SchemaType.Source, tableName);
                dataAdapter.Fill(ds, tableName);

            }


            object[] restrictions1 = new Object[] { null, null, null, null };
            DataTable table1 = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Foreign_Keys, restrictions1);

            //D: Relationen auslesen
            //US: Get relations
            foreach (DataRow dr in table1.Rows)
            {
                string childTable = dr["FK_TABLE_NAME"].ToString();
                string childCol = dr["FK_COLUMN_NAME"].ToString();
                // D:  Eltern = Primary
                //US: Parent = primary
                string parentTable = dr["PK_TABLE_NAME"].ToString();
                string parentCol = dr["PK_COLUMN_NAME"].ToString();
                string relationName = parentTable + "2" + childTable;

                //D: Beziehung zwischen den Tabellen definieren
                //US: Create the relationships between the tables
                ds.Relations.Add(new DataRelation(relationName, ds.Tables[parentTable].Columns[parentCol], ds.Tables[childTable].Columns[childCol]));
            }

            //D: Verbindung schliessen
            //US: Close connection
            conn.Close();

            //D: Datumsangaben modernisieren
            //US: modernize dates
            try
            {
                int yearOffset = DateTime.Now.Year - 2010 + 15;
                DataTable dtOrder = ds.Tables["Orders"];

                List<String> dateColumns = new List<string>() { "OrderDate", "RequiredDate", "ShippedDate" };
                foreach (string dateColumn in dateColumns)
                {
                    dtOrder.Select().ToList<DataRow>().ForEach(r => r[dateColumn] = (r[dateColumn] != DBNull.Value) ? ((DateTime)r[dateColumn]).AddYears(yearOffset) : r[dateColumn]);
                }
            }
            catch (Exception ex)
            {
                throw new ListLabelException(ex.ToString());
            }

            return (ds);
        }
        #endregion


        #region Private Methods
        private static void GetFilteredData(string tableName)
        {
            //needed function to get only the order and order details 
            //from available customers and orders
            IEnumerable<DataRow> result = null;
            DataTable dt = new DataTable(tableName);
            OleDbDataAdapter adapter;
            string columnValue;
            string query;

            if (tableName == "Orders")
            {
                //fill orders based on Employees and Customers
                if (IsEmployeeList)
                {
                    result = (from o in dtOrders.AsEnumerable()
                              join c in dtCustomers.AsEnumerable()
                              on o.Field<string>("CustomerID") equals c.Field<string>("CustomerID")
                              join e in dtEmployees.AsEnumerable()
                              on o.Field<int>("EmployeeID") equals e.Field<int>("EmployeeID")
                              select o).Take(requestedRows);
                    dtOrders = result.CopyToDataTable();
                }
                else
                {
                    //get all Orders based on Customers 
                    foreach (DataRow row in dtCustomers.Rows)
                    {
                        columnValue = row["CustomerID"].ToString();
                        query = "Select Top " + requestedRows + " * from [" + tableName + "] where [" + tableName + "].CustomerID = " + "'" + columnValue + "'";
                        adapter = new OleDbDataAdapter(new OleDbCommand(query, conn));
                        adapter.Fill(dt);

                        dtOrders = dt;
                    }
                }

            }
            else if (tableName == "Order Details")
            {
                //get order details from orders in order table
                result = from od in dtOrder_details.AsEnumerable()
                         join o in dtOrders.AsEnumerable()
                         on od.Field<int>("OrderID") equals o.Field<int>("OrderID")
                         select od;

                dtOrder_details = result.CopyToDataTable<DataRow>();

            }
            else if (tableName == "Shippers")
            {
                foreach (DataRow row in dtOrders.Rows)
                {
                    columnValue = row["ShipVia"].ToString();
                    query = "Select Top " + requestedRows + " * from [" + tableName + "] where [" + tableName + "].ShipperID = " + columnValue;
                    adapter = new OleDbDataAdapter(new OleDbCommand(query, conn));
                    adapter.Fill(dt);
                }

                //delete duplicates
                dtShippers = dt.AsEnumerable().Distinct(DataRowComparer.Default).CopyToDataTable();
            }

            else if (tableName == "Employees")
            {
                //get filtered Employees and delete duplicate
                result = from e in dtEmployees.AsEnumerable()
                         join o in dtOrders.AsEnumerable()
                         on e.Field<int>("EmployeeID") equals o.Field<int>("EmployeeID")
                         select e;

                //delete duplicates
                dtEmployees = result.AsEnumerable().Distinct(DataRowComparer.Default).CopyToDataTable();
            }

        }
        private static void ClearTables()
        {
            dtCustomers = null;
            dtOrder_details = null;
            dtOrders = null;
        }
        #endregion

    }

    #region Customer
    //D: Die Klasse "Customer" repraesentiert einen Kunden der n Bestellungen enthaelt 
    //US: The "Customer" class represents a customer who has n orders
    class Customer
    {
        //Constructor
        public Customer(int customerID, string company, string firstname, string lastname, string title, string salutationLetter, string street, string city)
        {
            CustomerID = customerID;
            Company = company;
            Firstname = firstname;
            Lastname = lastname;
            Title = title;
            SalutationLetter = salutationLetter;
            Street = street;
            City = city;
            Item = new List<Item>();
        }

        public List<Item> Item { get; set; }

        // D: Die CustomerID soll nicht im Designer zur Auswahl verfuegbar sein
        // US: The CustomerID should not be available in the designer
        public int CustomerID { get; set; }
        public string Company { get; set; }

        // D: Setze Property-Name, welcher im Designer verwendet werden soll
        // US: Set property name, which should be used in the designer
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Title { get; set; }
        public string SalutationLetter { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
    }
    #endregion

    #region Item
    //D: Die Klasse "Order" repraesentiert eine einzelne Bestellung eines Kunden
    //US: The "Order" class represents a single order of a customer
    class Item
    {
        //Constructor
        public Item(double price, string itemNo, string itemDescription, string itemDescription2, int quantity)
        {
            UnitPrice = price;
            ItemNo = itemNo;
            Description1 = itemDescription;
            Description2 = itemDescription2;
            Quantity = quantity;

        }
        public double UnitPrice { get; set; }
        public string ItemNo { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public int Quantity { get; set; }



        [FieldType(LlFieldType.Barcode_EAN128)]
        public string ItemNo_EAN128
        {
            get { return ItemNo.ToString(); }
        }

    }
    #endregion

}
