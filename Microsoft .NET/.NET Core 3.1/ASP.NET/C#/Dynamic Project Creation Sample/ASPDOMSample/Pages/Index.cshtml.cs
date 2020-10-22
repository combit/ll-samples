using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using combit.Reporting;
using combit.Reporting.Dom;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.FileProviders;

namespace ASPDOMSample
{
    public class IndexModel : PageModel
    {
        private static ListLabel _ll;
        private static DataSet _ds;
        private static string _projFile;
        private static string _table;
        private static List<SelectListItem> _availableFields = new List<SelectListItem>();
        private static List<SelectListItem> _selectedFields = new List<SelectListItem>();



        [BindProperty]
        public string Table { get; set; }
        [BindProperty]
        public string Title { get; set; } = "Dynamically created project";
        [BindProperty]
        public int Format { get; set; }
        [BindProperty]
        public string FileName { get; set; } = "Example";
        [BindProperty]
        public List<SelectListItem> Tables { get; set; } = new List<SelectListItem>();
        [BindProperty]
        public string AvailableField { get; set; }
        [BindProperty]
        public List<SelectListItem> AvailableFields { get; set; } = new List<SelectListItem>();
        [BindProperty]
        public string SelectedField { get; set; }
        [BindProperty]
        public List<SelectListItem> SelectedFields { get; set; } = new List<SelectListItem>();
        [BindProperty]
        public List<SelectListItem> Formats { get; set; }

        private void UpdateView()
        {
            Formats = new List<SelectListItem>() {
                new SelectListItem() { Text = "XHTML", Value = "0" },
                new SelectListItem() { Text = "XLSX", Value = "1" },
                new SelectListItem() { Text = "PDF", Value = "2" },
                new SelectListItem() { Text = "Multi TIFF", Value = "3" },
                new SelectListItem() { Text = "Preview", Value = "4" }
            };

            foreach (DataTable dt in _ds.Tables)
                Tables.Add(new SelectListItem { Value = dt.TableName, Text = dt.TableName });

            if (Table == null)
            {
                Table = Tables.First().Value;
            }

            if (Table != _table)
            {
                _availableFields.Clear();
                _selectedFields.Clear();

                foreach (DataColumn col in _ds.Tables[Table].Columns)
                    _availableFields.Add(new SelectListItem { Value = col.ColumnName, Text = col.ColumnName });

                _table = Table;
            }

            if (AvailableField != null)
            {
                _availableFields.Remove(_availableFields.Where(af => af.Value == AvailableField).First());
                _selectedFields.Add(new SelectListItem { Value = AvailableField, Text = AvailableField });
            }

            if (SelectedField != null)
            {
                _selectedFields.Remove(_selectedFields.Where(af => af.Value == SelectedField).First());
                _availableFields.Add(new SelectListItem { Value = SelectedField, Text = SelectedField });
            }

            AvailableFields = _availableFields;
            SelectedFields = _selectedFields;
        }

        public void OnPost()
        {
            UpdateView();
        }

        public void OnGet()
        {
            _ll = new ListLabel();

            //D: Erzeuge DataSet
            //US: Create DataSet
            _ds = CreateDataSet();

            UpdateView();

            //D: Setze Datenquelle
            //US: Set datasource
            _ll.DataSource = _ds;
            //D: Erstelle Projektdateinamen
            //US: create project filename
            _projFile = "dynamic_" + "temp" + ".lst";
        }

        // Init Data Set to access northwind_full.xml
        private DataSet CreateDataSet()
        {
            string databasePath = Server.MapPath("~/App_Data/northwind_full.xml");

            if (databasePath.Length == 0)
            {
                byte[] bytes = Encoding.ASCII.GetBytes("<script>alert('Unable to find sample database.')</script>");
                Response.BodyWriter.WriteAsync(bytes);
            }
            DataSet ds = new System.Data.DataSet();
            ds.ReadXml(databasePath);

            return ds;
        }

        //D: Hinweis: Beim Verwenden der List & Label DOM Klassen ist zu beachten, dass die einzelnen Eigenschafts-Werte als Zeichenkette angegeben werden           
        //	   müssen. Dies ist notwendig um ein Höchstmaß an Flexibilität zu gewährleisten, da somit auch List & Label Formeln erlaubt sind.

        //US: Hint: When using List & Label DOM classes please note that the property values have to be passed as strings. This is necessary to ensure a
        //		 maximum of flexibility - om this way, List & Label formulas can be used as property values.
        private void GenerateLLProject()
        {
            try
            {
                //D: Neues DOM-Projekt vom Typen LlProject.List erzeugen
                //US: Create new DOM project, type LlProject.List
                ProjectList proj = new ProjectList(_ll);

                //D: Dateinamen und Dateizugriffsoptionen setzen
                //US: Set file name and file access options        
                var t = Path.Combine(Path.GetTempPath(), _projFile);
                proj.Open(t, LlDomFileMode.Create, LlDomAccessMode.ReadWrite);

                //D: Eine neue Projektbeschreibung zuweisen
                //US: Assign new project description
                proj.ProjectParameters["LL.ProjectDescription"].Contents = Title;

                //D: Ein leeres Text Objekt erstellen
                //US: Create an empty text object 
                ObjectText llobjText = new ObjectText(proj.Objects);

                //D: Auslesen der Seitenkoordinaten der ersten Seite
                //US: Get the coordinates for the first page
                Size pageExtend = proj.Regions[0].Paper.Extent.Get();

                //D: Setzen von Eigenschaften für das Textobjekt. Alle Einheiten sind SCM (1/1000 mm).
                //US: Set some properties for the text object. All units are SCM (1/1000 mm).
                llobjText.Position.Set(10000, 10000, pageExtend.Width - 65000, 27000);

                //D: Hinzufügen eines Absatzes und setzen diverser Eigenschaften
                //US: Add a paragraph to the text object and set some properties
                Paragraph llobjParagraph = new Paragraph(llobjText.Paragraphs);
                llobjParagraph.Contents = string.Format("\"{0}\"", Title);
                llobjParagraph.Font.Bold = "True";

                //D: Hinzufügen eines Grafikobjekts
                //US: Add a drawing object
                if (HttpContext.Request.Form.Files.Count != 0)
                {
                    var file = HttpContext.Request.Form.Files[0];
                    using (FileStream fs = new FileStream(Path.Combine(Path.GetTempPath(), file.FileName), FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
                    {
                        file.CopyTo(fs);
                    }

                    ObjectDrawing llobjPic = new ObjectDrawing(proj.Objects);
                    llobjPic.Source.FileInfo.FileName = Path.Combine(Path.GetTempPath(), file.FileName);
                    llobjPic.Position.Set(pageExtend.Width - 50000, 10000, pageExtend.Width - (pageExtend.Width - 40000), 27000);
                }

                //D: Hinzufügen eines Tabellencontainers und setzen diverser Eigenschaften
                //US: Add a table container and set some properties
                ObjectReportContainer container = new ObjectReportContainer(proj.Objects);
                container.Position.Set(10000, 40000, pageExtend.Width - 20000, pageExtend.Height - 44000);

                //D: In dem Tabellencontainer eine Tabelle hinzufügen
                //US: Add a table into the table container
                SubItemTable table = new SubItemTable(container.SubItems)
                {
                    //D: Gewünschte Tabelle als Datenquelle setzen
                    //US: Set required source table
                    TableId = Table
                };

                //D: Zebramuster für Tabelle definieren
                //US: Define zebra pattern for table
                table.LineOptions.Data.ZebraPattern.Style = "1";
                table.LineOptions.Data.ZebraPattern.Pattern = "1";
                table.LineOptions.Data.ZebraPattern.Color = "RGB(225,225,225)";

                //D: Eine neue Datenzeile hinzufügen mit allen ausgewählten Feldern
                //US: Add a new data line including all selected fields
                TableLineData tableLineData = new TableLineData(table.Lines.Data);
                TableLineHeader tableLineHeader = new TableLineHeader(table.Lines.Header);


                foreach (var listItem in _selectedFields)
                {
                    string fieldWidth = (Convert.ToInt32(container.Position.Width) / _selectedFields.Count).ToString();

                    //D: Kopfzeile definieren
                    //US: Define header line
                    TableFieldText header = new TableFieldText(tableLineHeader.Fields);
                    header.Contents = string.Format("\"{0}\"", listItem.Text);
                    header.Filling.Style = "1";
                    header.Filling.Color = "RGB(255,153,51)";
                    header.Font.Bold = "True";
                    header.Width = fieldWidth;

                    //D: Datenzeile definieren
                    //US: Define data line
                    TableFieldText tableField = new TableFieldText(tableLineData.Fields);
                    tableField.Contents = Table + "." + listItem.Text;
                    tableField.Width = fieldWidth;
                }


                //D: Projekt speichern und schliessen
                //US: Save project and close it
                proj.Save();
                proj.Close();
                proj.Dispose();
            }
            catch (ListLabelException llException)
            {
                //D: Exception abfangen
                //US: Catch Exceptions
                byte[] bytes = Encoding.ASCII.GetBytes("Information: " + llException.Message + "\n\nThis information was generated by a List & Label custom exception.");
                Response.BodyWriter.WriteAsync(bytes);
            }
        }

        public void OnPostCreate()
        {
            UpdateView();

            //D: Erstelle Projekt über DOM
            //US: Create project via DOM
            GenerateLLProject();

            //D: Sicher stellen, dass Projekt erzeugt wurde
            //US: Make sure project was created succesfully
            string path = Path.Combine(Path.GetTempPath(), _projFile);
            if (System.IO.File.Exists(path))
            {
                ExportConfiguration exportConfiguration = new ExportConfiguration(GetExportTarget(), Path.Combine(Path.GetTempPath(), FileName), path);
                try
                {
                    exportConfiguration.Path = BuildExportFilename(exportConfiguration);
                    _ll.Export(exportConfiguration);



                    if (System.IO.File.Exists(exportConfiguration.Path))
                    {
                        new Process
                        {
                            StartInfo = new ProcessStartInfo(exportConfiguration.Path)
                            {
                                UseShellExecute = true
                            }
                        }.Start();
                    }
                    else
                    {
                        Response.BodyWriter.WriteAsync(Encoding.ASCII.GetBytes("File '" + exportConfiguration.Path + "' doesn't exist."));
                    }
                }
                catch (Exception ex)
                {
                    Response.BodyWriter.WriteAsync(Encoding.ASCII.GetBytes("Information: " + ex.Message));
                }
            }
            else
            {
                Response.BodyWriter.WriteAsync(Encoding.ASCII.GetBytes("File '" + _projFile + "' doesn't exist."));
            }
        }

        protected LlExportTarget GetExportTarget()
        {
            //D: Hole Export Format
            //US: Get export format
            switch (Format)
            {
                case 0: return LlExportTarget.Xhtml;
                case 1: return LlExportTarget.Xlsx;
                case 2: return LlExportTarget.Pdf;
                case 3: return LlExportTarget.MultiTiff;
                case 4: return LlExportTarget.Preview;
                default: return LlExportTarget.Xhtml;
            }
        }

        protected string BuildExportFilename(ExportConfiguration config)
        {
            string fileExt = string.Empty;
            switch (config.ExportTarget)
            {
                case LlExportTarget.Pdf:
                    fileExt = ".pdf";
                    break;
                case LlExportTarget.MultiTiff:
                    fileExt = ".tif";
                    break;
                case LlExportTarget.Xlsx:
                    fileExt = ".xlsx";
                    break;
                case LlExportTarget.Xhtml:
                    fileExt = ".htm";
                    break;
                case LlExportTarget.Preview:
                    fileExt = ".ll";
                    break;
                default:
                    break;
            }
            return (Path.Combine(Path.GetDirectoryName(config.Path), Path.GetFileName(config.Path) + fileExt));
        }
    }
}

