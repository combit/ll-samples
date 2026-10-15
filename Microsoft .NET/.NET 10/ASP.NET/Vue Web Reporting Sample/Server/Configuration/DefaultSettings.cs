using combit.Reporting;
using combit.Reporting.DataProviders;
using combit.Reporting.Repository;
using combit.Reporting.Web.WebReportDesigner.Server;
using System.Globalization;
using combit.Samples.Repository;

namespace VueWebReportingSample
{
    static class CmbtSettings
    {
        public static class LanguageSettings
        {
            //D: Sprache des Windows Betriebssystems abfragen.
            //US: Get the language of the Windows operating system.
            public static string OSLanguage = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;

            // D:   Einstellen der Sprache fuer die Berichte und Designer anhand der Systemsprache.
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

        public static List<string> UnlimitedRecordsList
        {
            get
            {
                return new List<string>()
                {
                    "Customer list with sort order.srt",
                    "Kundenliste mit Sortierung.lsr",
                    "Crosstab with comparison of previous year.srt",
                    "Kreuztabelle mit Vorjahresvergleich.lsr",
                    "Conditional formatting and native aggregate functions.srt",
                    "Bedingte Formatierung und native Aggregatsfunktionen.lsr"
                };
            }
        }

        public static List<string> IsEmployeeList
        {
            get
            {
                return new List<string>()
                {
                    "Mixed portrait and landscape.srt",
                    "Mischung von Hoch- und Querformat.lsr",
                    "Crosstab.srt",
                    "Kreuztabelle.lsr"
                };
            }
        }
    }

    public static class DefaultSettings
    {
        private static IRepository? _repository;

        public static string DefaultSelectedReport
        {
            get
            {
                if (CmbtSettings.LanguageSettings.Language == LlLanguage.German)
                    return "Kundenliste mit Sortierung";
                return "Customer list with sort order";
            }
        }

        public static string DataMember
        {
            get { return "Customers"; }
        }

        public static IRepository GetBaseRepository()
        {
            _repository ??= new SQLiteFileRepository(Program.RepositoryDatabaseFile, CmbtSettings.RepositoryLanguage);
            return _repository;
        }

        // D:   Zuletzt geoeffneter Bericht. Bewusst nur im Speicher - nach einem Neustart der
        //      Anwendung beginnt das Beispiel wieder mit einer leeren Auswahl.
        // US:  Last opened report. Deliberately in memory only - after an application restart the
        //      sample starts with an empty selection again.
        private static string? _lastOpenedProject;

        // D:   Wird vom Designer-Controller aufgerufen, sobald ein Bericht geoeffnet wird. Der
        //      Viewer meldet bewusst nichts, sonst wuerde ein Wechsel in den Viewer die Auswahl
        //      des Benutzers ueberschreiben.
        // US:  Called by the designer controller whenever a report is opened. The viewer
        //      deliberately reports nothing, otherwise switching to the viewer would overwrite the
        //      user's selection.
        public static void RememberOpenedProject(string? repositoryId)
        {
            if (!string.IsNullOrEmpty(repositoryId))
                _lastOpenedProject = repositoryId;
        }

        // D:   Bericht, mit dem der Designer startet:
        //      - erster Start: nichts gemerkt, also leer - der Designer zeigt seine Auswahlseite
        //      - danach: der zuletzt geoeffnete Bericht
        //      - Notnagel: existiert der gemerkte Bericht nicht mehr, der Standardbericht
        // US:  The report the designer starts with:
        //      - first start: nothing remembered, so empty - the designer shows its selection page
        //      - afterwards: the last opened report
        //      - failsafe: if the remembered report no longer exists, the default report
        public static string StartupProject
        {
            get
            {
                if (string.IsNullOrEmpty(_lastOpenedProject))
                    return string.Empty;

                if (GetBaseRepository().ContainsItem(_lastOpenedProject))
                    return _lastOpenedProject;

                return FindDefaultReport() ?? string.Empty;
            }
        }

        // D:   Bericht, den der Viewer anzeigt: die Auswahl aus dem Designer, sonst der
        //      Standardbericht. Der Viewer braucht immer etwas anzuzeigen und darf daher - anders
        //      als der Designer - nicht leer zurueckkommen.
        // US:  The report the viewer shows: the selection made in the designer, otherwise the
        //      default report. The viewer always needs something to display and therefore - unlike
        //      the designer - must never come back empty.
        public static string ViewerProject
        {
            get
            {
                if (!string.IsNullOrEmpty(_lastOpenedProject) && GetBaseRepository().ContainsItem(_lastOpenedProject))
                    return _lastOpenedProject;

                return FindDefaultReport() ?? string.Empty;
            }
        }

        // D:   Sucht den Standardbericht ueber seinen Anzeigenamen, damit keine GUID fest im Code
        //      steht und der Bericht in beiden Sprachen gefunden wird.
        // US:  Looks the default report up by its display name so that no GUID is hardcoded and the
        //      report is found in both languages.
        private static string? FindDefaultReport()
        {
            return GetBaseRepository().GetAllItems()
                .FirstOrDefault(item => string.Equals(item.ExtractDisplayName(), DefaultSelectedReport, StringComparison.OrdinalIgnoreCase))?
                .InternalID;
        }

        private static IDataProvider? GetDataSourceForProject(string repositoryIdOfProject, bool forDesign)
        {
            if (!string.IsNullOrEmpty(repositoryIdOfProject))
            {
                string? reportDisplayName = GetBaseRepository().GetItem(repositoryIdOfProject)?.ExtractDisplayName();
                IDataProvider dataProvider = DataAccess.SampleData.CreateProviderCollection(
                    reportDisplayName + CmbtSettings.FileExtension, forDesign);
                return dataProvider;
            }
            return null;
        }

        public static string? GetDataMemberForProject(string repositoryIdOfProject)
        {
            if (string.IsNullOrEmpty(repositoryIdOfProject))
                return null;

            RepositoryItem? project = GetBaseRepository().GetItem(repositoryIdOfProject);

            if (project?.Type != RepositoryItemType.ProjectLabel.Value)
                return null;

            return DataMember;
        }

        public static ListLabel GetListLabelInstance(string repositoryID, IRepository? repository = null, bool printerless = false, bool initializing = false)
        {
            ListLabel LL = new()
            {
                // TODO: Set license key for non-development machines
                // LicensingInfo = "<insert your license key here>",
                Printerless = printerless,
                DataSource = initializing ? null : GetDataSourceForProject(repositoryID, false),
                DataMember = initializing ? null : GetDataMemberForProject(repositoryID),
                Language = CmbtSettings.LanguageSettings.Language,
                Unit = CmbtSettings.LanguageSettings.Unit
            };

            return LL;
        }

        public static WebReportDesignerAction[] GetProhibitedActions()
        {
            return new WebReportDesignerAction[]
            {
                // Uncomment to prohibit specific actions:
                // WebReportDesignerAction.OpenProjects,
                // WebReportDesignerAction.CreateNewProject,
                // WebReportDesignerAction.UploadProject,
                // WebReportDesignerAction.SaveProject,
                // WebReportDesignerAction.SaveAsProject,
                // WebReportDesignerAction.DeleteProject,
                // WebReportDesignerAction.UnlockProject,
                // WebReportDesignerAction.ExportAs,
                // WebReportDesignerAction.DeleteFile,
                // WebReportDesignerAction.DownloadProject,
                // WebReportDesignerAction.ManageRepository,
            };
        }
    }
}
