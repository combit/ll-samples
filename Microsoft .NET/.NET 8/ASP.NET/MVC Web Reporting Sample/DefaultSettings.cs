using combit.Reporting;
using combit.Reporting.DataProviders;
using combit.Reporting.Repository;
using combit.Reporting.Web.WebReportDesigner.Server;

using System;
using System.Collections.Generic;
using System.Globalization;

namespace MvcWebReportingSample
{
    static class CmbtSettings
    {

        public static class LanguageSettings
        {
            //D: Sprache des Windows-Betriebssystems abfragen.
            //US: Get the language of the Windows operating system.
            public static string OSLanguage = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            //public static string OSLanguage = "de";
            //public static string OSLanguage = "en";

            // D:   Einstellen der Sprache für die Berichte und Designer anhand der Systemsprache.
            // US:  Setting the language for the reports and the Designer depending on the language of the system.
            public static LlLanguage Language
            {
                get
                {
                    return OSLanguage == "de" ? LlLanguage.German : LlLanguage.English;
                }
            }

            // D: Setzen der Einheiten auf Inch oder Millimeter anhand der Systemsprache. SysDefault Werte verwenden für den WebReportDesigner immer Millimeter, um die Synchronisierung zwischen Client und Server zu gewährleisten.
            // US: Set the Unit to Inch or Millimeter depending on the language of the system. SysDefault Values automatically use millimeter in the web report designer context to make sure client and server units are synchronized. 
            public static LlUnits Unit
            {
                get
                {
                    return OSLanguage == "de" ? LlUnits.Millimeter_1_100 : LlUnits.Inch_1_1000;
                }
            }
        }


        public static string RepositoryLanguage
        {
            get
            {
                return LanguageSettings.Language == LlLanguage.German ? "de" : "en";
            }
        }

        public static string FileExtension
        {
            get
            {
                return LanguageSettings.Language == LlLanguage.German ? ".lsr" : ".srt";
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
                return String.Empty;
            }
        }

        // D:   Für Etikettenprojekte wird die Tabelle "Customers" ausgewählt.
        // US:  The table "Customers" is chosen for label projects.
        private static string DataMember
        {
            get
            {
                return "Customers";
            }
        }

        public static SQLiteFileRepository GetBaseRepository()
        {
            _fileRepository ??= new SQLiteFileRepository(Program.RepositoryDatabaseFile, CmbtSettings.RepositoryLanguage);

            return _fileRepository;
        }

        // D:   Liefert die passende Datenquelle zu einem Beispiel-Report.
        // US:  Returns the required data source of the sample report.
        private static IDataProvider GetDataSourceForProject(string repositoryIdOfProject, bool forDesign)
        {
            // D:   Für dieses Beispielprojekt hängt die benötigte Datenquelle vom Namen des geöffneten Projekt ab, daher muss der Name ausgelesen werden.
            // US:  For this sample project the datasource depends on the name of the opened project, so we need to read the display name.               
            string reportDisplayName = String.IsNullOrEmpty(repositoryIdOfProject) ? "" : GetBaseRepository().GetItem(repositoryIdOfProject).ExtractDisplayName();

            IDataProvider dataProvider = DataAccess.SampleData.CreateProviderCollection(String.IsNullOrEmpty(repositoryIdOfProject) ? "" : reportDisplayName + CmbtSettings.FileExtension, forDesign);
            return dataProvider;
        }

        // D:   Liefert den passenden DataMember zu einem Beispiel-Etikett.
        // US:  Returns the matching data member for a sample label.
        public static string GetDataMemberForProject(string repositoryIdOfProject)
        {
            if (String.IsNullOrEmpty(repositoryIdOfProject))
            {
                return null;
            }

            RepositoryItem project = GetBaseRepository().GetItem(repositoryIdOfProject);

            return project.Type != RepositoryItemType.ProjectLabel.Value ? null : DataMember;
        }

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
                Language = CmbtSettings.LanguageSettings.Language,
                Unit = CmbtSettings.LanguageSettings.Unit
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
                //WebReportDesignerAction.DeleteProject,
                //WebReportDesignerAction.DeleteFile,
                //WebReportDesignerAction.DownloadProject,
                //WebReportDesignerAction.ExportAs,
                //WebReportDesignerAction.ManageRepository,
                //WebReportDesignerAction.OpenProjects,
                //WebReportDesignerAction.SaveAsProject,
                //WebReportDesignerAction.SaveProject,
                //WebReportDesignerAction.UnlockProject,
                //WebReportDesignerAction.UploadProject,
            };
        }
    }
}