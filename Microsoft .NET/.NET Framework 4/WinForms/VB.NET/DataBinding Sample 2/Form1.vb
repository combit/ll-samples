Imports System.Data.OleDb
Imports System.IO
Imports System.Windows.Forms
Imports combit.Reporting
Imports combit.Reporting.DataProviders
Imports Microsoft.Win32


Public Partial Class Form1
    Inherits Form
    Private _commandDataSetProvider As DbCommandSetDataProvider

	Public Sub New()
        Directory.SetCurrentDirectory("..\..\..\..\..\..\Report Files")
        InitializeComponent()

		InitDataSet()
	End Sub

	' Init Data Set to access nwind.mdb
	Private Sub InitDataSet()
		'D: Versuche Registry Schlüssel auszulesen
		'US: Try to read registry key
		Dim databasePath As String = [String].Empty
		Dim installKey As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\combit\cmbtll")
		If installKey IsNot Nothing Then
			databasePath = DirectCast(installKey.GetValue("NWINDPath", String.Empty), String)
		End If

		If [String].IsNullOrEmpty(databasePath) Then
			MessageBox.Show("Unable to find sample database. Make sure List & Label is installed correctly.", "List & Label")

			'D: Buttons deaktivieren
			'US: Disable Buttons
			button1.Enabled = False
			button2.Enabled = False
			button3.Enabled = False
			button4.Enabled = False
		Else
			'D: Erzeuge eine OleDbConnection
			'US: Create an OleDbConnection
			Dim connectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & databasePath
			Dim conn As New OleDbConnection(connectionString)
			conn.Open()

			'D: Erstelle zwei Datenbankabfragen
			'US: Create two database queries
			Dim command As New OleDbCommand("SELECT * FROM Orders WHERE (OrderID > 11040)", conn)
			Dim command2 As New OleDbCommand("SELECT [Order Details].OrderID, [Order Details].Quantity, [Order Details].UnitPrice, [Order Details].ProductID, Products.ProductID AS ProductsProductID, Products.CategoryID, Products.Discontinued, Products.ProductName, Products.QuantityPerUnit, Products.ReorderLevel, Products.SupplierID, Products.UnitPrice AS ProductsUnitPrice, Products.UnitsInStock, Products.UnitsOnOrder FROM [Order Details] INNER JOIN Products ON [Order Details].ProductID = Products.ProductID WHERE ([Order Details].OrderID > 11040)", conn)

			'D: Füge dem Provider zwei Tabellen hinzu
			'US: Add two tables to the provider
			_commandDataSetProvider = New DbCommandSetDataProvider()
            _commandDataSetProvider.AddCommand(command, "Orders", "[{0}]", "?")
            _commandDataSetProvider.AddCommand(command2, "Order Details", "[{0}]", "?")

			'D: Füge eine Relation zwischen den beiden Tabellen hinzu
			'US: Add a relation between the two tables
			_commandDataSetProvider.AddRelation("Orders2Order Details", "Orders", "Order Details", "OrderID", "OrderID")

			' automatic selector cannot handle complex join statements - switch off this optimization
			_commandDataSetProvider.MinimalSelect = False

			'D: Schließe die Verbindung
			'US: Close the connection
			conn.Close()
		End If
	End Sub


    <STAThread>
    Public Shared Sub Main()
        SetProcessDPIAware()
        Application.EnableVisualStyles()
        Application.Run(New Form1())
    End Sub
    <System.Runtime.InteropServices.DllImport("user32.dll")>
    Private Shared Function SetProcessDPIAware() As Boolean
    End Function

    Private Sub Form1_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load
        LL.SetDataBinding(_commandDataSetProvider, "Orders")
    End Sub

    Private Sub Button1_Click(sender As Object, e As System.EventArgs) Handles button1.Click
        Try
            'D: Die order master Daten sollen als Variablen angemeldet werden
            'US: we want to have the order master data as variables
            LL.AutoMasterMode = LlAutoMasterMode.AsVariables

            'D: Den Standard-Projektnamen setzen
            'US: set the default project name
            LL.AutoProjectFile = "inv_merg.lst"

            'D: Designer aufrufen
            'US: call the designer
            LL.Design()
        Catch LlException As ListLabelException
            'D: Exception abfangen
            'US: Catch Exceptions
            MessageBox.Show("Information: " & LlException.Message & vbLf & vbLf & "This information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As System.EventArgs) Handles button2.Click
        Try
            'D: Die order master Daten sollen als Variablen angemeldet werden
            'US: we want to have the order master data as variables
            LL.AutoMasterMode = LlAutoMasterMode.AsVariables

            'D: Den Standard-Projektnamen setzen
            'US: set the default project name
            LL.AutoProjectFile = "inv_merg.lst"

            'D: Drucken
            'US: print
            LL.Print()
        Catch LlException As ListLabelException
            'D: Exception abfangen
            'US: Catch Exceptions
            MessageBox.Show("Information: " & LlException.Message & vbLf & vbLf & "This information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As System.EventArgs) Handles button4.Click
        Try
            'D: Die order master Daten sollen als Felder angemeldet werden
            'US: we want to have the order master data as fields
            LL.AutoMasterMode = LlAutoMasterMode.AsFields

            'D: Den Standard-Projektnamen setzen
            'US: set the default project name
            LL.AutoProjectFile = "inv_lst.lst"

            'D: Designer aufrufen
            'US: call the designer
            LL.Design()
        Catch LlException As ListLabelException
            'D: Exception abfangen
            'US: Catch Exceptions
            MessageBox.Show("Information: " & LlException.Message & vbLf & vbLf & "This information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub Button3_Click(sender As Object, e As System.EventArgs) Handles button3.Click
        Try
            'D: Die order master Daten sollen als Felder angemeldet werden
            'US: we want to have the order master data as fields
            LL.AutoMasterMode = LlAutoMasterMode.AsFields

            'D: Den Standard-Projektnamen setzen
            'US: set the default project name
            LL.AutoProjectFile = "inv_lst.lst"

            'D: Drucken
            'US: print
            LL.Print()
        Catch LlException As ListLabelException
            'D: Exception abfangen
            'US: Catch Exceptions
            MessageBox.Show("Information: " & LlException.Message & vbLf & vbLf & "This information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
End Class
