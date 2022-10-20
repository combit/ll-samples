using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using combit.Reporting.Dom;
using System.Xml.Serialization;
using System.Xml;
using System.Drawing.Printing;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data;
using System.Data.SqlClient;

namespace combit.Reporting.Converters
{
    public class RdlConverter : IDisposable
    {
        private Report _report;
        private Dictionary<string, XmlElement> _reportElements = new Dictionary<string, XmlElement>();
        private Dictionary<string, EmbeddedImageType> _reportEmbeddedImages = new Dictionary<string, EmbeddedImageType>();
        private Dictionary<string, DataSetType> _reportDataSets = new Dictionary<string, DataSetType>();
        private Dictionary<string, DataSourceType> _reportDataSources = new Dictionary<string, DataSourceType>();
        string _reportUnitType = string.Empty;
        private ProjectList Project { get; set; }
        private ListLabel Parent { get; set; }
        private string _tableName = string.Empty;
        private string _projectDirectory = string.Empty;
        private string _sourceDirectory = string.Empty;

        public RdlConverter(string sourceFileName)
        {
            _sourceDirectory = Path.GetDirectoryName(sourceFileName);

            _report = new Report();
            XmlSerializer serializer = new XmlSerializer(typeof(Report));
            using (XmlReader reader = XmlReader.Create(sourceFileName))
            {
                _report = (Report)serializer.Deserialize(reader);
            }

            foreach (object element in _report.Items)
            {
                switch (element.GetType().Name)
                {
                    case "XmlElement":
                        _reportElements.Add((element as XmlElement).LocalName, element as XmlElement);
                        break;
                    case "EmbeddedImagesType":
                        foreach (EmbeddedImageType img in (element as EmbeddedImagesType).EmbeddedImage)
                        {
                            _reportEmbeddedImages.Add(img.Name, img);
                        }
                        break;
                    case "DataSetsType":
                        foreach (DataSetType dataSet in (element as DataSetsType).DataSet)
                        {
                            _reportDataSets.Add(dataSet.Name, dataSet);
                        }
                        break;
                    case "DataSourcesType":
                        foreach (DataSourceType dataSource in (element as DataSourcesType).DataSource)
                        {
                            _reportDataSources.Add(dataSource.Name, dataSource);
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        /// 
        /// Releases all resources used by an instance of the  class.
        /// 
        /// 
        /// This method calls the virtual  method, passing in true, and then suppresses 
        /// finalization of the instance.
        /// 
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// 
        /// Releases unmanaged resources before an instance of the  class is reclaimed by garbage collection.
        /// 
        /// 
        /// This method releases unmanaged resources by calling the virtual  method, passing in false.
        /// 
        ~RdlConverter()
        {
            Dispose(false);
        }

        /// 
        /// Releases the unmanaged resources used by an instance of the  class and optionally releases the managed resources.
        /// 
        /// true to release both managed and unmanaged resources; false to release only unmanaged resources.
        private bool disposed;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    //_report.Dispose();
                }
                disposed = true;
            }
        }


        private System.Drawing.Point _sectionOffset = new System.Drawing.Point();
        int pageFooterOffset = 0;

        public void ConvertReport(ListLabel parent, string sourceFileName, string targetFileName)
        {
            _reportUnitType = _reportElements["ReportUnitType"].InnerText;
            StaticHelper._reportUnitType = _reportUnitType;

            PrinterSettings settings = new PrinterSettings();
            PageSettings pageSetting = settings.DefaultPageSettings;

            Parent = parent;

            _projectDirectory = Path.GetDirectoryName(targetFileName);

            Project = new ProjectList(Parent);
            Project.Open(targetFileName, LlDomFileMode.Create, LlDomAccessMode.ReadWrite, true);
            ConvertPrintOptions(_reportElements["Page"]);

            int topMargin = 0;


            // SectionOffset will hold the top left point of the section that is currently processed
            _sectionOffset.X = 0;
            _sectionOffset.Y = topMargin;

            int footerHeight = _reportElements["Page"]["PageFooter"] != null ? StaticHelper.ConvertUnit(_reportElements["Page"]["PageFooter"]["Height"].InnerText, _reportUnitType) : 0;
            pageFooterOffset = StaticHelper.ConvertUnit(pageSetting.PaperSize.Height.ToString(), "HundredthInch") - footerHeight - StaticHelper.ConvertUnit(_reportElements["Page"]["BottomMargin"].InnerText, _reportUnitType);

            if (_reportElements["Page"]["PageHeader"] != null)
            {
                ConvertSection(_reportElements["Page"]["PageHeader"]["ReportItems"], "Header");
                _sectionOffset.Y += StaticHelper.ConvertUnit(_reportElements["Page"]["PageHeader"]["Height"].InnerText, _reportUnitType);
            }

            ConvertSection(_reportElements["Body"]["ReportItems"], "Detail");

            if (_reportElements["Page"]["PageFooter"] != null)
            {
                _sectionOffset.Y = pageFooterOffset;
                ConvertSection(_reportElements["Page"]["PageFooter"]["ReportItems"], "Footer");
            }

            Project.Save();
            Project.Close();
            Project.Dispose();
        }

        private void ConvertPrintOptions(XmlElement page)
        {
            combit.Reporting.Dom.Region baseRegion = Project.Regions[0];

            PrinterSettings settings = new PrinterSettings();
            // device name
            baseRegion.Device.Name = settings.PrinterName.ToFormula();

            // duplex setting
            baseRegion.Duplex = "0";

            // paper orientation
            if (settings.DefaultPageSettings.Landscape)
                baseRegion.Paper.Orientation = "2";
            else
                baseRegion.Paper.Orientation = "1";

            // paper format
            baseRegion.Paper.Format = settings.DefaultPageSettings.PaperSize.RawKind.ToString();

            // source tray
            baseRegion.SourceTray = settings.DefaultPageSettings.PaperSource.RawKind.ToString();
        }

        private ObjectBase ConvertTextObject(XmlElement textObject)
        {
            ObjectText obj = Project.Objects.AddNewText();
            StaticHelper.SetCommonObjectProperties(obj, textObject, _sectionOffset);

            if (textObject["Style"]["BackgroundColor"] != null)
            {
                obj.Filling.Style = "1";
                obj.Filling.Color = Color.FromName(textObject["Style"]["BackgroundColor"].InnerText.FixSqlColorName()).ToFormula();
            }

            StaticHelper.ConvertBorder(obj.Frame, textObject["Style"]);
            StaticHelper.ConvertPadding(obj.Frame, textObject["Style"]);
            Paragraph paragraph = obj.Paragraphs.AddNew();
            if (textObject["Paragraphs"]["Paragraph"]["TextRuns"]["TextRun"]["Value"] != null)
            {
                paragraph.Contents = StaticHelper.ConvertFormula(textObject["Paragraphs"]["Paragraph"]["TextRuns"]["TextRun"]["Value"].InnerText);
            }
            paragraph.Font.SetFont(GenerateFont(textObject["Paragraphs"]["Paragraph"]["TextRuns"]["TextRun"]["Style"]));
            paragraph.Font.Color = Color.FromName((textObject["Paragraphs"]["Paragraph"]["TextRuns"]["TextRun"]["Style"]["Color"] != null ?
                                   textObject["Paragraphs"]["Paragraph"]["TextRuns"]["TextRun"]["Style"]["Color"].InnerText :
                                   "Black").FixSqlColorName()).ToFormula();

            return obj;
        }

        private ObjectBase ConvertPictureObject(XmlElement pictureObject)
        {
            ObjectDrawing obj = Project.Objects.AddNewDrawing();
            StaticHelper.SetCommonObjectProperties(obj, pictureObject, _sectionOffset);
            StaticHelper.ConvertBorder(obj.Frame, pictureObject["Style"]);
            StaticHelper.ConvertPadding(obj.Frame, pictureObject["Style"]);
            if (pictureObject["Source"].InnerText == "Embedded")
            {
                string fileExtension = PictureFileExtension(_reportEmbeddedImages[pictureObject["Value"].InnerText].Items[0].ToString());
                byte[] b = Convert.FromBase64String(_reportEmbeddedImages[pictureObject["Value"].InnerText].Items[1].ToString());
                string destFilePath = string.Format("{0}\\{1}.{2}", _projectDirectory, pictureObject["Value"].InnerText, fileExtension);
                FileStream fs = new FileStream(destFilePath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                fs.Write(b, 0, b.Length);
                fs.Close();

                obj.Source.Formula = String.Format(CultureInfo.InvariantCulture, "Drawing(ProjectPath$() + \"{0}.{1}\")", pictureObject["Value"].InnerText, fileExtension);
                obj.Source.Mode = "1";
            }

            return obj;
        }

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        private void ConvertTablixObject(XmlElement tablixObject)
        {

            // add a report containter for the area that will be filled by the "bands"
            ObjectReportContainer container = Project.Objects.AddNewReportContainer();
            container.Position.Set((StaticHelper.ConvertUnit(tablixObject["Left"].InnerText, _reportUnitType) + _sectionOffset.X).ToUnit(),
                                   (StaticHelper.ConvertUnit(tablixObject["Top"].InnerText, _reportUnitType) + _sectionOffset.Y).ToUnit(),
                                   StaticHelper.ConvertUnit(tablixObject["Width"].InnerText, _reportUnitType).ToUnit(),
                                   (pageFooterOffset - (StaticHelper.ConvertUnit(tablixObject["Top"].InnerText, _reportUnitType) + _sectionOffset.Y)).ToUnit());

            // add a table to the container
            SubItemTable table = container.SubItems.AddNewTable();
            table.TableId = tablixObject["DataSetName"].InnerText;
            StaticHelper._tableName = table.TableId;

            List<TablixRowMember> tablixRowTypeList = new List<TablixRowMember>();
            List<string> tablixGroupExpressions = new List<string>();
            List<string> tablixExternalGroupExpressions = new List<string>();
            List<XmlElement> tablixExternalGroupHeaders = new List<XmlElement>();
            List<XmlElement> tablixExternalGroupCells = new List<XmlElement>();
            AnalyseTablixRowHierarchy(tablixObject["TablixRowHierarchy"]["TablixMembers"], tablixRowTypeList, tablixGroupExpressions, false, string.Empty, string.Empty, tablixExternalGroupHeaders, tablixExternalGroupCells);

            int rowNumber = 0;
            int groupRowNumber = 0;
            int externalGroupNumber = 0;
            int headerRowHeight = 0;

            List<int> columnsWidth = new List<int>();

            foreach (var column in tablixObject["TablixBody"]["TablixColumns"])
            {
                if (column is XmlElement)
                {
                    columnsWidth.Add(StaticHelper.ConvertUnit((column as XmlElement)["Width"].InnerText, _reportUnitType));
                }
            }

            int tablixHeaderXCoordinate = 0;
            List<int> tablixHeaderWidths = new List<int>();
            foreach (var item in tablixRowTypeList.Where(r => r.Type == TablixRowTypeEnum.HeaderRow).First().RowHeaders)
            {
                tablixHeaderXCoordinate += StaticHelper.ConvertUnit(item["Size"].InnerText, _reportUnitType);
                tablixHeaderWidths.Add(StaticHelper.ConvertUnit(item["Size"].InnerText, _reportUnitType));
            }

            foreach (var item in tablixGroupExpressions)
            {
                if (!tablixRowTypeList.Any(r => r.Type == TablixRowTypeEnum.GroupRow && r.GroupExpression == item))
                    tablixExternalGroupExpressions.Add(item);
            }

            int currentXCoordinate = 0;
            List<string> addedGroups = new List<string>();

            foreach (var row in tablixObject["TablixBody"]["TablixRows"])
            {
                if (row is XmlElement)
                {

                    if (rowNumber == tablixRowTypeList.IndexOf(tablixRowTypeList.Where(r => r.Type == TablixRowTypeEnum.HeaderRow).First()))
                    {
                        TableLineHeader header = table.Lines.Header.AddNew();
                        headerRowHeight = StaticHelper.ConvertUnit((row as XmlElement)["Height"].InnerText, _reportUnitType);
                        for (int i = 0; i < tablixRowTypeList[rowNumber].RowHeaders.Count; i++)
                        {
                            ConvertTablixHeaderCellToField(headerRowHeight, 0, tablixRowTypeList[rowNumber].RowHeaders[i], header);
                        }
                        ConvertTablixCellsToFields(columnsWidth, 0, row as XmlElement, header, "After", string.Empty);
                    }
                    else if (tablixRowTypeList[rowNumber].Type == TablixRowTypeEnum.AggregateRow)
                    {
                        int xCoordinate = 0;
                        for (int i = 0; i < tablixExternalGroupExpressions.Count; i++)
                        {
                            xCoordinate += tablixHeaderWidths[i];
                            if (tablixExternalGroupExpressions[i] == tablixRowTypeList[rowNumber].GroupExpression)
                                break;
                        }
                        if (tablixRowTypeList[rowNumber].KeepWithGroup == "After")
                        {
                            if (!addedGroups.Contains(tablixRowTypeList[rowNumber].GroupExpression))
                            {
                                while (tablixGroupExpressions[groupRowNumber] != tablixRowTypeList[rowNumber].GroupExpression)
                                {
                                    AddTablixExternalGroup(table, tablixGroupExpressions, tablixExternalGroupCells, ref groupRowNumber, ref externalGroupNumber, headerRowHeight, ref currentXCoordinate, addedGroups);
                                }
                                AddTablixExternalGroup(table, tablixGroupExpressions, tablixExternalGroupCells, ref groupRowNumber, ref externalGroupNumber, headerRowHeight, ref currentXCoordinate, addedGroups);
                            }
                            TableLineGroupHeader groupHeader = table.Lines.GroupHeader.AddNew();
                            for (int i = 0; i < tablixRowTypeList[rowNumber].RowHeaders.Count; i++)
                            {
                                ConvertTablixHeaderCellToField(headerRowHeight, xCoordinate, tablixRowTypeList[rowNumber].RowHeaders[i], groupHeader);
                            }
                            groupHeader.GroupBy = StaticHelper.ConvertFormula(tablixRowTypeList[rowNumber].GroupExpression);
                            ConvertTablixCellsToFields(columnsWidth, xCoordinate, row as XmlElement, groupHeader, tablixRowTypeList[rowNumber].KeepWithGroup, groupHeader.GroupBy);
                        }
                        else
                        {
                            TableLineGroupFooter groupFooter = table.Lines.GroupFooter.AddNew();
                            for (int i = 0; i < tablixRowTypeList[rowNumber].RowHeaders.Count; i++)
                            {
                                ConvertTablixHeaderCellToField(headerRowHeight, xCoordinate, tablixRowTypeList[rowNumber].RowHeaders[i], groupFooter);
                            }
                            groupFooter.GroupBy = StaticHelper.ConvertFormula(tablixRowTypeList[rowNumber].GroupExpression);
                            ConvertTablixCellsToFields(columnsWidth, xCoordinate, row as XmlElement, groupFooter, tablixRowTypeList[rowNumber].KeepWithGroup, groupFooter.GroupBy);
                        }
                    }
                    else if (tablixRowTypeList[rowNumber].Type == TablixRowTypeEnum.GroupRow)
                    {
                        while (tablixGroupExpressions[groupRowNumber] != tablixRowTypeList[rowNumber].GroupExpression)
                        {
                            AddTablixExternalGroup(table, tablixGroupExpressions, tablixExternalGroupCells, ref groupRowNumber, ref externalGroupNumber, headerRowHeight, ref currentXCoordinate, addedGroups);
                        }
                        TableLineGroupHeader groupHeader = table.Lines.GroupHeader.AddNew();
                        groupHeader.GroupBy = StaticHelper.ConvertFormula(tablixGroupExpressions[groupRowNumber]);
                        ConvertTablixCellsToFields(columnsWidth, tablixHeaderXCoordinate, row as XmlElement, groupHeader, tablixRowTypeList[rowNumber].KeepWithGroup, groupHeader.GroupBy);
                        addedGroups.Add(tablixGroupExpressions[groupRowNumber]);
                        groupRowNumber++;
                    }
                    else if (tablixRowTypeList[rowNumber].Type == TablixRowTypeEnum.DetailRow)
                    {
                        while (groupRowNumber < tablixGroupExpressions.Count)
                        {
                            AddTablixExternalGroup(table, tablixGroupExpressions, tablixExternalGroupCells, ref groupRowNumber, ref externalGroupNumber, headerRowHeight, ref currentXCoordinate, addedGroups);
                        }
                        TableLineData data = table.Lines.Data.AddNew();
                        ConvertTablixCellsToFields(columnsWidth, tablixHeaderXCoordinate, row as XmlElement, data, string.Empty, string.Empty);
                    }
                    else if (tablixRowTypeList[rowNumber].Type == TablixRowTypeEnum.FooterRow)
                    {
                        TableLineGroupFooter footer = table.Lines.GroupFooter.AddNew();
                        for (int i = 0; i < tablixRowTypeList[rowNumber].RowHeaders.Count; i++)
                        {
                            ConvertTablixHeaderCellToField(headerRowHeight, 0, tablixRowTypeList[rowNumber].RowHeaders[i], footer);
                        }
                        ConvertTablixCellsToFields(columnsWidth, 0, row as XmlElement, footer, string.Empty, string.Empty);
                    }
                    rowNumber++;
                }
            }
        }

        private void AddTablixExternalGroup(SubItemTable table, List<string> tablixGroupExpressions, List<XmlElement> tablixExternalGroupCells, ref int groupRowNumber, ref int externalGroupNumber, int headerRowHeight, ref int currentXCoordinate, List<string> addedGroups)
        {
            TableLineGroupHeader externalgroupHeader = table.Lines.GroupHeader.AddNew();
            externalgroupHeader.GroupBy = StaticHelper.ConvertFormula(tablixGroupExpressions[groupRowNumber]);
            ConvertTablixHeaderCellToField(headerRowHeight, currentXCoordinate, tablixExternalGroupCells[externalGroupNumber], externalgroupHeader);
            currentXCoordinate += StaticHelper.ConvertUnit(tablixExternalGroupCells[externalGroupNumber]["Size"].InnerText, _reportUnitType);
            addedGroups.Add(tablixGroupExpressions[groupRowNumber]);
            externalGroupNumber++;
            groupRowNumber++;
        }

        private void AnalyseTablixRowHierarchy(XmlElement tablixMembers, List<TablixRowMember> tablixRowTypeList, List<string> tablixGroupExpressions, bool isGroup, string groupExpression, string sortExpression, List<XmlElement> tablixRowHeaders, List<XmlElement> tablixExternalGroupCells)
        {
            foreach (var member in tablixMembers)
            {
                if (member is XmlElement)
                {
                    if ((member as XmlElement)["TablixMembers"] != null)
                    {
                        if ((member as XmlElement)["Group"] != null)
                        {
                            tablixGroupExpressions.Add((member as XmlElement)["Group"]["GroupExpressions"]["GroupExpression"].InnerText);
                            if ((member as XmlElement)["TablixHeader"] != null)
                                tablixExternalGroupCells.Add((member as XmlElement)["TablixHeader"]);
                            AnalyseTablixRowHierarchy((member as XmlElement)["TablixMembers"], tablixRowTypeList, tablixGroupExpressions, true, (member as XmlElement)["Group"]["GroupExpressions"]["GroupExpression"].InnerText, (member as XmlElement)["SortExpressions"]["SortExpression"]["Value"].InnerText, tablixRowHeaders, tablixExternalGroupCells);
                        }
                        else
                        {
                            if ((member as XmlElement)["TablixHeader"] != null)
                                tablixRowHeaders.Add((member as XmlElement)["TablixHeader"]);
                            AnalyseTablixRowHierarchy((member as XmlElement)["TablixMembers"], tablixRowTypeList, tablixGroupExpressions, false, groupExpression, sortExpression, tablixRowHeaders, tablixExternalGroupCells);
                        }
                    }
                    else
                    {
                        if ((member as XmlElement)["Group"] != null)
                        {
                            if ((member as XmlElement)["Group"]["GroupExpressions"] == null)
                            {
                                tablixRowTypeList.Add(new TablixRowMember(TablixRowTypeEnum.DetailRow, string.Empty, string.Empty, string.Empty, tablixRowHeaders));
                                tablixRowHeaders.Clear();
                            }
                        }
                        else
                        {
                            if ((member as XmlElement)["KeepWithGroup"] != null || (member as XmlElement)["TablixHeader"] != null)
                            {
                                if ((member as XmlElement)["TablixHeader"] != null)
                                    tablixRowHeaders.Add((member as XmlElement)["TablixHeader"]);
                                if (groupExpression != string.Empty)
                                {
                                    tablixRowTypeList.Add(new TablixRowMember(TablixRowTypeEnum.AggregateRow, groupExpression, sortExpression, (member as XmlElement)["KeepWithGroup"].InnerText, tablixRowHeaders));
                                    tablixRowHeaders.Clear();
                                }
                                else
                                {
                                    tablixRowTypeList.Add(new TablixRowMember(TablixRowTypeEnum.FooterRow, string.Empty, string.Empty, (member as XmlElement)["KeepWithGroup"] != null ? (member as XmlElement)["KeepWithGroup"].InnerText : string.Empty, tablixRowHeaders));
                                    tablixRowHeaders.Clear();
                                }
                            }
                            else
                            {
                                if (tablixRowTypeList.Any(r => r.Type == TablixRowTypeEnum.HeaderRow))
                                {
                                    tablixRowTypeList.Add(new TablixRowMember(TablixRowTypeEnum.GroupRow, groupExpression, sortExpression, string.Empty, tablixRowHeaders));
                                    tablixRowHeaders.Clear();
                                }
                                else
                                {
                                    tablixRowTypeList.Add(new TablixRowMember(TablixRowTypeEnum.HeaderRow, string.Empty, string.Empty, string.Empty, tablixRowHeaders));
                                    tablixRowHeaders.Clear();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void ConvertSection(XmlElement section, string sectionName)
        {
            ObjectBase obj;
            foreach (var item in section)
            {
                if (item is XmlElement)
                {
                    switch ((item as XmlElement).LocalName)
                    {
                        case "Line":
                            break;
                        case "Rectangle":
                            break;
                        case "Textbox":
                            obj = ConvertTextObject(item as XmlElement);
                            if (sectionName == "Detail")
                                obj.LayerId = 1;
                            break;
                        case "Image":
                            obj = ConvertPictureObject(item as XmlElement);
                            if (sectionName == "Detail")
                                obj.LayerId = 1;
                            break;
                        case "Subreport":
                            break;
                        case "Chart":
                            break;
                        case "GaugePanel":
                            break;
                        case "Tablix":
                            ConvertTablixObject(item as XmlElement);
                            break;
                        case "CustomReportItem":
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void ConvertTablixHeaderCellToField(int headerHeight, int columnLeft, XmlElement tablixHeader, TableLineBase data)
        {
            if (columnLeft != 0)
                CreateEmptyTextField(data, columnLeft, headerHeight);
            ConvertTablixCellToField(tablixHeader, data, StaticHelper.ConvertUnit(tablixHeader["Size"].InnerText, _reportUnitType), headerHeight, string.Empty, string.Empty);
        }

        private void ConvertTablixCellsToFields(List<int> columnsWidth, int columnLeft, XmlElement row, TableLineBase data, string keepWithGroup, string groupExpression)
        {
            int columnNumber = 0;
            int rowHeight = StaticHelper.ConvertUnit((row as XmlElement)["Height"].InnerText, _reportUnitType);
            if (columnLeft != 0 && data.Fields.Count == 0)
                CreateEmptyTextField(data, columnLeft, rowHeight);
            foreach (var cell in row["TablixCells"])
            {
                if (cell is XmlElement)
                {
                    ConvertTablixCellToField(cell as XmlElement, data, columnsWidth[columnNumber], rowHeight, keepWithGroup, groupExpression);
                    columnNumber++;
                }
            }
        }

        private void ConvertTablixCellToField(XmlElement cell, TableLineBase tableLine, int cellWidth, int cellHeight, string keepWithGroup, string groupExpression)
        {
            XmlElement content = cell;
            foreach (var item in cell["CellContents"])
            {
                if (item is XmlElement)
                {
                    content = item as XmlElement;
                    break;
                }
            }

            switch (content.LocalName)
            {
                case "Textbox":
                    ConvertTextObjectToField(content, tableLine, cellWidth, cellHeight, keepWithGroup, groupExpression);
                    break;
                case "Image":
                    ConvertPictureObjectToField(content, tableLine, cellWidth, cellHeight);
                    break;
                default:
                    break;
            }

        }

        private void CreateEmptyTextField(TableLineBase tableLine, int cellWidth, int cellHeight)
        {
            TableFieldText textField;

            // now create the actual field
            textField = tableLine.Fields.AddNewText();
            textField.Width = cellWidth.ToUnit();
            textField.Filling.Style = "0";
            textField.Frame.Default = "False";
            textField.FixedHeight = cellHeight.ToUnit();
            textField.Frame.Bottom.Line.Visible = "False";
            textField.Frame.Top.Line.Visible = "False";
            textField.Frame.Left.Line.Visible = "False";
            textField.Frame.Right.Line.Visible = "False";
        }

        private void ConvertTextObjectToField(XmlElement obj, TableLineBase tableLine, int cellWidth, int cellHeight, string keepWithGroup, string groupExpression)
        {
            TableFieldText textField;

            // now create the actual field
            textField = tableLine.Fields.AddNewText();
            StaticHelper.SetCommonFieldProperties(textField, obj, cellWidth);
            textField.Font.SetFont(GenerateFont(obj["Paragraphs"]["Paragraph"]["TextRuns"]["TextRun"]["Style"]));
            textField.Font.Color = Color.FromName((obj["Paragraphs"]["Paragraph"]["TextRuns"]["TextRun"]["Style"]["Color"] != null ?
                                   obj["Paragraphs"]["Paragraph"]["TextRuns"]["TextRun"]["Style"]["Color"].InnerText :
                                   "Black").FixSqlColorName()).ToFormula();
            if (obj["Style"]["BackgroundColor"] != null)
            {
                textField.Filling.Style = "1";
                textField.Filling.Color = Color.FromName(obj["Style"]["BackgroundColor"].InnerText.FixSqlColorName()).ToFormula();
            }
            if (obj["Paragraphs"]["Paragraph"]["TextRuns"]["TextRun"]["Value"] != null)
            {
                textField.Contents = StaticHelper.ConvertFormula(obj["Paragraphs"]["Paragraph"]["TextRuns"]["TextRun"]["Value"].InnerText, keepWithGroup, groupExpression);
            }
            textField.FixedHeight = cellHeight.ToUnit();
            StaticHelper.ConvertObjectFormat(textField, obj);
        }

        private void ConvertPictureObjectToField(XmlElement obj, TableLineBase tableLine, int cellWidth, int cellHeight)
        {
            TableFieldDrawing drawingField;
            // now create the actual field
            drawingField = tableLine.Fields.AddNewDrawing();
            StaticHelper.SetCommonFieldProperties(drawingField, obj, cellWidth);

            if (obj["Value"] != null)
            {
                drawingField.Contents = string.Format("{0}", StaticHelper.ConvertFormula(obj["Value"].InnerText));
            }
        }

        private Font GenerateFont(XmlElement style)
        {
            string fontFamily = "Arial";
            if (style["FontFamily"] != null)
                fontFamily = style["FontFamily"].InnerText;
            float fontSize = 10;
            if (style["FontSize"] != null)
                fontSize = float.Parse(style["FontSize"].InnerText);
            FontStyle fontStyle = new FontStyle();
            if (style["FontWeight"] != null && style["FontWeight"].InnerText == "Bold")
                fontStyle = FontStyle.Bold;
            if (style["FontStyle"] != null && style["FontStyle"].InnerText == "Italic")
            {
                if (fontStyle == FontStyle.Bold)
                    fontStyle = FontStyle.Bold | FontStyle.Italic;
                else
                    fontStyle = FontStyle.Italic;
            }
            return new Font(fontFamily, fontSize, fontStyle, GraphicsUnit.Point);
        }

        private string PictureFileExtension(string mimeType)
        {
            switch (mimeType)
            {
                case "image/bmp":
                    return "bmp";
                case "image/jpeg":
                    return "jpg";
                case "image/x-png":
                case "image/png":
                    return "png";
                default:
                    return string.Empty;
            }
        }

        public Dictionary<string, IDbCommand> GetDataSource(SqlCredential credential)
        {
            Dictionary<string, IDbCommand> result = new Dictionary<string, IDbCommand>();
            foreach (var dataSet in _reportDataSets.Values)
            {
                DataSourceType dataSource = _reportDataSources[(dataSet.Items[0] as QueryType).Items[0].ToString()];
                SqlConnection con = null;
                if (dataSource.Items[0] is ConnectionPropertiesType)
                {
                    int integratedSecurityIndex = (dataSource.Items[0] as ConnectionPropertiesType).ItemsElementName.ToList().IndexOf(ItemsChoiceType.IntegratedSecurity);
                    if (integratedSecurityIndex > -1)
                    {
                        if ((dataSource.Items[0] as ConnectionPropertiesType).Items[integratedSecurityIndex].ToString().ToLower() == "true")
                            con = new SqlConnection(string.Format("{0};Integrated Security=True", (dataSource.Items[0] as ConnectionPropertiesType).Items[1]));
                        else
                        {
                            string connString = (dataSource.Items[0] as ConnectionPropertiesType).Items[1].ToString().Replace("DataSource", "Data Source").Replace("UserID", "User ID").Replace("InitialCatalog", "Initial Catalog");
                            con = new SqlConnection(connString);
                        }
                    }
                }
                else
                {
                    string reportDataSourceFileName = string.Format("{0}\\{1}.rds", _sourceDirectory, dataSource.Items[0]);
                    using (XmlReader reader = XmlReader.Create(reportDataSourceFileName))
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(reader);
                        XmlElement el = doc.DocumentElement;
                        if (el["ConnectionProperties"]["IntegratedSecurity"].InnerText == "true")
                            con = new SqlConnection(string.Format("{0};Integrated Security=True", el["ConnectionProperties"]["ConnectString"].InnerText));
                    }
                }
                SqlCommand com = new SqlCommand((dataSet.Items[0] as QueryType).Items[1].ToString(), con);
                result.Add(dataSet.Name, com);
            }
            return result;
        }
    }

    internal class TablixRowMember
    {
        internal List<XmlElement> RowHeaders;
        internal TablixRowTypeEnum Type;
        internal string GroupExpression;
        internal string SortExpression;
        internal string KeepWithGroup;

        public TablixRowMember(TablixRowTypeEnum type, string groupExpression, string sortExpression, string keepWithGroup, List<XmlElement> rowHeaders)
        {
            Type = type;
            GroupExpression = groupExpression;
            SortExpression = sortExpression;
            KeepWithGroup = keepWithGroup;
            RowHeaders = new List<XmlElement>();
            foreach (var item in rowHeaders)
                RowHeaders.Add(item);
        }
    }

    enum TablixRowTypeEnum
    {
        HeaderRow,
        GroupRow,
        DetailRow,
        AggregateRow,
        FooterRow
    }
}
