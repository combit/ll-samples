
Imports combit.ListLabel25
Imports combit.ListLabel25.DataProviders
Imports Microsoft.Win32
Imports System.Collections
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes
Imports System.Xml
Imports System.ComponentModel
Imports WPFDataBinding.DataBind.GenericList


Namespace LLViewer
	''' <summary>
	''' Interaction logic for Window2.xaml
	''' </summary>
	Public Partial Class Window1
		Inherits Window
		Private _cultureInfo As CultureInfo
		Private _databasePath As String
		Private _xmlFile As String
		Private _isNotPrinting As Boolean
		Friend LL As ListLabel

		Public Sub New()
			InitializeComponent()
			AddHandler Loaded, AddressOf Window_Loaded
			AddHandler Closing, AddressOf Window_Closing
			AddHandler Closed, AddressOf Window_Closed
            LL = New ListLabel()
            AddHandler LL.AutoDefineField, AddressOf LL_AutoDefineField
            LL.Core.LlSetOptionString(LlOptionString.DefaultDesignScheme, "COMBITCOLORWHEEL")

            'D: Pfad auf Sample-Hauptverzeichnis setzen, Datenbank- und XML-Pfad auslesen
            'US: Set path to main sample path, read database- and xml-path
            Directory.SetCurrentDirectory(System.AppDomain.CurrentDomain.BaseDirectory & "\..\..\..\..\..\..\Report Files")
            Dim installKey As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\combit\cmbtll")
			If installKey IsNot Nothing Then
                _databasePath = DirectCast(installKey.GetValue("NWINDPath", String.Empty), String)
                _xmlFile = System.IO.Path.Combine(installKey.GetValue("LL" + LlCore.LlGetVersion(LlVersion.Major).ToString + "SampleDir").ToString(), "Microsoft .NET\\Report Files\\sampledata.xml")
                _isNotPrinting = True
			End If

			If String.IsNullOrEmpty(_databasePath) OrElse Not File.Exists(_databasePath) Then
				MessageBox.Show("Unable to find sample database. Make sure List & Label is installed correctly.", "List & Label")
			End If

			If String.IsNullOrEmpty(_xmlFile) OrElse Not File.Exists(_xmlFile) Then
				MessageBox.Show("Unable to find sampledata.xml. Make sure List & Label is installed correctly.", "List & Label")
			End If
		End Sub


		Private Sub Window_Loaded(sender As Object, e As RoutedEventArgs)
			Dim conn As New OleDbConnection(Convert.ToString("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=") & _databasePath)
            conn.Open()

            Dim cmd As New OleDbCommand("SELECT DISTINCT Customers.CompanyName, Orders.CustomerID from Customers, Orders WHERE Orders.CustomerID=Customers.CustomerID AND Orders.OrderID > 11040", conn)
            Dim dr As OleDbDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)

			Dim customers As New List(Of KeyValuePair(Of String, String))()
			cbCustomerNames.ItemsSource = customers
			cbCustomerNames.DisplayMemberPath = "Key"
			cbCustomerNames.SelectedValuePath = "Value"
            While dr.Read()
                customers.Add(New KeyValuePair(Of String, String)(dr(0).ToString(), dr(1).ToString()))
            End While

            'D: PreviewControl mit dem List & Label Objekt verbinden
            'US: Bind PreviewControl to the List & Label object
            LL.PreviewControl = enhancedPreviewControl.PreviewControl
        End Sub

		Private Sub EnableButtons(enableButtons__1 As Boolean)
			_isNotPrinting = enableButtons__1
			print_DataSet.IsEnabled = enableButtons__1
			design_DataSet.IsEnabled = enableButtons__1
		End Sub

		Private Function CreateDataTable() As DataTable
			Dim conn As New OleDbConnection(Convert.ToString("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=") & _databasePath)
			conn.Open()

			Dim cmd As New OleDbCommand("SELECT * FROM Products INNER JOIN Categories ON (Products.CategoryID=Categories.CategoryID)", conn)
			Dim adapter As New OleDbDataAdapter(cmd)
			Dim dt As New DataTable("Products")
			adapter.FillSchema(dt, SchemaType.Source)
			adapter.Fill(dt)
			conn.Close()
			Return dt
		End Function

		Private Function CreateDataView() As DataView
			Return CreateDataTable().DefaultView
		End Function

		Private Function CreateOleDbCommand() As OleDbCommand
			Dim conn As New OleDbConnection(Convert.ToString("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=") & _databasePath)
			conn.Open()
			Dim cmd As New OleDbCommand("SELECT * FROM Products INNER JOIN Categories ON (Products.CategoryID=Categories.CategoryID)", conn)
			conn.Close()
			Return cmd
		End Function

		Private Function CreateDataSet() As DataSet
			Dim ds As DataSet = New System.Data.DataSet()

			'D: DataSet Objekt erstellen
			'US: Create the DataSet object
			Dim conn As New OleDbConnection(Convert.ToString("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=") & _databasePath)

			conn.Open()

			Dim restrictions As Object() = New [Object]() {Nothing, Nothing, Nothing, "TABLE"}
			Dim table As DataTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, restrictions)

			'D: Durch alle Tabellen iterieren und in das DataSet aufnehmen
			'US: Iterate all tabels and add them to the DataSet
			For Each dr As DataRow In table.Rows
				Dim tableName As String = dr("Table_Name").ToString()
				Dim dataAdapter As OleDbDataAdapter

				'D: Die "Orders" und "Order Details" Tabelle einschränken.
				'US: Limit the "Order" an "Order Details" table. 
				If tableName = "Orders" OrElse tableName = "Order Details" Then
					dataAdapter = New OleDbDataAdapter(New OleDbCommand((Convert.ToString("SELECT * FROM [") & tableName) + "] WHERE OrderID > 11040", conn))
				Else
					dataAdapter = New OleDbDataAdapter(New OleDbCommand((Convert.ToString("SELECT * FROM [") & tableName) + "]", conn))
				End If

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

			Return (ds)
		End Function

		Private Function CreateDataSetGantt() As DataSet
			Dim ds As New DataSet()
			Dim dbPath As String = System.IO.Path.GetDirectoryName(_databasePath)

			Dim conn As New OleDbConnection((Convert.ToString("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=") & dbPath) + "\gantt.mdb")
			conn.Open()

			Dim restrictions As Object() = New [Object]() {Nothing, Nothing, Nothing, "TABLE"}
			Dim table As DataTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, restrictions)

			'D: Durch alle Tabellen iterieren und in das DataSet aufnehmen
			'US: Iterate all tables and add them to the DataSet
			For Each dr As DataRow In table.Rows
				Dim tableName As String = dr("Table_Name").ToString()
				Dim dataAdapter As New OleDbDataAdapter(New OleDbCommand((Convert.ToString("SELECT * FROM [") & tableName) + "]", conn))
				dataAdapter.FillSchema(ds, SchemaType.Source, tableName)
				dataAdapter.Fill(ds, tableName)
			Next

			'D: Verbindung schliessen
			'US: Close connection
			conn.Close()

			Return ds
		End Function

		Private Sub SetFileExtensions()
			_cultureInfo = CultureInfo.CurrentCulture
			If _cultureInfo.TwoLetterISOLanguageName = "de" Then
				LL.FileExtensions.SetFileExtension(LlProject.List, LlFileType.Project, "lsr")
				LL.FileExtensions.SetFileExtension(LlProject.List, LlFileType.PrinterSettings, "llp")
				LL.FileExtensions.SetFileExtension(LlProject.List, LlFileType.Sketch, "llv")

				'D: Den Standard-Projektnamen setzen
				'US: set the default project name
				LL.AutoProjectFile = "Unterberichte und Relationen.lsr"
			Else
				LL.FileExtensions.SetFileExtension(LlProject.List, LlFileType.Project, "srt")
				LL.FileExtensions.SetFileExtension(LlProject.List, LlFileType.PrinterSettings, "srp")
				LL.FileExtensions.SetFileExtension(LlProject.List, LlFileType.Sketch, "srv")

				'D: Den Standard-Projektnamen setzen
				'US: set the default project name
				LL.AutoProjectFile = "Sub reports and relations.srt"
			End If

		End Sub

		Private Sub ResetFileExtensions()
			'D:Dateiendungen wieder zuruecksetzen
			'US: set the file extension back
			If _isNotPrinting Then
				LL.FileExtensions.SetFileExtension(LlProject.List, LlFileType.Project, "lst")
				LL.FileExtensions.SetFileExtension(LlProject.List, LlFileType.PrinterSettings, "lsp")
				LL.FileExtensions.SetFileExtension(LlProject.List, LlFileType.Sketch, "lsv")
			End If
		End Sub

		Private Function CreateProviderCollection(useDataViewManager As Boolean) As DataProviderCollection
			Dim ds As DataSet = CreateDataSet()
			Dim dataSetGantt As DataSet = CreateDataSetGantt()
            Dim provider As New CsvDataProvider(System.AppDomain.CurrentDomain.BaseDirectory & "\..\..\..\..\..\..\Report Files\Sales.csv", True)

            'D:Daten je nach Auswahl in einer Datenquelle kombinieren
            'US:combine data to one datasource
            Dim providerCollection As New DataProviderCollection()
			providerCollection.Add(provider)

			If Not useDataViewManager Then
				providerCollection.Add(New AdoDataProvider(ds))
				providerCollection.Add(New AdoDataProvider(dataSetGantt))
			Else
				Dim dvm As New DataViewManager(ds)
				Dim dataViewManagerGantt As New DataViewManager(dataSetGantt)

				'D: Filter
				'US: Filter
				If cbCustomerNames.Text <> String.Empty Then
					Dim selectedItem As Object = cbCustomerNames.SelectedItem
					dvm.DataViewSettings("Customers").RowFilter = "CustomerID='" + DirectCast(selectedItem, KeyValuePair(Of String, String)).Value + "'"
				End If
				providerCollection.Add(New AdoDataProvider(dvm))
				providerCollection.Add(New AdoDataProvider(dataViewManagerGantt))
			End If

			Return (providerCollection)
		End Function

        Private Sub Design_DataSet_Click(sender As Object, e As RoutedEventArgs)
            Dim providerCollection As DataProviderCollection = CreateProviderCollection(False)

            Try
                'D:Dateiendung je nach Sprach setzen
                'US:set the file extension for used CultureInfo
                SetFileExtensions()

                'D: An die provideColletion binden
                'US: now bind to the providerCollection
                LL.DataMember = String.Empty
                LL.DataSource = providerCollection

                'D: Dateiauswahldialog anzeigen und den Benutzer das Erstellen von neuen Listen erlauben
                'US: choose a list project, allow the user to create new ones also
                LL.AutoProjectType = LlProject.List Or LlProject.FileAlsoNew

                'D: Designer aufrufen
                'US: call the designer

                LL.Design()
            Catch generatedExceptionName As LL_User_Aborted_Exception
            Catch LlException As ListLabelException
                'D: Exception abfangen
                'US: Catch Exceptions
                MessageBox.Show("Information: " + LlException.Message + vbLf & vbLf & "This information was generated by a List & Label custom exception.", "Information", MessageBoxButton.OK, MessageBoxImage.Information)
            Finally
                'D:Dateiendungen wieder zuruecksetzen
                'US: set the file extension back
                ResetFileExtensions()
            End Try
        End Sub

        Private Sub Print_DataSet_Click(sender As Object, e As RoutedEventArgs)
            'D: Schaltflächen für Druck und Design deaktivieren
            'US: disable the buttons for print and design
            EnableButtons(False)

            Dim providerCollection As DataProviderCollection = CreateProviderCollection(False)
            Try
                'D:Dateiendung je nach Sprach setzen
                'US:set the file extension for used CultureInfo
                SetFileExtensions()

                'D: An die provideColletion binden
                'US: now bind to the providerCollection
                LL.DataMember = String.Empty
                LL.DataSource = providerCollection

                'D: Printmode auf PreviewControl stellen
                'US: set print mode to previewControl
                LL.AutoDestination = LlPrintMode.PreviewControl

                'D: Unterdrücken des Druckdialogs
                'US: suppress print options dialog
                LL.AutoShowPrintOptions = False

                'D: Drucken
                'US: print
                LL.Print()

                _isNotPrinting = True
            Catch generatedExceptionName As LL_User_Aborted_Exception
            Catch LlException As ListLabelException
                'D: Exception abfangen
                'US: Catch Exceptions
                MessageBox.Show("Information: " + LlException.Message + vbLf & vbLf & "This information was generated by a List & Label custom exception.", "Information", MessageBoxButton.OK, MessageBoxImage.Information)
            Finally
                'D:Dateiendungen wieder zuruecksetzen
                'US: set the file extension back
                ResetFileExtensions()

                'D: Fortschrittsanzeige ausblenden
                'US: hide progressbar
                progressBar1.Value = 0
                progressBar1.Visibility = Visibility.Hidden

                'D: Schaltflächen für Druck und Design aktivieren
                'US: enable the buttons for print and design
                EnableButtons(True)
            End Try
        End Sub

        Private Sub Design_XML_Click(sender As Object, e As RoutedEventArgs)
            Dim xmlDocument As New XmlDocument()
            If xmlDocument IsNot Nothing Then
                Try
                    'D: Lade die XML-Datei
                    'US: load the xml-file
                    xmlDocument.Load(_xmlFile)

                    'D: Erstelle ein XmlDataProvider Objekt
                    'US: create a XmlDataProvider object
                    Dim provider As New combit.ListLabel25.DataProviders.XmlDataProvider(xmlDocument)

                    'D: An das XmlDataProvider Objekt binden
                    'US: now bind to the XmlDataProvider
                    LL.SetDataBinding(provider, String.Empty)

                    'D: Den Standard-Projektnamen setzen
                    'US: set the default project name
                    LL.AutoProjectFile = "InvoiceList.lst"

                    'D: Dateiauswahldialog anzeigen und den Benutzer das Erstellen von neuen Listen erlauben
                    'US: choose a list project, allow the user to create new ones also
                    LL.AutoProjectType = LlProject.List Or LlProject.FileAlsoNew

                    'D: Designer aufrufen
                    'US: call the designer
                    LL.Design()
                Catch generatedExceptionName As LL_User_Aborted_Exception
                Catch LlException As ListLabelException
                    'D: Exception abfangen
                    'US: catch Exceptions
                    MessageBox.Show("Information: " + LlException.Message + vbLf & vbLf & "This information was generated by a List & Label custom exception.", "Information", MessageBoxButton.OK, MessageBoxImage.Information)
                Catch ecx As Exception
                    'D: Exception abfangen
                    'US: catch general Exceptions
                    MessageBox.Show("Information: " + ecx.Message, "Information", MessageBoxButton.OK, MessageBoxImage.Information)
                End Try
            End If
        End Sub

        Private Sub Print_XML_Click(sender As Object, e As RoutedEventArgs)
            'D: Schaltflächen für Druck und Design deaktivieren
            'US: disable the buttons for print and design
            EnableButtons(False)

            Dim xmlDocument As New XmlDocument()
            If xmlDocument IsNot Nothing Then
                Try
                    'D: Lade die XML-Datei
                    'US: load the xml-file
                    xmlDocument.Load(_xmlFile)

                    'D: Erstelle ein XmlDataProvider Objekt
                    'US: create a XmlDataProvider object
                    Dim provider As New combit.ListLabel25.DataProviders.XmlDataProvider(xmlDocument)

                    'D: An das XmlDataProvider Objekt binden
                    'US: now bind to the XmlDataProvider
                    LL.SetDataBinding(provider, String.Empty)

                    'D: Den Standard-Projektnamen setzen
                    'US: set the default project name
                    LL.AutoProjectFile = "InvoiceList.lst"

                    'D: Printmode auf Previewcontrol setzen
                    'US: set print mode to previewControl
                    LL.AutoDestination = LlPrintMode.PreviewControl

                    'D: Unterdrücken des Druckerdialogs
                    'US: suppress print options dialog
                    LL.AutoShowPrintOptions = False

                    'D: Drucken
                    'US: print
                    LL.Print()
                    _isNotPrinting = True
                Catch generatedExceptionName As LL_User_Aborted_Exception
                Catch LlException As ListLabelException
                    'D: Exception abfangen
                    'US: catch Exceptions
                    MessageBox.Show("Information: " + LlException.Message + vbLf & vbLf & "This information was generated by a List & Label custom exception.", "Information", MessageBoxButton.OK, MessageBoxImage.Information)
                Catch ecx As Exception
                    'D: Exception abfangen
                    'US: catch general Exceptions
                    MessageBox.Show("Information: " + ecx.Message, "Information", MessageBoxButton.OK, MessageBoxImage.Information)
                Finally
                    'D: Fortschrittsanzeige ausblenden
                    'US: hide progressbar
                    progressBar1.Value = 0
                    progressBar1.Visibility = Visibility.Hidden

                    'D: Schaltflächen für Druck und Design aktivieren
                    'US: enable the buttons for print and design
                    EnableButtons(True)
                End Try
            End If
        End Sub

        Private Sub Design_Reader_Click(sender As Object, e As RoutedEventArgs)
            'D: Erstelle eine SQL Abfrage
            'US: Create a SQL statement 
            Dim cmd As OleDbCommand = CreateOleDbCommand()

            Dim provider As New DbCommandSetDataProvider()
            provider.AddCommand(cmd, "Products")

            Try
                'D: An das DbCommandSetDataProvider Objekt binden
                'US: now bind to the DbCommandSetDataProvider
                LL.SetDataBinding(provider, "Products")

                'D: Den Standard-Projektnamen setzen
                'US: set the default project name
                LL.AutoProjectFile = "simple.lst"

                'D: Dateiauswahldialog anzeigen und den Benutzer das Erstellen von neuen Listen erlauben
                'US: choose a list project, allow the user to create new ones also
                LL.AutoProjectType = LlProject.List Or LlProject.FileAlsoNew

                'D: Designer aufrufen
                'US: call the designer
                LL.Design()
            Catch generatedExceptionName As LL_User_Aborted_Exception
            Catch LlException As ListLabelException
                'D: Exception abfangen
                'US: Catch Exceptions
                MessageBox.Show("Information: " + LlException.Message + vbLf & vbLf & "This information was generated by a List & Label custom exception.", "Information", MessageBoxButton.OK, MessageBoxImage.Information)
            End Try
        End Sub

        Private Sub Print_Reader_Click(sender As Object, e As RoutedEventArgs)
            'D: Schaltflächen für Druck und Design deaktivieren
            'US: disable the buttons for print and design
            EnableButtons(False)

            Dim cmd As OleDbCommand = CreateOleDbCommand()
            Dim provider As New DbCommandSetDataProvider()
            provider.AddCommand(cmd, "Products")

            Try
                'D: An das DataReader Objekt binden
                'US: now bind to the DataReader
                LL.SetDataBinding(provider, "Products")

                'D: Den Standard-Projektnamen setzen
                'US: set the default project name
                LL.AutoProjectFile = "simple.lst"

                'D: Auswählen eines Listenprojekts
                'US: choose a list project
                LL.AutoProjectType = LlProject.List

                'D: Printmode auf PreviewControl stellen
                'US: set print mode to previewControl
                LL.AutoDestination = LlPrintMode.PreviewControl

                'D: Unterdrücken des Druckerdialogs
                'US: suppress print options dialog
                LL.AutoShowPrintOptions = False

                'D: Drucken
                'US: print
                LL.Print()
                _isNotPrinting = True
            Catch generatedExceptionName As LL_User_Aborted_Exception
            Catch LlException As ListLabelException
                'D: Exception abfangen
                'US: Catch Exceptions
                MessageBox.Show("Information: " + LlException.Message + vbLf & vbLf & "This information was generated by a List & Label custom exception.", "Information", MessageBoxButton.OK, MessageBoxImage.Information)
            Finally
                'D: Fortschrittsanzeige ausblenden
                'US: hide progressbar
                progressBar1.Value = 0
                progressBar1.Visibility = Visibility.Hidden

                'D: Schaltflächen für Druck und Design aktivieren
                'US: enable the buttons for print and design
                EnableButtons(True)
            End Try
        End Sub

        Private Sub Design_DataView_Click(sender As Object, e As RoutedEventArgs)
            Dim dv As DataView = CreateDataView()

            Try
                'D: An das DataView Objekt binden
                'US: now bind to the DataView
                LL.SetDataBinding(dv, "Products")

                'D: Den Standard-Projektnamen setzen
                'US: set the default project name
                LL.AutoProjectFile = "simple.lst"

                'D: Dateiauswahldialog anzeigen und den Benutzer das Erstellen von neuen Listen erlauben
                'US: choose a list project, allow the user to create new ones also
                LL.AutoProjectType = LlProject.List Or LlProject.FileAlsoNew

                'D: Designer aufrufen
                'US: call the designer
                LL.Design()
            Catch generatedExceptionName As LL_User_Aborted_Exception
            Catch LlException As ListLabelException
                'D: Exception abfangen
                'US: Catch Exceptions

                MessageBox.Show("Information: " + LlException.Message + vbLf & vbLf & "This information was generated by a List & Label custom exception.", "Information", MessageBoxButton.OK, MessageBoxImage.Information)
            End Try
        End Sub

        Private Sub Print_DataView_Click(sender As Object, e As RoutedEventArgs)
            'D: Schaltflächen für Druck und Design deaktivieren
            'US: disable the buttons for print and design
            EnableButtons(False)

            Dim dv As DataView = CreateDataView()

            Try
                'D: An das DataView Objekt binden
                'US: now bind to the DataView
                LL.SetDataBinding(dv, "Products")

                'D: Den Standard-Projektnamen setzen
                'US: set the default project name
                LL.AutoProjectFile = "simple.lst"

                'D: Auswählen eines Listenprojekts
                'US: choose a list project
                LL.AutoProjectType = LlProject.List

                'D: Printmode auf PreviewControl stellen
                'US: set print mode to preview
                LL.AutoDestination = LlPrintMode.PreviewControl

                'D: Unterdrücken des Druckerdialogs
                'US: suppress print options dialog
                LL.AutoShowPrintOptions = False

                'D: Drucken
                'US: print
                LL.Print()
                _isNotPrinting = True
            Catch generatedExceptionName As LL_User_Aborted_Exception
            Catch LlException As ListLabelException
                'D: Exception abfangen
                'US: Catch Exceptions
                MessageBox.Show("Information: " + LlException.Message + vbLf & vbLf & "This information was generated by a List & Label custom exception.", "Information", MessageBoxButton.OK, MessageBoxImage.Information)
            Finally
                'D: Fortschrittsanzeige ausblenden
                'US: hide progressbar
                progressBar1.Value = 0
                progressBar1.Visibility = Visibility.Hidden

                'D: Schaltflächen für Druck und Design aktivieren
                'US: enable the buttons for print and design
                EnableButtons(True)
            End Try
        End Sub

        Private Sub Design_DataTable_Click(sender As Object, e As RoutedEventArgs)
            Dim dt As DataTable = CreateDataTable()

            Try
                'D: An das DataTable Objekt binden
                'US: now bind to the DataTable
                LL.SetDataBinding(dt, "Products")

                'D: Den Standard-Projektnamen setzen
                'US: set the default project name
                LL.AutoProjectFile = "simple.lst"

                'D: Dateiauswahldialog anzeigen und den Benutzer das Erstellen von neuen Listen erlauben
                'US: choose a list project, allow the user to create new ones also
                LL.AutoProjectType = LlProject.List Or LlProject.FileAlsoNew

                'D: Designer aufrufen
                'US: call the designer
                LL.Design()
            Catch generatedExceptionName As LL_User_Aborted_Exception
            Catch LlException As ListLabelException
                'D: Exception abfangen
                'US: Catch Exceptions
                MessageBox.Show("Information: " + LlException.Message + vbLf & vbLf & "This information was generated by a List & Label custom exception.", "Information", MessageBoxButton.OK, MessageBoxImage.Information)
            End Try
        End Sub

        Private Sub Print_DataTable_Click(sender As Object, e As RoutedEventArgs)
            'D: Schaltflächen für Druck und Design deaktivieren
            'US: disable the buttons for print and design
            EnableButtons(False)

            Dim dt As DataTable = CreateDataTable()

            Try
                'D: An das DataTable Objekt binden
                'US: now bind to the DataTable
                LL.SetDataBinding(dt, "Products")

                'D: Den Standard-Projektnamen setzen
                'US: set the default project name
                LL.AutoProjectFile = "simple.lst"

                'D: Auswählen eines Listenprojekts
                'US: choose a list project
                LL.AutoProjectType = LlProject.List

                'D: Printmode auf PreviewControl stellen
                'US: set print mode to preview
                LL.AutoDestination = LlPrintMode.PreviewControl

                'D: Unterdrücken des Druckerdialogs
                'US: suppress print options dialog
                LL.AutoShowPrintOptions = False

                'D: Drucken
                'US: print
                LL.Print()
                _isNotPrinting = True
            Catch generatedExceptionName As LL_User_Aborted_Exception
            Catch LlException As ListLabelException
                'D: Exception abfangen
                'US: Catch Exceptions
                MessageBox.Show("Information: " + LlException.Message + vbLf & vbLf & "This information was generated by a List & Label custom exception.", "Information", MessageBoxButton.OK, MessageBoxImage.Information)
            Finally
                'D: Fortschrittsanzeige ausblenden
                'US: hide progressbar
                progressBar1.Value = 0
                progressBar1.Visibility = Visibility.Hidden

                'D: Schaltflächen für Druck und Design aktivieren
                'US: enable the buttons for print and design
                EnableButtons(True)
            End Try
        End Sub

        Private Sub Print_DataViewManager_Click(sender As Object, e As RoutedEventArgs)
            'D: Schaltflächen für Druck und Design deaktivieren
            'US: disable the buttons for print and design
            EnableButtons(False)
            Dim providerCollection As DataProviderCollection = CreateProviderCollection(True)

            Try
                'D:Dateiendung je nach Sprach setzen
                'US:set the file extension for used CultureInfo
                SetFileExtensions()

                'D: An die provideColletion binden
                'US: now bind to the providerCollection
                LL.DataMember = String.Empty
                LL.DataSource = providerCollection

                'D: Printmode auf PreviewControl stellen
                'US: set print mode to preview
                LL.AutoDestination = LlPrintMode.PreviewControl

                'D: Unterdrücken des Druckerdialogs
                'US: suppress print options dialog
                LL.AutoShowPrintOptions = False

                'D: Drucken
                'US: print
                LL.Print()
                _isNotPrinting = True
            Catch generatedExceptionName As LL_User_Aborted_Exception
            Catch LlException As ListLabelException
                'D: Exception abfangen
                'US: Catch Exceptions
                MessageBox.Show("Information: " + LlException.Message + vbLf & vbLf & "This information was generated by a List & Label custom exception.", "Information", MessageBoxButton.OK, MessageBoxImage.Information)
            Finally
                'D:Dateiendungen wieder zuruecksetzen
                'US: set the file extension back
                ResetFileExtensions()

                'D: Fortschrittsanzeige ausblenden
                'US: hide progressbar
                progressBar1.Value = 0
                progressBar1.Visibility = Visibility.Hidden

                'D: Schaltflächen für Druck und Design aktivieren
                'US: enable the buttons for print and design
                EnableButtons(True)
            End Try
        End Sub

        Private Sub Design_DataViewManager_Click(sender As Object, e As RoutedEventArgs)

            Dim providerCollection As DataProviderCollection = CreateProviderCollection(True)
            Try
                'D:Dateiendung je nach Sprach setzen
                'US:set the file extension for used CultureInfo
                SetFileExtensions()

                'D: An die provideColletion binden
                'US: now bind to the providerCollection
                LL.DataMember = String.Empty
                LL.DataSource = providerCollection

                'D: Dateiauswahldialog anzeigen und den Benutzer das Erstellen von neuen Listen erlauben
                'US: choose a list project, allow the user to create new ones also
                LL.AutoProjectType = LlProject.List Or LlProject.FileAlsoNew

                'D: Designer aufrufen
                'US: call the designer
                LL.Design()
            Catch generatedExceptionName As LL_User_Aborted_Exception
            Catch LlException As ListLabelException
                'D: Exception abfangen
                'US: Catch Exceptions
                MessageBox.Show("Information: " + LlException.Message + vbLf & vbLf & "This information was generated by a List & Label custom exception.", "Information", MessageBoxButton.OK, MessageBoxImage.Information)
            Finally
                'D:Dateiendungen wieder zuruecksetzen
                'US: set the file extension back
                ResetFileExtensions()
            End Try
        End Sub

        Private Sub LL_NotifyProgress(sender As Object, e As NotifyProgressEventArgs)
			If Dispatcher.CheckAccess() Then
                'Dispatcher.BeginInvoke(New System.Windows.Forms.MethodInvoker(Sub() LL_NotifyProgress(sender, e)))
			Else
				If e.Percentage = 100 Then
					progressBar1.Visibility = Visibility.Hidden
					Return
				End If

				progressBar1.Visibility = Visibility.Visible
				progressBar1.Value = e.Percentage
			End If
		End Sub

        Private Sub Design_GenericList_Click(sender As Object, e As RoutedEventArgs)
            'D: Erstelle eine generische Liste
            'US: create a generic list
            Dim customerList As List(Of Customer) = GenericList.GetGenericList()

            'D: An die generische Liste binden
            'US: Now bind to the generic list
            LL.SetDataBinding(customerList, String.Empty)

            'D: Den Standard-Projektnamen setzen
            'US: Set the default project name
            LL.AutoProjectFile = "genericlist.lst"

            'D: Dateiauswahldialog anzeigen und den Benutzer das Erstellen von neuen Listen erlauben
            'US: Choose a list project, allow the user to create new ones also
            LL.AutoProjectType = LlProject.List Or LlProject.FileAlsoNew

            Try
                'D: Designer aufrufen
                'US: Call the designer
                LL.Design()
            Catch generatedExceptionName As LL_User_Aborted_Exception
            Catch LlException As ListLabelException
                ' Catch Exceptions
                MessageBox.Show("Information: " + LlException.Message + vbLf & vbLf & "This information was generated by a List & Label custom exception.", "Information", MessageBoxButton.OK, MessageBoxImage.Information)
            End Try
        End Sub

        Private Sub Print_GenericList_Click(sender As Object, e As RoutedEventArgs)
            'D: Schaltflächen für Druck und Design deaktivieren
            'US: disable the buttons for print and design
            EnableButtons(False)

            'D: Erstelle eine generische Liste
            'US: create a generic list
            Dim customerList As List(Of Customer) = GenericList.GetGenericList()

            Try
                'D: An die generische Liste binden
                'US: Now bind to the generic list
                LL.SetDataBinding(customerList, String.Empty)

                'D: Den Standard-Projektnamen setzen
                'US: Set the default project name
                LL.AutoProjectFile = "genericlist.lst"

                'D: Printmode auf PreviewControl stellen
                'US: set print mode to preview
                LL.AutoDestination = LlPrintMode.PreviewControl

                'D: Unterdrücken des Druckerdialogs
                'US: suppress print options dialog
                LL.AutoShowPrintOptions = False

                'D: Dateiauswahldialog anzeigen und den Benutzer das Erstellen von neuen Listen erlauben
                'US: Choose a list project, allow the user to create new ones also
                LL.AutoProjectType = LlProject.List Or LlProject.FileAlsoNew

                'D: Drucken
                'US: Print
                LL.Print()
                _isNotPrinting = True
            Catch generatedExceptionName As LL_User_Aborted_Exception
            Catch LlException As ListLabelException
                'D: Exception abfangen
                'US: Catch Exceptions
                MessageBox.Show("Information: " + LlException.Message + vbLf & vbLf & "This information was generated by a List & Label custom exception.", "Information", MessageBoxButton.OK, MessageBoxImage.Information)
            Finally
                'D: Schaltflächen für Druck und Design aktivieren
                'US: enable the buttons for print and design
                EnableButtons(True)
            End Try
        End Sub

        Private Sub Design_SQL_Click(sender As Object, e As RoutedEventArgs)
            Try
                'D: Erstelle einen SqlConnectionDataProvider
                'US: create a SqlConnectionDataProvider
                Dim conn As New SqlConnection(tbConnectionString.Text)
                Dim prov As New SqlConnectionDataProvider(conn)

                'D: An das DataViewManager Objekt binden
                'US: now bind to the DataViewManager
                LL.SetDataBinding(prov, String.Empty)

                'D: Den Standard-Projektnamen setzen
                'US: set the default project name
                LL.AutoProjectFile = String.Empty

                'D: Printmode auf PreviewControl stellen
                'US: set print mode to preview
                LL.AutoDestination = LlPrintMode.PreviewControl

                'D: Unterdrücken des Druckerdialogs
                'US: suppress print options dialog
                LL.AutoShowPrintOptions = False

                'D: Dateiauswahldialog anzeigen und den Benutzer das Erstellen von neuen Listen erlauben
                'US: choose a list project, allow the user to create new ones also
                LL.AutoProjectType = LlProject.List Or LlProject.FileAlsoNew

                'D: Designer aufrufen
                'US: call the designer
                LL.Design()
            Catch generatedExceptionName As LL_User_Aborted_Exception
            Catch LlException As ListLabelException
                'D: Exception abfangen
                'US: Catch Exceptions
                MessageBox.Show("Information: " + LlException.Message + vbLf & vbLf & "This information was generated by a List & Label custom exception.", "Information", MessageBoxButton.OK, MessageBoxImage.Information)
            Catch sqlException As SqlException
                'D: Exception abfangen
                'US: Catch Exceptions
                MessageBox.Show("Information: " + sqlException.Message, "Information", MessageBoxButton.OK, MessageBoxImage.Information)
            Catch invalidOperationException As InvalidOperationException
                'D: Exception abfangen
                'US: Catch Exceptions
                MessageBox.Show("Information: " + invalidOperationException.Message, "Information", MessageBoxButton.OK, MessageBoxImage.Information)
            End Try
        End Sub

        Private Sub Print_SQL_Click(sender As Object, e As RoutedEventArgs)
            'D: Schaltflächen für Druck und Design deaktivieren
            'US: disable the buttons for print and design
            EnableButtons(False)

            Try
                'D: Erstelle einen SqlConnectionDataProvider
                'US: create a SqlConnectionDataProvider
                Dim conn As New SqlConnection(tbConnectionString.Text)
                Dim prov As New SqlConnectionDataProvider(conn)

                'D: An das DataViewManager Objekt binden
                'US: now bind to the DataViewManager
                LL.SetDataBinding(prov, String.Empty)

                'D: Den Standard-Projektnamen setzen
                'US: set the default project name
                LL.AutoProjectFile = String.Empty

                'D: Dateiauswahldialog anzeigen und den Benutzer das Erstellen von neuen Listen erlauben
                'US: choose a list project, allow the user to create new ones also
                LL.AutoProjectType = LlProject.List Or LlProject.FileAlsoNew

                'D: Designer aufrufen
                'US: call the designer
                LL.Print()
                _isNotPrinting = True
            Catch generatedExceptionName As LL_User_Aborted_Exception
            Catch LlException As ListLabelException
                'D: Exception abfangen
                'US: Catch Exceptions
                MessageBox.Show("Information: " + LlException.Message + vbLf & vbLf & "This information was generated by a List & Label custom exception.", "Information", MessageBoxButton.OK, MessageBoxImage.Information)
            Catch sqlException As SqlException
                'D: Exception abfangen
                'US: Catch Exceptions
                MessageBox.Show("Information: " + sqlException.Message, "Information", MessageBoxButton.OK, MessageBoxImage.Information)
            Catch invalidOperationException As InvalidOperationException
                'D: Exception abfangen
                'US: Catch Exceptions
                MessageBox.Show("Information: " + invalidOperationException.Message, "Information", MessageBoxButton.OK, MessageBoxImage.Information)
            Finally
                'D: Schaltflächen für Druck und Design aktivieren
                'US: enable the buttons for print and design
                EnableButtons(True)
            End Try
        End Sub

        Private Sub Design_OData_Click(sender As Object, e As RoutedEventArgs)
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait
            'Cursor.Current = Cursors.WaitCursor;
            'D: Erstelle ein ODataDataProvider Objekt
            'US: create a ODataDataProvider object
            Dim provider As New ODataDataProvider(odataUrlTb.Text, False)

            Try
                'D: An das ODataDataProvider Objekt binden
                'US: now bind to the ODataDataProvider
                LL.SetDataBinding(provider, [String].Empty)

                'D: Den Standard-Projektnamen setzen
                'US: set the default project name
                LL.AutoProjectFile = "OData sub reports and relations.lst"

                'D: Dateiauswahldialog anzeigen und den Benutzer das Erstellen von neuen Listen erlauben
                'US: choose a list project, allow the user to create new ones also
                LL.AutoProjectType = LlProject.List Or LlProject.FileAlsoNew

                'D: Designer aufrufen
                'US: call the designer
                LL.Design()
            Catch generatedExceptionName As LL_User_Aborted_Exception
            Catch LlException As ListLabelException
                'D: Exception abfangen
                'US: Catch Exceptions
                MessageBox.Show("Information: " + LlException.Message + vbLf & vbLf & "This information was generated by a List & Label custom exception.", "Information", MessageBoxButton.OK, MessageBoxImage.Information)
            Finally
                'Cursor.Current = Cursors.Default;
                Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow
            End Try
        End Sub

        Private Sub Print_OData_Click(sender As Object, e As RoutedEventArgs)
            'D: Schaltflächen für Druck und Design deaktivieren
            'US: disable the buttons for print and design
            EnableButtons(False)

            'D: Erstelle ein ODataDataProvider Objekt
            'US: create a ODataDataProvider object
            Dim provider As New ODataDataProvider(odataUrlTb.Text, False)

            Try
                'D: An das ODataDataProvider Objekt binden
                'US: now bind to the ODataDataProvider
                LL.SetDataBinding(provider, [String].Empty)

                'D: Den Standard-Projektnamen setzen
                'US: set the default project name
                LL.AutoProjectFile = "OData sub reports and relations.lst"

                'D: Printmode auf Previewcontrol setzen
                'US: set print mode to previewControl
                LL.AutoDestination = LlPrintMode.PreviewControl

                'D: Unterdrücken des Druckerdialogs
                'US: suppress print options dialog
                LL.AutoShowPrintOptions = False

                'D: Drucken
                'US: print
                LL.Print()
                _isNotPrinting = True
            Catch generatedExceptionName As LL_User_Aborted_Exception
            Catch LlException As ListLabelException
                'D: Exception abfangen
                'US: Catch Exceptions
                MessageBox.Show("Information: " + LlException.Message + vbLf & vbLf & "This information was generated by a List & Label custom exception.", "Information", MessageBoxButton.OK, MessageBoxImage.Information)
            Finally
                'D: Fortschrittsanzeige ausblenden
                'US: hide progressbar
                progressBar1.Value = 0
                progressBar1.Visibility = Visibility.Hidden

                'D: Schaltflächen für Druck und Design aktivieren
                'US: enable the buttons for print and design
                EnableButtons(True)
            End Try
        End Sub

        Private Sub Design_REST_Click(sender As Object, e As RoutedEventArgs)
            Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait
            'Cursor.Current = Cursors.WaitCursor;
            'D: Erstelle ein RestDataProvider Objekt
            'US: create a RestDataProvider object
            Dim provider As New RestDataProvider(restUrlTb.Text)

            Try
                'D: An das RestDataProvider Objekt binden
                'US: now bind to the RestDataProvider
                LL.SetDataBinding(provider, [String].Empty)

                'D: Den Standard-Projektnamen setzen
                'US: set the default project name
                LL.AutoProjectFile = "REST.lst"

                'D: Dateiauswahldialog anzeigen und den Benutzer das Erstellen von neuen Listen erlauben
                'US: choose a list project, allow the user to create new ones also
                LL.AutoProjectType = LlProject.List Or LlProject.FileAlsoNew

                'D: Designer aufrufen
                'US: call the designer
                LL.Design()
            Catch generatedExceptionName As LL_User_Aborted_Exception
            Catch LlException As ListLabelException
                'D: Exception abfangen
                'US: Catch Exceptions
                MessageBox.Show("Information: " + LlException.Message + vbLf & vbLf & "This information was generated by a List & Label custom exception.", "Information", MessageBoxButton.OK, MessageBoxImage.Information)
            Finally
                'Cursor.Current = Cursors.Default;
                Mouse.OverrideCursor = System.Windows.Input.Cursors.Arrow
            End Try
        End Sub

        Private Sub Print_REST_Click(sender As Object, e As RoutedEventArgs)
            'D: Schaltflächen für Druck und Design deaktivieren
            'US: disable the buttons for print and design
            EnableButtons(False)

            'D: Erstelle ein RestDataProvider Objekt
            'US: create a RestDataProvider object
            Dim provider As New RestDataProvider(restUrlTb.Text)

            Try
                'D: An das RestDataProvider Objekt binden
                'US: now bind to the RestDataProvider
                LL.SetDataBinding(provider, [String].Empty)

                'D: Den Standard-Projektnamen setzen
                'US: set the default project name
                LL.AutoProjectFile = "REST.lst"

                'D: Printmode auf Previewcontrol setzen
                'US: set print mode to previewControl
                LL.AutoDestination = LlPrintMode.PreviewControl

                'D: Unterdrücken des Druckerdialogs
                'US: suppress print options dialog
                LL.AutoShowPrintOptions = False

                'D: Drucken
                'US: print
                LL.Print()
                _isNotPrinting = True
            Catch generatedExceptionName As LL_User_Aborted_Exception
            Catch LlException As ListLabelException
                'D: Exception abfangen
                'US: Catch Exceptions
                MessageBox.Show("Information: " + LlException.Message + vbLf & vbLf & "This information was generated by a List & Label custom exception.", "Information", MessageBoxButton.OK, MessageBoxImage.Information)
            Finally
                'D: Fortschrittsanzeige ausblenden
                'US: hide progressbar
                progressBar1.Value = 0
                progressBar1.Visibility = Visibility.Hidden

                'D: Schaltflächen für Druck und Design aktivieren
                'US: enable the buttons for print and design
                EnableButtons(True)
            End Try
        End Sub

        Private Sub LL_AutoDefineField(sender As Object, e As AutoDefineElementEventArgs)
			' D: Datum der Northwind-Datensätze in aktuellen Bereich verschieben
			' US: Move Northwind dates to a more current point in time
            If e.Value IsNot Nothing AndAlso e.Value.ToString() <> DBNull.Value.ToString() AndAlso e.FieldType = LlFieldType.[Date] AndAlso e.Name.Contains("Orders") Then
                Dim dt As DateTime = DirectCast(e.Value, DateTime)
                Dim YearOffset As Integer = DateTime.Now.Year - 2010 + 14
                e.Value = New DateTime(dt.Year + YearOffset, Convert.ToInt32(dt.Month), Convert.ToInt32(dt.Day))
            End If
		End Sub

		Private Sub Window_Closing(sender As Object, e As CancelEventArgs)
			If LL.Core.IsPrinting Then
				e.Cancel = True
			End If
		End Sub

		Private Sub Window_Closed(sender As Object, e As EventArgs)
			LL.Dispose()
		End Sub
	End Class
End Namespace

