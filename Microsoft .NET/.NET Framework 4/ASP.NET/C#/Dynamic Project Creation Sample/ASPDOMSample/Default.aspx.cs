using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using combit.ListLabel25;
using combit.ListLabel25.Dom;

namespace ASPDOMSample
{
    public partial class Default : System.Web.UI.Page
    {
        private ListLabel _ll;
        private DataSet _ds;
        private static string _projFile;

        protected void Page_Load(object sender, EventArgs e)
        {
            _ll = new ListLabel();

            //D: Erzeuge DataSet
            //US: Create DataSet
            _ds = CreateDataSet();

            //D: Alle verfügbaren Tabellen in das Control schreiben
            //US: Add all available tables to the control
            if (!Page.IsPostBack)
            {
                foreach (DataTable dt in _ds.Tables)
                    DropDownList1.Items.Add(dt.TableName);

                //D: Ersten Eintrag selektieren
                //US: Select first entry
                DropDownList1.SelectedIndex = 0;

                //D: Löse Event hier manuell aus
                //US: Fire event manually
                DropDownList1_SelectedIndexChanged1(null, null);
            }

            //D: Setze Datenquelle
            //US: Set datasource
            _ll.DataSource = _ds;

            //D: Erstelle Projektdateinamen
            //US: create project filename
            _projFile = "dynamic_" + this.Session.SessionID.ToString() + ".lst";
        }

        // Init Data Set to access nwind.mdb
        private DataSet CreateDataSet()
        {
            string databasePath = Server.MapPath(Path.Combine(HttpContext.Current.Request.ApplicationPath, "App_Data/NWIND.MDB"));

            if (databasePath.Length == 0)
                Response.Write("<script>alert('Unable to find sample database.')</script>");

            DataSet dataSet = new DataSet();
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + databasePath;
            OleDbConnection myOleDbConnection = new OleDbConnection(connectionString);
            myOleDbConnection.Open();

            object[] restrictions = new Object[] { null, null, null, "TABLE" };
            DataTable table = myOleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, restrictions);

            //D: Durch alle Tabellen iterieren und in das DataSet aufnehmen
            //US: Iterate all tables and add them to the DataSet
            foreach (DataRow dr in table.Rows)
            {
                string tableName = dr["Table_Name"].ToString();
                OleDbDataAdapter dataAdapter;

                //D: Die "Orders" und "Order Details" Tabelle einschränken.
                //US: Limit the "Order" and "Order Details" table. 
                if (tableName == "Orders" || tableName == "Order Details")
                    dataAdapter = new OleDbDataAdapter(new OleDbCommand("SELECT * FROM [" + tableName + "] WHERE OrderID > 11040", myOleDbConnection));
                else
                    dataAdapter = new OleDbDataAdapter(new OleDbCommand("SELECT * FROM [" + tableName + "]", myOleDbConnection));

                if (tableName == "Order Details")
                    tableName = tableName.Replace(" ", "_");

                dataAdapter.FillSchema(dataSet, SchemaType.Source, tableName);
                dataAdapter.Fill(dataSet, tableName);
            }

            //D: Verbindung schliessen
            //US: Close connection
            myOleDbConnection.Close();

            return dataSet;
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
                proj.Open(Path.Combine(Path.GetTempPath(), _projFile), LlDomFileMode.Create, LlDomAccessMode.ReadWrite);

                //D: Eine neue Projektbeschreibung zuweisen
                //US: Assign new project description
                proj.ProjectParameters["LL.ProjectDescription"].Contents = txtTitle.Text;

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
                llobjParagraph.Contents = string.Format("\"{0}\"", txtTitle.Text);
                llobjParagraph.Font.Bold = "True";

                //D: Hinzufügen eines Grafikobjekts
                //US: Add a drawing object
                if (!string.IsNullOrEmpty(FileUpload1.PostedFile.FileName))
                {
                    //D: Speicher Bild als physikalische Datei
                    //US: Save image as physical file
                    BinaryReader reader = new BinaryReader(FileUpload1.PostedFile.InputStream);
                    {
                        byte[] bytes = new byte[FileUpload1.PostedFile.InputStream.Length];
                        reader.Read(bytes, 0, bytes.Length);
                        FileStream fileStream = null;
                        try
                        {
                            fileStream = new FileStream(Path.Combine(Path.GetTempPath(), FileUpload1.PostedFile.FileName), FileMode.OpenOrCreate, FileAccess.ReadWrite);

                            using (BinaryWriter tempFileWriter = new BinaryWriter(fileStream))
                            {
                                fileStream = null;
                                tempFileWriter.Write(bytes);
                            }
                        }
                        finally
                        {
                            if (fileStream != null)
                                fileStream.Dispose();
                        }
                    }

                    ObjectDrawing llobjPic = new ObjectDrawing(proj.Objects);
                    llobjPic.Source.FileInfo.FileName = Path.Combine(Path.GetTempPath(), FileUpload1.PostedFile.FileName);
                    llobjPic.Position.Set(pageExtend.Width - 50000, 10000, pageExtend.Width - (pageExtend.Width - 40000), 27000);
                }

                //D: Hinzufügen eines Tabellencontainers und setzen diverser Eigenschaften
                //US: Add a table container and set some properties
                ObjectReportContainer container = new ObjectReportContainer(proj.Objects);
                container.Position.Set(10000, 40000, pageExtend.Width - 20000, pageExtend.Height - 44000);

                //D: In dem Tabellencontainer eine Tabelle hinzufügen
                //US: Add a table into the table container
                SubItemTable table = new SubItemTable(container.SubItems);

                //D: Gewünschte Tabelle als Datenquelle setzen
                //US: Set required source table
                table.TableId = DropDownList1.SelectedValue;

                //D: Zebramuster für Tabelle definieren
                //US: Define zebra pattern for table
                table.LineOptions.Data.ZebraPattern.Style = "1";
                table.LineOptions.Data.ZebraPattern.Pattern = "1";
                table.LineOptions.Data.ZebraPattern.Color = "RGB(225,225,225)";

                //D: Eine neue Datenzeile hinzufügen mit allen ausgewählten Feldern
                //US: Add a new data line including all selected fields
                TableLineData tableLineData = new TableLineData(table.Lines.Data);
                TableLineHeader tableLineHeader = new TableLineHeader(table.Lines.Header);

                foreach (ListItem listItem in lstSelectedFlds.Items)
                {
                    string fieldWidth = (Convert.ToInt32(container.Position.Width) / lstSelectedFlds.Items.Count).ToString();

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
                    tableField.Contents = DropDownList1.SelectedValue + "." + listItem.Text;
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
                Response.Write("Information: " + llException.Message + "\n\nThis information was generated by a List & Label custom exception.");
            }
        }

        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            //D: Alle Felder aus der Liste löschen
            //US: Clear all fields from the list
            lstAvailableFlds.Items.Clear();
            lstSelectedFlds.Items.Clear();

            //D: Alle verfügbaren Felder in die ListBox einfügen
            //US: Add all available fields into the listbox
            foreach (DataColumn col in _ds.Tables[DropDownList1.SelectedValue].Columns)
                lstAvailableFlds.Items.Add(col.ColumnName);
        }

        protected void HandleBtn_Click(object sender, EventArgs e)
        {
            List<ListItem> itemsToRemove = new List<ListItem>();

            if (sender == btnSelect)
            {
                foreach (ListItem item in lstAvailableFlds.Items)
                {
                    if (item.Selected)
                    {
                        lstSelectedFlds.Items.Add(item);
                        itemsToRemove.Add(item);
                    }
                }

                foreach (ListItem itemToRemove in itemsToRemove)
                    lstAvailableFlds.Items.Remove(itemToRemove);
            }
            else if (sender == btnDeselect)
            {
                foreach (ListItem item in lstSelectedFlds.Items)
                {
                    if (item.Selected)
                    {
                        lstAvailableFlds.Items.Add(item);
                        itemsToRemove.Add(item);
                    }
                }

                foreach (ListItem itemToRemove in itemsToRemove)
                    lstSelectedFlds.Items.Remove(itemToRemove);
            }
        }

        protected void BtnCreateReport_Click(object sender, EventArgs e)
        {
            //D: Erstelle Projekt über DOM
            //US: Create project via DOM
            GenerateLLProject();

            //D: Sicher stellen, dass Projekt erzeugt wurde
            //US: Make sure project was created succesfully
            string path = Path.Combine(Path.GetTempPath(), _projFile);
            if (File.Exists(path))
            {
                ExportConfiguration exportConfiguration = new ExportConfiguration(GetExportTarget(), Path.Combine(Path.GetTempPath(), txtFilename.Text), path);
                try
                {
                    exportConfiguration.Path = BuildExportFilename(exportConfiguration);
                    _ll.Export(exportConfiguration);
                    
                    if (File.Exists(exportConfiguration.Path))
                    {
                        try
                        {
                            Process.Start(exportConfiguration.Path);
                        }
                        catch (Exception ex)
                        {
                            Response.Write("Information: " + ex.Message);
                        }
                    }
                    else
                        Response.Write("File '" + exportConfiguration.Path + "' doesn't exist.");
                }
                catch (Exception ex)
                {
                    Response.Write("Information: " + ex.Message);
                }
            }
            else
                Response.Write("File '" + _projFile + "' doesn't exist.");
        }
		
		protected void Page_Unload(object sender, EventArgs e)
        {
            _ll.Dispose();
        }


        protected LlExportTarget GetExportTarget()
        {
            //D: Hole Export Format
            //US: Get export format
            switch (DropDownListFormat.SelectedIndex)
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
