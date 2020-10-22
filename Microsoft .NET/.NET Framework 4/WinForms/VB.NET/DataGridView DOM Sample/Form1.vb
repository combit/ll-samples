Imports System.Collections.Generic
Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing
Imports System.IO
Imports System.Windows.Forms
Imports combit.Reporting
Imports combit.Reporting.DataProviders
Imports combit.Reporting.Dom
Imports Microsoft.Win32

Public Partial Class Form1
    Inherits Form
    Private _myDataSet As DataSet
	Private _invisibleColumns As New List(Of String)()

	Public Sub New()
		InitializeComponent()
		InitDataSet()
	End Sub

	Private Sub InitDataSet()
		Dim installKey As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\combit\cmbtll")
		Dim databasePath As String = [String].Empty
		If installKey IsNot Nothing Then
			databasePath = DirectCast(installKey.GetValue("NWINDPath", ""), String)
		End If
		If databasePath.Length = 0 Then
			MessageBox.Show("Unable to find sample database. Make sure List & Label is installed correctly.", "List & Label")
		End If

		Dim connectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & databasePath
		

		Dim myOleDbConnection As New OleDbConnection(connectionString)

		myOleDbConnection.Open()

		Dim restrictions As Object() = New [Object]() {Nothing, Nothing, Nothing, "TABLE"}
		Dim table As DataTable = myOleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, restrictions)

		Dim tableName As String
		_myDataSet = New DataSet()

		'D:  Durch alle Tabellen iterieren und in das DataSet aufnehmen
		'US: Iterate all tables and add them to the DataSet
		For Each dr As DataRow In table.Rows
			tableName = dr("Table_Name").ToString()
			Dim dataAdapter As OleDbDataAdapter

			'D:  Die "Orders" und "Order Details" Tabelle einschränken.
			'US: Limit the "Order" and "Order Details" table. 
			If tableName = "Orders" OrElse tableName = "Order Details" Then
				dataAdapter = New OleDbDataAdapter(New OleDbCommand("SELECT * FROM [" & tableName & "] WHERE OrderID > 11040", myOleDbConnection))
			Else
				dataAdapter = New OleDbDataAdapter(New OleDbCommand("SELECT * FROM [" & tableName & "]", myOleDbConnection))
			End If


			If tableName = "Order Details" Then
				tableName = tableName.Replace(" ", "_")
			End If

			dataAdapter.FillSchema(_myDataSet, SchemaType.Source, tableName)
			dataAdapter.Fill(_myDataSet, tableName)
		Next

		'D:  Verbindung schliessen
		'US: Close connection
		myOleDbConnection.Close()

		'D:  Alle verfügbaren Tabellen in das Control schreiben
		'US: Add all available tables to combobox control
		For Each dt As DataTable In _myDataSet.Tables
			cbTable.Items.Add(dt.TableName)
		Next

		'D:  Ersten Eintrag selektieren
		'US: Select first entry
		cbTable.SelectedIndex = 0
	End Sub

	'D: Hinweis: Beim Verwenden der List & Label DOM Klassen ist zu beachten, dass die einzelnen Eigenschafts-Werte als Zeichenkette angegeben werden           
	'	   müssen. Dies ist notwendig um ein Höchstmaß an Flexibilität zu gewährleisten, da somit auch List & Label Formeln erlaubt sind.

	' US: Hint: When using List & Label DOM classes please note that the property values have to be passed as strings. This is necessary to ensure a
	' maximum of flexibility - om this way, List & Label formulas can be used as property values.
	Private Sub GenerateLLProject()
		Try
			'D:  Neues DOM-Projekt vom Typen LlProject.List erzeugen
			'US: Create new DOM project, type LlProject.List
			Using proj As New ProjectList(LL)
				'D:  Dateinamen und Dateizugriffsoptionen setzen
				'US: Set file name and file access options
				proj.Open(Path.Combine(Application.StartupPath, "dynamic.lst"), LlDomFileMode.Create, LlDomAccessMode.ReadWrite)

                'D Standardschrift und -größe setzen
                'US: Set default font and size
                proj.Settings.DefaultFont.FaceName = """Calibri"""
                proj.Settings.DefaultFont.Size = "12"

                'D Designschema setzen
                'US: Set design scheme
                proj.ProjectParameters("LL.DesignScheme").Contents = """COMBITCOLORWHEEL"""

                'D:  Eine neue Projektbeschreibung zuweisen
                'US: Assign new project description
                proj.ProjectParameters("LL.ProjectDescription").Contents = tbDescription.Text

                'D:  Default-Ausgabeziel setzen
                'US: set default export target
                proj.Settings.DefaultDestination = "PRV"

				'D:  Auslesen der Seitenkoordinaten der ersten Seite
				'US: Get the coordinates for the first page
				Dim pageExtend As Size = proj.Regions(0).Paper.Extent.[Get]()
				Dim pageWidth As Single = pageExtend.Width - 15000

				'D:  Hinzufügen eines Berichtscontainers und setzen diverser Eigenschaften
				'US: Add a report container and set some properties
				Dim container As New ObjectReportContainer(proj.Objects)
				container.Position.[Set](7500, 5000, CInt(Math.Truncate(pageWidth)), pageExtend.Height - 10000)

				'D:  In dem Berichtscontainer eine Tabelle hinzufügen
				'US: Add a table into the report container
				Dim table As New SubItemTable(container.SubItems)

				'D:  Gewünschte Tabelle als Datenquelle setzen
				'US: Set required source table
				table.TableId = cbTable.Text

				'D:  Eine neue Datenzeile hinzufügen mit allen ausgewählten Feldern
				'US: Add a new data line including all selected fields
				Dim tableLineHeader As New TableLineHeader(table.Lines.Header)
				Dim tableLineData As New TableLineData(table.Lines.Data)

				'D:  Aktuelle DPI holen
				'US: Get current DPI
				Dim currentDPI As Integer = 0
				Using g As Graphics = Me.CreateGraphics()
					currentDPI = CInt(Math.Truncate(g.DpiX))
				End Using

				Dim fieldWidth As Double

				Dim onlyVisibleColumns As Boolean = False
				If cbOnlyDisplayableColumns.Checked Then
					onlyVisibleColumns = True
				End If

				'D:  Im ersten Durchlauf den Multiplikator berechnen, im zweiten die Tabelle
				'US: Calculate the multiplicator at first pass, on second pass create the table

				Dim allFieldsWidth As Double = 0, multiplicator As Double = 1, completeFieldWidth As Double = 0
				For pass As Integer = 1 To 2
					For Each dataColumn As DataGridViewColumn In dgvData.Columns
						'D:  Sollte die Spalte auf unsichtbar gestellt sein, dann ignorieren
						'US: If the column is invisisble -> ignore it
						If dataColumn.Visible Then
							'D:  Spaltenbreite berechnen
							'US: Calculate the columnwidth
							fieldWidth = ((dataColumn.Width * 2.54) / currentDPI) * 10000

							completeFieldWidth += fieldWidth
							If (completeFieldWidth <= pageWidth) OrElse Not onlyVisibleColumns Then
								If pass = 1 Then
									allFieldsWidth += fieldWidth
								Else
									AddHeaderAndData(tableLineHeader, tableLineData, dataColumn, (fieldWidth * multiplicator).ToString())

								End If
							Else
								Exit For
							End If
						End If
					Next
					completeFieldWidth = 0
					multiplicator = pageWidth / allFieldsWidth
				Next

				'D:  Projekt speichern
				'US: Save project
				proj.Save()
			End Using
		Catch LlException As ListLabelException
			'D:  Exception abfangen
			'US: Catch exceptions
			MessageBox.Show("Information: " & LlException.Message & vbLf & vbLf & "This information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
		End Try
	End Sub

	Private Sub AddHeaderAndData(tableLineHeader As TableLineHeader, tableLineData As TableLineData, dataColumn As DataGridViewColumn, fieldWidth As String)
		'D:  Kopfzeile definieren
		'US: Define header line
		Dim header As New TableFieldText(tableLineHeader.Fields)
		header.Contents = String.Format("""{0}""", dataColumn.Name)
		header.Filling.Style = "1"
        header.Filling.Color = "LL.Scheme.BackgroundColor2"
        header.Font.Bold = "True"
        header.Font.Color = "LL.Color.White"
        header.Width = fieldWidth

		'D:  Datenzeile definieren
		'US: Define data line
		Dim tableField As New TableFieldText(tableLineData.Fields)
        tableField.Contents = cbTable.Text & "." & dataColumn.Name
        tableField.Filling.Pattern = "0"
        tableField.Width = fieldWidth
	End Sub

    Private Sub BtnDesign_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDesign.Click
        Try
            'D:  Provider für List & Label erstellen
            'US: Create provider for List & Label
            Dim provider As New AdoDataProvider(GetDataTable())

            'D:  An den Provider binden
            'US: Bind to provider
            LL.DataSource = provider
            LL.AutoShowPrintOptions = True

            'D:  List & Label Projekt anhand Einstellungen erstellen
            'US: Create List & Label project based on the settings
            GenerateLLProject()

            'D:  Designer aufrufen
            'US: Call the designer
            LL.Design(LlProject.List, Path.Combine(Application.StartupPath, "dynamic.lst"))
        Catch LlException As ListLabelException
            'D:  Exception abfangen
            'US: Catch exceptions
            MessageBox.Show("Information: " & LlException.Message & vbLf & vbLf & "This information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub CbTable_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbTable.SelectedIndexChanged
        _invisibleColumns.Clear()
        FillDataGridView(cbTable.Text)
        dgvData.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
    End Sub

    Private Sub FillDataGridView(tableName As String)
		'D:  Alle Einträge enfernen
		'US: Remove all entries
		If dgvData.RowCount <> 0 OrElse dgvData.ColumnCount <> 0 Then
			dgvData.Rows.Clear()
			dgvData.Columns.Clear()
		End If

		Dim dataTable As DataTable = _myDataSet.Tables(tableName)

		'D:  Alle Spalten dem DataGridView hinzufügen
		'US: Add all columns to DataGridView
		For Each dc As DataColumn In dataTable.Columns
			'D:  Wenn der Datentyp string ist, soll eine Textspalte hinzugefügt werden
			'US: If the data type is string, add a text column
			If dc.DataType.ToString() <> "System.Byte[]" Then
				Dim column As New DataGridViewColumn()
				column.Name = dc.ToString()
				column.CellTemplate = New DataGridViewTextBoxCell()
				dgvData.Columns.Add(column)
			Else
				'D:  Wenn der Datentyp byte ist, soll eine Bilderspalte hinzugefügt werden
				'US: If the data type is byte, add an image column

				Dim column As New DataGridViewImageColumn()
				column.Name = dc.ToString()
				column.CellTemplate = New DataGridViewImageCell()
				dgvData.Columns.Add(column)
			End If
		Next

		'D:  Alle Reihen dem DataGridView hinzufügen
		'US: Add all rows to the DataGridView
		For Each dr As DataRow In dataTable.Rows
			Dim objectArray As Object() = dr.ItemArray
			dgvData.Rows.Add(objectArray)
		Next
	End Sub

	Private Function GetDataTable() As DataTable

		Dim dataTable As New DataTable(cbTable.Text)
		Dim invisibleColumns As Integer = 0

		For Each column As DataGridViewColumn In dgvData.Columns
			If column.Visible Then
				If column.CellTemplate.ToString().Contains("DataGridViewImageCell") Then
					dataTable.Columns.Add(column.Name, GetType([Byte]()))
				Else
					dataTable.Columns.Add(column.Name)
				End If
			Else
				invisibleColumns += 1
			End If
		Next

		Dim row As Integer = 0, dgvColumnCount As Integer = dataTable.Columns.Count + invisibleColumns
		For Each dgvrow As DataGridViewRow In dgvData.Rows
			dataTable.Rows.Add()
			Dim dr As DataRow = dataTable.Rows(row)
			For i As Integer = 0 To dgvColumnCount - 1
				If dgvrow.Cells(i).Visible Then
					If dgvrow.Cells(i).ValueType.ToString() = "System.Drawing.Image" Then
						If dgvrow.Cells(i).Value IsNot Nothing AndAlso Not (dgvrow.Cells(i).Value.ToString().Contains("Bitmap")) Then
							dr(dgvrow.Cells(i).OwningColumn.Name) = dgvrow.Cells(i).Value
						End If
					Else
						dr(dgvrow.Cells(i).OwningColumn.Name) = dgvrow.Cells(i).Value
					End If
				End If
			Next
			row += 1
		Next
		Return dataTable
	End Function

    Private Sub DgvData_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles dgvData.ColumnHeaderMouseClick
        If e.Button = MouseButtons.Right Then
            cmsRightClick.Items.Clear()
            'D:  Für jede Spalte eine Checkbox erstellen
            'US: Create check box for each column
            For Each col As DataGridViewColumn In dgvData.Columns
                Dim cb As New CheckBox()
                cb.Name = col.Name & ""
                cb.Text = col.Name & "    "
                cb.BackColor = Color.White
                'D:  Wenn die Spalte sichtbar ist, Checkbox checken
                'US: If column is visible, check the checkbox
                cb.Checked = Not _invisibleColumns.Contains(col.Name)

                AddHandler cb.Click, New EventHandler(AddressOf Cb_Clicked)
                Dim ch As New ToolStripControlHost(cb)

                cmsRightClick.Items.Add(ch)
            Next
            cmsRightClick.Show(Cursor.Position)
            cmsRightClick.Refresh()
        End If
    End Sub

    Private Sub Cb_Clicked(sender As Object, e As System.EventArgs)
        Dim clickedCombobox As CheckBox = DirectCast(sender, CheckBox)

        If clickedCombobox.Checked Then
            dgvData.Columns(clickedCombobox.Name).Visible = True
            _invisibleColumns.Remove(clickedCombobox.Name)
        Else
            dgvData.Columns(clickedCombobox.Name).Visible = False
            _invisibleColumns.Add(clickedCombobox.Name)
        End If
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPrint.Click
        Try
            'D:  Provider für List & Label erstellen
            'US: Create provider for List & Label
            Dim provider As New AdoDataProvider(GetDataTable())

            'D:  An den provider binden
            'US: Bind to provider
            LL.DataSource = provider
            LL.AutoShowPrintOptions = True

            'D:  List & Label Projekt anhand Einstellungen erstellen
            'US: Create List & Label project based on the settings
            GenerateLLProject()

            'D:  Drucken
            'US: Print
            LL.Print(LlProject.List, Path.Combine(Application.StartupPath, "dynamic.lst"))
        Catch LlException As ListLabelException
            'D:  Exception abfangen
            'US: Catch exceptions
            MessageBox.Show("Information: " & LlException.Message & vbLf & vbLf & "This information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
End Class
