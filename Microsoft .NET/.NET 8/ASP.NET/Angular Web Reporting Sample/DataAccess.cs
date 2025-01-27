using System;
using System.Collections.Generic;
using System.Linq;
using combit.Reporting.DataProviders;
using System.Data;
using combit.Reporting;
using Microsoft.Extensions.Caching.Memory;
using System.IO;

namespace AngularWebReportingSample.DataAccess
{
    static class CmbtSettings
    {
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
            IMemoryCache cache = MemoryCache.Default;
            DataProviderCollection cachedCollection = (DataProviderCollection)cache.Get(reportName);
            if (!forDesign && cachedCollection != null)
            {
                return cachedCollection;
            }
            else
            {
                DataProviderCollection providerCollection = new();
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
                cache.Set(reportName, providerCollection, DateTimeOffset.Now.AddMinutes(30.0));
                return (providerCollection);
            }
        }

    }

    class LlDemoDataSources
    {
        #region Gantt DB
        public static DataSet GantDS()
        {
            DataSet ds = new();

            //D: Laden der Daten (XML) in das DataSet
            //US: load DataSet from the XML
            var xmlFile = Program.GanttDatabaseXmlFile;
            var xmlSchemaFile = Path.Combine(Path.GetDirectoryName(xmlFile), Path.GetFileNameWithoutExtension(xmlFile) + "_schema.xml");
            ds.ReadXmlSchema(xmlSchemaFile);
            ds.ReadXml(xmlFile);
            
            //D: Datumsangaben modernisieren
            //US: modernize dates
            try
            {

                int yearOffset = DateTime.Now.Year - 2010 + 15;

                Dictionary<string, List<string>> tablesWithDates = new()
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

    }


    public static class NorthWndDataSetHelper
    {
        #region Members
        private static DataSet ds;
        #endregion

        #region Public Methods
        //needed for extended sample
        public static DataSet CreateDataSet(bool isEmployeeList)
        {
            //D: DataSet Objekt erstellen
            //US: Create the DataSet object
            ds = new System.Data.DataSet();

            //D: Laden der Daten (XML) in das DataSet
            //US: load DataSet from the XML
            var xmlFile = isEmployeeList ? Program.NorthwindSmallDatabaseWithEmployeeListXmlFile : Program.NorthwindSmallDatabaseXmlFile;
            var xmlSchemaFile = Path.Combine(Path.GetDirectoryName(xmlFile), Path.GetFileNameWithoutExtension(xmlFile) + "_schema.xml");
            ds.ReadXmlSchema(xmlSchemaFile);
            ds.ReadXml(xmlFile);
            
            //D: Datumsangaben modernisieren
            //US: modernize dates
            try
            {
                int yearOffset = DateTime.Now.Year - 2010 + 15;
                DataTable dtOrder = ds.Tables["Orders"];

                List<String> dateColumns = new() { "OrderDate", "RequiredDate", "ShippedDate" };
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
            DataSet ds = new();

            //D: Laden der Daten (XML) in das DataSet
            //US: load DataSet from the XML
            var xmlFile = Program.NorthwindFullDatabaseXmlFile;
            var xmlSchemaFile = Path.Combine(Path.GetDirectoryName(xmlFile), Path.GetFileNameWithoutExtension(xmlFile) + "_schema.xml");
            ds.ReadXmlSchema(xmlSchemaFile);
            ds.ReadXml(xmlFile);

            //D: Datumsangaben modernisieren
            //US: modernize dates
            try
            {
                int yearOffset = DateTime.Now.Year - 2010 + 15;
                DataTable dtOrder = ds.Tables["Orders"];

                List<String> dateColumns = new() { "OrderDate", "RequiredDate", "ShippedDate" };
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
