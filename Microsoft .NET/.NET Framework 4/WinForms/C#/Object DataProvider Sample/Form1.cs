using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using combit.ListLabel25.DataProviders;
using Microsoft.Win32;

namespace combit.ListLabel25.CSharpSample.ObjectDataProviderSample
{
    public partial class Form1 : Form
    {
        private string _databasePath;
        private ObjectDataProvider _provider;

        public Form1()
        {
            InitializeComponent();

            //D: Pfad auf Sample-Hauptverzeichnis setzen, Datenbankpfad auslesen
            //US: Set path to main sample path, read database path
            Directory.SetCurrentDirectory(Application.StartupPath + @"\..\..\..\..\..\..\Report Files");
            RegistryKey installKey = Registry.CurrentUser.CreateSubKey(@"Software\combit\cmbtll");
            if (installKey != null)
            {
                _databasePath = (string)installKey.GetValue("NWINDPath", "");
            }
            if (String.IsNullOrEmpty(_databasePath))
                MessageBox.Show("Unable to find sample database. Make sure List & Label is installed correctly.", "List & Label");

            // D: Initialisiere DropDown Liste
            // US: Initialize DropDown list
            comboSelection.Items.Add("IEnumerable<T>");
            comboSelection.Items.Add("LINQ with GenericList");
            comboSelection.Items.Add("LINQ with DataSet");
            comboSelection.SelectedIndex = 0;
        }

        private DataSet CreateDataSet()
        {
            DataSet ds = new System.Data.DataSet();

            //D: DataSet Objekt erstellen
            //US: Create the DataSet object
            OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + _databasePath);
            connection.Open();

            object[] restrictions = new Object[] { null, null, null, "TABLE" };
            DataTable table = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, restrictions);

            //D: Durch alle Tabellen iterieren und in das DataSet aufnehmen
            //US: Iterate all tabels and add them to the DataSet
            foreach (DataRow dr in table.Rows)
            {
                string tableName = dr["Table_Name"].ToString();
                OleDbDataAdapter dataAdapter;

                dataAdapter = new OleDbDataAdapter(new OleDbCommand("SELECT * FROM [" + tableName + "]", connection));
                dataAdapter.FillSchema(ds, SchemaType.Source, tableName);
                dataAdapter.Fill(ds, tableName);
            }

            object[] restrictions1 = new Object[] { null, null, null, null };
            DataTable table1 = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Foreign_Keys, restrictions1);

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
            connection.Close();

            return (ds);
        }

        private void SetupObjectDataProvider()
        {
            switch (comboSelection.SelectedIndex)
            {
                // D: Demonstriert die Benutzung des ObjectDataProviders mit einem IEnumerable<T>
                // US: Demonstrates the use of the ObjectDataProvider with an IEnumerable<T>
                case 0:
                    _provider = new ObjectDataProvider(GenericList.GetGenericList());

                    // D: Den vom Designer verwendeten Tabellennamen festlegen (optional)
                    // US: Declare a name for the table, which will be used in the designer (optional)
                    _provider.RootTableName = "Customer";
                    LL.AutoProjectFile = "IEnumerable.lst";
                    break;

                // D: LINQ in Verbindung mit einer Generischen Liste
                // US: LINQ with a Generic List
                case 1:
                    IEnumerable<Customer> customerList = GenericList.GetGenericList();

                    // D: LINQ Abfrage, listet alle Kunden aus Zuerich auf
                    // US: LINQ Query, selecting all customers from Zurich
                     IEnumerable<Customer> customerQuery = from customer in customerList
                                    where customer.City == "Zurich"
                                    select customer;

                    _provider = new ObjectDataProvider(customerQuery);
                    LL.AutoProjectFile = "LINQwithGenericList.lst";
                    break;

                // D: LINQ in Verbindung mit einem DataSet
                // US: LINQ with DataSet
                case 2:
                    // D: LINQ Abfrage, listet alle Kunden aus Berlin oder London auf
                    // US: LINQ Query, selects all customers from Berlin or London
                    var customerQuery2 = from customers in this.CreateDataSet().Tables["Customers"].AsEnumerable()
                                        where customers.Field<string>("City") == "Berlin" || customers.Field<string>("City") == "London"
                                        orderby customers.Field<string>("CompanyName") descending
                                        select customers;

                    _provider = new ObjectDataProvider(customerQuery2.AsDataView<DataRow>());
                    _provider.UseLinqForSorting = false;
                    LL.AutoProjectFile = "LINQwithDataSet.lst";
                    break;
            }
        }

        private void ButtonDesign_Click(object sender, EventArgs e)
        {
            try
            {
                // D: Je nach DropDown Listen Auswahl andere Datenquelle dem ObjectDataProvider zuweisen
                // US: Link data sources of the ObjectDataProvider, depending on the selection of the dropdown list 
                SetupObjectDataProvider();

                // D: Den Datenprovider bei List und Label anmelden und den Designer starten
                // US: Pass the data provider to List and Label and start the designer
                LL.DataSource = _provider;
                LL.Design();
            }
            catch (ListLabelException LlException)
            {
                //D: Exception abfangen
                //US: Catch Exceptions
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ButtonPrint_Click(object sender, EventArgs e)
        {
            try
            {
                // D: Je nach DropDown Listen Auswahl andere Datenquelle dem ObjectDataProvider zuweisen
                // US: Link data sources of the ObjectDataProvider, depending on the selection of the dropdown list 
                SetupObjectDataProvider();

                // D: Den Datenprovider bei List und Label anmelden und den Druck starten
                // US: Pass the data provider to List and Label and print
                LL.DataSource = _provider;
                LL.Print();
            }
            catch (ListLabelException LlException)
            {
                //D: Exception abfangen
                //US: Catch Exceptions
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // D: Diese Funktion aendert den Text auf der Form bei Auswahl aus der DropDown Liste
        // US:This function changes the text of the form when a item is selected from the dropdown list
        private void ComboSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboSelection.SelectedIndex)
            {
                case 0:
                    label_DE.Text = "Beachten Sie bitte die Properties \"CustomerID\" und \"ContactName\" in GenericList.cs.";
                    label_US.Text = "Please hava a look into GenericList.cs for the properties \"CustomerID\" and \"ContactName\".";
                    break;

                case 1:
                    label_DE.Text = "Diese Auswahl demonstriert die Benutzung von LINQ mit einer Generischen Liste.";
                    label_US.Text = "This selection demonstrates the use of LINQ with a Generic List.";
                    break;

                case 2:
                    label_DE.Text = "Diese Auswahl demonstriert die Benutzung von LINQ mit einem DataSet.";
                    label_US.Text = "This selection demonstrates the use of LINQ with a DataSet.";
                    break;

                default:
                    break;
            }
        }
    }
}
