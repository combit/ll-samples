using combit.Reporting;
using combit.Reporting.DataProviders;
using combit.Reporting.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebReporting
{
    static class CmbtSettings
    {
        public static int ArtkRecCount { get { return 20; } }

        // D:   Stellen Sie hier die Sprache für die Berichte und den Designer ein.
        // US:  Set the language for the reports and the Designer here.
        public static LlLanguage Language { get { return LlLanguage.English; } }
        //public static LlLanguage Language { get { return LlLanguage.German; } }

        // D: Setzen Sie die gewünschte Einheit auf Inch oder Millimeter. SysDefault Werte verwenden für den WebReportDesigner immer Millimeter, um die Synchronisierung zwischen Client und Server zu gewährleisten.
        // US: Set the Unit to Inch or Millimeter. SysDefault Values automatically use millimeter in the web report designer context to make sure client and server units are synchronized. 
        public static LlUnits Unit { get { return LlUnits.Inch_1_1000; } }
        //public static LlUnits Unit { get { return LlUnits.Millimeter_1_1000; } }

        public static int MultiTabRecCount { get { return 5; } }

        public static List<string> UnlimitedRecordsList
        {
            get
            {
                return new List<string>() { "Customer list with sort order.srt", "Kundenliste mit Sortierung.lsr", "Crosstab with comparison of previous year.srt", "Kreuztabelle mit Vorjahresvergleich.lsr", "Conditional formatting and native aggregate functions.srt", "Bedingte Formatierung und native Aggregatsfunktionen.lsr" };
            }
        }

        public static List<string> IsEmployeeList
        {
            get
            {
                return new List<string>() { "Mixed portrait and landscape.srt", "Mischung von Hoch- und Querformat.lsr", "Crosstab.srt", "Kreuztabelle.lsr" };
            }
        }

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

        public static ListLabel GetListLabelInstance(string repositoryID, IRepository repository = null)
        {
            ListLabel LL = new ListLabel
            {

                // D:   Lizenzschlüssel für List & Label setzen. Auf Nicht-Entwicklungsrechnern wird ein Lizenzfehler angezeigt, falls dieser nicht gesetzt wurde.
                // US:  Set license key for List & Label (client + server). If not set, a license error will be displayed on non-development machines.
                // LicensingInfo = "insert license here";

                // D:   Lade die zum Report passende Datenquelle.
                // US:  Get the corresponding data source for the report.
                DataSource = GetDataSourceForProject(repositoryID, false),
                Language = CmbtSettings.Language,
                Unit = CmbtSettings.Unit
            };

            if (CmbtSettings.Language == LlLanguage.German)
            {
                LL.Variables.Add("ArtikelListe.ArtikelNr.Von", string.Empty);
                LL.Variables.Add("ArtikelListe.ArtikelNr.Bis", string.Empty);
            }
            else
            {
                LL.Variables.Add("ItemList.ItemNo.From", string.Empty);
                LL.Variables.Add("ItemList.ItemNo.To", string.Empty);
            }
            return LL;
        }
    }
}