using System;
using System.Data;
using System.Data.OleDb;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using combit.ListLabel24;
using Microsoft.Win32;
using MetroFramework.Forms;

namespace LocalizationSample
{
    public partial class LocalizationForm : MetroForm
    {
        private string _databasePath;
        private DataSet _dsReportData;
        private int _designerLanguageLCIDde = new CultureInfo("de").LCID;
        private int _designerLanguageLCIDfr = new CultureInfo("fr").LCID;

        public LocalizationForm()
        {
            InitializeComponent();

            //D: Pfad auf Sample-Hauptverzeichnis setzen, Datenbankpfad auslesen
            //US: Set path to main sample path, read database path
            Directory.SetCurrentDirectory(Application.StartupPath + @"\..\..\..\");
            RegistryKey installKey = Registry.CurrentUser.CreateSubKey(@"Software\combit\cmbtll");
            if (installKey != null)
            {
                _databasePath = (string)installKey.GetValue("NWINDPath", "");
            }
            if (_databasePath == "")
                MessageBox.Show("Unable to find sample database. Make sure List & Label is installed correctly.", "List & Label");

            _dsReportData = CreateDataSet();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new LocalizationForm());
        }

        private DataSet CreateDataSet()
        {
            //D: DataSet Objekt erstellen
            //US: Create the DataSet object
            DataSet ds = new DataSet();
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + _databasePath);
            conn.Open();

            object[] restrictions = new Object[] { null, null, null, "TABLE" };
            DataTable table = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, restrictions);

            //D: Durch alle Tabellen iterieren und Orders sowie OrderDetails gefiltert in das DataSet aufnehmen
            //US: Iterate all tables and add Orders and OrderDetails to the DataSet
            foreach (DataRow dr in table.Rows)
            {
                string tableName = dr["Table_Name"].ToString();
                OleDbDataAdapter dataAdapter;

                if (tableName == "Orders" || tableName == "Order Details")
                {
                    if (tableName == "Orders")
                        dataAdapter = new OleDbDataAdapter(new OleDbCommand("SELECT * FROM [" + tableName + "] WHERE (OrderID mod 5 = 0)", conn));
                    else
                        dataAdapter = new OleDbDataAdapter(new OleDbCommand(@"SELECT [Order Details].OrderID, [Order Details].Quantity, [Order Details].UnitPrice, [Order Details].ProductID, Products.ProductID AS ProductsProductID, Products.CategoryID, Products.Discontinued, Products.ProductName, Products.QuantityPerUnit, Products.ReorderLevel, Products.SupplierID, Products.UnitPrice AS ProductsUnitPrice, Products.UnitsInStock, Products.UnitsOnOrder FROM [Order Details] INNER JOIN Products ON [Order Details].ProductID = Products.ProductID WHERE ([Order Details].OrderID mod 5 = 0)", conn));

                    dataAdapter.FillSchema(ds, SchemaType.Source, tableName);
                    dataAdapter.Fill(ds, tableName);
                }
            }

            //D: Beziehung zwischen den Tabellen definieren
            //US: Create the relationships between the tables
            ds.Relations.Add(new DataRelation("Orders2Order Details", ds.Tables["Orders"].Columns["OrderID"], ds.Tables["Order Details"].Columns["OrderID"]));

            //D: Verbindung schliessen
            //US: Close connection
            conn.Close();

            return (ds);
        }

        private void FillStaticTextDictionary()
        {
            // D: Zusätzliche statische Texte lokalisieren
            // US: Localize additional static values
            LL.Dictionary.StaticTexts.Add("Language", "Sprache", _designerLanguageLCIDde);
            LL.Dictionary.StaticTexts.Add("Summary of Sales by Year", "Verkäufe nach Jahren", _designerLanguageLCIDde);
            LL.Dictionary.StaticTexts.Add("Quarter", "Quartal", _designerLanguageLCIDde);
            LL.Dictionary.StaticTexts.Add("Shipped", "Bestellungen", _designerLanguageLCIDde);
            LL.Dictionary.StaticTexts.Add("Sales", "Umsatz", _designerLanguageLCIDde);
            LL.Dictionary.StaticTexts.Add("Totals for", "Summen für", _designerLanguageLCIDde);
            LL.Dictionary.StaticTexts.Add("Sales by Year", "Umsatz nach Jahr", _designerLanguageLCIDde);
            LL.Dictionary.StaticTexts.Add("Lot by Year", "Stückzahlen nach Jahr", _designerLanguageLCIDde);

            LL.Dictionary.StaticTexts.Add("designed & printed with combit® List & Label®", "gestaltet & gedruckt mit combit® List & Label®", _designerLanguageLCIDde);
            LL.Dictionary.StaticTexts.Add("Page {0} of {1}", "Seite {0} von {1}", _designerLanguageLCIDde);
            LL.Dictionary.StaticTexts.Add("Effective: {0} {1}", "Stand: {0} {1}", _designerLanguageLCIDde);

            // D: Zusätzliche statische Texte lokalisieren
            // US: Localize additional static values
            LL.Dictionary.StaticTexts.Add("Language", "Langue", _designerLanguageLCIDfr);
            LL.Dictionary.StaticTexts.Add("Summary of Sales by Year", "Chiffre d´affaires à année", _designerLanguageLCIDfr);
            LL.Dictionary.StaticTexts.Add("Quarter", "Trimestre", _designerLanguageLCIDfr);
            LL.Dictionary.StaticTexts.Add("Shipped", "Commandes", _designerLanguageLCIDfr);
            LL.Dictionary.StaticTexts.Add("Sales", "Volume d'affaires", _designerLanguageLCIDfr);
            LL.Dictionary.StaticTexts.Add("Totals for", "Bourdonnement pour", _designerLanguageLCIDfr);
            LL.Dictionary.StaticTexts.Add("Sales by Year", "Volume d´affaires à année", _designerLanguageLCIDfr);
            LL.Dictionary.StaticTexts.Add("Lot by Year", "Nombre de pièces à année", _designerLanguageLCIDfr);

            LL.Dictionary.StaticTexts.Add("designed & printed with combit® List & Label®", "modeler & imprimée avec combit® List & Label®", _designerLanguageLCIDfr);
            LL.Dictionary.StaticTexts.Add("Page {0} of {1}", "Page {0} de {1}", _designerLanguageLCIDfr);
            LL.Dictionary.StaticTexts.Add("Effective: {0} {1}", "Mise à jour : {0} {1}", _designerLanguageLCIDfr);
        }

        private void FillDictionary()
        {
            // D: Dictionary löschen
            // US: Clear dictionary
            LL.Dictionary.Clear();
            LL.DesignerWorkspace.DesignerLanguages.Clear();

            // D: Zur Verfügung stehende Sprachen im Designer hinzufügen. Die zuerst angemeldete Sprache wird als Basissprache verwendet!
            // US: Add available languages for the designer. The first language is the basic language
            LL.DesignerWorkspace.DesignerLanguages.Add(new CultureInfo("en").LCID);
            LL.DesignerWorkspace.DesignerLanguages.Add(_designerLanguageLCIDde);
            LL.DesignerWorkspace.DesignerLanguages.Add(_designerLanguageLCIDfr);

            // D: Für die Basissprache werden die Originalbezeichner verwendet, nur die anderen Sprachen müssen lokalisiert werden
            // US: We'll use the original names for the basic language. Localize for the other languages

            // D: Deutsche Lokalisierung
            // US: German localization

            // D: Tabellennamen lokalisieren
            // US: Localize table names
            LL.Dictionary.Tables.Add("Orders", "Bestellungen", _designerLanguageLCIDde);
            LL.Dictionary.Tables.Add("Order Details", "Bestellposten", _designerLanguageLCIDde);

            // D: Relationsnamen lokalisieren
            // US: Localize relation name
            LL.Dictionary.Relations.Add("Orders2Order Details", "Bestellungen/Bestellposten", _designerLanguageLCIDde);

            // D: Feldnamen lokalisieren
            // US: Localize field names
            LL.Dictionary.Identifiers.Add("ProductID", "ProduktID", _designerLanguageLCIDde);
            LL.Dictionary.Identifiers.Add("ProductName", "Produktname", _designerLanguageLCIDde);
            LL.Dictionary.Identifiers.Add("Quantity", "Anzahl", _designerLanguageLCIDde);
            LL.Dictionary.Identifiers.Add("UnitPrice", "Einzelpreis", _designerLanguageLCIDde);
            LL.Dictionary.Identifiers.Add("Discount", "Rabatt", _designerLanguageLCIDde);

            LL.Dictionary.Identifiers.Add("OrderID", "BestellID", _designerLanguageLCIDde);
            LL.Dictionary.Identifiers.Add("CustomerID", "KundenID", _designerLanguageLCIDde);
            LL.Dictionary.Identifiers.Add("EmployeeID", "MitarbeiterID", _designerLanguageLCIDde);
            LL.Dictionary.Identifiers.Add("OrderDate", "Bestelldatum", _designerLanguageLCIDde);
            LL.Dictionary.Identifiers.Add("RequiredDate", "Bedarfstermin", _designerLanguageLCIDde);
            LL.Dictionary.Identifiers.Add("ShippedDate", "Versanddatum", _designerLanguageLCIDde);
            LL.Dictionary.Identifiers.Add("ShipVia", "VersandDurch", _designerLanguageLCIDde);
            LL.Dictionary.Identifiers.Add("Freight", "Frachtkosten", _designerLanguageLCIDde);
            LL.Dictionary.Identifiers.Add("ShipName", "EmpfängerName", _designerLanguageLCIDde);
            LL.Dictionary.Identifiers.Add("ShipAddress", "EmpfängerAdresse", _designerLanguageLCIDde);
            LL.Dictionary.Identifiers.Add("ShipCity", "EmpfängerStadt", _designerLanguageLCIDde);
            LL.Dictionary.Identifiers.Add("ShipRegion", "Bundesland", _designerLanguageLCIDde);
            LL.Dictionary.Identifiers.Add("ShipPostalCode", "PLZ", _designerLanguageLCIDde);
            LL.Dictionary.Identifiers.Add("ShipCountry", "EmpfängerLand", _designerLanguageLCIDde);

            // D: Französische Lokalisierung
            // US: French localization

            // D: Tabellennamen lokalisieren
            // US: Localize table names
            LL.Dictionary.Tables.Add("Orders", "Commandes", _designerLanguageLCIDfr);
            LL.Dictionary.Tables.Add("Order Details", "DétailsDesCommandes", _designerLanguageLCIDfr);

            // D: Relationsnamen lokalisieren
            // US: Localize relation name
            LL.Dictionary.Relations.Add("Orders2Order Details", "Commandes2DétailsDesCommandes", _designerLanguageLCIDfr);

            // D: Feldnamen lokalisieren
            // US: Localize field names
            LL.Dictionary.Identifiers.Add("ProductID", "ProduitID", _designerLanguageLCIDfr);
            LL.Dictionary.Identifiers.Add("ProductName", "NomDuProduit", _designerLanguageLCIDfr);
            LL.Dictionary.Identifiers.Add("Quantity", "Quantité", _designerLanguageLCIDfr);
            LL.Dictionary.Identifiers.Add("UnitPrice", "PrixUnitaire", _designerLanguageLCIDfr);
            LL.Dictionary.Identifiers.Add("Discount", "Ristourne", _designerLanguageLCIDfr);

            LL.Dictionary.Identifiers.Add("OrderID", "CommandeID", _designerLanguageLCIDfr);
            LL.Dictionary.Identifiers.Add("CustomerID", "ClientID", _designerLanguageLCIDfr);
            LL.Dictionary.Identifiers.Add("EmployeeID", "CoopérateurID", _designerLanguageLCIDfr);
            LL.Dictionary.Identifiers.Add("OrderDate", "DateDeLaCommande", _designerLanguageLCIDfr);
            LL.Dictionary.Identifiers.Add("RequiredDate", "BesoinDate", _designerLanguageLCIDfr);
            LL.Dictionary.Identifiers.Add("ShippedDate", "EnvoiDate", _designerLanguageLCIDfr);
            LL.Dictionary.Identifiers.Add("ShipVia", "EnvoiPar", _designerLanguageLCIDfr);
            LL.Dictionary.Identifiers.Add("Freight", "Fret", _designerLanguageLCIDfr);
            LL.Dictionary.Identifiers.Add("ShipName", "DestinataireNom", _designerLanguageLCIDfr);
            LL.Dictionary.Identifiers.Add("ShipAddress", "DestinataireAdresse", _designerLanguageLCIDfr);
            LL.Dictionary.Identifiers.Add("ShipCity", "DestinataireVille", _designerLanguageLCIDfr);
            LL.Dictionary.Identifiers.Add("ShipRegion", "Région", _designerLanguageLCIDfr);
            LL.Dictionary.Identifiers.Add("ShipPostalCode", "CodePostal", _designerLanguageLCIDfr);
            LL.Dictionary.Identifiers.Add("ShipCountry", "DestinatairePays", _designerLanguageLCIDfr);

            //D:   Spezieller Fall für statische Texte, da diese später auch für den Druck benötigt werden
            //US: Handling for static texts, because static texts will be neccessary for later printing
            FillStaticTextDictionary();
        }

        private void DesignButton_Click(object sender, System.EventArgs e)
        {
            // D: An DataSet binden
            // US: Bind to DataSet
            LL.SetDataBinding(_dsReportData, "Orders");

            // D: Optionen setzen
            // US: Set options
            LL.AutoProjectFile = "localization.lst";

            // D: Dictionary füllen
            // US: Fill Dictionary
            FillDictionary();

            try
            {
                //D: Designer aufrufen - Event 'AutoDefineField' anmelden, um nicht vorhandene Übersetzungen zu überspringen
                //US: call the designer - attach event 'AutoDefineField' to skip non existing localizations
                LL.AutoDefineField += new AutoDefineElementHandler(LL_AutoDefineField);
                LL.Design();
                LL.AutoDefineField -= new AutoDefineElementHandler(LL_AutoDefineField);
            }
            catch (ListLabelException LlException)
            {
                //D: Exception abfangen
                //US: Catch Exceptions
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void PrintButton_Click(object sender, System.EventArgs e)
        {
            // D: An DataSet binden
            // US: Bind to DataSet
            LL.SetDataBinding(_dsReportData, "Orders");

            // D: Optionen setzen
            // US: Set options
            LL.AutoProjectFile = "localization.lst";

            // D: Dictionary löschen - beim Druck wird es nicht benötigt
            // US: Clear Dictionary - it's not needed at print time
            LL.Dictionary.Clear();

            //D:   Lokalisierung der statischen Texte sind für den Druck notwendig
            //US: Localization for static texts are neccessary for printing
            FillStaticTextDictionary();

            try
            {
                //D: Drucken
                //US: print
                LL.Print();
            }
            catch (ListLabelException LlException)
            {
                //D: Exception abfangen
                //US: Catch Exceptions
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LL_AutoDefineField(object sender, AutoDefineElementEventArgs e)
        {
            //D: In der Übersetzung fehlendes Feld nicht anmelden
            //US: Suppress field that is not localized
            char[] delimiters = { '.', ':' };
            string[] parts = e.Name.Split(delimiters);
            if (!LL.Dictionary.Identifiers.Contains(parts[parts.Length - 1]))
                e.Suppress = true;
        }
    }
}
