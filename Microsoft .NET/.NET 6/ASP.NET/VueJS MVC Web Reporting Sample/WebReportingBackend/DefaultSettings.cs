﻿using combit.Reporting;
using combit.Reporting.DataProviders;
using combit.Reporting.Repository;
using combit.Reporting.Web.WebReportDesigner.Server;

namespace VueJsMvcWebReportingSample
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "Software is only available on Windows")]
    static class CmbtSettings
    {
        // D:   Stellen Sie hier die Sprache für die Berichte und den Designer ein. Passen Sie dazu ebenfalls die Dateien "src\components\WebReportDesigner.vue" und "src\components\WebReportViewer.vue".
        // US:  Set the language for the reports and the Designer here. Also adjust the files "src\components\WebReportDesigner.vue" and "src\components\WebReportViewer.vue".

        public static LlLanguage Language { get { return LlLanguage.English; } }
        //public static LlLanguage Language { get { return LlLanguage.German; } }

        // D: Setzen Sie die gewünschte Einheit auf Zoll (Inch) oder Millimeter. SysDefault Werte verwenden für den WebReportDesigner immer Millimeter, um die Synchronisierung zwischen Client und Server zu gewährleisten.
        // US: Set the Unit to Inch or Millimeter. SysDefault Values automatically use millimeter in the web report designer context to make sure client and server units are synchronized. 
        public static LlUnits Unit { get { return LlUnits.Inch_1_1000; } }
        //public static LlUnits Unit { get { return LlUnits.Millimeter_1_100; } }

        public static string RepositoryLanguage
        {
            get
            {
                if (Language == LlLanguage.German)
                {
                    return "de";
                }
                return "en";
            }
        }

        public static string FileExtension
        {
            get
            {
                if (Language == LlLanguage.German)
                {
                    return ".lsr";
                }
                return ".srt";
            }
        }
    }

    public static class DefaultSettings
    {
        private static SQLiteFileRepository _fileRepository;

        public static string DefaultSelectedReport
        {
            get
            {
                if (CmbtSettings.Language == LlLanguage.German)
                {
                    return "Kundenliste mit Sortierung";
                }
                return "Customer list with sort order";
            }
        }
        
        // D:   Für Etikettenprojekte wird die Tabelle "Customers" ausgewählt.
        // US:  The Table "Customers" is chosen for label projects.
        public static string DataMember
        {
            get
            {
                return "Customers";
            }
        }

        public static SQLiteFileRepository GetBaseRepository()
        {
            if (_fileRepository == null)
            {
                _fileRepository = new SQLiteFileRepository(Program.RepositoryDatabaseFile, CmbtSettings.RepositoryLanguage);
            }

            return _fileRepository;
        }

        // D:   Liefert die passende Datenquelle zu einem Beispiel-Report.
        // US:  Returns the required data source of the sample report.
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "This Software is only available on Windows")]
        private static IDataProvider GetDataSourceForProject(string repositoryIdOfProject, bool forDesign)
        {
            if (!String.IsNullOrEmpty(repositoryIdOfProject))
            {
                // D:   Für dieses Beispielprojekt hängt die benötigte Datenquelle vom Namen des geöffneten Projekt ab, daher muss der Name ausgelesen werden.
                // US:  For this sample project the datasource depends on the name of the opened project, so we need to read the display name.
                string reportDisplayName = GetBaseRepository().GetItem(repositoryIdOfProject).ExtractDisplayName();

                IDataProvider dataProvider = DataAccess.SampleData.CreateProviderCollection(reportDisplayName + CmbtSettings.FileExtension, forDesign);
                return dataProvider;
            }
            return null;
        }

        // D:   Liefert die passende Tabelle zu einem Beispiel-Etikett.
        // US:  Returns the matching data member for a sample label.
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "The Software is only available on Windows")]
        public static string GetDataMemberForProject(string repositoryIdOfProject)
        {
            if (String.IsNullOrEmpty(repositoryIdOfProject))
            {
#pragma warning disable CS8603 // Suppress Warning, this is clearly done on purpose.
                return null;
#pragma warning restore CS8603 // Suppress Warning, this is clearly done on purpose.
            }

            RepositoryItem project = GetBaseRepository().GetItem(repositoryIdOfProject);

            if (project.Type != RepositoryItemType.ProjectLabel.Value)
            {
#pragma warning disable CS8603 // Suppress Warning, this is clearly done on purpose.
                return null;
#pragma warning restore CS8603 // Suppress Warning, this is clearly done on purpose.
            }

            return DataMember;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "The Software is only available on Windows")]
        public static ListLabel GetListLabelInstance(string repositoryID, IRepository repository = null)
        {
            ListLabel LL = new()
            {
                // D:   Lizenzschlüssel für List & Label setzen. Auf Nicht-Entwicklungsrechnern wird ein Lizenzfehler angezeigt, falls dieser nicht gesetzt wurde.
                // US:  Set license key for List & Label. If not set, a license error will be displayed on non-development machines.
                // LicensingInfo = "<insert your license key here>",
                
                // D:   Lade die zum Report passende Datenquelle.
                // US:  Get the corresponding data source for the report.
                DataSource = GetDataSourceForProject(repositoryID, false),
                DataMember = GetDataMemberForProject(repositoryID),
                Language = CmbtSettings.Language,
                Unit = CmbtSettings.Unit
            };

            return LL;
        }

        public static WebReportDesignerAction[] GetProhibitedActions()
        {
            //US: You can modify the user prohibitions here by uncommenting actions which should be prohibited.
            //D: Hier können Sie die Benutzerverbote ändern, indem Sie die zu sperrende Aktion einkommentieren.
            return new WebReportDesignerAction[]
            {
                //WebReportDesignerAction.CreateNewProject,
                //WebReportDesignerAction.BrowseProjects,
                //WebReportDesignerAction.DeleteProject,
                //WebReportDesignerAction.DownloadProject,
                //WebReportDesignerAction.SaveAsProject,
                //WebReportDesignerAction.SaveProject,
                //WebReportDesignerAction.UnlockProject,
                //WebReportDesignerAction.UploadProject,
            };
        }
    }
}