using AdhocDesignerSample.ViewModels;
using combit.Reporting.AdhocDesign;
using combit.Reporting.AdhocDesign.SessionHandling;
using combit.Reporting.AdhocDesign.Web;
using combit.Reporting.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using WebReporting;

namespace AdhocDesignerSample.Controllers
{

    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View(new IndexViewModel()
            {
                // DE:  Auflisten der vorhandenen Projekte sowohl im Dateisystem als auch im Repository (hier eine SQLite-Datenbank).
                // EN:  Enumerate the existing projects both in the file system and the repository (a SQLite database in this example).
                ProjectsFromFileSystem = Directory.GetFiles(Server.MapPath("~/App_Data"), "*.lst").Select(x => Path.GetFileNameWithoutExtension(x)),
                ProjectsFromRepository = GetCurrentRepository().GetAllItems()
                                                                    // get only the project files from the repository
                                                                    .Where(item => RepositoryItemType.IsProjectType(item.Type))
                                                                    // get the project name for the UI, and the hash of the repository item Id (the ID itself is not suitable for URLs)
                                                                    .Select(item => new Tuple<int, string>(item.InternalID.GetHashCode(), item.ExtractDisplayName()))
            });
        }


        // DE:  Diese Aktion legt ein neues Ad-hoc Projekt an, wahlweise als Datei im Dateisystem oder als Repository-Element.
        // EN:  This action creates a new ad-hoc project, either as a file in the file system or as a repository item.
        [HttpPost]
        public ActionResult CreateNewProject(string projectType, string reportTitle, bool repositoryMode)
        {
            // DE:  Lege die Optionen fest, die spezifisch für diese Designer-Instanz sind.
            // EN:  Set the options that are specific to this new instance of the Ad-hoc Designers.
            var options = GetDesignerOptions(reportTitle, projectType);

            // DE:  Lege eine neue Ad-hoc Designer Session an. Der Ad-hoc Designer kann die Projekte aus einer beliebigen Quelle laden. 
            //      Für Projektdateien aus dem Dateisystem oder aus einem Repository (vgl. IRepository) können Sie die integrierten Funktionen nutzen:
            // EN:  Create a new Ad-hoc Designer session. The Ad-hoc Designer supports loading projects from any source.
            //      For project files in the file system or in a repository (see IRepository) you may use the integrated methods:

            IAdhocDesignerSession designerSession;
            if (repositoryMode)
            {
                // DE:  Zum Anlegen eines neuen Elements im Repository muss null als Item-ID übergeben werden.
                // EN:  To create a new item in the repository, null must be passed as the item ID.
                string repositoryItemId = null;
                designerSession = AdhocDesignerSession.FromRepositoryItem(repositoryItemId, GetCurrentRepository(), options);

                // DE:  Nachdem die Session erzeugt wurde, kann auf die ID des neuen Repository-Elements zugegriffen werden:
                // EN:  After the session was created, we can get the ID of the new repository item:
                repositoryItemId = (designerSession as AdhocDesignerSessionRepositoryBased).RepositoryItemId;
            }
            else
            {
                // DE: Für eine Projektdatei, die im Dateisystem gespeichert werden soll, wird nur der Dateipfad übergeben. Existiert die Datei noch nicht, wird sie angelegt.
                // EN: For a project file that is saved in the file system we only need to pass the file path. If the file does not exist yet it will be created.
                designerSession = AdhocDesignerSession.FromFile(GetProjectFilePathFromName(reportTitle), options);
            }

            // DE:  Der Designer wird geöffnet, indem auf eine spezielle (interne) URL umgeleitet wird.
            // EN:  The designer is opened by redirecting to a special (internal) URL.
            return this.RedirectToAdhocDesigner(designerSession);
        }



        // DE:  Diese Aktion öffnet ein Ad-hoc Projekt, das in einer Datei aus dem Dateisystem gespeichert ist.
        // EN:  This action opens an ad-hoc project which is saved as a file in the file system.
        public ActionResult OpenDesignerForFile(string projectName)
        {
            // DE:  Für Beschreibungen der Befehle siehe CreateNewProject().
            // EN:  For descriptions of the operations see CreateNewProject().
            var options = GetDesignerOptions(projectName, null);
            var designerSession = AdhocDesignerSession.FromFile(GetProjectFilePathFromName(projectName), options);
            return this.RedirectToAdhocDesigner(designerSession);
        }


        // DE:  Diese Aktion öffnet ein Projekt, das in einem Repository gespeichert ist (vgl. IRepository).
        // EN:  This action opens a project which is saved in a repository (see IRepository).
        public ActionResult OpenDesignerForRepositoryItem(int id)
        {
            // DE:  Ermitteln des zu öffnenden Projekts. Siehe Index(): Um gültige URLs zu erhalten wurde statt der ID des Repository-Elements dessen Hash-Code verwendet.
            // EN:  Get the project to open. See Index(): To get valid URL the item ID of the repository item was replaced with it's hash code.
            RepositoryItem projectToOpen = GetCurrentRepository().GetAllItems().First(item => item.InternalID.GetHashCode() == id);

            // DE:  Für Beschreibungen der Befehle siehe CreateNewProject().
            // EN:  For descriptions of the operations see CreateNewProject().
            var options = GetDesignerOptions(projectToOpen.ExtractDisplayName(), null);
            var designerSession = AdhocDesignerSession.FromRepositoryItem(projectToOpen.InternalID, GetCurrentRepository(), options);
            return this.RedirectToAdhocDesigner(designerSession);
        }


        // DE:  Liefert die Optionen für eine neue Instanz des Ad-hoc Designers.
        // EN:  Returns the options for a new instance of the Ad-hoc Designer.
        private AdhocWebDesignerSessionOptions GetDesignerOptions(string reportTitle, string projectType)
        {
            return new AdhocWebDesignerSessionOptions()
            {
                // DE:  Weitere Informationen zu den verfügbaren Optionen finden Sie in der List & Label Online-Hilfe.
                // EN:  You can find more information on the available options in the online help of List & Label.

                DataSource = ExampleDatasources.GetOleDbProviderNorthwindDb(),
                // LicensingInfo = "<insert your license key here>",

                DefaultProjectTitle = reportTitle,
                DesignerTitle = reportTitle + " [Design]",
                DefaultProjectType = projectType == null ? AdhocProjectType.SimpleTable : (AdhocProjectType)Enum.Parse(typeof(AdhocProjectType), projectType),
                // ...
            };
        }


        // DE:  Liefert ein Repository zur Speicherung der Projekte, hier ein Repository, das auf einer SQLite-Datenbank basiert (vgl. IRepository-Interface).
        // EN:  Returns the repository for storing the projects, in this case a repository which is based on a SQLite database (see the IRepository-Interface).
        private IRepository GetCurrentRepository()
        {
            if (_repository == null)
            {
                _repository = new SQLiteFileRepository(Server.MapPath("~/App_Data/repository.db"), "en" /* language for the reports */);
            }
            return _repository;
        }
        private static IRepository _repository;


        private string GetProjectFilePathFromName(string projectName)
        {
            return Path.Combine(Server.MapPath("~/App_Data"), Path.GetFileNameWithoutExtension(projectName) + ".lst");
        }

    }


}
