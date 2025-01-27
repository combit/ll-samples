using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Xml;
using combit.Reporting;
using combit.Reporting.DataProviders;
using DataBind.GenericList;
using Microsoft.Win32;

namespace DataBinding
{
    public partial class Form1 : Form
    {
        private CultureInfo _cultureInfo;
        private string _databasePath;
        private string _xmlFile;
        private bool _isNotPrinting;

        public Form1()
        {
            InitializeComponent();

            //D: Pfad auf Sample-Hauptverzeichnis setzen, Datenbank- und XML-Pfad auslesen
            //US: Set path to main sample path, read database- and xml-path
            Directory.SetCurrentDirectory(Application.StartupPath + @"\..\..\..\..\..\..\Report Files");
            RegistryKey installKey = Registry.CurrentUser.CreateSubKey(@"Software\combit\cmbtll");
            if (installKey != null)
            {
                _databasePath = (string)installKey.GetValue("NWINDPath", string.Empty);
				_xmlFile = Path.Combine(installKey.GetValue("LL" + LlCore.LlGetVersion(LlVersion.Major) + "SampleDir").ToString(), "Microsoft .NET\\Report Files\\sampledata.xml");
                _isNotPrinting = true;
            }

            if (string.IsNullOrEmpty(_databasePath) || !File.Exists(_databasePath))
                MessageBox.Show("Unable to find sample database. Make sure List & Label is installed correctly.", "List & Label");

            if (string.IsNullOrEmpty(_xmlFile) || !File.Exists(_xmlFile))
                MessageBox.Show("Unable to find sampledata.xml. Make sure List & Label is installed correctly.", "List & Label");
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + _databasePath);
            conn.Open();

            OleDbCommand cmd = new OleDbCommand("SELECT DISTINCT Customers.CompanyName, Orders.CustomerID from Customers, Orders WHERE Orders.CustomerID=Customers.CustomerID AND Orders.OrderID > 11040", conn);
            OleDbDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
                cbCustomerNames.Items.Add(new ItemClass(dr[0].ToString(), dr[1].ToString()));

            //D: PreviewControl mit dem List & Label Objekt verbinden
            //US: Bind PreviewControl to the List & Label object
            LL.PreviewControl = LLPreviewControl;
        }

        private void EnableButtons(bool enableButtons)
        {
            _isNotPrinting = enableButtons;
            // get all controls of the form
            foreach (Control control in this.Controls)
            {
                // look at the tab control with its sub pages
                if (control is TabControl == false)
                    continue;

                // get all tab pages
                foreach (TabPage tabPage in (control as TabControl).Controls)
                {
                    // get all controls of the sub page
                    foreach (Control controlInTabControl in tabPage.Controls)
                    {
                        // get all buttons of the sub page
                        foreach (Control innerControlInTabControl in controlInTabControl.Controls)
                        {
                            if (innerControlInTabControl is Button)
                            {
                                (innerControlInTabControl as Button).Enabled = enableButtons;
                            }
                        }
                    }
                }
            }
        }

        private DataTable CreateDataTable()
        {
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + _databasePath);
            conn.Open();

            OleDbCommand cmd = new OleDbCommand("SELECT * FROM Products INNER JOIN Categories ON (Products.CategoryID=Categories.CategoryID)", conn);
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            DataTable dt = new DataTable("Products");
            adapter.FillSchema(dt, SchemaType.Source);
            adapter.Fill(dt);
            conn.Close();
            return dt;
        }

        private DataView CreateDataView()
        {
            return CreateDataTable().DefaultView;
        }

        private OleDbCommand CreateOleDbCommand()
        {
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + _databasePath);
            conn.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM Products INNER JOIN Categories ON (Products.CategoryID=Categories.CategoryID)", conn);
            conn.Close();
            return cmd;
        }


        private DataSet CreateDataSet()
        {
            DataSet ds = new System.Data.DataSet();

            //D: DataSet Objekt erstellen
            //US: Create the DataSet object
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + _databasePath);

            conn.Open();

            DataTable table = conn.GetSchema("Tables");

            //D: Durch alle Tabellen iterieren und in das DataSet aufnehmen
            //US: Iterate all tabels and add them to the DataSet
            foreach (DataRow dr in table.Rows)
            {
                if (dr["TABLE_TYPE"].ToString() == "TABLE")
                {
                    string tableName = dr["Table_Name"].ToString();
                    OleDbDataAdapter dataAdapter;

                    //D: Die "Orders" und "Order Details" Tabelle einschränken.
                    //US: Limit the "Order" an "Order Details" table. 
                    if (tableName == "Orders" || tableName == "Order Details")
                        dataAdapter = new OleDbDataAdapter(new OleDbCommand("SELECT * FROM [" + tableName + "] WHERE OrderID > 11040", conn));
                    else
                        dataAdapter = new OleDbDataAdapter(new OleDbCommand("SELECT * FROM [" + tableName + "]", conn));

                    dataAdapter.FillSchema(ds, SchemaType.Source, tableName);
                    dataAdapter.Fill(ds, tableName);
                }

            }


            List<string> childTables = new List<string>() { "Products", "Orders", "Orders", "Order Details", "Order Details", "Orders", "Products" };
            List<string> childCols = new List<string>() { "CategoryID", "CustomerID", "EmployeeID", "OrderID", "ProductID", "ShipVia", "SupplierID" };
            List<string> parentTables = new List<string>() { "Categories", "Customers", "Employees", "Orders", "Products", "Shippers", "Suppliers" };
            List<string> parentCols = new List<string>() { "CategoryID", "CustomerID", "EmployeeID", "OrderID", "ProductID", "ShipperID", "SupplierID" };
            List<string> relationNames = new List<string>() { "Categories2Products", "Customers2Orders", "Employees2Orders", "Orders2Order Details", "Products2Order Details", "Shippers2Orders", "Suppliers2Products" };

            //D: Relationen auslesen
            //US: Get relations
            for (int i = 0; i < relationNames.Count; i++)
            {
                ds.Relations.Add(new DataRelation(relationNames[i], ds.Tables[parentTables[i]].Columns[parentCols[i]], ds.Tables[childTables[i]].Columns[childCols[i]]));
            }

            //D: Verbindung schliessen
            //US: Close connection
            conn.Close();

            return (ds);
        }
        private DataSet CreateDataSetGantt()
        {
            DataSet ds = new DataSet();
            string dbPath = Path.GetDirectoryName(_databasePath);

            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dbPath + "\\gantt.mdb");
            conn.Open();

            DataTable table = conn.GetSchema("Tables");

            //D: Durch alle Tabellen iterieren und in das DataSet aufnehmen
            //US: Iterate all tables and add them to the DataSet
            foreach (DataRow dr in table.Rows)
            {
                if (dr["TABLE_TYPE"].ToString() == "TABLE")
                {
                    string tableName = dr["Table_Name"].ToString();
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(new OleDbCommand("SELECT * FROM [" + tableName + "]", conn));
                    dataAdapter.FillSchema(ds, SchemaType.Source, tableName);
                    dataAdapter.Fill(ds, tableName);
                }
            }

            //D: Verbindung schliessen
            //US: Close connection
            conn.Close();

            return ds;
        }

        private void SetFileExtensions()
        {
            _cultureInfo = CultureInfo.CurrentCulture;
            if (_cultureInfo.TwoLetterISOLanguageName == "de")
            {
                LL.FileExtensions.SetFileExtension(LlProject.List, LlFileType.Project, "lsr");
                LL.FileExtensions.SetFileExtension(LlProject.List, LlFileType.PrinterSettings, "llp");
                LL.FileExtensions.SetFileExtension(LlProject.List, LlFileType.Sketch, "llv");

                //D: Den Standard-Projektnamen setzen
                //US: set the default project name
                LL.AutoProjectFile = "Unterberichte und Relationen.lsr";
            }
            else
            {
                LL.FileExtensions.SetFileExtension(LlProject.List, LlFileType.Project, "srt");
                LL.FileExtensions.SetFileExtension(LlProject.List, LlFileType.PrinterSettings, "srp");
                LL.FileExtensions.SetFileExtension(LlProject.List, LlFileType.Sketch, "srv");

                //D: Den Standard-Projektnamen setzen
                //US: set the default project name
                LL.AutoProjectFile = "Sub reports and relations.srt";
            }

        }

        private void ResetFileExtensions()
        {
            //D: Dateiendungen wieder zuruecksetzen
            //US: set the file extension back
            if (_isNotPrinting)
            {
                LL.FileExtensions.SetFileExtension(LlProject.List, LlFileType.Project, "lst");
                LL.FileExtensions.SetFileExtension(LlProject.List, LlFileType.PrinterSettings, "lsp");
                LL.FileExtensions.SetFileExtension(LlProject.List, LlFileType.Sketch, "lsv");
            }
        }

        private DataProviderCollection CreateProviderCollection(bool useDataViewManager)
        {
            DataSet ds = CreateDataSet();
            DataSet dataSetGantt = CreateDataSetGantt();
            CsvDataProvider provider = new CsvDataProvider(Application.StartupPath + @"\..\..\..\..\..\..\Report Files\Sales.csv", true);

            //D:Daten je nach Auswahl in einer Datenquelle kombinieren
            //US:combine data to one datasource
            DataProviderCollection providerCollection = new DataProviderCollection();
            providerCollection.Add(provider);

            if (!useDataViewManager)
            {
                providerCollection.Add(new AdoDataProvider(ds));
                providerCollection.Add(new AdoDataProvider(dataSetGantt));
            }
            else
            {
                DataViewManager dvm = new DataViewManager(ds);
                DataViewManager dataViewManagerGantt = new DataViewManager(dataSetGantt);

                //D: Filter
                //US: Filter
                if (cbCustomerNames.Text != string.Empty)
                {
                    ItemClass selectedItem = (ItemClass)cbCustomerNames.SelectedItem;

                    //D: Für den Fall, dass der Filter der eingegeben wurde in der Collection nicht gefunden werden kann, wird eine Fehlermeldung ausgegeben, und null zurückgegeben.
                    //US: In case the filter is invalid, and therefore cannot be found inside the Collection, show an error message, and return null.

                    if (selectedItem == null)
                    {
                        MessageBox.Show("The entered Filter is invalid. Please check, correct and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                    dvm.DataViewSettings["Customers"].RowFilter = "CustomerID='" + selectedItem.Value + "'";
                }
                providerCollection.Add(new AdoDataProvider(dvm));
                providerCollection.Add(new AdoDataProvider(dataViewManagerGantt));
            }

            return (providerCollection);
        }

        private void Design_DataSet_Click(object sender, System.EventArgs e)
        {
            DataProviderCollection providerCollection = CreateProviderCollection(false);

            try
            {
                //D:Dateiendung je nach Sprache setzen
                //US: set the file extension for used CultureInfo
                SetFileExtensions();

                //D: An die providerColletion binden
                //US: now bind to the providerCollection
                LL.DataMember = string.Empty;
                LL.DataSource = providerCollection;

                //D: Dateiauswahldialog anzeigen und den Benutzer das Erstellen von neuen Listen erlauben
                //US: choose a list project, allow the user to create new ones also
                LL.AutoProjectType = LlProject.List | LlProject.FileAlsoNew;

                //D: Designer aufrufen
                //US: call the designer
                LL.Design();

            }
            catch (LL_User_Aborted_Exception)
            {
            }
            catch (ListLabelException LlException)
            {
                //D: Exception abfangen
                //US: Catch Exceptions
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                //D: Dateiendungen wieder zuruecksetzen
                //US: set the file extension back
                ResetFileExtensions();
            }
        }

        private void Print_DataSet_Click(object sender, System.EventArgs e)
        {
            //D: Schaltflächen für Druck und Design deaktivieren
            //US: disable the buttons for print and design
            EnableButtons(false);

            DataProviderCollection providerCollection = CreateProviderCollection(false);
            try
            {
                //D: Dateiendung je nach Sprache setzen
                //US: set the file extension for used CultureInfo
                SetFileExtensions();

                //D: An die provideCollection binden
                //US: now bind to the providerCollection
                LL.DataMember = string.Empty;
                LL.DataSource = providerCollection;

                //D: Printmode auf PreviewControl stellen
                //US: set print mode to previewControl
                LL.AutoDestination = LlPrintMode.PreviewControl;

                //D: Unterdrücken des Druckdialogs
                //US: suppress print options dialog
                LL.AutoShowPrintOptions = false;

                //D: Drucken
                //US: print
                LL.Print();
                _isNotPrinting = true;

            }
            catch (LL_User_Aborted_Exception)
            {
            }
            catch (ListLabelException LlException)
            {
                //D: Exception abfangen
                //US: Catch Exceptions
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                //D: Dateiendungen wieder zuruecksetzen
                //US: set the file extension back
                ResetFileExtensions();

                //D: Fortschrittsanzeige ausblenden
                //US: hide progressbar
                progressBar1.Value = 0;
                progressBar1.Visible = false;

                //D: Schaltflächen für Druck und Design aktivieren
                //US: enable the buttons for print and design
                EnableButtons(true);
            }
        }

        private void Design_XML_Click(object sender, System.EventArgs e)
        {
            XmlDocument xmlDocument = new XmlDocument();
            if (xmlDocument != null)
            {
                try
                {
                    //D: Lade die XML-Datei
                    //US: load the xml-file
                    xmlDocument.Load(_xmlFile);

                    //D: Erstelle ein XmlDataProvider Objekt
                    //US: create a XmlDataProvider object
                    XmlDataProvider provider = new XmlDataProvider(xmlDocument);

                    //D: An das XmlDataProvider Objekt binden
                    //US: now bind to the XmlDataProvider
                    LL.SetDataBinding(provider, string.Empty);

                    //D: Den Standard-Projektnamen setzen
                    //US: set the default project name
                    LL.AutoProjectFile = "InvoiceList.lst";

                    //D: Dateiauswahldialog anzeigen und den Benutzer das Erstellen von neuen Listen erlauben
                    //US: choose a list project, allow the user to create new ones also
                    LL.AutoProjectType = LlProject.List | LlProject.FileAlsoNew;

                    //D: Designer aufrufen
                    //US: call the designer
                    LL.Design();
                }
                catch (LL_User_Aborted_Exception)
                {
                }
                catch (ListLabelException LlException)
                {
                    //D: Exception abfangen
                    //US: catch Exceptions
                    MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ecx)
                {
                    //D: Exception abfangen
                    //US: catch general Exceptions
                    MessageBox.Show("Information: " + ecx.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void Print_XML_Click(object sender, System.EventArgs e)
        {
            //D: Schaltflächen für Druck und Design deaktivieren
            //US: disable the buttons for print and design
            EnableButtons(false);

            XmlDocument xmlDocument = new XmlDocument();
            if (xmlDocument != null)
            {
                try
                {
                    //D: Lade die XML-Datei
                    //US: load the xml-file
                    xmlDocument.Load(_xmlFile);

                    //D: Erstelle ein XmlDataProvider Objekt
                    //US: create a XmlDataProvider object
                    XmlDataProvider provider = new XmlDataProvider(xmlDocument);

                    //D: An das XmlDataProvider Objekt binden
                    //US: now bind to the XmlDataProvider
                    LL.SetDataBinding(provider, string.Empty);

                    //D: Den Standard-Projektnamen setzen
                    //US: set the default project name
                    LL.AutoProjectFile = "InvoiceList.lst";

                    //D: Printmode auf Previewcontrol setzen
                    //US: set print mode to previewControl
                    LL.AutoDestination = LlPrintMode.PreviewControl;

                    //D: Unterdrücken des Druckerdialogs
                    //US: suppress print options dialog
                    LL.AutoShowPrintOptions = false;

                    //D: Drucken
                    //US: print
                    LL.Print();
                    _isNotPrinting = true;
                }
                catch (LL_User_Aborted_Exception)
                {
                }
                catch (ListLabelException LlException)
                {
                    //D: Exception abfangen
                    //US: catch Exceptions
                    MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ecx)
                {
                    //D: Exception abfangen
                    //US: catch general Exceptions
                    MessageBox.Show("Information: " + ecx.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                finally
                {
                    //D: Fortschrittsanzeige ausblenden
                    //US: hide progressbar
                    progressBar1.Value = 0;
                    progressBar1.Visible = false;

                    //D: Schaltflächen für Druck und Design aktivieren
                    //US: enable the buttons for print and design
                    EnableButtons(true);
                }
            }
        }

        private void Design_Reader_Click(object sender, System.EventArgs e)
        {
            //D: Erstelle eine SQL Abfrage
            //US: Create a SQL statement 
            OleDbCommand cmd = CreateOleDbCommand();

            DbCommandSetDataProvider provider = new DbCommandSetDataProvider();
            provider.MinimalSelect = false;
            provider.AddCommand(cmd, "Products");

            try
            {
                //D: An das DbCommandSetDataProvider Objekt binden
                //US: now bind to the DbCommandSetDataProvider
                LL.SetDataBinding(provider, "Products");

                //D: Den Standard-Projektnamen setzen
                //US: set the default project name
                LL.AutoProjectFile = "simple.lst";

                //D: Dateiauswahldialog anzeigen und den Benutzer das Erstellen von neuen Listen erlauben
                //US: choose a list project, allow the user to create new ones also
                LL.AutoProjectType = LlProject.List | LlProject.FileAlsoNew;

                //D: Designer aufrufen
                //US: call the designer
                LL.Design();
            }
            catch (LL_User_Aborted_Exception)
            {
            }
            catch (ListLabelException LlException)
            {
                //D: Exception abfangen
                //US: Catch Exceptions
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Print_Reader_Click(object sender, System.EventArgs e)
        {
            //D: Schaltflächen für Druck und Design deaktivieren
            //US: disable the buttons for print and design
            EnableButtons(false);

            OleDbCommand cmd = CreateOleDbCommand();
            DbCommandSetDataProvider provider = new DbCommandSetDataProvider();
            provider.MinimalSelect = false;
            provider.AddCommand(cmd, "Products");

            try
            {
                //D: An das DataReader Objekt binden
                //US: now bind to the DataReader
                LL.SetDataBinding(provider, "Products");

                //D: Den Standard-Projektnamen setzen
                //US: set the default project name
                LL.AutoProjectFile = "simple.lst";

                //D: Auswählen eines Listenprojekts
                //US: choose a list project
                LL.AutoProjectType = LlProject.List;

                //D: Printmode auf PreviewControl stellen
                //US: set print mode to previewControl
                LL.AutoDestination = LlPrintMode.PreviewControl;

                //D: Unterdrücken des Druckerdialogs
                //US: suppress print options dialog
                LL.AutoShowPrintOptions = false;

                //D: Drucken
                //US: print
                LL.Print();
                _isNotPrinting = true;
            }
            catch (LL_User_Aborted_Exception)
            {
            }
            catch (ListLabelException LlException)
            {
                //D: Exception abfangen
                //US: Catch Exceptions
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                //D: Fortschrittsanzeige ausblenden
                //US: hide progressbar
                progressBar1.Value = 0;
                progressBar1.Visible = false;

                //D: Schaltflächen für Druck und Design aktivieren
                //US: enable the buttons for print and design
                EnableButtons(true);
            }
        }

        private void Design_DataView_Click(object sender, System.EventArgs e)
        {
            DataView dv = CreateDataView();

            try
            {
                //D: An das DataView Objekt binden
                //US: now bind to the DataView
                LL.SetDataBinding(dv, "Products");

                //D: Den Standard-Projektnamen setzen
                //US: set the default project name
                LL.AutoProjectFile = "simple.lst";

                //D: Dateiauswahldialog anzeigen und den Benutzer das Erstellen von neuen Listen erlauben
                //US: choose a list project, allow the user to create new ones also
                LL.AutoProjectType = LlProject.List | LlProject.FileAlsoNew;

                //D: Designer aufrufen
                //US: call the designer
                LL.Design();
            }
            catch (LL_User_Aborted_Exception)
            {
            }
            catch (ListLabelException LlException)
            {
                //D: Exception abfangen
                //US: Catch Exceptions
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void Print_DataView_Click(object sender, System.EventArgs e)
        {
            //D: Schaltflächen für Druck und Design deaktivieren
            //US: disable the buttons for print and design
            EnableButtons(false);

            DataView dv = CreateDataView();

            try
            {
                //D: An das DataView Objekt binden
                //US: now bind to the DataView
                LL.SetDataBinding(dv, "Products");

                //D: Den Standard-Projektnamen setzen
                //US: set the default project name
                LL.AutoProjectFile = "simple.lst";

                //D: Auswählen eines Listenprojekts
                //US: choose a list project
                LL.AutoProjectType = LlProject.List;

                //D: Printmode auf PreviewControl stellen
                //US: set print mode to preview
                LL.AutoDestination = LlPrintMode.PreviewControl;

                //D: Unterdrücken des Druckerdialogs
                //US: suppress print options dialog
                LL.AutoShowPrintOptions = false;

                //D: Drucken
                //US: print
                LL.Print();
                _isNotPrinting = true;
            }
            catch (LL_User_Aborted_Exception)
            {
            }
            catch (ListLabelException LlException)
            {
                //D: Exception abfangen
                //US: Catch Exceptions
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                //D: Fortschrittsanzeige ausblenden
                //US: hide progressbar
                progressBar1.Value = 0;
                progressBar1.Visible = false;

                //D: Schaltflächen für Druck und Design aktivieren
                //US: enable the buttons for print and design
                EnableButtons(true);
            }
        }

        private void Design_DataTable_Click(object sender, System.EventArgs e)
        {
            DataTable dt = CreateDataTable();

            try
            {
                //D: An das DataTable Objekt binden
                //US: now bind to the DataTable
                LL.SetDataBinding(dt, "Products");

                //D: Den Standard-Projektnamen setzen
                //US: set the default project name
                LL.AutoProjectFile = "simple.lst";

                //D: Dateiauswahldialog anzeigen und den Benutzer das Erstellen von neuen Listen erlauben
                //US: choose a list project, allow the user to create new ones also
                LL.AutoProjectType = LlProject.List | LlProject.FileAlsoNew;

                //D: Designer aufrufen
                //US: call the designer
                LL.Design();
            }
            catch (LL_User_Aborted_Exception)
            {
            }
            catch (ListLabelException LlException)
            {
                //D: Exception abfangen
                //US: Catch Exceptions
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Print_DataTable_Click(object sender, System.EventArgs e)
        {
            //D: Schaltflächen für Druck und Design deaktivieren
            //US: disable the buttons for print and design
            EnableButtons(false);

            DataTable dt = CreateDataTable();

            try
            {
                //D: An das DataTable Objekt binden
                //US: now bind to the DataTable
                LL.SetDataBinding(dt, "Products");

                //D: Den Standard-Projektnamen setzen
                //US: set the default project name
                LL.AutoProjectFile = "simple.lst";

                //D: Auswählen eines Listenprojekts
                //US: choose a list project
                LL.AutoProjectType = LlProject.List;

                //D: Printmode auf PreviewControl stellen
                //US: set print mode to preview
                LL.AutoDestination = LlPrintMode.PreviewControl;

                //D: Unterdrücken des Druckerdialogs
                //US: suppress print options dialog
                LL.AutoShowPrintOptions = false;

                //D: Drucken
                //US: print
                LL.Print();
                _isNotPrinting = true;
            }
            catch (LL_User_Aborted_Exception)
            {
            }
            catch (ListLabelException LlException)
            {
                //D: Exception abfangen
                //US: Catch Exceptions
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                //D: Fortschrittsanzeige ausblenden
                //US: hide progressbar
                progressBar1.Value = 0;
                progressBar1.Visible = false;

                //D: Schaltflächen für Druck und Design aktivieren
                //US: enable the buttons for print and design
                EnableButtons(true);
            }
        }

        private void Print_DataViewManager_Click(object sender, System.EventArgs e)
        {
            //D: Schaltflächen für Druck und Design deaktivieren
            //US: disable the buttons for print and design
            EnableButtons(false);
            DataProviderCollection providerCollection = CreateProviderCollection(true);

            //D: Falls null zurückgegeben wurde, was für den Fall, dass der Filter ungültig sein sollte erwartet wird, wird der Methodenaufruf beendet.
            //US:This stops execution if providerCollection returns null, which is expected, if the Filter the user entered is wrong. Therefore interrupt further execution.
            if (providerCollection == null)
            {
                EnableButtons(true);
                return;
            }

            try
            {
                //D: Dateiendung je nach Sprache setzen
                //US: set the file extension for used CultureInfo
                SetFileExtensions();

                //D: An die provideCollection binden
                //US: now bind to the providerCollection
                LL.DataMember = string.Empty;
                LL.DataSource = providerCollection;

                //D: Printmode auf PreviewControl stellen
                //US: set print mode to preview
                LL.AutoDestination = LlPrintMode.PreviewControl;

                //D: Unterdrücken des Druckerdialogs
                //US: suppress print options dialog
                LL.AutoShowPrintOptions = false;

                //D: Drucken
                //US: print
                LL.Print();
                _isNotPrinting = true;
            }
            catch (LL_User_Aborted_Exception)
            {
            }
            catch (ListLabelException LlException)
            {
                //D: Exception abfangen
                //US: Catch Exceptions
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                //D: Dateiendungen wieder zuruecksetzen
                //US: set the file extension back
                ResetFileExtensions();

                //D: Fortschrittsanzeige ausblenden
                //US: hide progressbar
                progressBar1.Value = 0;
                progressBar1.Visible = false;

                //D: Schaltflächen für Druck und Design aktivieren
                //US: enable the buttons for print and design
                EnableButtons(true);
            }
        }

        private void Design_DataViewManager_Click(object sender, System.EventArgs e)
        {

            DataProviderCollection providerCollection = CreateProviderCollection(true);
            //D: Falls null zurückgegeben wurde, was für den Fall, dass der Filter ungültig sein sollte erwartet wird, wird der Methodenaufruf beendet.
            //US:This stops execution if providerCollection returns null, which is expected, if the Filter the user entered is wrong. Therefore interrupt further execution.
            if (providerCollection == null)
            {
                return;
            }

            try
            {
                //D: Dateiendung je nach Sprache setzen
                //US: set the file extension for used CultureInfo
                SetFileExtensions();

                //D: An die provideCollection binden
                //US: now bind to the providerCollection
                LL.DataMember = string.Empty;
                LL.DataSource = providerCollection;

                //D: Dateiauswahldialog anzeigen und den Benutzer das Erstellen von neuen Listen erlauben
                //US: choose a list project, allow the user to create new ones also
                LL.AutoProjectType = LlProject.List | LlProject.FileAlsoNew;

                //D: Designer aufrufen
                //US: call the designer
                LL.Design();
            }
            catch (LL_User_Aborted_Exception)
            {
            }
            catch (ListLabelException LlException)
            {
                //D: Exception abfangen
                //US: Catch Exceptions
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                //D: Dateiendungen wieder zuruecksetzen
                //US: set the file extension back
                ResetFileExtensions();
            }
        }

        private void LL_NotifyProgress(object sender, NotifyProgressEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate
                {
                    LL_NotifyProgress(sender, e);
                }));
            }
            else
            {
                if (e.Percentage == 100)
                {
                    progressBar1.Visible = false;
                    return;
                }

                progressBar1.Visible = true;
                progressBar1.Value = e.Percentage;
            }
        }

        private void Design_GenericList_Click(object sender, EventArgs e)
        {
            //D: Erstelle eine generische Liste
            //US: create a generic list
            List<Customer> customerList = GenericList.GetGenericList();

            //D: An die generische Liste binden
            //US: Now bind to the generic list
            LL.SetDataBinding(customerList, string.Empty);

            //D: Den Standard-Projektnamen setzen
            //US: Set the default project name
            LL.AutoProjectFile = "genericlist.lst";

            //D: Dateiauswahldialog anzeigen und den Benutzer das Erstellen von neuen Listen erlauben
            //US: Choose a list project, allow the user to create new ones also
            LL.AutoProjectType = LlProject.List | LlProject.FileAlsoNew;

            try
            {
                //D: Designer aufrufen
                //US: Call the designer
                LL.Design();
            }
            catch (LL_User_Aborted_Exception)
            {
            }
            catch (ListLabelException LlException)
            {
                // Catch Exceptions
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Print_GenericList_Click(object sender, EventArgs e)
        {
            //D: Schaltflächen für Druck und Design deaktivieren
            //US: disable the buttons for print and design
            EnableButtons(false);

            //D: Erstelle eine generische Liste
            //US: create a generic list
            List<Customer> customerList = GenericList.GetGenericList();

            try
            {
                //D: An die generische Liste binden
                //US: Now bind to the generic list
                LL.SetDataBinding(customerList, string.Empty);

                //D: Den Standard-Projektnamen setzen
                //US: Set the default project name
                LL.AutoProjectFile = "genericlist.lst";

                //D: Printmode auf PreviewControl stellen
                //US: set print mode to preview
                LL.AutoDestination = LlPrintMode.PreviewControl;

                //D: Unterdrücken des Druckerdialogs
                //US: suppress print options dialog
                LL.AutoShowPrintOptions = false;

                //D: Dateiauswahldialog anzeigen und den Benutzer das Erstellen von neuen Listen erlauben
                //US: Choose a list project, allow the user to create new ones also
                LL.AutoProjectType = LlProject.List | LlProject.FileAlsoNew;

                //D: Drucken
                //US: Print
                LL.Print();
                _isNotPrinting = true;
            }
            catch (LL_User_Aborted_Exception)
            {
            }
            catch (ListLabelException LlException)
            {
                //D: Exception abfangen
                //US: Catch Exceptions
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                //D: Schaltflächen für Druck und Design aktivieren
                //US: enable the buttons for print and design
                EnableButtons(true);
            }
        }

        private void Design_SQL_Click(object sender, EventArgs e)
        {
            try
            {
                //D: Erstelle einen SqlConnectionDataProvider
                //US: create a SqlConnectionDataProvider
                SqlConnection conn = new SqlConnection(tbConnectionString.Text);
                SqlConnectionDataProvider prov = new SqlConnectionDataProvider(conn);

                //D: An das DataViewManager Objekt binden
                //US: now bind to the DataViewManager
                LL.SetDataBinding(prov, string.Empty);

                //D: Den Standard-Projektnamen setzen
                //US: set the default project name
                LL.AutoProjectFile = string.Empty;

                //D: Printmode auf PreviewControl stellen
                //US: set print mode to preview
                LL.AutoDestination = LlPrintMode.PreviewControl;

                //D: Unterdrücken des Druckerdialogs
                //US: suppress print options dialog
                LL.AutoShowPrintOptions = false;

                //D: Dateiauswahldialog anzeigen und den Benutzer das Erstellen von neuen Listen erlauben
                //US: choose a list project, allow the user to create new ones also
                LL.AutoProjectType = LlProject.List | LlProject.FileAlsoNew;

                //D: Designer aufrufen
                //US: call the designer
                LL.Design();
            }
            catch (LL_User_Aborted_Exception)
            {
            }
            catch (ListLabelException LlException)
            {
                //D: Exception abfangen
                //US: Catch Exceptions
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException sqlException)
            {
                //D: Exception abfangen
                //US: Catch Exceptions
                MessageBox.Show("Information: " + sqlException.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (InvalidOperationException invalidOperationException)
            {
                //D: Exception abfangen
                //US: Catch Exceptions
                MessageBox.Show("Information: " + invalidOperationException.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Print_SQL_Click(object sender, EventArgs e)
        {
            //D: Schaltflächen für Druck und Design deaktivieren
            //US: disable the buttons for print and design
            EnableButtons(false);

            try
            {
                //D: Erstelle einen SqlConnectionDataProvider
                //US: create a SqlConnectionDataProvider
                SqlConnection conn = new SqlConnection(tbConnectionString.Text);
                SqlConnectionDataProvider prov = new SqlConnectionDataProvider(conn);

                //D: An das DataViewManager Objekt binden
                //US: now bind to the DataViewManager
                LL.SetDataBinding(prov, string.Empty);

                //D: Den Standard-Projektnamen setzen
                //US: set the default project name
                LL.AutoProjectFile = string.Empty;

                //D: Dateiauswahldialog anzeigen und den Benutzer das Erstellen von neuen Listen erlauben
                //US: choose a list project, allow the user to create new ones also
                LL.AutoProjectType = LlProject.List | LlProject.FileAlsoNew;

                //D: Designer aufrufen
                //US: call the designer
                LL.Print();
                _isNotPrinting = true;
            }
            catch (LL_User_Aborted_Exception)
            {
            }
            catch (ListLabelException LlException)
            {
                //D: Exception abfangen
                //US: Catch Exceptions
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException sqlException)
            {
                //D: Exception abfangen
                //US: Catch Exceptions
                MessageBox.Show("Information: " + sqlException.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (InvalidOperationException invalidOperationException)
            {
                //D: Exception abfangen
                //US: Catch Exceptions
                MessageBox.Show("Information: " + invalidOperationException.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                //D: Schaltflächen für Druck und Design aktivieren
                //US: enable the buttons for print and design
                EnableButtons(true);
            }
        }

        private void DesignOdataBtn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //D: Erstelle ein ODataDataProvider Objekt
            //US: create a ODataDataProvider object
            ODataDataProvider provider = new ODataDataProvider(odataUrlTb.Text, false);

            try
            {
                //D: An das ODataDataProvider Objekt binden
                //US: now bind to the ODataDataProvider
                LL.SetDataBinding(provider, String.Empty);

                //D: Den Standard-Projektnamen setzen
                //US: set the default project name
                LL.AutoProjectFile = "OData sub reports and relations.lst";

                //D: Dateiauswahldialog anzeigen und den Benutzer das Erstellen von neuen Listen erlauben
                //US: choose a list project, allow the user to create new ones also
                LL.AutoProjectType = LlProject.List | LlProject.FileAlsoNew;

                //D: Designer aufrufen
                //US: call the designer
                LL.Design();
            }
            catch (LL_User_Aborted_Exception)
            {
            }
            catch (ListLabelException LlException)
            {
                //D: Exception abfangen
                //US: Catch Exceptions
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void PrintOdataBtn_Click(object sender, EventArgs e)
        {
            //D: Schaltflächen für Druck und Design deaktivieren
            //US: disable the buttons for print and design
            EnableButtons(false);

            //D: Erstelle ein ODataDataProvider Objekt
            //US: create a ODataDataProvider object
            ODataDataProvider provider = new ODataDataProvider(odataUrlTb.Text, false);

            try
            {
                //D: An das ODataDataProvider Objekt binden
                //US: now bind to the ODataDataProvider
                LL.SetDataBinding(provider, String.Empty);

                //D: Den Standard-Projektnamen setzen
                //US: set the default project name
                LL.AutoProjectFile = "OData sub reports and relations.lst";

                //D: Printmode auf Previewcontrol setzen
                //US: set print mode to previewControl
                LL.AutoDestination = LlPrintMode.PreviewControl;

                //D: Unterdrücken des Druckerdialogs
                //US: suppress print options dialog
                LL.AutoShowPrintOptions = false;

                //D: Drucken
                //US: print
                LL.Print();
                _isNotPrinting = true;
            }
            catch (LL_User_Aborted_Exception)
            {
            }
            catch (ListLabelException LlException)
            {
                //D: Exception abfangen
                //US: Catch Exceptions
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                //D: Fortschrittsanzeige ausblenden
                //US: hide progressbar
                progressBar1.Value = 0;
                progressBar1.Visible = false;

                //D: Schaltflächen für Druck und Design aktivieren
                //US: enable the buttons for print and design
                EnableButtons(true);
            }
        }

        private void RestDesignBtn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //D: Erstelle ein RestDataProvider Objekt
            //US: create a RestDataProvider object
            RestDataProvider provider = new RestDataProvider(restUrlTb.Text);

            try
            {
                //D: An das RestDataProvider Objekt binden
                //US: now bind to the RestDataProvider
                LL.SetDataBinding(provider, String.Empty);

                //D: Den Standard-Projektnamen setzen
                //US: set the default project name
                LL.AutoProjectFile = "REST.lst";

                //D: Dateiauswahldialog anzeigen und den Benutzer das Erstellen von neuen Listen erlauben
                //US: choose a list project, allow the user to create new ones also
                LL.AutoProjectType = LlProject.List | LlProject.FileAlsoNew;

                //D: Designer aufrufen
                //US: call the designer
                LL.Design();
            }
            catch (LL_User_Aborted_Exception)
            {
            }
            catch (ListLabelException LlException)
            {
                //D: Exception abfangen
                //US: Catch Exceptions
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void RestPrintBtn_Click(object sender, EventArgs e)
        {
            //D: Schaltflächen für Druck und Design deaktivieren
            //US: disable the buttons for print and design
            EnableButtons(false);

            //D: Erstelle ein RestDataProvider Objekt
            //US: create a RestDataProvider object
            RestDataProvider provider = new RestDataProvider(restUrlTb.Text);

            try
            {
                //D: An das RestDataProvider Objekt binden
                //US: now bind to the RestDataProvider
                LL.SetDataBinding(provider, String.Empty);

                //D: Den Standard-Projektnamen setzen
                //US: set the default project name
                LL.AutoProjectFile = "REST.lst";

                //D: Printmode auf Previewcontrol setzen
                //US: set print mode to previewControl
                LL.AutoDestination = LlPrintMode.PreviewControl;

                //D: Unterdrücken des Druckerdialogs
                //US: suppress print options dialog
                LL.AutoShowPrintOptions = false;

                //D: Drucken
                //US: print
                LL.Print();
                _isNotPrinting = true;
            }
            catch (LL_User_Aborted_Exception)
            {
            }
            catch (ListLabelException LlException)
            {
                //D: Exception abfangen
                //US: Catch Exceptions
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                //D: Fortschrittsanzeige ausblenden
                //US: hide progressbar
                progressBar1.Value = 0;
                progressBar1.Visible = false;

                //D: Schaltflächen für Druck und Design aktivieren
                //US: enable the buttons for print and design
                EnableButtons(true);
            }
        }

        private void LL_AutoDefineField(object sender, AutoDefineElementEventArgs e)
        {
            // D: Datum der Northwind-Datensätze in aktuellen Bereich verschieben
            // US: Move Northwind dates to a more current point in time
            if (e.Value != null && e.Value != DBNull.Value && e.FieldType == LlFieldType.Date && e.Name.Contains("Orders"))
            {
                DateTime dt = (DateTime)e.Value;
                int YearOffset = DateTime.Now.Year - 2010 + 14;
                e.Value = new DateTime(dt.Year + YearOffset, Convert.ToInt32(dt.Month), Convert.ToInt32(dt.Day));
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (LL.Core.IsPrinting)
            {
                e.Cancel = true;
            }
        }
    }

    class ItemClass
    {
        public string Text { get; set; }
        public string Value { get; set; }

        public ItemClass(string text, string value)
        {
            this.Text = text;
            this.Value = value;
        }

        public override string ToString()
        {
            return this.Text;
        }
    }
}
