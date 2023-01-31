Imports combit.Reporting
Imports combit.Reporting.DataProviders
Imports combit.Reporting.Repository
Imports combit.Reporting.Web.WebReportDesigner.Server

Namespace WebReporting
    Module CmbtSettings
        ' D:   Stellen Sie hier die Sprache für die Berichte und den Designer ein.
        ' US:  Set the language For the reports And the Designer here.
        Public ReadOnly Property Language As LlLanguage
            Get
                Return LlLanguage.English
                'Return LlLanguage.German
            End Get
        End Property

        ' D: Setzen Sie die gewünschte Einheit auf Inch oder Millimeter. SysDefault Werte verwenden für den WebReportDesigner immer Millimeter, um die Synchronisierung zwischen Client und Server zu gewährleisten.
        ' US: Set the Unit To Inch Or Millimeter. SysDefault Values automatically use millimeter In the web report designer context To make sure client And server units are synchronized. 
        Public ReadOnly Property Unit As LlUnits
            Get
                Return LlUnits.Inch_1_1000
                'Return LlUnits.Millimeter_1_100
            End Get
        End Property
		
        Public ReadOnly Property RepositoryLanguage As String
            Get

                If Language = LlLanguage.German Then
                    Return "de"
                End If

                Return "en"
            End Get
        End Property

        Public ReadOnly Property FileExtension As String
            Get
                If Language = LlLanguage.German Then
                    Return ".lsr"
                End If

                Return ".srt"
            End Get
        End Property
    End Module

    Public Module DefaultSettings
        Private _fileRepository As SQLiteFileRepository

        Public ReadOnly Property DefaultSelectedReport As String
            Get
                If CmbtSettings.Language = LlLanguage.German Then
                    Return "Kundenliste mit Sortierung"
                End If

                Return "Customer list with sort order"
            End Get
        End Property


        Private ReadOnly Property DataMember As String
            Get
                Return "Customers"
            End Get
        End Property

        Function GetBaseRepository() As SQLiteFileRepository
            If _fileRepository Is Nothing Then
                _fileRepository = New SQLiteFileRepository(WebReporting.SampleWebReportingApplication.RepositoryDatabaseFile, CmbtSettings.RepositoryLanguage)
            End If

            Return _fileRepository
        End Function

        Private Function GetDataSourceForProject(ByVal repositoryIdOfProject As String, ByVal forDesign As Boolean) As IDataProvider
            If Not String.IsNullOrEmpty(repositoryIdOfProject) Then
                Dim reportDisplayName As String = GetBaseRepository().GetItem(repositoryIdOfProject).ExtractDisplayName()
                Dim dataProvider As IDataProvider = DataAccess.SampleData.CreateProviderCollection(reportDisplayName & CmbtSettings.FileExtension, forDesign)
                Return dataProvider
            End If

            Return Nothing
        End Function

        Public Function GetDataMemberForProject(ByVal repositoryIdOfProject As String) As String
            If String.IsNullOrEmpty(repositoryIdOfProject) Then
                Return Nothing
            End If

            Dim project As RepositoryItem = GetBaseRepository().GetItem(repositoryIdOfProject)
            If project.Type <> RepositoryItemType.ProjectLabel.Value Then
                Return Nothing
            End If

            Return DataMember
        End Function

        Function GetListLabelInstance(ByVal repositoryID As String, ByVal Optional repository As IRepository = Nothing) As ListLabel
            Dim LL As ListLabel = New ListLabel With {
                .DataSource = GetDataSourceForProject(repositoryID, False),
                .DataMember = GetDataMemberForProject(repositoryID),
                .Language = CmbtSettings.Language,
                .Unit = CmbtSettings.Unit
            }
            'D: Lizenzschlüssel für List & Label setzen. Auf Nicht-Entwicklungsrechnern wird ein Lizenzfehler angezeigt, falls dieser nicht gesetzt wurde.
            'US:  Set license key for List & Label. If not set, a license error will be displayed on non-development machines.
            'LL.LicensingInfo = "<insert your license key here>"
			
            Return LL
        End Function

        Function GetProhibitedActions() As List(Of WebReportDesignerAction)

            'US: You can modify the user prohibitions here by uncommenting actions which should be prohibited.
            'D: Hier können Sie die Benutzerverbote ändern, indem Sie die zu sperrende Aktion einkommentieren.

            Dim prohibited = New List(Of WebReportDesignerAction) From {}
            ' prohibited.Add(WebReportDesignerAction.CreateNewProject)
            ' prohibited.Add(WebReportDesignerAction.BrowseProjects)
            ' prohibited.Add(WebReportDesignerAction.DeleteProject)
            ' prohibited.Add(WebReportDesignerAction.DownloadProject)
            ' prohibited.Add(WebReportDesignerAction.SaveAsProject)
            ' prohibited.Add(WebReportDesignerAction.SaveProject)
            ' prohibited.Add(WebReportDesignerAction.UnlockProject)
            ' prohibited.Add(WebReportDesignerAction.UploadProject)
            Return prohibited
        End Function
    End Module
End Namespace
