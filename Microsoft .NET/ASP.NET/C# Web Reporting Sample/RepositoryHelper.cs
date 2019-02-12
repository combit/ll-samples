using combit.ListLabel24.DataProviders;

namespace WebReporting
{
    public class RepositoryHelper
    {

        private static SQLiteFileRepository _fileRepository;

        public static SQLiteFileRepository GetCurrentRepository()
        {
            if (_fileRepository == null)
            {
                _fileRepository = new SQLiteFileRepository(Global.RepositoryDatabaseFile, "en" /* language for the reports */);
            }

            return _fileRepository;
        }

        public void DeleteRepositoryItem(string repoItemId)
        {
            GetCurrentRepository().DeleteItem(repoItemId);
        }

        // D:   Liefert die passende Datenquelle zu einem Beispiel-Report.
        // US:  Returns the required data source of the sample report.
        public static IDataProvider GetDataSourceForProject(string repositoryIdOfProject)
        {
            // D:   Für dieses Beispielprojekt hängt die benötigte Datenquelle vom Namen des geöffneten Projekt ab, daher muss der Name ausgelesen werden.
            // US:  For this sample project the datasource depends on the name of the opened project, so we need to read the display name.
            string reportDisplayName = GetCurrentRepository().GetItem(repositoryIdOfProject).ExtractDisplayName();

            IDataProvider dataProvider = DataAccess.SampleData.CreateProviderCollection(reportDisplayName + ".srt");
            return dataProvider;
        }

    }
}
