Imports combit.ListLabel24.DataProviders
Imports combit.ListLabel24
Imports System.Data.OleDb
Imports System.Linq
Imports System.Collections.Generic
Imports Microsoft.Win32
Imports System.IO
Imports System.ComponentModel
Imports MetroFramework.Forms

Public Class Form1

    Dim DatabasePath As String
    Dim provider As DataProviders.ObjectDataProvider
    Dim LL As ListLabel

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'D: Verzeichnis wechslen - wird bei der Ausführung in der IDE benötigt
        'US: Change Directory - needed while running within the IDE
        Directory.SetCurrentDirectory(Application.StartupPath + "\..\..\..\")

        Dim installKey As RegistryKey
        installKey = Registry.CurrentUser.CreateSubKey("Software\combit\cmbtll")
        If Not installKey Is Nothing Then
            DatabasePath = CStr(installKey.GetValue("NWINDPath", ""))
        End If
        If DatabasePath = "" Then
            MessageBox.Show("Unable to find sample database. Make sure List & Label is installed correctly.", "List & Label")
        End If

        ' D: Initialisiere DropDown Liste
        ' US: Initialize DropDown list
        comboSelection.Items.Add("IEnumerable<T>")
        comboSelection.Items.Add("LINQ with GenericList")
        comboSelection.Items.Add("LINQ with DataSet")
        comboSelection.SelectedIndex = 0

        ' D: Neues ListLabel Objekt anlegen
        ' US: Create new ListLabel object
        LL = New ListLabel()

    End Sub

    Private Function CreateDataSet() As DataSet
        Dim ds As New DataSet()

        'D: DataSet Objekt erstellen
        'US: Create the DataSet object
        Dim conn As New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DatabasePath)
        conn.Open()

        Dim table As DataTable
        table = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, New Object() {Nothing, Nothing, Nothing, "TABLE"})

        'D: Durch alle Tabellen iterieren und in das DataSet aufnehmen
        'US: Iterate all tabels and add them to DataSet
        Dim dr As DataRow
        For Each dr In table.Rows

            Dim tableName As String
            tablename = dr("Table_Name").ToString()
            Dim dataAdapter As OleDbDataAdapter

            'D: Die "Orders" und "Order Details" Tabelle einschränken.
            'US: Limit the "Order" an "Order Details" table. 
            dataAdapter = New OleDbDataAdapter(New OleDbCommand("SELECT * FROM [" + tableName + "]", conn))
            dataAdapter.FillSchema(ds, SchemaType.Source, tableName)
            dataAdapter.Fill(ds, tableName)

        Next

        Dim table1 As DataTable
        table1 = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Foreign_Keys, Nothing)

        'D: Relationen auslesen
        'US: Get relations
        Dim dr1 As DataRow
        For Each dr1 In table1.Rows

            Dim sChildTable As String
            sChildTable = dr1("FK_TABLE_NAME").ToString()
            Dim sChildCol As String
            sChildCol = dr1("FK_COLUMN_NAME").ToString()

            ' D:  Eltern = Primary
            'US: Parent = primary
            Dim sParentTable As String
            sParentTable = dr1("PK_TABLE_NAME").ToString()
            Dim sParentCol As String
            sParentCol = dr1("PK_COLUMN_NAME").ToString()
            Dim sRelationName As String
            sRelationName = sParentTable + "2" + sChildTable

            'D: Beziehung zwischen den Tabellen definieren
            'US: Create the relationships between the tables
            ds.Relations.Add(New DataRelation(sRelationName, ds.Tables(sParentTable).Columns(sParentCol), ds.Tables(sChildTable).Columns(sChildCol)))
        Next

        'D: Verbindung schliessen
        'US: Close connection
        conn.Close()

        Return (ds)
    End Function

    Private Sub SetupObjectDataProvider()
        ' D: Demonstriert die Benutzung des ObjectDataProviders mit einem IEnumerable<T>
        ' US: Demonstrates the use of the ObjectDataProvider with an IEnumerable<T>
        If comboSelection.SelectedItem.ToString() = "IEnumerable<T>" Then
            Dim customerList As IEnumerable(Of Customer) = GetGenericList()
            provider = New DataProviders.ObjectDataProvider(customerList)

            ' D: Den vom Designer verwendeten Tabellennamen festlegen (optional)
            ' US: Declare a name for the table, which will be used in the designer (optional)
            provider.RootTableName = "Customer"

            LL.AutoProjectFile = "IEnumerable.lst"


            ' D: LINQ in Verbindung mit einer Generischen Liste
            ' US: LINQ with a Generic List
        ElseIf comboSelection.SelectedItem.ToString() = "LINQ with GenericList" Then
            Dim customerList As IEnumerable(Of Customer) = GetGenericList()
            Dim customerQuery As IEnumerable(Of Customer)

            ' D: LINQ Abfrage, listet alle Kunden aus Zuerich auf
            ' US: LINQ Query, selecting all customers from Zurich
            customerQuery = From customer In customerList _
             Where customer.City = "Zurich" _
             Select customer

            provider = New DataProviders.ObjectDataProvider(customerQuery.ToList())

            LL.AutoProjectFile = "LINQwithGenericList.lst"

            ' D: LINQ in Verbindung mit einem DataSet
            ' US: LINQ with DataSet
        ElseIf comboSelection.SelectedItem.ToString() = "LINQ with DataSet" Then
            ' D: LINQ Abfrage, listet alle Kunden aus Berlin oder London auf
            ' US: LINQ Query, selects all customers from Berlin or London
            Dim customerQuery = From customers In Me.CreateDataSet().Tables("Customers").AsEnumerable() _
             Where customers.Field(Of String)("City") = "Berlin" _
             OrElse customers.Field(Of String)("City") = "London" _
             Order By customers.Field(Of String)("CompanyName") Descending _
             Select customers

            provider = New DataProviders.ObjectDataProvider(customerQuery.AsDataView())
			provider.UseLinqForSorting = False
            LL.AutoProjectFile = "LINQwithDataSet.lst"
        End If
    End Sub

    Private Sub ButtonDesign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonDesign.Click
        Try
            ' D: Je nach DropDown Listen Auswahl andere Datenquelle dem ObjectDataProvider zuweisen
            ' US: Link data sources of the ObjectDataProvider, depending on the selection of the dropdown list 
            SetupObjectDataProvider()

            ' D: Den Datenprovider bei List und Label anmelden und den Designer starten
            ' US: Pass the data provider to List and Label and start the designer
            LL.DataSource = provider
            LL.Design()

        Catch llException As ListLabelException
            ' D: Exception abfangen
            ' US: Catch Exceptions
            MessageBox.Show("Information: " + llException.Message + vbCrLf + vbCrLf + "This information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub ButtonPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonPrint.Click
        Try
            ' D: Je nach DropDown Listen Auswahl andere Datenquelle dem ObjectDataProvider zuweisen
            ' US: Link data sources of the ObjectDataProvider, depending on the selection of the dropdown list 
            SetupObjectDataProvider()

            ' D: Den Datenprovider bei List und Label anmelden und den Druck starten
            ' US: Pass the data provider to List and Label and print
            LL.DataSource = provider
            LL.Print()

        Catch llException As ListLabelException
            ' D: Exception abfangen
            ' US: Catch Exceptions
            MessageBox.Show("Information: " + llException.Message + vbCrLf + vbCrLf + "This information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Function GetGenericList() As IEnumerable(Of Customer)

        Dim customerList As New List(Of Customer)

        'D: Mehrere Kunden erstellen
        'US: Create some customers
        Dim customer1 As New Customer(1, "Joe's Tatoo", "Joe Smith", "Kingstreet 2a", "Queens")
        Dim customer2 As New Customer(2, "Tec n Toc", "Peter Bush", "Park Avenue", "NewYork")
        Dim customer3 As New Customer(3, "Sunshine Agency", "Brian Holiday", "Island Road 1", "Zurich")
        Dim customer4 As New Customer(4, "Hiking Store", "Sandra Mountain", "Hillstreet 6", "Garmisch")

        'D: Die Bestellungen fuer den ersten Kunden definieren
        'US: Define orders for the first customer
        customer1.OrderList.Add(New Order(1, New DateTime(2006, 1, 20), "Nils van de Glocke", "Houston", 14.64))
        customer1.OrderList.Add(New Order(2, New DateTime(2006, 6, 21), "Bruce White", "New Orleans", 214.0))
        customer1.OrderList.Add(New Order(3, New DateTime(2006, 3, 1), "Kurt Muster", "Berlin", 6420.0))

        'D: Die Bestellungen fuer den zweiten Kunden definieren
        'US: Define orders for the second customer
        customer2.OrderList.Add(New Order(4, New DateTime(2005, 12, 3), "Bill Bunny", "Frankfurt", 640.99))

        'D: Die Bestellungen fuer den dritten Kunden definieren
        'US: Define orders for the third customer
        customer3.OrderList.Add(New Order(5, New DateTime(2006, 4, 3), "Mia Rust", "Madrid", 56.6))
        customer3.OrderList.Add(New Order(6, New DateTime(2006, 4, 16), "Mia Rust", "Madrid", 450.0))
        customer3.OrderList.Add(New Order(7, New DateTime(2006, 4, 25), "Mia Rust", "Madrid", 1585.0))

        'D: Die Bestellungen fuer den vierten Kunden definieren
        'US: Define orders for the fourth customer
        customer4.OrderList.Add(New Order(8, New DateTime(2006, 6, 6), "Steve Random", "Vienna", 990.0))

        'D: Die einzelnen Kunden in die Kundenliste aufnehmen
        'US: Add the single customers to the customer list
        customerList.AddRange(New Customer() {customer1, customer2, customer3, customer4})

        Return (customerList)
    End Function

	Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing

		If (Not (LL Is Nothing)) Then
			LL.Dispose()
			LL = Nothing
		End If

	End Sub

    ' D: Diese Funktion aendert den Text auf der Form bei Auswahl aus der DropDown Liste
    ' US:This function changes the text of the form when a item is selected from the dropdown list
    Private Sub ComboSelection_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboSelection.SelectedIndexChanged

        Select Case comboSelection.SelectedIndex
            Case 0
                label_DE.Text = "Beachten Sie bitte die Properties ""CustomerID"" und ""ContactName"" in GenericList.cs"
                label_US.Text = "Please hava a look into GenericList.cs for the properties ""CustomerID"" and ""ContactName"""
                Exit Select

            Case 1
                label_DE.Text = "Diese Auswahl demonstriert die Benutzung von LINQ mit einer Generischen Liste"
                label_US.Text = "This selection demonstrates the use of LINQ with a Generic List"
                Exit Select

            Case 2
                label_DE.Text = "Diese Auswahl demonstriert die Benutzung von LINQ mit einem DataSet"
                label_US.Text = "This selection demonstrates the use of LINQ with a DataSet"
                Exit Select
            Case Else

                Exit Select
        End Select
    End Sub
End Class

'D: Die Klasse "Customer" repraesentiert einen Kunden der n Bestellungen enthaelt 
'US: The "Customer" class represents a customer who has n orders
Class Customer

    'Constructor
    Public Sub New(ByVal customerID As Integer, ByVal companyName As String, ByVal contactName As String, ByVal address As String, ByVal city As String)
        m_CustomerID = customerID
        m_CompanyName = companyName
        m_ContactName = contactName
        m_Address = address
        m_City = city
    End Sub

    Private m_OrderList As New List(Of Order)
    Public Property OrderList() As List(Of Order)
        Get
            Return (m_OrderList)
        End Get
        Set(ByVal value As List(Of Order))
            m_OrderList = value
        End Set
    End Property

    ' D: Die CustomerID soll nicht im Designer zur Auswahl verfuegbar sein
    ' US: The CustomerID should not be available in the designer
    Private m_CustomerID As Integer
    <Browsable(False)> _
    Public Property CustomerID() As Integer
        Get
            Return (m_CustomerID)
        End Get
        Set(ByVal value As Integer)
            m_CustomerID = value
        End Set
    End Property

    Private m_CompanyName As String
    Public Property CompanyName() As String
        Get
            Return (m_CompanyName)
        End Get
        Set(ByVal value As String)
            m_CompanyName = value
        End Set

    End Property

    ' D: Setze Property-Name, welcher im Designer verwendet werden soll
    ' US: Set property name, which should be used in the designer
    Private m_ContactName As String
    <DisplayName("Name")> _
    Public Property ContactName() As String
        Get
            Return (m_ContactName)
        End Get
        Set(ByVal value As String)
            m_ContactName = value
        End Set

    End Property

    Private m_Address As String
    Public Property Address() As String
        Get
            Return (m_Address)
        End Get
        Set(ByVal value As String)
            m_Address = value
        End Set
    End Property

    Private m_City As String
    Public Property City() As String
        Get
            Return (m_City)
        End Get
        Set(ByVal value As String)
            m_City = value
        End Set
    End Property
End Class

'D: Die Klasse "Order" repraesentiert eine einzelne Bestellung eines Kunden
'US: The "Order" class represents a single order of a customer
Class Order

    'Constructor
    Public Sub New(ByVal orderID As Integer, ByVal orderDate As Date, ByVal shipName As String, ByVal shipCountry As String, ByVal price As Double)

        m_OrderId = orderID
        m_OrderDate = orderDate
        m_ShipName = shipName
        m_ShipCountry = shipCountry
        m_Price = price
    End Sub

    Private m_OrderId As Integer
    Public Property OrderID() As Integer
        Get
            Return (m_OrderId)
        End Get
        Set(ByVal value As Integer)
            m_OrderId = value
        End Set
    End Property

    Private m_OrderDate As Date
    Public Property OrderDate() As Date
        Get
            Return (m_OrderDate)
        End Get
        Set(ByVal value As Date)
            m_OrderDate = value
        End Set
    End Property

    Private m_ShipName As String
    Public Property ShipName() As String
        Get
            Return (m_ShipName)
        End Get
        Set(ByVal value As String)
            m_ShipName = value
        End Set
    End Property

    Private m_ShipCountry As String
    Public Property ShipCountry() As String
        Get
            Return (m_ShipCountry)
        End Get
        Set(ByVal value As String)
            m_ShipCountry = value
        End Set
    End Property

    Private m_Price As Double
    Public Property Price() As Double
        Get
            Return (m_Price)
        End Get
        Set(ByVal value As Double)
            m_Price = value
        End Set
    End Property

    <FieldType(LlFieldType.Barcode_EAN128)> _
    Public ReadOnly Property PriceEan() As String
        Get
            Return (m_Price)
        End Get
    End Property

End Class
