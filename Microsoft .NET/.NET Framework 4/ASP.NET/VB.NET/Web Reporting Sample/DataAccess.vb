Imports System.Collections.Generic
Imports System.Linq
Imports combit.ListLabel25.DataProviders
Imports System.Data.OleDb
Imports System.Data
Imports System.Web.Configuration
Imports combit.ListLabel25
Imports System.Runtime.Caching

Namespace DataAccess
    NotInheritable Class CmbtSettings
        Private Sub New()
        End Sub
        Public Shared ReadOnly Property ArtkRecCount() As Integer
            Get
                Return 20
            End Get
        End Property
        Public Shared ReadOnly Property Language() As LlLanguage
            Get
                Return LlLanguage.English
            End Get
        End Property

        Public Shared ReadOnly Property MultiTabRecCount() As Integer
            Get
                Return 5
            End Get
        End Property

        Public Shared ReadOnly Property UnlimitedRecordsList() As List(Of String)
            Get
                Return New List(Of String)() From {
                    "Customer list with sort order.srt",
                    "Crosstab with comparison of previous year.srt",
                    "Conditional formatting and native aggregate functions.srt"
                }
            End Get
        End Property

        Public Shared ReadOnly Property IsEmployeeList() As List(Of String)
            Get
                Return New List(Of String)() From {
                    "Mixed portrait and landscape.srt",
                    "Crosstab.srt"
                }
            End Get
        End Property
    End Class


    Public NotInheritable Class SampleData
        Private Sub New()
        End Sub
        Public Shared Function CreateProviderCollection(reportName As String) As DataProviderCollection
            'DE: Caching der Daten
            'US: Caching Data
            Dim cache As ObjectCache = MemoryCache.[Default]
            Dim cachedCollection As DataProviderCollection = DirectCast(cache.[Get](reportName), DataProviderCollection)
            If cachedCollection IsNot Nothing Then
                Return cachedCollection
            Else
                Dim providerCollection As New DataProviderCollection()
                Dim ds As DataSet
                If DataAccess.CmbtSettings.UnlimitedRecordsList.Contains(reportName) Then
                    ds = DataAccess.NorthWndDataSetHelper.CreateFullDataSet()
                Else
                    ds = DataAccess.NorthWndDataSetHelper.CreateDataSet(DataAccess.CmbtSettings.IsEmployeeList.Contains(reportName))
                    Dim gDs As DataSet = LlDemoDataSources.GantDS()
                    providerCollection.Add(New AdoDataProvider(gDs))
                End If
                providerCollection.Add(New AdoDataProvider(ds))
                Dim cachePolicy As New CacheItemPolicy With {
                    .AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(30.0)
                }
                cache.Add(reportName, providerCollection, cachePolicy)
                Return (providerCollection)
            End If
        End Function
    End Class

    Class LlDemoDataSources
#Region "Gantt DB"
        Public Shared Function GantDS() As DataSet
            Dim ds As New DataSet()

            Dim TableNames As List(Of String)

            'get the tables for gantt
            TableNames = New List(Of String)() From {
                "Pollen",
                "Project",
                "ClimateData",
                "Venue",
                "SalesStages",
                "Sales",
				"Budget",
				"BusinessActivityTime",
				"Keyword"
            }
            Dim conn As New OleDbConnection(WebConfigurationManager.ConnectionStrings("Gantt").ConnectionString)
            Try
                conn.Open()
            Catch ex As Exception

                System.Diagnostics.Debug.WriteLine(ex.Message)
            End Try

            For Each tableName As String In TableNames

                Dim dataAdapter As New OleDbDataAdapter(New OleDbCommand([String].Format("SELECT * FROM {0}", tableName), conn))
                Dim dtData As New DataTable(tableName)
                dataAdapter.Fill(dtData)
                dtData.TableName = tableName
                ds.Tables.Add(dtData)
            Next


            Dim restrictions1 As Object() = New [Object]() {Nothing, Nothing, Nothing, Nothing}
            Dim table1 As DataTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Foreign_Keys, restrictions1)

            'D: Relationen auslesen
            'US: Get relations
            For Each dr As DataRow In table1.Rows
                Dim childTable As String = dr("FK_TABLE_NAME").ToString()
                Dim childCol As String = dr("FK_COLUMN_NAME").ToString()
                ' D:  Eltern = Primary
                'US: Parent = primary
                Dim parentTable As String = dr("PK_TABLE_NAME").ToString()
                Dim parentCol As String = dr("PK_COLUMN_NAME").ToString()
                Dim relationName As String = Convert.ToString(parentTable & Convert.ToString("2")) & childTable

                'D: Beziehung zwischen den Tabellen definieren
                'US: Create the relationships between the tables
                ds.Relations.Add(New DataRelation(relationName, ds.Tables(parentTable).Columns(parentCol), ds.Tables(childTable).Columns(childCol)))
            Next

            conn.Close()


            'D: Datumsangaben modernisieren
            'US: modernize dates
            Try

                Dim yearOffset As Integer = DateTime.Now.Year - 2010 + 15

                Dim tablesWithDates As New Dictionary(Of String, List(Of String)) From {
                    {"Project", New List(Of String)() From {
                    "BeginDate"
                }},
                    {"Pollen", New List(Of String)() From {
                    "PeriodBegin",
                    "PeriodEnd"
                }}
                }

                For Each tableName As String In tablesWithDates.Keys
                    Dim dtOrder As DataTable = ds.Tables(tableName)

                    Dim dateColumns As List(Of [String]) = DirectCast(tablesWithDates(tableName), List(Of String))
                    For Each dateColumn As String In dateColumns
                        dtOrder.[Select]().ToList().ForEach(Function(r) InlineAssignHelper(r(dateColumn), If((Not r.IsNull(dateColumn)), DirectCast(r(dateColumn), DateTime).AddYears(yearOffset), r(dateColumn))))
                    Next
                Next
            Catch ex As Exception
                Throw New ListLabelException(ex.ToString())
            End Try


            Return ds

        End Function
#End Region

#Region "Article /Item DB"
        Public Shared Function GetArticleDataTable(isLocalization As Boolean, Optional isInvoice As Boolean = False) As DataTable
            'get the datasource for the article projects (standalone)
            Dim dt As New DataTable()
            Dim tableName As String = String.Empty
            Dim conn As New OleDbConnection(WebConfigurationManager.ConnectionStrings("Gantt").ConnectionString)
            conn.Open()
            Dim requestedRows As Integer = CmbtSettings.ArtkRecCount
            If isLocalization Then
                tableName = "Item"
            Else
                tableName = If(CmbtSettings.Language = LlLanguage.German, "Artikel", "Item")
            End If


            Dim tableRows As Integer = CountTableRows(conn, tableName)
            'counted rows in table
            Dim cmd As OleDbCommand = Nothing
            Dim reader As OleDbDataReader = Nothing

            'check table is limited or multiplied
            If requestedRows <= tableRows And Not isInvoice Then
                cmd = New OleDbCommand((Convert.ToString("Select TOP " + CmbtSettings.ArtkRecCount.ToString() + " * from   ") & tableName) + " ", conn)
                reader = cmd.ExecuteReader()
                dt.Load(reader)
            Else
                cmd = New OleDbCommand(Convert.ToString("Select * from ") & tableName, conn)
                reader = cmd.ExecuteReader()
                dt.Load(reader)
                'multiple datatable
                MultipleDataTable(dt, requestedRows)
            End If

            If isLocalization Then
                dt.TableName = "Item"
            Else

                dt.TableName = If(CmbtSettings.Language = LlLanguage.German, "Artikel", "Item")
            End If

            Return dt
        End Function
#End Region

#Region "Helper Methods"
        Public Shared Function MultipleDataTable(dt As DataTable, requestedRows As Integer) As DataTable
            'function to multiple an datatable
            Dim _dt As DataTable = dt
            Dim countRows As Integer = dt.Rows.Count
            Dim _requestedRows As Integer = requestedRows - countRows
            Dim counter As Integer = -1
            For i As Integer = 0 To _requestedRows - 1
                counter += 1
                _dt.ImportRow(_dt.Rows(counter))
                If counter > countRows Then
                    counter = 0
                End If
            Next

            Return _dt

        End Function
        Public Shared Function CountTableRows(conn As OleDbConnection, tableName As String) As Integer
            Dim cloneable As ICloneable = DirectCast(conn, ICloneable)
            Dim query As String = Convert.ToString("SELECT COUNT(*) FROM ") & tableName
            Dim count As Integer = 0
            Try
                Using thisConnection As OleDbConnection = DirectCast(cloneable.Clone(), OleDbConnection)
                    Using cmdCount As New OleDbCommand(query, thisConnection)
                        If thisConnection.State <> ConnectionState.Open Then
                            thisConnection.Open()
                        End If
                        count = CInt(cmdCount.ExecuteScalar())
                    End Using
                End Using
            Catch ex As OleDbException
                System.Diagnostics.Debug.WriteLine(ex.Message)
            End Try

            Return count
        End Function
        Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
        End Function
#End Region
    End Class


    Public NotInheritable Class NorthWndDataSetHelper
        Private Sub New()
        End Sub
#Region "Members"
        Private Shared dtCustomers As DataTable
        Private Shared dtOrders As DataTable
        Private Shared dtOrder_details As DataTable
        Private Shared dtEmployees As DataTable
        Private Shared dtShippers As DataTable
        Private Shared IsEmployeeList As Boolean
        Private Shared ds As DataSet
        Private Shared conn As OleDbConnection
        Private Shared requestedRows As Integer
#End Region

#Region "Public Methods"
        'needed for extended sample
        Public Shared Function CreateDataSet(isEmployeeList__1 As Boolean) As DataSet
            'D: DataSet Objekt erstellen
            'US: Create the DataSet object
            ds = New System.Data.DataSet()
            dtCustomers = New DataTable("Customers")
            dtEmployees = New DataTable("Employees")
            dtShippers = New DataTable("Shippers")
            dtOrders = New DataTable("Orders")
            dtOrder_details = New DataTable("Order Details")
            IsEmployeeList = isEmployeeList__1
            Dim query As String
            Dim tableRows As Integer = 0
            'counted rows in table
            requestedRows = CmbtSettings.MultiTabRecCount

            conn = New OleDbConnection(WebConfigurationManager.ConnectionStrings("NWind").ConnectionString)
            Try
                conn.Open()
            Catch ex As Exception

                System.Diagnostics.Debug.WriteLine(ex.Message)
            End Try

            'count rows from customer tabel
            tableRows = LlDemoDataSources.CountTableRows(conn, "Customers")

            Dim restrictions As Object() = New [Object]() {Nothing, Nothing, Nothing, "TABLE"}
            Dim table As DataTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, restrictions)

            'D: Durch alle Tabellen iterieren und in das DataSet aufnehmen
            'US: Iterate all tabels and add them to the DataSet
            For Each dr As DataRow In table.Rows
                Dim tableName As String = dr("Table_Name").ToString()
                Dim dataAdapter As OleDbDataAdapter

                'standardquery for all records
                query = (Convert.ToString("SELECT * FROM [") & tableName) & "]"

                'check table is limited or multiplied
                If requestedRows <= tableRows Then
                    Select Case tableName
                        Case "Customers"
                            query = (Convert.ToString("SELECT TOP " & requestedRows & " * FROM [") & tableName) & "]"
                            Exit Select
                        Case Else

                            query = (Convert.ToString("SELECT * FROM [") & tableName) & "]"
                            Exit Select
                    End Select
                End If
                dataAdapter = New OleDbDataAdapter(New OleDbCommand(query, conn))

                'fill datatables and dataset
                Select Case tableName
                    Case "Customers"
                        dataAdapter.Fill(dtCustomers)
                        dtCustomers.TableName = tableName
                        ds.Tables.Add(dtCustomers)
                        Exit Select

                    Case "Shippers"
                        'fill the shippers (equals shipperid)
                        dataAdapter.Fill(dtShippers)
                        GetFilteredData("Shippers")
                        dtShippers.TableName = "Shippers"
                        ds.Tables.Add(dtShippers)
                        Exit Select

                    Case "Employees"
                        dataAdapter.Fill(dtEmployees)
                        'get all employees
                        If Not IsEmployeeList Then
                            dtEmployees.TableName = "Employees"
                            ds.Tables.Add(dtEmployees)
                        End If
                        Exit Select

                    Case "Orders"
                        dataAdapter.Fill(dtOrders)
                        'limited orders to available customers
                        GetFilteredData(tableName)
                        dtOrders.TableName = tableName
                        ds.Tables.Add(dtOrders)

                        'fill the order details (equals OrderID)
                        GetFilteredData("Order Details")
                        dtOrder_details.TableName = "Order Details"
                        ds.Tables.Add(dtOrder_details)

                        'get filtered employees
                        If IsEmployeeList Then
                            'fill the Employees (equals EmployeeID)
                            GetFilteredData("Employees")
                            dtEmployees.TableName = "Employees"
                            ds.Tables.Add(dtEmployees)
                        End If
                        Exit Select

                    Case "Order Details"
                        'get all orders
                        dataAdapter.Fill(dtOrder_details)
                        Exit Select
                    Case Else

                        dataAdapter.FillSchema(ds, SchemaType.Source, tableName)
                        dataAdapter.Fill(ds, tableName)
                        Exit Select

                End Select
            Next


            Dim restrictions1 As Object() = New [Object]() {Nothing, Nothing, Nothing, Nothing}
            Dim table1 As DataTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Foreign_Keys, restrictions1)

            'D: Relationen auslesen
            'US: Get relations
            For Each dr As DataRow In table1.Rows
                Dim childTable As String = dr("FK_TABLE_NAME").ToString()
                Dim childCol As String = dr("FK_COLUMN_NAME").ToString()
                ' D:  Eltern = Primary
                'US: Parent = primary
                Dim parentTable As String = dr("PK_TABLE_NAME").ToString()
                Dim parentCol As String = dr("PK_COLUMN_NAME").ToString()
                Dim relationName As String = Convert.ToString(parentTable & Convert.ToString("2")) & childTable

                'D: Beziehung zwischen den Tabellen definieren
                'US: Create the relationships between the tables
                ds.Relations.Add(New DataRelation(relationName, ds.Tables(parentTable).Columns(parentCol), ds.Tables(childTable).Columns(childCol)))
            Next

            'D: Verbindung schliessen
            'US: Close connection
            conn.Close()
            ClearTables()

            'D: Datumsangaben modernisieren
            'US: modernize dates
            Try
                Dim yearOffset As Integer = DateTime.Now.Year - 2010 + 15
                Dim dtOrder As DataTable = ds.Tables("Orders")

                Dim dateColumns As List(Of [String]) = New List(Of String)() From {
                    "OrderDate",
                    "RequiredDate",
                    "ShippedDate"
                }
                For Each dateColumn As String In dateColumns
                    dtOrder.[Select]().ToList().ForEach(Function(r) InlineAssignHelper(r(dateColumn), If((Not r.IsNull(dateColumn)), DirectCast(r(dateColumn), DateTime).AddYears(yearOffset), r(dateColumn))))
                Next
            Catch ex As Exception
                Throw New ListLabelException(ex.ToString())
            End Try

            Return (ds)
        End Function


        Public Shared Function CreateFullDataSet() As DataSet
            Dim ds As DataSet = New System.Data.DataSet()

            'D: DataSet Objekt erstellen
            'US: Create the DataSet object
            conn = New OleDbConnection(WebConfigurationManager.ConnectionStrings("NWind").ConnectionString)

            conn.Open()

            Dim restrictions As Object() = New [Object]() {Nothing, Nothing, Nothing, "TABLE"}
            Dim table As DataTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, restrictions)

            'D: Durch alle Tabellen iterieren und in das DataSet aufnehmen
            'US: Iterate all tabels and add them to the DataSet
            For Each dr As DataRow In table.Rows
                Dim tableName As String = dr("Table_Name").ToString()
                Dim dataAdapter As OleDbDataAdapter
                dataAdapter = New OleDbDataAdapter(New OleDbCommand((Convert.ToString("SELECT * FROM [") & tableName) + "]", conn))

                dataAdapter.FillSchema(ds, SchemaType.Source, tableName)

                dataAdapter.Fill(ds, tableName)
            Next


            Dim restrictions1 As Object() = New [Object]() {Nothing, Nothing, Nothing, Nothing}
            Dim table1 As DataTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Foreign_Keys, restrictions1)

            'D: Relationen auslesen
            'US: Get relations
            For Each dr As DataRow In table1.Rows
                Dim childTable As String = dr("FK_TABLE_NAME").ToString()
                Dim childCol As String = dr("FK_COLUMN_NAME").ToString()
                ' D:  Eltern = Primary
                'US: Parent = primary
                Dim parentTable As String = dr("PK_TABLE_NAME").ToString()
                Dim parentCol As String = dr("PK_COLUMN_NAME").ToString()
                Dim relationName As String = Convert.ToString(parentTable & Convert.ToString("2")) & childTable

                'D: Beziehung zwischen den Tabellen definieren
                'US: Create the relationships between the tables
                ds.Relations.Add(New DataRelation(relationName, ds.Tables(parentTable).Columns(parentCol), ds.Tables(childTable).Columns(childCol)))
            Next

            'D: Verbindung schliessen
            'US: Close connection
            conn.Close()

            'D: Datumsangaben modernisieren
            'US: modernize dates
            Try
                Dim yearOffset As Integer = DateTime.Now.Year - 2010 + 15
                Dim dtOrder As DataTable = ds.Tables("Orders")

                Dim dateColumns As List(Of [String]) = New List(Of String)() From {
                    "OrderDate",
                    "RequiredDate",
                    "ShippedDate"
                }
                For Each dateColumn As String In dateColumns
                    dtOrder.[Select]().ToList().ForEach(Function(r) InlineAssignHelper(r(dateColumn), If((Not r.IsNull(dateColumn)), DirectCast(r(dateColumn), DateTime).AddYears(yearOffset), r(dateColumn))))
                Next
            Catch ex As Exception
                Throw New ListLabelException(ex.ToString())
            End Try

            Return (ds)
        End Function
#End Region


#Region "Private Methods"
        Private Shared Sub GetFilteredData(tableName As String)
            'needed function to get only the order and order details 
            'from available customers and orders
            Dim result As IEnumerable(Of DataRow) = Nothing
            Dim dt As New DataTable(tableName)
            Dim adapter As OleDbDataAdapter
            Dim columnValue As String
            Dim query As String

            If tableName = "Orders" Then
                'fill orders based on Employees and Customers
                If IsEmployeeList Then
                    result = (From o In dtOrders.AsEnumerable()
                              Join c In dtCustomers.AsEnumerable()
                                  On o.Field(Of String)("CustomerID") Equals c.Field(Of String)("CustomerID")
                              Join e In dtEmployees.AsEnumerable()
                                  On o.Field(Of Integer)("EmployeeID") Equals e.Field(Of Integer)("EmployeeID")
                              Select o).Take(requestedRows)
                    dtOrders = result.CopyToDataTable()
                Else
                    'get all Orders based on Customers 
                    For Each row As DataRow In dtCustomers.Rows
                        columnValue = row("CustomerID").ToString()
                        query = (Convert.ToString((Convert.ToString((Convert.ToString("Select Top " & requestedRows & " * from [") & tableName) & "] where [") & tableName) & "].CustomerID = " & "'") & columnValue) & "'"
                        adapter = New OleDbDataAdapter(New OleDbCommand(query, conn))
                        adapter.Fill(dt)

                        dtOrders = dt
                    Next

                End If
            ElseIf tableName = "Order Details" Then
                'get order details from orders in order table
                result = From od In dtOrder_details.AsEnumerable()
                         Join o In dtOrders.AsEnumerable()
                             On od.Field(Of Integer)("OrderID") Equals o.Field(Of Integer)("OrderID")
                         Select od
                dtOrder_details = result.CopyToDataTable()
            ElseIf tableName = "Shippers" Then
                For Each row As DataRow In dtOrders.Rows
                    columnValue = row("ShipVia").ToString()
                    query = Convert.ToString((Convert.ToString((Convert.ToString("Select Top " & requestedRows & " * from [") & tableName) & "] where [") & tableName) & "].ShipperID = ") & columnValue
                    adapter = New OleDbDataAdapter(New OleDbCommand(query, conn))
                    adapter.Fill(dt)
                Next

                'delete duplicates
                dtShippers = dt.AsEnumerable().Distinct(DataRowComparer.[Default]).CopyToDataTable()

            ElseIf tableName = "Employees" Then
                'get filtered Employees and delete duplicate
                result = From e In dtEmployees.AsEnumerable()
                         Join o In dtOrders.AsEnumerable() On e.Field(Of Integer)("EmployeeID") Equals o.Field(Of Integer)("EmployeeID")
                         Select e

                'delete duplicates
                dtEmployees = result.AsEnumerable().Distinct(DataRowComparer.[Default]).CopyToDataTable()
            End If

        End Sub
        Private Shared Sub ClearTables()
            dtCustomers = Nothing
            dtOrder_details = Nothing
            dtOrders = Nothing
        End Sub
        Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
        End Function
#End Region

    End Class

#Region "Customer"
    'D: Die Klasse "Customer" repraesentiert einen Kunden der n Bestellungen enthaelt 
    'US: The "Customer" class represents a customer who has n orders
    Class Customer
        'Constructor
        Public Sub New(customerID__1 As Integer, company__2 As String, firstname__3 As String, lastname__4 As String, title__5 As String, salutationLetter__6 As String,
            street__7 As String, city__8 As String)
            CustomerID = customerID__1
            Company = company__2
            Firstname = firstname__3
            Lastname = lastname__4
            Title = title__5
            SalutationLetter = salutationLetter__6
            Street = street__7
            City = city__8
            Item = New List(Of Item)()
        End Sub

        Public Property Item() As List(Of Item)
            Get
                Return m_Item
            End Get
            Set
                m_Item = Value
            End Set
        End Property
        Private m_Item As List(Of Item)

        ' D: Die CustomerID soll nicht im Designer zur Auswahl verfuegbar sein
        ' US: The CustomerID should not be available in the designer
        Public Property CustomerID() As Integer
            Get
                Return m_CustomerID
            End Get
            Set
                m_CustomerID = Value
            End Set
        End Property
        Private m_CustomerID As Integer
        Public Property Company() As String
            Get
                Return m_Company
            End Get
            Set
                m_Company = Value
            End Set
        End Property
        Private m_Company As String

        ' D: Setze Property-Name, welcher im Designer verwendet werden soll
        ' US: Set property name, which should be used in the designer
        Public Property Firstname() As String
            Get
                Return m_Firstname
            End Get
            Set
                m_Firstname = Value
            End Set
        End Property
        Private m_Firstname As String
        Public Property Lastname() As String
            Get
                Return m_Lastname
            End Get
            Set
                m_Lastname = Value
            End Set
        End Property
        Private m_Lastname As String
        Public Property Title() As String
            Get
                Return m_Title
            End Get
            Set
                m_Title = Value
            End Set
        End Property
        Private m_Title As String
        Public Property SalutationLetter() As String
            Get
                Return m_SalutationLetter
            End Get
            Set
                m_SalutationLetter = Value
            End Set
        End Property
        Private m_SalutationLetter As String
        Public Property Street() As String
            Get
                Return m_Street
            End Get
            Set
                m_Street = Value
            End Set
        End Property
        Private m_Street As String
        Public Property City() As String
            Get
                Return m_City
            End Get
            Set
                m_City = Value
            End Set
        End Property
        Private m_City As String
    End Class
#End Region

#Region "Item"
    'D: Die Klasse "Order" repraesentiert eine einzelne Bestellung eines Kunden
    'US: The "Order" class represents a single order of a customer
    Class Item
        'Constructor
        Public Sub New(price As Double, itemNo__1 As String, itemDescription As String, itemDescription2 As String, quantity__2 As Integer)
            UnitPrice = price
            ItemNo = itemNo__1
            Description1 = itemDescription
            Description2 = itemDescription2

            Quantity = quantity__2
        End Sub
        Public Property UnitPrice() As Double
            Get
                Return m_UnitPrice
            End Get
            Set
                m_UnitPrice = Value
            End Set
        End Property
        Private m_UnitPrice As Double
        Public Property ItemNo() As String
            Get
                Return m_ItemNo
            End Get
            Set
                m_ItemNo = Value
            End Set
        End Property
        Private m_ItemNo As String
        Public Property Description1() As String
            Get
                Return m_Description1
            End Get
            Set
                m_Description1 = Value
            End Set
        End Property
        Private m_Description1 As String
        Public Property Description2() As String
            Get
                Return m_Description2
            End Get
            Set
                m_Description2 = Value
            End Set
        End Property
        Private m_Description2 As String
        Public Property Quantity() As Integer
            Get
                Return m_Quantity
            End Get
            Set
                m_Quantity = Value
            End Set
        End Property
        Private m_Quantity As Integer



        <FieldType(LlFieldType.Barcode_EAN128)>
        Public ReadOnly Property ItemNo_EAN128() As String
            Get
                Return ItemNo.ToString()
            End Get
        End Property

    End Class
#End Region

End Namespace
