Imports System.Data.OleDb
Imports System.Drawing
Imports System.IO
Imports combit.ListLabel25
Imports combit.ListLabel25.Dom

Partial Public Class _Default
    Inherits System.Web.UI.Page
    Private _ll As ListLabel
    Private _ds As DataSet
    Private Shared _projFile As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _ll = New ListLabel()

        'D: Erzeuge DataSet
        'US: Create DataSet
        _ds = CreateDataSet()

        'D: Alle verfügbaren Tabellen in das Control schreiben
        'US: Add all available tables to the control
        If Not Page.IsPostBack Then
            For Each dt As DataTable In _ds.Tables
                DropDownList1.Items.Add(dt.TableName)
            Next

            'D: Ersten Eintrag selektieren
            'US: Select first entry
            DropDownList1.SelectedIndex = 0

            'D: Löse Event hier manuell aus
            'US: Fire event manually
            DropDownList1_SelectedIndexChanged1(Nothing, Nothing)
        End If

        'D: Setze Datenquelle
        'US: Set datasource
        _ll.DataSource = _ds

        'D: Erstelle Projektdateinamen
        'US: create project filename
        _projFile = "dynamic_" + Me.Session.SessionID.ToString() + ".lst"

    End Sub

    ' Init Data Set to access nwind.mdb
    Private Function CreateDataSet() As DataSet
        Dim databasePath As String = Server.MapPath(Path.Combine(HttpContext.Current.Request.ApplicationPath, "App_Data/NWIND.MDB"))

        If databasePath.Length = 0 Then
            Response.Write("<script>alert('Unable to find sample database.')</script>")
        End If

        Dim dataSet As New DataSet()
        Dim connectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + databasePath
        Dim myOleDbConnection As New OleDbConnection(connectionString)
        myOleDbConnection.Open()

        Dim restrictions As Object() = New [Object]() {Nothing, Nothing, Nothing, "TABLE"}
        Dim table As DataTable = myOleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, restrictions)

        'D: Durch alle Tabellen iterieren und in das DataSet aufnehmen
        'US: Iterate all tables and add them to the DataSet
        For Each dr As DataRow In table.Rows
            Dim tableName As String = dr("Table_Name").ToString()
            Dim dataAdapter As OleDbDataAdapter

            'D: Die "Orders" und "Order Details" Tabelle einschränken.
            'US: Limit the "Order" and "Order Details" table. 
            If tableName = "Orders" OrElse tableName = "Order Details" Then
                dataAdapter = New OleDbDataAdapter(New OleDbCommand("SELECT * FROM [" + tableName + "] WHERE OrderID > 11040", myOleDbConnection))
            Else
                dataAdapter = New OleDbDataAdapter(New OleDbCommand("SELECT * FROM [" + tableName + "]", myOleDbConnection))
            End If

            If tableName = "Order Details" Then
                tableName = tableName.Replace(" ", "_")
            End If

            dataAdapter.FillSchema(dataSet, SchemaType.Source, tableName)
            dataAdapter.Fill(dataSet, tableName)
        Next

        'D: Verbindung schliessen
        'US: Close connection
        myOleDbConnection.Close()

        Return dataSet
    End Function

    'D: Hinweis: Beim Verwenden der List & Label DOM Klassen ist zu beachten, dass die einzelnen Eigenschafts-Werte als Zeichenkette angegeben werden           
    '	müssen. Dies ist notwendig um ein Höchstmaß an Flexibilität zu gewährleisten, da somit auch List & Label Formeln erlaubt sind.

    'US: Hint: When using List & Label DOM classes please note that the property values have to be passed as strings. This is necessary to ensure a
    '	 maximum of flexibility - om this way, List & Label formulas can be used as property values.
    Private Sub GenerateLLProject()
        Try
            'D: Neues DOM-Projekt vom Typen LlProject.List erzeugen
            'US: Create new DOM project, type LlProject.List
            Dim proj As New ProjectList(_ll)

            'D: Dateinamen und Dateizugriffsoptionen setzen
            'US: Set file name and file access options                
            proj.Open(Path.Combine(Path.GetTempPath(), _projFile), LlDomFileMode.Create, LlDomAccessMode.ReadWrite)

            'D: Eine neue Projektbeschreibung zuweisen
            'US: Assign new project description
            proj.ProjectParameters("LL.ProjectDescription").Contents = txtTitle.Text

            'D: Ein leeres Text Objekt erstellen
            'US: Create an empty text object 
            Dim llobjText As New ObjectText(proj.Objects)

            'D: Auslesen der Seitenkoordinaten der ersten Seite
            'US: Get the coordinates for the first page
            Dim pageExtend As Size = proj.Regions(0).Paper.Extent.[Get]()

            'D: Setzen von Eigenschaften für das Textobjekt. Alle Einheiten sind SCM (1/1000 mm).
            'US: Set some properties for the text object. All units are SCM (1/1000 mm).
            llobjText.Position.[Set](10000, 10000, pageExtend.Width - 65000, 27000)

            'D: Hinzufügen eines Absatzes und setzen diverser Eigenschaften
            'US: Add a paragraph to the text object and set some properties
            Dim llobjParagraph As New Paragraph(llobjText.Paragraphs)
            llobjParagraph.Contents = String.Format("""{0}""", txtTitle.Text)
            llobjParagraph.Font.Bold = "True"

            'D: Hinzufügen eines Grafikobjekts
            'US: Add a drawing object
            If Not String.IsNullOrEmpty(FileUpload1.PostedFile.FileName) Then
                'D: Speicher Bild als physikalische Datei
                'US: Save image as physical file
                Dim reader As New BinaryReader(FileUpload1.PostedFile.InputStream)
                If True Then
                    Dim bytes As Byte() = New Byte(FileUpload1.PostedFile.InputStream.Length - 1) {}
                    reader.Read(bytes, 0, bytes.Length)
                    Dim fileStream As FileStream = Nothing
                    Try
                        fileStream = New FileStream(Path.Combine(Path.GetTempPath(), FileUpload1.PostedFile.FileName), FileMode.OpenOrCreate, FileAccess.ReadWrite)

                        Using tempFileWriter As New BinaryWriter(fileStream)
                            fileStream = Nothing
                            tempFileWriter.Write(bytes)
                        End Using
                    Finally
                        If fileStream IsNot Nothing Then
                            fileStream.Dispose()
                        End If
                    End Try
                End If

                Dim llobjPic As New ObjectDrawing(proj.Objects)
                llobjPic.Source.FileInfo.FileName = Path.Combine(Path.GetTempPath(), FileUpload1.PostedFile.FileName)
                llobjPic.Position.[Set](pageExtend.Width - 50000, 10000, pageExtend.Width - (pageExtend.Width - 40000), 27000)
            End If

            'D: Hinzufügen eines Tabellencontainers und setzen diverser Eigenschaften
            'US: Add a table container and set some properties
            Dim container As New ObjectReportContainer(proj.Objects)
            container.Position.[Set](10000, 40000, pageExtend.Width - 20000, pageExtend.Height - 44000)

            'D: In dem Tabellencontainer eine Tabelle hinzufügen
            'US: Add a table into the table container
            Dim table As New SubItemTable(container.SubItems)

            'D: Gewünschte Tabelle als Datenquelle setzen
            'US: Set required source table
            table.TableId = DropDownList1.SelectedValue

            'D: Zebramuster für Tabelle definieren
            'US: Define zebra pattern for table
            table.LineOptions.Data.ZebraPattern.Style = "1"
            table.LineOptions.Data.ZebraPattern.Pattern = "1"
            table.LineOptions.Data.ZebraPattern.Color = "RGB(225,225,225)"

            'D: Eine neue Datenzeile hinzufügen mit allen ausgewählten Feldern
            'US: Add a new data line including all selected fields
            Dim tableLineData As New TableLineData(table.Lines.Data)
            Dim tableLineHeader As New TableLineHeader(table.Lines.Header)

            For Each listItem As ListItem In lstSelectedFlds.Items
                Dim fieldWidth As String = (Convert.ToInt32(container.Position.Width) / lstSelectedFlds.Items.Count).ToString()

                'D: Kopfzeile definieren
                'US: Define header line
                Dim header As New TableFieldText(tableLineHeader.Fields)
                header.Contents = String.Format("""{0}""", listItem.Text)
                header.Filling.Style = "1"
                header.Filling.Color = "RGB(255,153,51)"
                header.Font.Bold = "True"
                header.Width = fieldWidth

                'D: Datenzeile definieren
                'US: Define data line
                Dim tableField As New TableFieldText(tableLineData.Fields)
                tableField.Contents = DropDownList1.SelectedValue + "." + listItem.Text
                tableField.Width = fieldWidth
            Next

            'D: Projekt speichern und schliessen
            'US: Save project and close it
            proj.Save()
            proj.Close()
            proj.Dispose()
        Catch llException As ListLabelException
            'D: Exception abfangen
            'US: Catch Exceptions
            Response.Write("Information: " + llException.Message + vbLf & vbLf & "This information was generated by a List & Label custom exception.")
        End Try
    End Sub

    Protected Sub DropDownList1_SelectedIndexChanged1(ByVal sender As Object, ByVal e As EventArgs) Handles DropDownList1.SelectedIndexChanged
        'D: Alle Felder aus der Liste löschen
        'US: Clear all fields from the list
        lstAvailableFlds.Items.Clear()
        lstSelectedFlds.Items.Clear()

        'D: Alle verfügbaren Felder in die ListBox einfügen
        'US: Add all available fields into the listbox
        For Each col As DataColumn In _ds.Tables(DropDownList1.SelectedValue).Columns
            lstAvailableFlds.Items.Add(col.ColumnName)
        Next
    End Sub

    Protected Sub BtnCreateReport_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCreateReport.Click
        'D: Erstelle Projekt über DOM
        'US: Create project via DOM
        GenerateLLProject()

        'D: Sicher stellen, dass Projekt erzeugt wurde
        'US: Make sure project was created succesfully
        Dim path As String = System.IO.Path.Combine(System.IO.Path.GetTempPath, _projFile)

        If File.Exists(path) Then
            Dim exportConfiguration As New ExportConfiguration(GetExportTarget(), System.IO.Path.Combine(System.IO.Path.GetTempPath, txtFilename.Text), path)
            Try
                exportConfiguration.Path = BuildExportFilename(exportConfiguration)
                _ll.Export(exportConfiguration)

                If File.Exists(exportConfiguration.Path) Then
                    Try
                        Process.Start(exportConfiguration.Path)
                    Catch ex As Exception
                        Response.Write("Information: " + ex.Message)
                    End Try
                Else
                    Response.Write("File '" + exportConfiguration.Path + "' doesn't exist.")
                End If
            Catch ex As Exception
                Response.Write("Information: " + ex.Message)
            End Try
        Else
            Response.Write("File '" + _projFile + "' doesn't exist.")
        End If
    End Sub

    Protected Function GetExportTarget() As LlExportTarget
        'D: Hole Export Format
        'US: Get export format
        Select Case DropDownListFormat.SelectedIndex
            Case 0
                Return LlExportTarget.Xhtml
            Case 1
                Return LlExportTarget.Xlsx
            Case 2
                Return LlExportTarget.Pdf
            Case 3
                Return LlExportTarget.MultiTiff
            Case 4
                Return LlExportTarget.Preview
            Case Else
                Return LlExportTarget.Xhtml
        End Select
    End Function

    Protected Function BuildExportFilename(ByVal config As ExportConfiguration) As String
        Dim fileExt As String = String.Empty
        Select Case config.ExportTarget
            Case LlExportTarget.Pdf
                fileExt = ".pdf"
                Exit Select
            Case LlExportTarget.MultiTiff
                fileExt = ".tif"
                Exit Select
            Case LlExportTarget.Xlsx
                fileExt = ".xlsx"
                Exit Select
            Case LlExportTarget.Xhtml
                fileExt = ".htm"
                Exit Select
            Case LlExportTarget.Preview
                fileExt = ".ll"
                Exit Select
            Case Else
                Exit Select
        End Select
        Return (Path.Combine(Path.GetDirectoryName(config.Path), Path.GetFileName(config.Path) + fileExt))
    End Function

    Protected Sub HandleBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnDeselect.Click, btnSelect.Click
        Dim itemsToRemove As New List(Of ListItem)()

        If sender.Equals(btnSelect) Then
            For Each item As ListItem In lstAvailableFlds.Items
                If item.Selected Then
                    lstSelectedFlds.Items.Add(item)
                    itemsToRemove.Add(item)
                End If
            Next

            For Each itemToRemove As ListItem In itemsToRemove
                lstAvailableFlds.Items.Remove(itemToRemove)
            Next
        ElseIf sender.Equals(btnDeselect) Then
            For Each item As ListItem In lstSelectedFlds.Items
                If item.Selected Then
                    lstAvailableFlds.Items.Add(item)
                    itemsToRemove.Add(item)
                End If
            Next

            For Each itemToRemove As ListItem In itemsToRemove
                lstSelectedFlds.Items.Remove(itemToRemove)
            Next
        End If
    End Sub

    Protected Sub Page_Unload(sender As Object, e As EventArgs) Handles Me.Unload
        _ll.Dispose()
    End Sub

End Class
