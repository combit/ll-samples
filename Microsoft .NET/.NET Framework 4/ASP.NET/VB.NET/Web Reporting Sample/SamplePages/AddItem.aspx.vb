Option Infer On
Imports combit.Reporting
Imports combit.Reporting.Repository
Imports System.IO
Imports System.Web.UI
Imports System.Web.UI.WebControls

Namespace WebReporting
    ' D:   Legt ein neues, leeres Projekt im Repository an.
    ' US:  Creates a new, empty project in the repository
    Partial Public Class CreateNewProject
        Inherits System.Web.UI.Page
        Protected Sub Page_Load(sender As Object, e As EventArgs)
            If Not IsPostBack Then
                DropDownListProjectTypes.Items.Add(New ListItem("List", "ll/project/lst"))
                DropDownListProjectTypes.Items.Add(New ListItem("Label", "ll/project/lbl"))
                DropDownListProjectTypes.Items.Add(New ListItem("Card", "ll/project/crd"))
            End If
        End Sub

        Protected Sub ButtonCreateProject_Click(sender As Object, e As EventArgs)
            ' D:   Typ des Repository-Items prüfen.
            ' US:  Validate the item type.
            Dim projectType As LlProject = LlProject.Unknown
            Try
                projectType = RepositoryItemType.ToLlProject(DropDownListProjectTypes.SelectedValue)
            Catch generatedExceptionName As ArgumentException
                LabelProjectTypes.Visible = True
            End Try

            If Page.IsValid Then
                ' D:   Die RepositoryImportUtil-Klasse hilft beim Anlegen neuer Einträge bzw. Importieren bestehender Dateien.
                ' US:  The RepositoryImportUtil class helps to create new items & import existing files.
                Dim createdItemID As String
                Using util As New RepositoryImportUtil(RepositoryHelper.GetCurrentRepository())
                    createdItemID = util.CreateNewProject(projectType, TextBoxProjectName.Text)
                End Using

                ' D:   Wenn nicht nur die ID des Repository-Items angezeigt werden soll, muss ein Anzeigename für das UI festgelegt werden.
                ' US:  If we don't want to see the ID of the repository item, we need to set a name to display in the UI.
                Dim showAsReportInToolbar As Boolean = True
                SetRepositoryItemProperties(createdItemID, TextBoxProjectName.Text, showAsReportInToolbar, Nothing)
                ProjectCreated.Visible = True
                NewProject.Visible = False
            End If
        End Sub


        ' D:   Definiert einen Anzeigenamen für ein Repository-Item. Dieser Anzeigename wird nur für die Dialoge des Designers verwendet! Das Repository-Item wird weiterhin nur über seine ID referenziert.
        ' US:  Sets a display name for a repository item. Note that this name is only used in the dialogs of the designer, the repository item is still only identified by it's ID.
        Private Sub SetRepositoryItemProperties(itemId As String, name As String, showAsReportInToolbar As Boolean, originalFilename As String)
            Dim modifiedItem As CustomizedRepostoryItem = DirectCast(RepositoryHelper.GetCurrentRepository().GetItem(itemId), CustomizedRepostoryItem)

            ' D:   Rufe den (kodierten) Descriptor dieses Repository-Items ab (dieser enthält Metadaten wie den Anzeigenamen).
            ' US:  Get the (encoded) descriptor of this repository item (contains metadata like the display name).
            Dim descriptorString As String = modifiedItem.Descriptor

            ' D:   Dekodiere den String und setzte den gewünschten Anzeigenamen für das UI.
            ' US:  Decode the string and set the entered display name for the UI.
            Dim descriptor = RepositoryItemDescriptor.LoadFromDescriptorString(descriptorString)
            descriptor.SetUIName(0, name)
            ' 0 = default language
            descriptorString = descriptor.SerializeToString()
            ' encode again
            ' D:   Speichere den geänderten Descriptor wieder im Repository.
            ' US:  Save the updated descriptor in our repository.
            RepositoryHelper.GetCurrentRepository().SetItemMetadata(itemId, descriptorString, showAsReportInToolbar, Path.GetFileName(originalFilename))
        End Sub

        Dim createdItemId1 As String
        Dim createdItemId2 As String

        Protected Sub ButtonUploadItem_Click(sender As Object, e As EventArgs)
            If FileUploadItem.HasFile Then
                ' D:   Ermittle den Typ des Repository-Items (Projektdatei, Grafik, PDF, ...) anhand der Dateiendung.
                ' US:  Get the repository item type (project file, image, PDF, ...) from the file extension.
                Dim fileType As RepositoryItemType = GetRepositoryItemTypeForFileExtension(Path.GetExtension(FileUploadItem.FileName).ToLower())
                If fileType Is Nothing Then
                    LabelFileUploadItem.Text = "File type is not accepted"
                    LabelFileUploadItem.Visible = True
                    Return
                End If

                Dim filePath1 As String = Path.Combine(Path.GetTempPath(), Path.GetFileName(FileUploadItem.FileName))
                ' With Internet Explorer, FileName contains the complete local file path of the client
                Dim filePath2 As String = Nothing

                If FileUploadItem2.HasFile Then
                    ' For Shapefiles, two files are uploaded (Shapefile + Database file)
                    filePath2 = Path.Combine(Path.GetTempPath(), Path.GetFileName(FileUploadItem2.FileName))
                End If

                Try
                    ' D:   Speichere die hochgeladenen Daten in einer temporären Datei.
                    ' US:  Save the uploaded data to a temporary file.
                    FileUploadItem.SaveAs(filePath1)

                    ' D:   Für Dateien vom Type Shapefile muss die dazugehörende Datenbank (File2) mit dem Shapefile (File1) zusammen hochgeladen werden.
                    ' US:  For files of the type 'Shapefile' a suitable database file (File2) must be uploaded together with the shapefile (File1)
                    If fileType.Value = RepositoryItemType.Shapefile.Value Then
                        If FileUploadItem2.HasFile Then
                            FileUploadItem2.SaveAs(filePath2)
                        Else
                            LabelFileUploadItem.Text = "The database file (.dbf) must be uploaded together with the shapefile."
                            LabelFileUploadItem.Visible = True
                            Return
                        End If
                    End If


                    ' D:   Importiere die hochgeladenen Datei(en) ins Repository. Die Funktion gibt die IDs der angelegten Repository-Items mit den out-Parametern zurück.
                    ' US:  Import the uploaded file(s) into the repository. The method returns the IDs of the created repository items with the out parameters.
                    AddFileToRepository(fileType, filePath1, filePath2, createdItemId1, createdItemId2)

                    If createdItemId1 Is Nothing Then

                        LabelFileUploadItem.Text = "File type is not supported in this sample."
                        LabelFileUploadItem.Visible = True
                        Return
                    End If

                    ' D:   Lege den ursprünglichen Dateinamen (ohne Dateiendung) als Anzeigenamen des Repository-Items im UI fest und nehme das Item ggf. als Report in die Toolbar auf.
                    ' US:  Use the original file name (without file extension) as the UI display name of the repository item and add it as report to the toolbar if requested.

                    Dim displayName1 As String = FileUploadItem.FileName
                    If fileType.Value <> RepositoryItemType.Shapefile.Value Then
                        ' Keep file extension only for shapefiles (two files with the same name)
                        displayName1 = Path.GetFileNameWithoutExtension(displayName1)
                    End If

                    If Not RepositoryItemType.IsProjectType(fileType, False) Then
                        ' Only repository items of type 'Project' can be shown in the toolbar
                        CheckBoxShowinToolBar.Checked = False
                    End If

                    SetRepositoryItemProperties(createdItemId1, displayName1, CheckBoxShowinToolBar.Checked, FileUploadItem.FileName)

                    If createdItemId2 IsNot Nothing Then
                        SetRepositoryItemProperties(createdItemId2, FileUploadItem2.FileName, False, FileUploadItem2.FileName)
                    End If

                    ProjectCreated.Visible = True
                    NewProject.Visible = False
                Finally
                    ' D:   Nach dem Import ins Repository werden die hochgeladenen Dateien nicht mehr benötigt.
                    ' US:  After the repository import the uploaded files are not needed anymore.
                    File.Delete(filePath1)
                    If filePath2 IsNot Nothing Then
                        File.Delete(filePath2)

                    End If
                End Try
            End If
        End Sub


        ' D:   Führt eine passende Importfunktion für den Dateityp aus, und gibt die IDs der angelegten Repository-Items zurück.
        ' US:  Executes a suitable import call for the file type and returns the ID(s) of the created repository item(s).
        Private Sub AddFileToRepository(fileType As RepositoryItemType, file1 As String, file2 As String, ByRef createdItemId1 As String, ByRef createdItemId2 As String)
            createdItemId1 = Nothing
            createdItemId2 = Nothing

            ' D:   Die RepositoryImportUtil-Klasse hilft beim Anlegen neuer Einträge bzw. Importieren bestehender Dateien.
            ' US:  The RepositoryImportUtil class helps to create new items & import existing files.
            Using util As New RepositoryImportUtil(RepositoryHelper.GetCurrentRepository())
                Using LL As New ListLabel()
                    ' D:   Beachten Sie die Möglichkeit, eine eigene Information an die CreateOrUpdate()-Methode (in SQLiteFileRepository) zu übergeben, 
                    '      die durch den Import intern aufgerufen wird. Diese Information ist dort im Parameter "userImportData" wieder verfügbar.
                    ' US:  Consider the possibility to pass a custom information to the CreateOrUpdate() method (in SQLiteFileRepository),
                    '      which is internally called by the import and where this data will be available in the "userImportData" parameter.
                    Dim userImportData As String = "Some custom information for your repository"

                    If RepositoryItemType.IsProjectType(fileType) Then
                        ' , printerConfigFile, sketchImageFile 
                        createdItemId1 = util.ImportProjectFile(LL, file1, userImportData)
                    ElseIf fileType.Value = RepositoryItemType.Image.Value Then
                        createdItemId1 = util.ImportImageFile(LL, file1, userImportData)
                    ElseIf fileType.Value = RepositoryItemType.PDF.Value Then
                        createdItemId1 = util.ImportPdfFile(LL, file1, userImportData)
                    ElseIf fileType.Value = RepositoryItemType.ProjectReverseSide.Value Then
                        createdItemId1 = util.ImportReverseSideFile(LL, file1, userImportData)
                    ElseIf fileType.Value = RepositoryItemType.ProjectTableOfContents.Value Then
                        createdItemId1 = util.ImportTableOfContentsFile(LL, file1, userImportData)
                    ElseIf fileType.Value = RepositoryItemType.ProjectIndex.Value Then
                        createdItemId1 = util.ImportIndexFile(LL, file1, userImportData)
                    ElseIf fileType.Value = RepositoryItemType.Shapefile.Value Then
                        Dim createdShapeFileItems = util.ImportShapefile(LL, file1, file2, userImportData)
                        createdItemId1 = createdShapeFileItems.Item1
                        ' ImportShapeFile() returns two IDs (for shapefile and database file)
                        createdItemId2 = createdShapeFileItems.Item2
                    End If
                End Using
            End Using
        End Sub



        ' D:   Liefert den passenden Repository-Item-Typ zu einer Dateiendung.
        ' US:  Returns the corresponding repository item type for a file extensions.
        Private Function GetRepositoryItemTypeForFileExtension(extension As String) As RepositoryItemType
            Select Case extension
                Case ".wmf", ".emf", ".bmp", ".rle", ".dib", ".pcx",
                    ".scr", ".tif", ".tiff", ".gif", ".jpg", ".pcd",
                    ".png", ".icp", ".wdp", ".hdp"
                    Return RepositoryItemType.Image

                Case ".pdf"
                    Return RepositoryItemType.PDF

                Case ".lst", ".srt", ".lsr"
                    Return RepositoryItemType.ProjectList

                Case ".crd"
                    Return RepositoryItemType.ProjectCard

                Case ".lbl"
                    Return RepositoryItemType.ProjectLabel

                Case ".idx"
                    Return RepositoryItemType.ProjectIndex

                Case ".toc"
                    Return RepositoryItemType.ProjectTableOfContents

                Case ".gtc"
                    Return RepositoryItemType.ProjectReverseSide

                Case ".shp"
                    Return RepositoryItemType.Shapefile
                Case Else

                    Return Nothing
            End Select
        End Function


    End Class
End Namespace
