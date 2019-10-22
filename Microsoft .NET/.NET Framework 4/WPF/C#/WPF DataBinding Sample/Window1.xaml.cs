using combit.ListLabel25;
using combit.ListLabel25.DataProviders;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;
using System.ComponentModel;
using DataBind.GenericList;

namespace LLViewer
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private CultureInfo _cultureInfo;
        private string _databasePath;
        private string _xmlFile;
        private bool _isNotPrinting;
        internal ListLabel LL;

        public Window1()
        {
            InitializeComponent();
            Loaded += Window_Loaded;
            Closing += Window_Closing;
            Closed += Window_Closed;
            LL = new ListLabel();
            LL.AutoDefineField += new AutoDefineElementHandler(LL_AutoDefineField);
            LL.Core.LlSetOptionString(LlOptionString.DefaultDesignScheme, "COMBITCOLORWHEEL");

            //D: Pfad auf Sample-Hauptverzeichnis setzen, Datenbank- und XML-Pfad auslesen
            //US: Set path to main sample path, read database- and xml-path
            Directory.SetCurrentDirectory(System.AppDomain.CurrentDomain.BaseDirectory + @"\..\..\..\..\..\..\Report Files");
            RegistryKey installKey = Registry.CurrentUser.CreateSubKey(@"Software\combit\cmbtll");
            if (installKey != null)
            {
                _databasePath = (string)installKey.GetValue("NWINDPath", string.Empty);
                _xmlFile = System.IO.Path.Combine(installKey.GetValue("LL" + LlCore.LlGetVersion(LlVersion.Major) + "SampleDir").ToString(), "Microsoft .NET\\Report Files\\sampledata.xml");
                _isNotPrinting = true;
            }

            if (string.IsNullOrEmpty(_databasePath) || !File.Exists(_databasePath))
                MessageBox.Show("Unable to find sample database. Make sure List & Label is installed correctly.", "List & Label");

            if (string.IsNullOrEmpty(_xmlFile) || !File.Exists(_xmlFile))
                MessageBox.Show("Unable to find sampledata.xml. Make sure List & Label is installed correctly.", "List & Label");
        }
        

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + _databasePath);
            conn.Open();

            OleDbCommand cmd = new OleDbCommand("SELECT DISTINCT Customers.CompanyName, Orders.CustomerID from Customers, Orders WHERE Orders.CustomerID=Customers.CustomerID AND Orders.OrderID > 11040", conn);
            OleDbDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            List<KeyValuePair<string, string>> customers = new List<KeyValuePair<string, string>>();
            cbCustomerNames.ItemsSource = customers;
            cbCustomerNames.DisplayMemberPath = "Key";
            cbCustomerNames.SelectedValuePath = "Value";            
            while (dr.Read())
                customers.Add(new KeyValuePair<string, string>(dr[0].ToString(), dr[1].ToString()));

            //D: PreviewControl mit dem List & Label Objekt verbinden
            //US: Bind PreviewControl to the List & Label object
            LL.PreviewControl = enhancedPreviewControl.PreviewControl;
        }

        private void EnableButtons(bool enableButtons)
        {
            _isNotPrinting = enableButtons;
            print_DataSet.IsEnabled = enableButtons;
            design_DataSet.IsEnabled = enableButtons;
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

            object[] restrictions = new Object[] { null, null, null, "TABLE" };
            DataTable table = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, restrictions);

            //D: Durch alle Tabellen iterieren und in das DataSet aufnehmen
            //US: Iterate all tabels and add them to the DataSet
            foreach (DataRow dr in table.Rows)
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

            return (ds);
        }

        private DataSet CreateDataSetGantt()
        {
            DataSet ds = new DataSet();
            string dbPath = System.IO.Path.GetDirectoryName(_databasePath);

            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dbPath + "\\gantt.mdb");
            conn.Open();

            object[] restrictions = new Object[] { null, null, null, "TABLE" };
            DataTable table = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, restrictions);

            //D: Durch alle Tabellen iterieren und in das DataSet aufnehmen
            //US: Iterate all tables and add them to the DataSet
            foreach (DataRow dr in table.Rows)
            {
                string tableName = dr["Table_Name"].ToString();
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(new OleDbCommand("SELECT * FROM [" + tableName + "]", conn));
                dataAdapter.FillSchema(ds, SchemaType.Source, tableName);
                dataAdapter.Fill(ds, tableName);
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
            //D:Dateiendungen wieder zuruecksetzen
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
            CsvDataProvider provider = new CsvDataProvider(System.AppDomain.CurrentDomain.BaseDirectory + @"\..\..\..\..\..\..\Report Files\Sales.csv", true);

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
                    object selectedItem = cbCustomerNames.SelectedItem;
                    dvm.DataViewSettings["Customers"].RowFilter = "CustomerID='" + ((KeyValuePair<string, string>)selectedItem).Value + "'";
                }
                providerCollection.Add(new AdoDataProvider(dvm));
                providerCollection.Add(new AdoDataProvider(dataViewManagerGantt));
            }

            return (providerCollection);
        }

        private void Design_DataSet_Click(object sender, RoutedEventArgs e)
        {
            DataProviderCollection providerCollection = CreateProviderCollection(false);

            try
            {
                //D:Dateiendung je nach Sprach setzen
                //US:set the file extension for used CultureInfo
                SetFileExtensions();

                //D: An die provideColletion binden
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
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            finally
            {
                //D:Dateiendungen wieder zuruecksetzen
                //US: set the file extension back
                ResetFileExtensions();
            }
        }

        private void Print_DataSet_Click(object sender, RoutedEventArgs e)
        {
            //D: Schaltflächen für Druck und Design deaktivieren
            //US: disable the buttons for print and design
            EnableButtons(false);

            DataProviderCollection providerCollection = CreateProviderCollection(false);
            try
            {
                //D:Dateiendung je nach Sprach setzen
                //US:set the file extension for used CultureInfo
                SetFileExtensions();

                //D: An die provideColletion binden
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
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            finally
            {
                //D:Dateiendungen wieder zuruecksetzen
                //US: set the file extension back
                ResetFileExtensions();

                //D: Fortschrittsanzeige ausblenden
                //US: hide progressbar
                progressBar1.Value = 0;
                progressBar1.Visibility = Visibility.Hidden;

                //D: Schaltflächen für Druck und Design aktivieren
                //US: enable the buttons for print and design
                EnableButtons(true);
            }
        }

        private void Design_XML_Click(object sender, RoutedEventArgs e)
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
                    combit.ListLabel25.DataProviders.XmlDataProvider provider = new combit.ListLabel25.DataProviders.XmlDataProvider(xmlDocument);

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
                    MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ecx)
                {
                    //D: Exception abfangen
                    //US: catch general Exceptions
                    MessageBox.Show("Information: " + ecx.Message, "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void Print_XML_Click(object sender, RoutedEventArgs e)
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
                    combit.ListLabel25.DataProviders.XmlDataProvider provider = new combit.ListLabel25.DataProviders.XmlDataProvider(xmlDocument);

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
                    MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ecx)
                {
                    //D: Exception abfangen
                    //US: catch general Exceptions
                    MessageBox.Show("Information: " + ecx.Message, "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                finally
                {
                    //D: Fortschrittsanzeige ausblenden
                    //US: hide progressbar
                    progressBar1.Value = 0;
                    progressBar1.Visibility = Visibility.Hidden;

                    //D: Schaltflächen für Druck und Design aktivieren
                    //US: enable the buttons for print and design
                    EnableButtons(true);
                }
            }
        }

        private void Design_Reader_Click(object sender, RoutedEventArgs e)
        {
            //D: Erstelle eine SQL Abfrage
            //US: Create a SQL statement 
            OleDbCommand cmd = CreateOleDbCommand();

            DbCommandSetDataProvider provider = new DbCommandSetDataProvider();
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
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Print_Reader_Click(object sender, RoutedEventArgs e)
        {
            //D: Schaltflächen für Druck und Design deaktivieren
            //US: disable the buttons for print and design
            EnableButtons(false);

            OleDbCommand cmd = CreateOleDbCommand();
            DbCommandSetDataProvider provider = new DbCommandSetDataProvider();
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
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            finally
            {
                //D: Fortschrittsanzeige ausblenden
                //US: hide progressbar
                progressBar1.Value = 0;
                progressBar1.Visibility = Visibility.Hidden;

                //D: Schaltflächen für Druck und Design aktivieren
                //US: enable the buttons for print and design
                EnableButtons(true);
            }
        }

        private void Design_DataView_Click(object sender, RoutedEventArgs e)
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
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }

        private void Print_DataView_Click(object sender, RoutedEventArgs e)
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
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            finally
            {
                //D: Fortschrittsanzeige ausblenden
                //US: hide progressbar
                progressBar1.Value = 0;
                progressBar1.Visibility = Visibility.Hidden;

                //D: Schaltflächen für Druck und Design aktivieren
                //US: enable the buttons for print and design
                EnableButtons(true);
            }
        }

        private void Design_DataTable_Click(object sender, RoutedEventArgs e)
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
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Print_DataTable_Click(object sender, RoutedEventArgs e)
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
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            finally
            {
                //D: Fortschrittsanzeige ausblenden
                //US: hide progressbar
                progressBar1.Value = 0;
                progressBar1.Visibility = Visibility.Hidden;

                //D: Schaltflächen für Druck und Design aktivieren
                //US: enable the buttons for print and design
                EnableButtons(true);
            }
        }

        private void Print_DataViewManager_Click(object sender, RoutedEventArgs e)
        {
            //D: Schaltflächen für Druck und Design deaktivieren
            //US: disable the buttons for print and design
            EnableButtons(false);
            DataProviderCollection providerCollection = CreateProviderCollection(true);

            try
            {
                //D:Dateiendung je nach Sprach setzen
                //US:set the file extension for used CultureInfo
                SetFileExtensions();

                //D: An die provideColletion binden
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
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            finally
            {
                //D:Dateiendungen wieder zuruecksetzen
                //US: set the file extension back
                ResetFileExtensions();

                //D: Fortschrittsanzeige ausblenden
                //US: hide progressbar
                progressBar1.Value = 0;
                progressBar1.Visibility = Visibility.Hidden;

                //D: Schaltflächen für Druck und Design aktivieren
                //US: enable the buttons for print and design
                EnableButtons(true);
            }
        }

        private void Design_DataViewManager_Click(object sender, RoutedEventArgs e)
        {

            DataProviderCollection providerCollection = CreateProviderCollection(true);
            try
            {
                //D:Dateiendung je nach Sprach setzen
                //US:set the file extension for used CultureInfo
                SetFileExtensions();

                //D: An die provideColletion binden
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
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            finally
            {
                //D:Dateiendungen wieder zuruecksetzen
                //US: set the file extension back
                ResetFileExtensions();
            }
        }

        private void LL_NotifyProgress(object sender, NotifyProgressEventArgs e)
        {
            if (Dispatcher.CheckAccess())
            {
                Dispatcher.BeginInvoke(new System.Windows.Forms.MethodInvoker(delegate
                {
                    LL_NotifyProgress(sender, e);
                }));
            }
            else
            {
                if (e.Percentage == 100)
                {
                    progressBar1.Visibility = Visibility.Hidden;
                    return;
                }

                progressBar1.Visibility = Visibility.Visible;
                progressBar1.Value = e.Percentage;
            }
        }

        private void Design_GenericList_Click(object sender, RoutedEventArgs e)
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
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Print_GenericList_Click(object sender, RoutedEventArgs e)
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
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            finally
            {
                //D: Schaltflächen für Druck und Design aktivieren
                //US: enable the buttons for print and design
                EnableButtons(true);
            }
        }

        private void Design_SQL_Click(object sender, RoutedEventArgs e)
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
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (SqlException sqlException)
            {
                //D: Exception abfangen
                //US: Catch Exceptions
                MessageBox.Show("Information: " + sqlException.Message, "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (InvalidOperationException invalidOperationException)
            {
                //D: Exception abfangen
                //US: Catch Exceptions
                MessageBox.Show("Information: " + invalidOperationException.Message, "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Print_SQL_Click(object sender, RoutedEventArgs e)
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
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (SqlException sqlException)
            {
                //D: Exception abfangen
                //US: Catch Exceptions
                MessageBox.Show("Information: " + sqlException.Message, "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (InvalidOperationException invalidOperationException)
            {
                //D: Exception abfangen
                //US: Catch Exceptions
                MessageBox.Show("Information: " + invalidOperationException.Message, "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            finally
            {
                //D: Schaltflächen für Druck und Design aktivieren
                //US: enable the buttons for print and design
                EnableButtons(true);
            }
        }

        private void Design_OData_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
            //Cursor.Current = Cursors.WaitCursor;
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
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            finally
            {
                Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                //Cursor.Current = Cursors.Default;
            }
        }

        private void Print_OData_Click(object sender, RoutedEventArgs e)
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
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            finally
            {
                //D: Fortschrittsanzeige ausblenden
                //US: hide progressbar
                progressBar1.Value = 0;
                progressBar1.Visibility = Visibility.Hidden;

                //D: Schaltflächen für Druck und Design aktivieren
                //US: enable the buttons for print and design
                EnableButtons(true);
            }
        }

        private void Design_REST_Click(object sender, RoutedEventArgs e)
        {
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
            //Cursor.Current = Cursors.WaitCursor;
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
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            finally
            {
                Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow;
                //Cursor.Current = Cursors.Default;
            }
        }

        private void Print_REST_Click(object sender, RoutedEventArgs e)
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
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            finally
            {
                //D: Fortschrittsanzeige ausblenden
                //US: hide progressbar
                progressBar1.Value = 0;
                progressBar1.Visibility = Visibility.Hidden;

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

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (LL.Core.IsPrinting)
            {
                e.Cancel = true;
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            LL.Dispose();
        }
    }
}
