Imports combit.ListLabel24
Imports combit.ListLabel24.DataProviders
Imports combit.ListLabel24.Repository
Imports combit.ListLabel24.Web.WebDesigner.Server
Imports System.IO
Imports System.Linq
Imports System.Net
Imports System.Threading
Imports System.Web.Mvc
Imports System.Web.Security
Imports MVC_Web_Reporting_Sample.WebReporting.ViewModels

Namespace WebReporting.Controllers

    <Authorize>
    Public Class SampleController
        Inherits Controller
        Private Shared _fileRepository As SQLiteFileRepository

        Public Function Index() As ActionResult
            ' D:   Liste alle Einträge im Repository auf. Da das Beispiel-Repository eine erweiterte RepositoryItem-Klasse verwendet, werden die Einträge in den erweiterten Typ gecastet
            ' US:  Enumerate all items in the repository. As the sample repository uses a subclass of RepositoryItem, we need to cast the items to the extended type.
            Return View("Index", New StartPageModel() With {
                        .RepositoryItems = GetCurrentRepository().GetAllItems().OfType(Of CustomizedRepostoryItem)()
                        })

        End Function

        Public Function StartPage() As ActionResult
            Return View("StartPage", New StartPageModel() With {
                .RepositoryItems = GetCurrentRepository().GetAllItems().OfType(Of CustomizedRepostoryItem)()
            })
        End Function


#Region "Repository Management"


        Private Shared Function GetCurrentRepository() As SQLiteFileRepository
            If _fileRepository Is Nothing Then
			    ' D:   Stellen Sie hier die Sprache für die Berichte ein. Wechseln Sie auf "de" für Deutsch. Vergessen Sie nicht, ".srt" in ".lsr" in der Funktion GetDataSourceForProject in dieser Datei zu ändern.
                ' US:  Set the language for the reports here. Change to "de" for German. Don't forget to change ".srt" to ".lsr" in the GetDataSourceForProject function in this file.
                _fileRepository = New SQLiteFileRepository(SampleWebReportingApplication.RepositoryDatabaseFile, "en")
            End If

            Return _fileRepository
        End Function

        Public Function DeleteRepositoryItem(repoItemId As String) As ActionResult
            If Not RepositoryItem.IsValidItemId(repoItemId) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If

            GetCurrentRepository().DeleteItem(repoItemId)
            Return StartPage()
        End Function

        ' D:   Lässt den Client den Inhalt eines Repository-Items als Datei herunterladen.
        ' US:  Lets the client download the content of a repository item as a file.
        Public Function DownloadRepositoryItem(repoItemId As String) As ActionResult
            If Not RepositoryItem.IsValidItemId(repoItemId) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If

            Dim repository = GetCurrentRepository()
            Dim itemToDownload = DirectCast(repository.GetItem(repoItemId), CustomizedRepostoryItem)

            If itemToDownload Is Nothing Then
                Return HttpNotFound()
            End If

            ' D:    Dateinamen bestimmen. Verwende den ursprünglichen Dateinamen (vor dem Import), den Anzeigenamen (aus dem Designer) oder die RepositoryItem-ID.
            ' US:   Get the file name. Use the original filename (before the import), the display name (from the Designer) or the repository item ID.
            Dim fileName As String = itemToDownload.OriginalFileName
            If String.IsNullOrEmpty(fileName) Then
                fileName = itemToDownload.ExtractDisplayName() + ".bin"
            End If
            If String.IsNullOrEmpty(fileName) Then
                fileName = itemToDownload.InternalID + ".bin"
            End If

            Using memoryStream = New MemoryStream()
                repository.LoadItem(repoItemId, memoryStream, CancellationToken.None)

                Return New FileContentResult(memoryStream.ToArray(), "application/octet-stream") With {
                    .FileDownloadName = fileName
                }
            End Using
        End Function


        Public Function AddItem() As ActionResult
            Return View("AddItem", New AddItemModel() With {
                .ShowInToolbar = True
            })
        End Function


        ' D:   Legt ein neus, leeres Projekt im Repository an.
        ' US:  Creates a new, empty project in the repository
        <HttpPost>
        Public Function CreateNewProject(model As AddItemModel) As ActionResult
            ' D:   Typ des Repository-Items prüfen.
            ' US:  Validate the item type.
            Dim projectType As LlProject = LlProject.Unknown
            Try
                projectType = RepositoryItemType.ToLlProject(model.ProjectType)
            Catch generatedExceptionName As ArgumentException
                ModelState.AddModelError(NameOf(model.ProjectType), "Not a valid repository item type!")
            End Try

            If Not ModelState.IsValid Then
                Return View("AddItem", model)
            End If

            ' D:   Die RepositoryImportUtil-Klasse hilft beim Anlegen neuer Einträge bzw. Importieren bestehender Dateien.
            ' US:  The RepositoryImportUtil class helps to create new items & import existing files.
            Dim createdItemID As String
            Using util As New RepositoryImportUtil(GetCurrentRepository())
                createdItemID = util.CreateNewProject(projectType, model.ProjectName)
            End Using

            ' D:   Wenn nicht nur die ID des Repository-Items angezeigt werden soll, muss ein Anzeigename für das UI festgelegt werden.
            ' US:  If we don't want to see the ID of the repository item, we need to set a name to display in the UI.
            Dim showAsReportInToolbar As Boolean = True
            SetRepositoryItemProperties(createdItemID, model.ProjectName, showAsReportInToolbar, Nothing)

            Return View("AddItem", New AddItemModel() With {
                .WasCreated = True
            })
        End Function

        ' D:   Definiert einen Anzeigenamen für ein Repository-Item. Dieser Anzeigename wird nur für die Dialoge des Designers verwendet! Das Repository-Item wird weiterhin nur über seine ID referenziert.
        ' US:  Sets a display name for a repository item. Note that this name is only used in the dialogs of the designer, the repository item is still only identified by it's ID.
        Private Sub SetRepositoryItemProperties(itemId As String, name As String, showAsReportInToolbar As Boolean, originalFilename As String)
            Dim modifiedItem As CustomizedRepostoryItem = DirectCast(GetCurrentRepository().GetItem(itemId), CustomizedRepostoryItem)

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
            GetCurrentRepository().SetItemMetadata(itemId, descriptorString, showAsReportInToolbar, Path.GetFileName(originalFilename))
        End Sub

        Dim createdItemId1 As String
        Dim createdItemId2 As String

        ' D:   Empfängt eine hochgeladene Datei und fügt Sie zum Repository hinzu, sodass sie im Web Designer eingebunden werden kann.
        ' US:  Accepts an uploaded file and adds it to the repository, so it can be used in the Web Designer.
        <HttpPost>
        Public Function UploadFile(model As AddItemModel) As ActionResult
            ModelState.Clear()

            If model.File1 Is Nothing OrElse model.File1.ContentLength = 0 Then
                Return AddItem()
            End If

            ' D:   Ermittle den Typ des Repository-Items (Projektdatei, Bild, PDF, ...) anhand der Dateiendung.
            ' US:  Get the repository item type (project file, picture, PDF, ...) from the file extension.
            Dim fileType As RepositoryItemType = GetRepositoryItemTypeForFileExtension(Path.GetExtension(model.File1.FileName).ToLower())
            If fileType Is Nothing Then
                ModelState.AddModelError("File1", "File type is not accepted")
                Return View("AddItem", model)
            End If

            Dim filePath1 As String = Path.Combine(Path.GetTempPath(), Path.GetFileName(model.File1.FileName))
            ' With Internet Explorer, FileName contains the complete local file path of the client
            Dim filePath2 As String = Nothing
            If model.File2 IsNot Nothing Then
                ' For Shapefiles, two files are uploaded (Shapefile + Database file)
                filePath2 = Path.Combine(Path.GetTempPath(), Path.GetFileName(model.File2.FileName))
            End If

            Try
                ' D:   Speichere die hochgeladenen Daten in einer temporären Datei.
                ' US:  Save the uploaded data to a temporary file.
                model.File1.SaveAs(filePath1)

                ' D:   Für Dateien vom Type Shapefile muss die dazugehörende Datenbank (File2) mit dem Shapefile (File1) zusammen hochgeladen werden.
                ' US:  For files of the type 'Shapefile' a suitable database file (File2) must be uploaded together with the shapefile (File1)
                If fileType.Value = Repository.RepositoryItemType.Shapefile.Value Then
                    If model.File2 IsNot Nothing Then
                        model.File2.SaveAs(filePath2)
                    Else
                        ModelState.AddModelError("File1", "The database file (.dbf) must be uploaded together with the shapefile.")
                        Return View("AddItem", model)
                    End If
                End If

                ' D:   Importiere die hochgeladenen Datei(en) ins Repository. Die Funktion gibt die IDs der angelegten Repository-Items mit den out-Parametern zurück.
                ' US:  Import the uploaded file(s) into the repository. The method returns the IDs of the created repository items with the out parameters.
                AddFileToRepository(fileType, filePath1, filePath2, createdItemId1, createdItemId2)

                If createdItemId1 Is Nothing Then
                    ModelState.AddModelError("File1", "File type is not supported in this sample")
                    Return View("AddItem", model)
                End If

                ' D:   Lege den ursprünglichen Dateinamen (ohne Dateiendung) als Anzeigenamen des Repository-Items im UI fest und nehme das Item ggf. als Report in die Toolbar auf.
                ' US:  Use the original file name (without file extension) as the UI display name of the repository item and add it as report to the toolbar if requested.

                Dim displayName1 As String = model.File1.FileName
                If fileType.Value <> RepositoryItemType.Shapefile.Value Then
                    ' Keep file extension only for shapefiles (two files with the same name)
                    displayName1 = Path.GetFileNameWithoutExtension(displayName1)
                End If

                If Not RepositoryItemType.IsProjectType(fileType, False) Then
                    ' Only repository items of type 'Project' can be shown in the toolbar
                    model.ShowInToolbar = False
                End If

                SetRepositoryItemProperties(createdItemId1, displayName1, model.ShowInToolbar, model.File1.FileName)

                If createdItemId2 IsNot Nothing Then
                    SetRepositoryItemProperties(createdItemId2, model.File2.FileName, False, model.File2.FileName)
                End If
            Finally
                ' D:   Nach dem Import ins Repository werden die hochgeladenen Dateien nicht mehr benötigt.
                ' US:  After the repository import the uploaded files are not needed anymore.
                System.IO.File.Delete(filePath1)
                If filePath2 IsNot Nothing Then
                    System.IO.File.Delete(filePath2)
                End If
            End Try

            Return View("AddItem", New AddItemModel() With {
                .WasCreated = True
            })
        End Function


        ' D:   Führt eine passende Importfunktion für den Dateityp aus, und gibt die IDs der angelegten Repository-Items zurück.
        ' US:  Executes a suitable import call for the file type and returns the ID(s) of the created repository item(s).
        Private Sub AddFileToRepository(fileType As RepositoryItemType, file1 As String, file2 As String, ByRef createdItemId1 As String, ByRef createdItemId2 As String)
            createdItemId1 = Nothing
            createdItemId2 = Nothing

            ' D:   Die RepositoryImportUtil-Klasse hilft beim Anlegen neuer Einträge bzw. Importieren bestehender Dateien.
            ' US:  The RepositoryImportUtil class helps to create new items & import existing files.
            Using util As New RepositoryImportUtil(GetCurrentRepository())
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


#End Region


#Region "Html5Viewer"

        ' D:   Öffnet den Html5Viewer für das Projekt mit der angegebenen Repository-ID
        ' US:  Loads the Html5Viewer for the project with with specified repository ID.
        Public Function Html5Viewer(reportRepositoryId As String) As ActionResult
            If Not RepositoryItem.IsValidItemId(reportRepositoryId) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If

            If Not GetCurrentRepository().ContainsItem(reportRepositoryId) Then
                Return Content("The selected project does not exist")
            End If

            If GetCurrentRepository().GetItem(reportRepositoryId).IsEmpty Then
                Return Content("The selected project is empty. Please run the Designer first.")
            End If


            Dim model As New Html5ViewerModel()
            model.ViewerOptions.UseUIMiniStyle = True
            AddHandler model.ViewerOptions.OnListLabelRequest, AddressOf Html5Viewer_OnListLabelRequest

            ' D:   'ReportName' wird im OnListLabelRequest-Event wieder zurückgeliefert, wo der Pfad zur Projektdatei gesetzt werden muss.
            '      Anstelle des lokalen Dateipfads wird bei Verwendung von Repositories die ID der Datei im Repository verwendet.
            ' US:  The report name is returned in the OnListLabelRequest Event, where we need to set the project file.
            '      When using a repository, the ID of the repository item has to be set instead of the local file path.
            model.ReportName = reportRepositoryId

            Return View("Html5Viewer", model)
        End Function

        ' D:   Wenn keine Instanz dieser Controller-Klasse für den folgenden Code benötigt wird, sollte dieses Event statisch sein.
        ' US:  When no instance of this Controller class is requried for the following code, make this event static.
        Private Shared Sub Html5Viewer_OnListLabelRequest(sender As Object, e As combit.ListLabel24.Web.ListLabelRequestEventArgs)
            Dim repositoryIdOfProject As String = e.ReportName
            Dim LL As New ListLabel()

            ' D:   Lizenzschlüssel für List & Label setzen. Auf Nicht-Entwicklungsrechnern wird ein Lizenzfehler angezeigt, falls dieser nicht gesetzt wurde.
            ' US:  Set license key for List & Label (client + server). If not set, a license error will be displayed on non-development machines.
            ' LL.LicensingInfo = "insert license here";

            ' D:   Die Referenz auf das Repository muss an List & Label übergeben werden, damit die Repository-ID des Projekts für 'AutoProjectFile' akzeptiert wird.
            ' US:  The repository reference must be passed to List & Label to make the repository ID of the project a valid value for the 'AutoProjectFile' property.
            LL.FileRepository = GetCurrentRepository()
            LL.AutoProjectFile = repositoryIdOfProject

            ' D:   Lade die zum Report passende Datenquelle.
            ' US:  Get the corresponding data source for the report.
            LL.DataSource = GetDataSourceForProject(repositoryIdOfProject, False)

            ' D:   Der Html5Viewer benötigt ein Verzeichnis für temporäre Dateien. Diese werden einige Minuten nach Schließen eines Html5Viewers automatisch gelöscht.
            ' US:  The Html5Viewer requires a directory for temporary files. Some minutes after a Html5Viewer is closed, these files will be deleted automatically.
            e.ExportPath = Path.Combine(SampleWebReportingApplication.TempDirectory, Guid.NewGuid().ToString("D"))

            e.NewInstance = LL
        End Sub

#End Region


#Region "Web Designer"

        ' D:   Liefert eine Seite mit einer HTML/Javascript-Komponente, die den Start des Web Designers auf dem Client auslöst.
        ' US:  Returns a page that contains a HTML/Javascript component which will triggert the start of the Web Designer on the client.
        Public Function WebDesignerLauncher(reportRepositoryID As String) As ActionResult
            If Not RepositoryItem.IsValidItemId(reportRepositoryID) Then
                Return New HttpStatusCodeResult(HttpStatusCode.BadRequest)
            End If

            If Not GetCurrentRepository().ContainsItem(reportRepositoryID) Then
                Return Content("The selected project does not exist")
            End If

            Dim options = New WebDesignerOptions()

            ' D:   Lade die zum Report passende Datenquelle.
            '      Der zweite Parameter (forDesign) kann dazu benutzt werden, einen eigenen Provider (z.B. mit der Eig. MinimalSelect = false) für den Designer zu verwenden.
            ' US:  Get the corresponding data source for the report. 
            '      Set the second parameter (forDesign) to true if you're using different provider (e.q. with property  MinimalSelect = false) for the designer.
            options.DataSource = GetDataSourceForProject(reportRepositoryID, False)

            ' D:   Die Referenz auf das Repository muss an List & Label übergeben werden, damit die Repository-ID des Projekts für 'AutoProjectFile' akzeptiert wird.
            ' US:  The repository reference must be passed to List & Label to make the repository ID of the project a valid value for the 'AutoProjectFile' property.
            options.FileRepository = GetCurrentRepository()

            ' D:   Anstelle des lokalen Dateipfads wird bei Verwendung von Repositories die ID der Datei im Repository verwendet.
            ' US:  When using a repository, the ID of the repository item has to be set instead of the local file path.
            options.ProjectFile = reportRepositoryID
            options.ProjectType = RepositoryItemType.ToLlProject(GetCurrentRepository().GetItem(reportRepositoryID).Type)
			
            ' D:   Optional können Handler-Funktionen hinterlegt werden, die die Variablen oder Wörterbücher für den Web Designer initialisieren. (Zugriff auf ListLabel.Variables / ListLabel.Dictionary)
            ' US:  Optionally you can define handler methods which initialize the variables or dictionaries for the Web Designer.  (Access to ListLabel.Variables / ListLabel.Dictionary)

            '      options.VariableInitializer = (variables =>
            '      {
            '          variables.Add("MyVariable", "Hello World!");
            '      });
            '      options.DictionaryInitializer = (dictionary =>
            '      {
            '          dictionary.Tables.Add("Customers", "Kunden");
            '      });
			

            Return View("WebDesignerLauncher", options)
        End Function

#End Region


#Region "Authentication"

        <AllowAnonymous>
        Public Function Login() As ActionResult
            Return View("Login")
        End Function

        <HttpPost, AllowAnonymous>
        Public Function Login(username As String) As ActionResult
            If String.IsNullOrEmpty(username) Then
                Return Login()
            End If

            ' D:   Dummy-Login zur Demonstration der Nutzung des Web Designers mit Forms Authentication
            ' US:  Dummy-Login for demonstration of using the Web Designer with Forms Autentication.
            FormsAuthentication.SetAuthCookie(username, False)
            Return RedirectToAction("Index", "Sample")
        End Function

#End Region


#Region "Helpers"


        ' D:   Liefert die passende Datenquelle zu einem Beispiel-Report.
        ' US:  Returns the required data source of the sample report.
        Private Shared Function GetDataSourceForProject(repositoryIdOfProject As String, forDesign As Boolean) As IDataProvider
            ' D:   Für dieses Beispielprojekt hängt die benötigte Datenquelle vom Namen des geöffneten Projekt ab, daher muss der Name ausgelesen werden.
            ' US:  For this sample project the datasource depends on the name of the opened project, so we need to read the display name.
            Dim reportDisplayName As String = GetCurrentRepository().GetItem(repositoryIdOfProject).ExtractDisplayName()

            Dim dataProvider As IDataProvider = DataAccess.SampleData.CreateProviderCollection(reportDisplayName & Convert.ToString(".srt"), forDesign)
            Return dataProvider
        End Function


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

#End Region

    End Class
End Namespace
