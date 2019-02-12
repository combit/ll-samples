Imports combit.ListLabel24.DataProviders

Namespace WebReporting
    Public Class RepositoryHelper

        Private Shared _fileRepository As SQLiteFileRepository

        Public Shared Function GetCurrentRepository() As SQLiteFileRepository
            If _fileRepository Is Nothing Then
                _fileRepository = New SQLiteFileRepository([Global].RepositoryDatabaseFile, "en")
            End If

            Return _fileRepository
        End Function

        Public Sub DeleteRepositoryItem(repoItemId As String)
            GetCurrentRepository().DeleteItem(repoItemId)
        End Sub

        ' D:   Liefert die passende Datenquelle zu einem Beispiel-Report.
        ' US:  Returns the required data source of the sample report.
        Public Shared Function GetDataSourceForProject(repositoryIdOfProject As String) As IDataProvider
            ' D:   Für dieses Beispielprojekt hängt die benötigte Datenquelle vom Namen des geöffneten Projekt ab, daher muss der Name ausgelesen werden.
            ' US:  For this sample project the datasource depends on the name of the opened project, so we need to read the display name.
            Dim reportDisplayName As String = GetCurrentRepository().GetItem(repositoryIdOfProject).ExtractDisplayName()

            Dim dataProvider As IDataProvider = DataAccess.SampleData.CreateProviderCollection(reportDisplayName & Convert.ToString(".srt"))
            Return dataProvider
        End Function

    End Class
End Namespace
