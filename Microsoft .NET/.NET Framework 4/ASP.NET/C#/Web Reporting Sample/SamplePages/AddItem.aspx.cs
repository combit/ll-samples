using combit.ListLabel25;
using combit.ListLabel25.Repository;
using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebReporting
{
    // D:   Legt ein neues, leeres Projekt im Repository an.
    // US:  Creates a new, empty project in the repository
    public partial class CreateNewProject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownListProjectTypes.Items.Add(new ListItem("List", "ll/project/lst"));
                DropDownListProjectTypes.Items.Add(new ListItem("Label", "ll/project/lbl"));
                DropDownListProjectTypes.Items.Add(new ListItem("Card", "ll/project/crd"));
            }
        }

        protected void ButtonCreateProject_Click(object sender, EventArgs e)
        {
            // D:   Typ des Repository-Items prüfen.
            // US:  Validate the item type.
            LlProject projectType = LlProject.Unknown;
            try
            {
                projectType = RepositoryItemType.ToLlProject(DropDownListProjectTypes.SelectedValue);
            }
            catch (ArgumentException)
            {
                LabelProjectTypes.Visible = true;
            }

            if (Page.IsValid)
            {
                // D:   Die RepositoryImportUtil-Klasse hilft beim Anlegen neuer Einträge bzw. Importieren bestehender Dateien.
                // US:  The RepositoryImportUtil class helps to create new items & import existing files.
                string createdItemID;
                using (RepositoryImportUtil util = new RepositoryImportUtil(RepositoryHelper.GetCurrentRepository()))
                {
                    createdItemID = util.CreateNewProject(projectType, TextBoxProjectName.Text);
                }

                // D:   Wenn nicht nur die ID des Repository-Items angezeigt werden soll, muss ein Anzeigename für das UI festgelegt werden.
                // US:  If we don't want to see the ID of the repository item, we need to set a name to display in the UI.
                bool showAsReportInToolbar = true;
                SetRepositoryItemProperties(createdItemID, TextBoxProjectName.Text, showAsReportInToolbar, null);
                ProjectCreated.Visible = true;
                NewProject.Visible = false;
            }
        }


        // D:   Definiert einen Anzeigenamen für ein Repository-Item. Dieser Anzeigename wird nur für die Dialoge des Designers verwendet! Das Repository-Item wird weiterhin nur über seine ID referenziert.
        // US:  Sets a display name for a repository item. Note that this name is only used in the dialogs of the designer, the repository item is still only identified by it's ID.
        private void SetRepositoryItemProperties(string itemId, string name, bool showAsReportInToolbar, string originalFilename)
        {
            CustomizedRepostoryItem modifiedItem = (CustomizedRepostoryItem)RepositoryHelper.GetCurrentRepository().GetItem(itemId);

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
            RepositoryHelper.GetCurrentRepository().SetItemMetadata(itemId, descriptorString, showAsReportInToolbar, Path.GetFileName(originalFilename));
        }


        protected void ButtonUploadItem_Click(object sender, EventArgs e)
        {
            if (FileUploadItem.HasFile)
            {
                // D:   Ermittle den Typ des Repository-Items (Projektdatei, Grafik, PDF, ...) anhand der Dateiendung.
                // US:  Get the repository item type (project file, image, PDF, ...) from the file extension.
                RepositoryItemType fileType = GetRepositoryItemTypeForFileExtension(Path.GetExtension(FileUploadItem.FileName).ToLower());
                if (fileType == null)
                {
                    LabelFileUploadItem.Text = "File type is not accepted";
                    LabelFileUploadItem.Visible = true;
                    return;
                }

                string filePath1 = Path.Combine(Path.GetTempPath(), Path.GetFileName(FileUploadItem.FileName));  // With Internet Explorer, FileName contains the complete local file path of the client
                string filePath2 = null;

                if (FileUploadItem2.HasFile)
                {
                    filePath2 = Path.Combine(Path.GetTempPath(), Path.GetFileName(FileUploadItem2.FileName));    // For Shapefiles, two files are uploaded (Shapefile + Database file)
                }

                try
                {
                    // D:   Speichere die hochgeladenen Daten in einer temporären Datei.
                    // US:  Save the uploaded data to a temporary file.
                    FileUploadItem.SaveAs(filePath1);

                    // D:   Für Dateien vom Type Shapefile muss die dazugehörende Datenbank (File2) mit dem Shapefile (File1) zusammen hochgeladen werden.
                    // US:  For files of the type 'Shapefile' a suitable database file (File2) must be uploaded together with the shapefile (File1)
                    if (fileType == RepositoryItemType.Shapefile)
                    {
                        if (FileUploadItem2.HasFile)
                        {
                            FileUploadItem2.SaveAs(filePath2);
                        }
                        else
                        {
                            LabelFileUploadItem.Text = "The database file (.dbf) must be uploaded together with the shapefile.";
                            LabelFileUploadItem.Visible = true;
                            return;
                        }
                    }

                    string createdItemId1;
                    string createdItemId2;

                    // D:   Importiere die hochgeladenen Datei(en) ins Repository. Die Funktion gibt die IDs der angelegten Repository-Items mit den out-Parametern zurück.
                    // US:  Import the uploaded file(s) into the repository. The method returns the IDs of the created repository items with the out parameters.
                    AddFileToRepository(fileType, filePath1, filePath2, out createdItemId1, out createdItemId2);

                    if (createdItemId1 == null)
                    {

                        LabelFileUploadItem.Text = "File type is not supported in this sample.";
                        LabelFileUploadItem.Visible = true;
                        return;
                    }

                    // D:   Lege den ursprünglichen Dateinamen (ohne Dateiendung) als Anzeigenamen des Repository-Items im UI fest und nehme das Item ggf. als Report in die Toolbar auf.
                    // US:  Use the original file name (without file extension) as the UI display name of the repository item and add it as report to the toolbar if requested.

                    string displayName1 = FileUploadItem.FileName;
                    if (fileType != RepositoryItemType.Shapefile)   // Keep file extension only for shapefiles (two files with the same name)
                        displayName1 = Path.GetFileNameWithoutExtension(displayName1);

                    if (!RepositoryItemType.IsProjectType(fileType, false))   // Only repository items of type 'Project' can be shown in the toolbar
                        CheckBoxShowinToolBar.Checked = false;

                    SetRepositoryItemProperties(createdItemId1, displayName1, CheckBoxShowinToolBar.Checked, FileUploadItem.FileName);

                    if (createdItemId2 != null)
                        SetRepositoryItemProperties(createdItemId2, FileUploadItem2.FileName, false, FileUploadItem2.FileName);

                    ProjectCreated.Visible = true;
                    NewProject.Visible = false;
                }
                finally
                {
                    // D:   Nach dem Import ins Repository werden die hochgeladenen Dateien nicht mehr benötigt.
                    // US:  After the repository import the uploaded files are not needed anymore.
                    File.Delete(filePath1);
                    if (filePath2 != null)
                    {
                        File.Delete(filePath2);
                    }

                }
            }
        }


        // D:   Führt eine passende Importfunktion für den Dateityp aus, und gibt die IDs der angelegten Repository-Items zurück.
        // US:  Executes a suitable import call for the file type and returns the ID(s) of the created repository item(s).
        private void AddFileToRepository(RepositoryItemType fileType, string file1, string file2, out string createdItemId1, out string createdItemId2)
        {
            createdItemId1 = null;
            createdItemId2 = null;

            // D:   Die RepositoryImportUtil-Klasse hilft beim Anlegen neuer Einträge bzw. Importieren bestehender Dateien.
            // US:  The RepositoryImportUtil class helps to create new items & import existing files.
            using (RepositoryImportUtil util = new RepositoryImportUtil(RepositoryHelper.GetCurrentRepository()))
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



        // D:   Liefert den passenden Repository-Item-Typ zu einer Dateiendung.
        // US:  Returns the corresponding repository item type for a file extensions.
        private RepositoryItemType GetRepositoryItemTypeForFileExtension(string extension)
        {
            switch (extension)
            {
                case ".wmf":
                case ".emf":
                case ".bmp":
                case ".rle":
                case ".dib":
                case ".pcx":
                case ".scr":
                case ".tif":
                case ".tiff":
                case ".gif":
                case ".jpg":
                case ".pcd":
                case ".png":
                case ".icp":
                case ".wdp":
                case ".hdp":
                    return RepositoryItemType.Image;

                case ".pdf":
                    return RepositoryItemType.PDF;

                case ".lst":
                case ".srt":
                case ".lsr":
                    return RepositoryItemType.ProjectList;

                case ".crd":
                    return RepositoryItemType.ProjectCard;

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


    }
}
