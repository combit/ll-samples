Imports System.Data
Imports System.Data.OleDb
Imports System.Globalization
Imports System.IO
Imports System.Windows.Forms
Imports combit.ListLabel24
Imports Microsoft.Win32
Imports MetroFramework.Forms

Public Partial Class LocalizationForm
    Inherits MetroFramework.Forms.MetroForm
	Private _databasePath As String
	Private _dsReportData As DataSet
	Private _designerLanguageLCIDde As Integer = New CultureInfo("de").LCID
	Private _designerLanguageLCIDfr As Integer = New CultureInfo("fr").LCID

	Public Sub New()
		InitializeComponent()

		'D: Pfad auf Sample-Hauptverzeichnis setzen, Datenbankpfad auslesen
		'US: Set path to main sample path, read database path
		Directory.SetCurrentDirectory(Application.StartupPath & "\..\..\..\")
		Dim installKey As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\combit\cmbtll")
		If installKey IsNot Nothing Then
			_databasePath = DirectCast(installKey.GetValue("NWINDPath", ""), String)
		End If
		If _databasePath = "" Then
			MessageBox.Show("Unable to find sample database. Make sure List & Label is installed correctly.", "List & Label")
		End If

		_dsReportData = CreateDataSet()
	End Sub

	''' <summary>
	''' The main entry point for the application.
	''' </summary>
	<STAThread> _
	Friend Shared Sub Main()
		Application.EnableVisualStyles()
		Application.Run(New LocalizationForm())
	End Sub

	Private Function CreateDataSet() As DataSet
		'D: DataSet Objekt erstellen
		'US: Create the DataSet object
		Dim ds As New DataSet()
		Dim conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & _databasePath)
		conn.Open()

		Dim restrictions As Object() = New [Object]() {Nothing, Nothing, Nothing, "TABLE"}
		Dim table As DataTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, restrictions)

		'D: Durch alle Tabellen iterieren und Orders sowie OrderDetails gefiltert in das DataSet aufnehmen
		'US: Iterate all tables and add Orders and OrderDetails to the DataSet
		For Each dr As DataRow In table.Rows
			Dim tableName As String = dr("Table_Name").ToString()
			Dim dataAdapter As OleDbDataAdapter

			If tableName = "Orders" OrElse tableName = "Order Details" Then
				If tableName = "Orders" Then
					dataAdapter = New OleDbDataAdapter(New OleDbCommand("SELECT * FROM [" & tableName & "] WHERE (OrderID mod 5 = 0)", conn))
				Else
					dataAdapter = New OleDbDataAdapter(New OleDbCommand("SELECT [Order Details].OrderID, [Order Details].Quantity, [Order Details].UnitPrice, [Order Details].ProductID, Products.ProductID AS ProductsProductID, Products.CategoryID, Products.Discontinued, Products.ProductName, Products.QuantityPerUnit, Products.ReorderLevel, Products.SupplierID, Products.UnitPrice AS ProductsUnitPrice, Products.UnitsInStock, Products.UnitsOnOrder FROM [Order Details] INNER JOIN Products ON [Order Details].ProductID = Products.ProductID WHERE ([Order Details].OrderID mod 5 = 0)", conn))
				End If

				dataAdapter.FillSchema(ds, SchemaType.Source, tableName)
				dataAdapter.Fill(ds, tableName)
			End If
		Next

		'D: Beziehung zwischen den Tabellen definieren
		'US: Create the relationships between the tables
		ds.Relations.Add(New DataRelation("Orders2Order Details", ds.Tables("Orders").Columns("OrderID"), ds.Tables("Order Details").Columns("OrderID")))

		'D: Verbindung schliessen
		'US: Close connection
		conn.Close()

		Return (ds)
	End Function

	Private Sub FillStaticTextDictionary()
		' D: Zusätzliche statische Texte lokalisieren
		' US: Localize additional static values
		LL.Dictionary.StaticTexts.Add("Language", "Sprache", _designerLanguageLCIDde)
		LL.Dictionary.StaticTexts.Add("Summary of Sales by Year", "Verkäufe nach Jahren", _designerLanguageLCIDde)
		LL.Dictionary.StaticTexts.Add("Quarter", "Quartal", _designerLanguageLCIDde)
		LL.Dictionary.StaticTexts.Add("Shipped", "Bestellungen", _designerLanguageLCIDde)
		LL.Dictionary.StaticTexts.Add("Sales", "Umsatz", _designerLanguageLCIDde)
		LL.Dictionary.StaticTexts.Add("Totals for", "Summen für", _designerLanguageLCIDde)
		LL.Dictionary.StaticTexts.Add("Sales by Year", "Umsatz nach Jahr", _designerLanguageLCIDde)
		LL.Dictionary.StaticTexts.Add("Lot by Year", "Stückzahlen nach Jahr", _designerLanguageLCIDde)

		LL.Dictionary.StaticTexts.Add("designed & printed with combit® List & Label®", "gestaltet & gedruckt mit combit® List & Label®", _designerLanguageLCIDde)
		LL.Dictionary.StaticTexts.Add("Page {0} of {1}", "Seite {0} von {1}", _designerLanguageLCIDde)
        LL.Dictionary.StaticTexts.Add("Effective: {0} {1}", "Stand: {0} {1}", _designerLanguageLCIDde)

		' D: Zusätzliche statische Texte lokalisieren
		' US: Localize additional static values
		LL.Dictionary.StaticTexts.Add("Language", "Langue", _designerLanguageLCIDfr)
		LL.Dictionary.StaticTexts.Add("Summary of Sales by Year", "Chiffre d´affaires à année", _designerLanguageLCIDfr)
		LL.Dictionary.StaticTexts.Add("Quarter", "Trimestre", _designerLanguageLCIDfr)
		LL.Dictionary.StaticTexts.Add("Shipped", "Commandes", _designerLanguageLCIDfr)
		LL.Dictionary.StaticTexts.Add("Sales", "Volume d'affaires", _designerLanguageLCIDfr)
		LL.Dictionary.StaticTexts.Add("Totals for", "Bourdonnement pour", _designerLanguageLCIDfr)
		LL.Dictionary.StaticTexts.Add("Sales by Year", "Volume d´affaires à année", _designerLanguageLCIDfr)
		LL.Dictionary.StaticTexts.Add("Lot by Year", "Nombre de pièces à année", _designerLanguageLCIDfr)

		LL.Dictionary.StaticTexts.Add("designed & printed with combit® List & Label®", "modeler & imprimée avec combit® List & Label®", _designerLanguageLCIDfr)
		LL.Dictionary.StaticTexts.Add("Page {0} of {1}", "Page {0} de {1}", _designerLanguageLCIDfr)
        LL.Dictionary.StaticTexts.Add("Effective: {0} {1}", "Mise à jour : {0} {1}", _designerLanguageLCIDfr)
	End Sub

	Private Sub FillDictionary()
		' D: Dictionary löschen
		' US: Clear dictionary
		LL.Dictionary.Clear()
		LL.DesignerWorkspace.DesignerLanguages.Clear()

		' D: Zur Verfügung stehende Sprachen im Designer hinzufügen. Die zuerst angemeldete Sprache wird als Basissprache verwendet!
		' US: Add available languages for the designer. The first language is the basic language
		LL.DesignerWorkspace.DesignerLanguages.Add(New CultureInfo("en").LCID)
		LL.DesignerWorkspace.DesignerLanguages.Add(_designerLanguageLCIDde)
		LL.DesignerWorkspace.DesignerLanguages.Add(_designerLanguageLCIDfr)

		' D: Für die Basissprache werden die Originalbezeichner verwendet, nur die anderen Sprachen müssen lokalisiert werden
		' US: We'll use the original names for the basic language. Localize for the other languages

		' D: Deutsche Lokalisierung
		' US: German localization

		' D: Tabellennamen lokalisieren
		' US: Localize table names
		LL.Dictionary.Tables.Add("Orders", "Bestellungen", _designerLanguageLCIDde)
		LL.Dictionary.Tables.Add("Order Details", "Bestellposten", _designerLanguageLCIDde)

		' D: Relationsnamen lokalisieren
		' US: Localize relation name
		LL.Dictionary.Relations.Add("Orders2Order Details", "Bestellungen/Bestellposten", _designerLanguageLCIDde)

		' D: Feldnamen lokalisieren
		' US: Localize field names
		LL.Dictionary.Identifiers.Add("ProductID", "ProduktID", _designerLanguageLCIDde)
		LL.Dictionary.Identifiers.Add("ProductName", "Produktname", _designerLanguageLCIDde)
		LL.Dictionary.Identifiers.Add("Quantity", "Anzahl", _designerLanguageLCIDde)
		LL.Dictionary.Identifiers.Add("UnitPrice", "Einzelpreis", _designerLanguageLCIDde)
		LL.Dictionary.Identifiers.Add("Discount", "Rabatt", _designerLanguageLCIDde)

		LL.Dictionary.Identifiers.Add("OrderID", "BestellID", _designerLanguageLCIDde)
		LL.Dictionary.Identifiers.Add("CustomerID", "KundenID", _designerLanguageLCIDde)
		LL.Dictionary.Identifiers.Add("EmployeeID", "MitarbeiterID", _designerLanguageLCIDde)
		LL.Dictionary.Identifiers.Add("OrderDate", "Bestelldatum", _designerLanguageLCIDde)
		LL.Dictionary.Identifiers.Add("RequiredDate", "Bedarfstermin", _designerLanguageLCIDde)
		LL.Dictionary.Identifiers.Add("ShippedDate", "Versanddatum", _designerLanguageLCIDde)
		LL.Dictionary.Identifiers.Add("ShipVia", "VersandDurch", _designerLanguageLCIDde)
		LL.Dictionary.Identifiers.Add("Freight", "Frachtkosten", _designerLanguageLCIDde)
		LL.Dictionary.Identifiers.Add("ShipName", "EmpfängerName", _designerLanguageLCIDde)
		LL.Dictionary.Identifiers.Add("ShipAddress", "EmpfängerAdresse", _designerLanguageLCIDde)
		LL.Dictionary.Identifiers.Add("ShipCity", "EmpfängerStadt", _designerLanguageLCIDde)
		LL.Dictionary.Identifiers.Add("ShipRegion", "Bundesland", _designerLanguageLCIDde)
		LL.Dictionary.Identifiers.Add("ShipPostalCode", "PLZ", _designerLanguageLCIDde)
		LL.Dictionary.Identifiers.Add("ShipCountry", "EmpfängerLand", _designerLanguageLCIDde)

		' D: Französische Lokalisierung
		' US: French localization

		' D: Tabellennamen lokalisieren
		' US: Localize table names
		LL.Dictionary.Tables.Add("Orders", "Commandes", _designerLanguageLCIDfr)
		LL.Dictionary.Tables.Add("Order Details", "DétailsDesCommandes", _designerLanguageLCIDfr)

		' D: Relationsnamen lokalisieren
		' US: Localize relation name
		LL.Dictionary.Relations.Add("Orders2Order Details", "Commandes2DétailsDesCommandes", _designerLanguageLCIDfr)

		' D: Feldnamen lokalisieren
		' US: Localize field names
		LL.Dictionary.Identifiers.Add("ProductID", "ProduitID", _designerLanguageLCIDfr)
		LL.Dictionary.Identifiers.Add("ProductName", "NomDuProduit", _designerLanguageLCIDfr)
		LL.Dictionary.Identifiers.Add("Quantity", "Quantité", _designerLanguageLCIDfr)
		LL.Dictionary.Identifiers.Add("UnitPrice", "PrixUnitaire", _designerLanguageLCIDfr)
		LL.Dictionary.Identifiers.Add("Discount", "Ristourne", _designerLanguageLCIDfr)

		LL.Dictionary.Identifiers.Add("OrderID", "CommandeID", _designerLanguageLCIDfr)
		LL.Dictionary.Identifiers.Add("CustomerID", "ClientID", _designerLanguageLCIDfr)
		LL.Dictionary.Identifiers.Add("EmployeeID", "CoopérateurID", _designerLanguageLCIDfr)
		LL.Dictionary.Identifiers.Add("OrderDate", "DateDeLaCommande", _designerLanguageLCIDfr)
		LL.Dictionary.Identifiers.Add("RequiredDate", "BesoinDate", _designerLanguageLCIDfr)
		LL.Dictionary.Identifiers.Add("ShippedDate", "EnvoiDate", _designerLanguageLCIDfr)
		LL.Dictionary.Identifiers.Add("ShipVia", "EnvoiPar", _designerLanguageLCIDfr)
		LL.Dictionary.Identifiers.Add("Freight", "Fret", _designerLanguageLCIDfr)
		LL.Dictionary.Identifiers.Add("ShipName", "DestinataireNom", _designerLanguageLCIDfr)
		LL.Dictionary.Identifiers.Add("ShipAddress", "DestinataireAdresse", _designerLanguageLCIDfr)
		LL.Dictionary.Identifiers.Add("ShipCity", "DestinataireVille", _designerLanguageLCIDfr)
		LL.Dictionary.Identifiers.Add("ShipRegion", "Région", _designerLanguageLCIDfr)
		LL.Dictionary.Identifiers.Add("ShipPostalCode", "CodePostal", _designerLanguageLCIDfr)
		LL.Dictionary.Identifiers.Add("ShipCountry", "DestinatairePays", _designerLanguageLCIDfr)

		'D:   Spezieller Fall für statische Texte, da diese später auch für den Druck benötigt werden
		'US: Handling for static texts, because static texts will be neccessary for later printing
		FillStaticTextDictionary()
	End Sub

    Private Sub DesignButton_Click(sender As Object, e As System.EventArgs) Handles designButton.Click
        ' D: An DataSet binden
        ' US: Bind to DataSet
        LL.SetDataBinding(_dsReportData, "Orders")

        ' D: Optionen setzen
        ' US: Set options
        LL.AutoProjectFile = "localization.lst"

        ' D: Dictionary füllen
        ' US: Fill Dictionary
        FillDictionary()

        Try
            'D: Designer aufrufen - Event 'AutoDefineField' anmelden, um nicht vorhandene Übersetzungen zu überspringen
            'US: call the designer - attach event 'AutoDefineField' to skip non existing localizations
            AddHandler LL.AutoDefineField, New AutoDefineElementHandler(AddressOf LL_AutoDefineField)
            LL.Design()
            RemoveHandler LL.AutoDefineField, New AutoDefineElementHandler(AddressOf LL_AutoDefineField)
        Catch LlException As ListLabelException
            'D: Exception abfangen
            'US: Catch Exceptions
            MessageBox.Show("Information: " & LlException.Message & vbLf & vbLf & "This information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub PrintButton_Click(sender As Object, e As System.EventArgs) Handles printButton.Click
        ' D: An DataSet binden
        ' US: Bind to DataSet
        LL.SetDataBinding(_dsReportData, "Orders")

        ' D: Optionen setzen
        ' US: Set options
        LL.AutoProjectFile = "localization.lst"

        ' D: Dictionary löschen - beim Druck wird es nicht benötigt
        ' US: Clear Dictionary - it's not needed at print time
        LL.Dictionary.Clear()

        'D:   Lokalisierung der statischen Texte sind für den Druck notwendig
        'US: Localization for static texts are neccessary for printing
        FillStaticTextDictionary()

        Try
            'D: Drucken
            'US: print
            LL.Print()
        Catch LlException As ListLabelException
            'D: Exception abfangen
            'US: Catch Exceptions
            MessageBox.Show("Information: " & LlException.Message & vbLf & vbLf & "This information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub LL_AutoDefineField(sender As Object, e As AutoDefineElementEventArgs)
		'D: In der Übersetzung fehlendes Feld nicht anmelden
		'US: Suppress field that is not localized
		Dim delimiters As Char() = {"."C, ":"C}
		Dim parts As String() = e.Name.Split(delimiters)
		If Not LL.Dictionary.Identifiers.Contains(parts(parts.Length - 1)) Then
			e.Suppress = True
		End If
	End Sub
End Class
