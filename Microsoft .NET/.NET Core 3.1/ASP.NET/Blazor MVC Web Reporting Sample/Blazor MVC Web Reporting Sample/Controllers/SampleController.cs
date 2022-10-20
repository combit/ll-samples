using combit.Reporting;
using combit.Reporting.DataProviders;
using combit.Reporting.Repository;
using combit.Reporting.Web.WindowsClientWebDesigner.Server;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebReporting.ViewModels;

namespace WebReporting.Controllers
{

	[Authorize]
	public class SampleController : Controller
	{

		public ActionResult Index()
		{
			// D:   Liste alle Einträge im Repository auf. Da das Beispiel-Repository eine erweiterte RepositoryItem-Klasse verwendet, werden die Einträge in den erweiterten Typ gecastet
			// US:  Enumerate all items in the repository. As the sample repository uses a subclass of RepositoryItem, we need to cast the items to the extended type.
			return LocalRedirect("~/Blazor");
		}

		public ActionResult StartPage()
		{
			return View("StartPage", new StartPageModel() { RepositoryItems = GetCurrentRepository().GetAllItems().OfType<CustomizedRepostoryItem>() });
		}


		#region "WebReportViewer"
		public ActionResult Viewer()
		{
			return View("WebReportViewer");
		}
		#endregion

		#region "WebReportDesigner"
		public ActionResult WebReportDesigner()
		{
			return View("WebReportDesigner");
		}
		#endregion
		#region "Repository Management"


		public  static SQLiteFileRepository GetCurrentRepository()
		{
			return DefaultSettings.GetBaseRepository();
		}



		public ActionResult DeleteRepositoryItem(string repoItemId)
		{
			if (!RepositoryItem.IsValidItemId(repoItemId))
				return new StatusCodeResult(StatusCodes.Status400BadRequest);

			GetCurrentRepository().DeleteItem(repoItemId);
			return StartPage();
		}

		// D:   Lässt den Client den Inhalt eines Repository-Items als Datei herunterladen.
		// US:  Lets the client download the content of a repository item as a file.
		public ActionResult DownloadRepositoryItem(string repoItemId)
		{
			if (!RepositoryItem.IsValidItemId(repoItemId))
				return new StatusCodeResult(StatusCodes.Status400BadRequest);

			var repository = GetCurrentRepository();
			var itemToDownload = (CustomizedRepostoryItem)repository.GetItem(repoItemId);

			if (itemToDownload == null)
				return new StatusCodeResult(StatusCodes.Status404NotFound);

			// D:    Dateinamen bestimmen. Verwende den ursprünglichen Dateinamen (vor dem Import), den Anzeigenamen (aus dem Designer) oder die RepositoryItem-ID.
			// US:   Get the file name. Use the original filename (before the import), the display name (from the Designer) or the repository item ID.
			string fileName = itemToDownload.OriginalFileName;
			if (string.IsNullOrEmpty(fileName))
				fileName = itemToDownload.ExtractDisplayName() + ".bin";
			if (string.IsNullOrEmpty(fileName))
				fileName = itemToDownload.InternalID + ".bin";

			using (var memoryStream = new MemoryStream())
			{
				repository.LoadItem(repoItemId, memoryStream, CancellationToken.None);

				return new FileContentResult(memoryStream.ToArray(), "application/octet-stream")
				{
					FileDownloadName = fileName
				};
			}
		}


		public ActionResult AddItem()
		{
			return View("AddItem", new AddItemModel() { ShowInToolbar = true });
		}


		// D:   Legt ein neus, leeres Projekt im Repository an.
		// US:  Creates a new, empty project in the repository
		[HttpPost]
		public ActionResult CreateNewProject(AddItemModel model)
		{
			// D:   Typ des Repository-Items prüfen.
			// US:  Validate the item type.
			LlProject projectType = LlProject.Unknown;
			try
			{
				projectType = RepositoryItemType.ToLlProject(model.ProjectType);
			}
			catch (ArgumentException)
			{
				ModelState.AddModelError(nameof(model.ProjectType), "Not a valid repository item type!");
			}

			if (!ModelState.IsValid)
				return View("AddItem", model);

			// D:   Die RepositoryImportUtil-Klasse hilft beim Anlegen neuer Einträge bzw. Importieren bestehender Dateien.
			// US:  The RepositoryImportUtil class helps to create new items & import existing files.
			string createdItemID;
			using (RepositoryImportUtil util = new RepositoryImportUtil(GetCurrentRepository()))
			{
				createdItemID = util.CreateNewProject(projectType, model.ProjectName);
			}

			// D:   Wenn nicht nur die ID des Repository-Items angezeigt werden soll, muss ein Anzeigename für das UI festgelegt werden.
			// US:  If we don't want to see the ID of the repository item, we need to set a name to display in the UI.
			bool showAsReportInToolbar = true;
			SetRepositoryItemProperties(createdItemID, model.ProjectName, showAsReportInToolbar, null);

			return View("AddItem", new AddItemModel() { WasCreated = true });
		}

		// D:   Definiert einen Anzeigenamen für ein Repository-Item. Dieser Anzeigename wird nur für die Dialoge des Designers verwendet! Das Repository-Item wird weiterhin nur über seine ID referenziert.
		// US:  Sets a display name for a repository item. Note that this name is only used in the dialogs of the designer, the repository item is still only identified by it's ID.
		private void SetRepositoryItemProperties(string itemId, string name, bool showAsReportInToolbar, string originalFilename)
		{
			CustomizedRepostoryItem modifiedItem = (CustomizedRepostoryItem)GetCurrentRepository().GetItem(itemId);

			// D:   Rufe den (kodierten) Descriptor dieses Repository-Items ab (dieser enthält Metadaten wie den Anzeigenamen).
			// US:  Get the (encoded) descriptor of this repository item (contains metadata like the display name).
			string descriptorString = modifiedItem.Descriptor;

			// D:   Dekodiere den String und setzte den gewünschten Anzeigenamen für das UI.
			// US:  Decode the string and set the entered display name for the UI.
			var descriptor = RepositoryItemDescriptor.LoadFromDescriptorString(descriptorString);
			descriptor.SetUIName(0, name);   // 0 = default language
			descriptorString = descriptor.SerializeToString();  // encode again

			// D:   Speichere den geänderten Descriptor wieder im Repository.
			// US:  Save the updated descriptor in our repository.
			GetCurrentRepository().SetItemMetadata(itemId, descriptorString, showAsReportInToolbar, Path.GetFileName(originalFilename));
		}


		// D:   Empfängt eine hochgeladene Datei und fügt Sie zum Repository hinzu, sodass sie im Web Designer eingebunden werden kann.
		// US:  Accepts an uploaded file and adds it to the repository, so it can be used in the Web Designer.
		[HttpPost]
		public ActionResult UploadFile(AddItemModel model)
		{
			ModelState.Clear();

			if (model.File1 == null || model.File1.Length == 0)
				return AddItem();

			// D:   Ermittle den Typ des Repository-Items (Projektdatei, Bild, PDF, ...) anhand der Dateiendung.
			// US:  Get the repository item type (project file, picture, PDF, ...) from the file extension.
			RepositoryItemType fileType = GetRepositoryItemTypeForFileExtension(Path.GetExtension(model.File1.FileName).ToLower());
			if (fileType == null)
			{
				ModelState.AddModelError("File1", "File type is not accepted");
				return View("AddItem", model);
			}

			string filePath1 = Path.Combine(Path.GetTempPath(), Path.GetFileName(model.File1.FileName));  // With Internet Explorer, FileName contains the complete local file path of the client
			string filePath2 = null;
			if (model.File2 != null)
			{
				filePath2 = Path.Combine(Path.GetTempPath(), Path.GetFileName(model.File2.FileName));    // For Shapefiles, two files are uploaded (Shapefile + Database file)
			}

			try
			{
				// D:   Speichere die hochgeladenen Daten in einer temporären Datei.
				// US:  Save the uploaded data to a temporary file.
				using (var stream = new FileStream(filePath1, FileMode.Create))
				{
					model.File1.CopyTo(stream);
				}

				// D:   Für Dateien vom Type Shapefile muss die dazugehörende Datenbank (File2) mit dem Shapefile (File1) zusammen hochgeladen werden.
				// US:  For files of the type 'Shapefile' a suitable database file (File2) must be uploaded together with the shapefile (File1)
				if (fileType == RepositoryItemType.Shapefile)
				{
					if (model.File2 != null)
					{
						using (var stream = new FileStream(filePath2, FileMode.Create))
						{
							model.File2.CopyTo(stream);
						}

					}
					else
					{
						ModelState.AddModelError("File1", "The database file (.dbf) must be uploaded together with the shapefile.");
						return View("AddItem", model);
					}
				}



				// D:   Importiere die hochgeladenen Datei(en) ins Repository. Die Funktion gibt die IDs der angelegten Repository-Items mit den out-Parametern zurück.
				// US:  Import the uploaded file(s) into the repository. The method returns the IDs of the created repository items with the out parameters.
				AddFileToRepository(fileType, filePath1, filePath2, out string createdItemId1, out string createdItemId2);

				if (createdItemId1 == null)
				{
					ModelState.AddModelError("File1", "File type is not supported in this sample");
					return View("AddItem", model);
				}

				// D:   Lege den ursprünglichen Dateinamen (ohne Dateiendung) als Anzeigenamen des Repository-Items im UI fest und nehme das Item ggf. als Report in die Toolbar auf.
				// US:  Use the original file name (without file extension) as the UI display name of the repository item and add it as report to the toolbar if requested.

				string displayName1 = model.File1.FileName;
				if (fileType != RepositoryItemType.Shapefile)   // Keep file extension only for shapefiles (two files with the same name)
					displayName1 = Path.GetFileNameWithoutExtension(displayName1);

				if (!RepositoryItemType.IsProjectType(fileType, false))   // Only repository items of type 'Project' can be shown in the toolbar
					model.ShowInToolbar = false;

				SetRepositoryItemProperties(createdItemId1, displayName1, model.ShowInToolbar, model.File1.FileName);

				if (createdItemId2 != null)
					SetRepositoryItemProperties(createdItemId2, model.File2.FileName, false, model.File2.FileName);
			}
			finally
			{
				// D:   Nach dem Import ins Repository werden die hochgeladenen Dateien nicht mehr benötigt.
				// US:  After the repository import the uploaded files are not needed anymore.
				System.IO.File.Delete(filePath1);
				if (filePath2 != null)
				{
					System.IO.File.Delete(filePath2);
				}
			}

			return View("AddItem", new AddItemModel() { WasCreated = true });
		}


		// D:   Führt eine passende Importfunktion für den Dateityp aus, und gibt die IDs der angelegten Repository-Items zurück.
		// US:  Executes a suitable import call for the file type and returns the ID(s) of the created repository item(s).
		private void AddFileToRepository(RepositoryItemType fileType, string file1, string file2, out string createdItemId1, out string createdItemId2)
		{
			createdItemId1 = null;
			createdItemId2 = null;

			// D:   Die RepositoryImportUtil-Klasse hilft beim Anlegen neuer Einträge bzw. Importieren bestehender Dateien.
			// US:  The RepositoryImportUtil class helps to create new items & import existing files.
			using (RepositoryImportUtil util = new RepositoryImportUtil(GetCurrentRepository()))
			{
				using (ListLabel LL = new ListLabel())
				{
					// D:   Beachten Sie die Möglichkeit, eine eigene Information an die CreateOrUpdate()-Methode (in SQLiteFileRepository) zu übergeben, 
					//      die durch den Import intern aufgerufen wird. Diese Information ist dort im Parameter "userImportData" wieder verfügbar.
					// US:  Consider the possibility to pass a custom information to the CreateOrUpdate() method (in SQLiteFileRepository),
					//      which is internally called by the import and where this data will be available in the "userImportData" parameter.
					string userImportData = "Some custom information for your repository";

					if (RepositoryItemType.IsProjectType(fileType))
					{
						createdItemId1 = util.ImportProjectFile(LL, file1, userImportData /* , printerConfigFile, sketchImageFile */);
					}
					else if (fileType == RepositoryItemType.Image)
					{
						createdItemId1 = util.ImportImageFile(LL, file1, userImportData);
					}
					else if (fileType == RepositoryItemType.PDF)
					{
						createdItemId1 = util.ImportPdfFile(LL, file1, userImportData);
					}
					else if (fileType == RepositoryItemType.ProjectReverseSide)
					{
						createdItemId1 = util.ImportReverseSideFile(LL, file1, userImportData);
					}
					else if (fileType == RepositoryItemType.ProjectTableOfContents)
					{
						createdItemId1 = util.ImportTableOfContentsFile(LL, file1, userImportData);
					}
					else if (fileType == RepositoryItemType.ProjectIndex)
					{
						createdItemId1 = util.ImportIndexFile(LL, file1, userImportData);
					}
					else if (fileType == RepositoryItemType.Shapefile)
					{
						var createdShapeFileItems = util.ImportShapefile(LL, file1, file2, userImportData);
						createdItemId1 = createdShapeFileItems.Item1;   // ImportShapeFile() returns two IDs (for shapefile and database file)
						createdItemId2 = createdShapeFileItems.Item2;
					}
				}
			}
		}


		#endregion


		#region "Web Designer"

		// D:   Liefert eine Seite mit einer HTML/Javascript-Komponente, die den Start des Web Designers auf dem Client auslöst.
		// US:  Returns a page that contains a HTML/Javascript component which will triggert the start of the Web Designer on the client.
		public ActionResult WebDesignerLauncher(string reportRepositoryID)
		{
			if (!RepositoryItem.IsValidItemId(reportRepositoryID))
				return new StatusCodeResult(StatusCodes.Status400BadRequest);

			if (!GetCurrentRepository().ContainsItem(reportRepositoryID))
				return Content("The selected project does not exist");

			var options = new WindowsClientWebDesignerOptions
			{

				// D:   Lade die zum Report passende Datenquelle.
				// US:  Get the corresponding data source for the report.
				DataSource = GetDataSourceForProject(reportRepositoryID, true),

                DataMember = DefaultSettings.GetDataMemberForProject(reportRepositoryID),

                // D:   Die Referenz auf das Repository muss an List & Label übergeben werden, damit die Repository-ID des Projekts für 'AutoProjectFile' akzeptiert wird.
                // US:  The repository reference must be passed to List & Label to make the repository ID of the project a valid value for the 'AutoProjectFile' property.
                FileRepository = GetCurrentRepository(),

				// D:   Anstelle des lokalen Dateipfads wird bei Verwendung von Repositories die ID der Datei im Repository verwendet.
				// US:  When using a repository, the ID of the repository item has to be set instead of the local file path.
				ProjectFile = reportRepositoryID,
				ProjectType = RepositoryItemType.ToLlProject(GetCurrentRepository().GetItem(reportRepositoryID).Type)
			};

			// D:   Optional können Handler-Funktionen hinterlegt werden, die die Variablen oder Wörterbücher für den Web Designer initialisieren. (Zugriff auf ListLabel.Variables / ListLabel.Dictionary)
			// US:  Optionally you can define handler methods which initialize the variables or dictionaries for the Web Designer.  (Access to ListLabel.Variables / ListLabel.Dictionary)

			//      options.VariableInitializer = (variables =>
			//      {
			//          variables.Add("MyVariable", "Hello World!");
			//      });
			//      options.DictionaryInitializer = (dictionary =>
			//      {
			//          dictionary.Tables.Add("Customers", "Kunden");
			//      });

			return View("WebDesignerLauncher", options);
		}

		#endregion

		#region "Authentication"

		[AllowAnonymous]
		public ActionResult Login()
		{
			return View("Login");
		}

		[HttpPost, AllowAnonymous]
		public ActionResult Login(string username)
		{
			if (string.IsNullOrEmpty(username))
				return Login();

			// D:   Dummy-Login zur Demonstration der Nutzung des Web Designers mit Forms Authentication
			// US:  Dummy-Login for demonstration of using the Web Designer with Forms Autentication.
			//FormsAuthentication.SetAuthCookie(username, false);
			var claims = new[] { new Claim(ClaimTypes.Name, username) };
			var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

			HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
			return RedirectToAction("Index", "Sample");
		}

		#endregion

		#region "Helpers"


		// D:   Liefert die passende Datenquelle zu einem Beispiel-Report.
		// US:  Returns the required data source of the sample report.
		private static IDataProvider GetDataSourceForProject(string repositoryIdOfProject, bool forDesign)
		{
			// D:   Für dieses Beispielprojekt hängt die benötigte Datenquelle vom Namen des geöffneten Projekt ab, daher muss der Name ausgelesen werden.
			// US:  For this sample project the datasource depends on the name of the opened project, so we need to read the display name.
			string reportDisplayName = GetCurrentRepository().GetItem(repositoryIdOfProject).ExtractDisplayName();

			IDataProvider dataProvider = DataAccess.SampleData.CreateProviderCollection(reportDisplayName + ".srt", forDesign);
			return dataProvider;
		}


		// D:   Liefert den passenden Repository-Item-Typ zu einer Dateiendung.
		// US:  Returns the corresponding repository item type for a file extensions.
		private RepositoryItemType GetRepositoryItemTypeForFileExtension(string extension)
		{
			switch (extension)
			{
				case ".bmp":
				case ".dib":
				case ".emf":
				case ".gif":
				case ".hdp":
				case ".heic":
				case ".heif":
				case ".ico":
				case ".jpeg":
				case ".jpg":
				case ".jxr":
				case ".pcd":
				case ".pcx":
				case ".png":
				case ".rle":
				case ".scr":
				case ".svg":
				case ".svgz":
				case ".tif":
				case ".tiff":
				case ".wdp":
				case ".webp":
				case ".wmf":
					return RepositoryItemType.Image;

				case ".pdf":
					return RepositoryItemType.PDF;

				case ".lst":
				case ".srt":
				case ".lsr":
					return RepositoryItemType.ProjectList;

				case ".crd":
					return RepositoryItemType.ProjectCard;

                case ".lab":
                case ".lbl":
					return RepositoryItemType.ProjectLabel;

				case ".idx":
					return RepositoryItemType.ProjectIndex;

				case ".toc":
					return RepositoryItemType.ProjectTableOfContents;

				case ".gtc":
					return RepositoryItemType.ProjectReverseSide;

				case ".shp":
					return RepositoryItemType.Shapefile;

				default:
					return null;
			}
		}

		#endregion

	}
}