using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using combit.ListLabel25.Dom;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace combit.ListLabel25.Converters
{
    [CLSCompliant(true)]
    public class RptConverter : IDisposable
    {
        private ReportDocument ReportDocument { get; set; }
        private ProjectList Project { get; set; }
        private ListLabel Parent { get; set; }

        public RptConverter()
        {
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
        ~RptConverter()
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
                    ReportDocument.Dispose();
                }
                disposed = true;
            }
        }


        private System.Drawing.Point _sectionOffset = new System.Drawing.Point();

        public void ConvertReport(ListLabel parent, string sourceFileName, string targetFileName, string tableId)
        {
            ReportDocument = new ReportDocument();
            ReportDocument.Load(sourceFileName);
            Parent = parent;

            Project = new ProjectList(Parent);
            Project.Open(targetFileName, LlDomFileMode.Create, LlDomAccessMode.ReadWrite, true);
            ConvertPrintOptions(ReportDocument.PrintOptions);
            int topMargin = StaticHelper.ConvertUnit(ReportDocument.PrintOptions.PageMargins.topMargin);


            // SectionOffset will hold the top left point of the section that is currently processed
            _sectionOffset.X = StaticHelper.ConvertUnit(ReportDocument.PrintOptions.PageMargins.leftMargin);
            _sectionOffset.Y = topMargin;

            // PageFooterOffset will hold the top coordinate of the topmost page footer section
            int pageFooterOffset = StaticHelper.ConvertUnit(ReportDocument.PrintOptions.PageContentHeight + ReportDocument.PrintOptions.PageMargins.topMargin);

            // first, convert the report header and collect sizes of page footer sections
            foreach (Section section in ReportDocument.ReportDefinition.Sections)
            {
                if (!section.SectionFormat.EnableSuppress)
                {
                    try
                    {
                        if (section.Kind == AreaSectionKind.ReportHeader)
                        {
                            foreach (ReportObject obj in section.ReportObjects)
                            {
                                // convert object and assign to first page layer
                                ObjectBase llObj = ConvertReportObject(obj);
                                if (llObj != null)
                                    llObj.LayerId = 1;
                            }
                            _sectionOffset.Y += StaticHelper.ConvertUnit(section.Height);
                        }
                        else if (section.Kind == AreaSectionKind.PageFooter)
                        {
                            // need to collate offsets first in order to be able to position correctly
                            pageFooterOffset = pageFooterOffset - StaticHelper.ConvertUnit(section.Height);
                        }
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        //there are some section.Kind that have not match in DotNetAreaSectionKind enumeration(inside Crystal Report.Net) and throw this exception
                        if (!ex.StackTrace.Contains("CrystalDecisions.ReportAppServer.ConvertDotNetToErom.EromAreaSectionKindEnumToDotNetAreaSectionKind(CrAreaSectionKindEnum eAreaSectionKind)"))
                            throw ex;
                    }
                }
            }

            // convert page footers in second pass
            int totalFooterHeight = 0;
            foreach (Section section in ReportDocument.ReportDefinition.Sections)
            {
                if (!section.SectionFormat.EnableSuppress)
                {
                    try
                    {
                        if (section.Kind == AreaSectionKind.PageFooter)
                        {
                            foreach (ReportObject obj in section.ReportObjects)
                            {
                                // convert object
                                ObjectBase llObj = ConvertReportObject(obj);

                                // correct position
                                llObj.Position.Top = (pageFooterOffset + StaticHelper.ConvertUnit(totalFooterHeight + obj.Top)).ToUnit();
                            }
                            totalFooterHeight += section.Height;

                        }
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        //there are some section.Kind that have not match in DotNetAreaSectionKind enumeration(inside Crystal Report.Net) and throw this exception
                        if (!ex.StackTrace.Contains("CrystalDecisions.ReportAppServer.ConvertDotNetToErom.EromAreaSectionKindEnumToDotNetAreaSectionKind(CrAreaSectionKindEnum eAreaSectionKind)"))
                            throw ex;
                    }
                }
            }

            // add invisible rectangle for linkage
            ObjectRectangle rect = Project.Objects.AddNewRectangle();
            rect.Filling.Pattern = "0";
            rect.Position.Set(0, topMargin, 1000, _sectionOffset.Y - topMargin);
            rect.Frame.Style = "0";
            rect.LayerId = 1;
            rect.Name = "Positioning rectangle";

            // add a report containter for the area that will be filled by the "bands"
            ObjectReportContainer container = Project.Objects.AddNewReportContainer();
            container.Position.Set(_sectionOffset.X.ToUnit(), _sectionOffset.Y.ToUnit(), StaticHelper.ConvertUnit(ReportDocument.PrintOptions.PageContentWidth).ToUnit(), (pageFooterOffset - _sectionOffset.Y).ToUnit());

            // link the report containter to the positioning rectangle
            container.LinkTo(rect, LlDomVerticalLinkType.RelativeToEnd, LlDomVerticalSizeAdaptionType.Inverse);

            // add a table to the container
            SubItemTable table = container.SubItems.AddNewTable();
            table.TableId = tableId;

            // third pass, this time convert "the rest"
            foreach (Section section in ReportDocument.ReportDefinition.Sections)
            {
                try {
                    switch (section.Kind)
                    {
                        case AreaSectionKind.PageHeader:
                            ConvertPageHeaderSection(section, table);
                            break;
                        case AreaSectionKind.Detail:
                            ConvertDetailSection(section, table);
                            break;
                        case AreaSectionKind.GroupHeader:
                            ConvertGroupHeaderSection(section, table);
                            break;
                        case AreaSectionKind.GroupFooter:
                            ConvertGroupFooterSection(section, table);
                            break;
                        case AreaSectionKind.ReportFooter:
                            ConvertReportFooterSection(section, table);
                            break;
                    }
                }
                catch (IndexOutOfRangeException ex)
                {
                    //there are some section.Kind that have not match in DotNetAreaSectionKind enumeration(inside Crystal Report.Net) and throw this exception
                    if (!ex.StackTrace.Contains("CrystalDecisions.ReportAppServer.ConvertDotNetToErom.EromAreaSectionKindEnumToDotNetAreaSectionKind(CrAreaSectionKindEnum eAreaSectionKind)"))
                        throw ex;
                }

            }

            Project.Save();
            Project.Close();
            Project.Dispose();
        }

        #region Conversion Functions (Objects)

        private void ConvertPrintOptions(PrintOptions printOptions)
        {
            Region baseRegion = Project.Regions[0];

            // device name
            baseRegion.Device.Name = printOptions.PrinterName.ToFormula();

            // duplex setting
            baseRegion.Duplex = ((int)printOptions.PrinterDuplex).ToString();

            // paper orientation
            switch (printOptions.PaperOrientation)
            {
                case PaperOrientation.Landscape:
                    baseRegion.Paper.Orientation = "2";
                    break;
                case PaperOrientation.Portrait:
                    baseRegion.Paper.Orientation = "1";
                    break;
            }

            // paper format
            baseRegion.Paper.Format = ((int)printOptions.PaperSize).ToString(CultureInfo.InvariantCulture);

            // source tray
            baseRegion.SourceTray = ((int)printOptions.PaperSource).ToString(CultureInfo.InvariantCulture);
        }

        private ObjectBase ConvertReportObject(ReportObject obj)
        {
            switch (obj.Kind)
            {
                case ReportObjectKind.TextObject:
                case ReportObjectKind.FieldHeadingObject:
                    return ConvertTextObject(obj as TextObject);
                case ReportObjectKind.FieldObject:
                    return ConvertFieldObject(obj as FieldObject);
                case ReportObjectKind.BoxObject:
                    return ConvertBoxObject(obj as BoxObject);
                case ReportObjectKind.PictureObject:
                    return ConvertPictureObject(obj as PictureObject);
                case ReportObjectKind.LineObject:
                    return ConvertLineObject(obj as LineObject);
                default:
                    return null;
            }
        }

        private ObjectBase ConvertTextObject(TextObject textObject)
        {
            ObjectText obj = Project.Objects.AddNewText();
            StaticHelper.SetCommonObjectProperties(obj, textObject, _sectionOffset);

            // add a small height tolerance to prevent cropping of font descents
            obj.Position.Height = String.Concat(obj.Position.Height, "+", StaticHelper.ConvertUnit(50).ToUnit());

            obj.Filling.Color = textObject.Color.ToFormula();
            StaticHelper.ConvertBorder(obj.Frame, textObject.Border);
            Paragraph paragraph = obj.Paragraphs.AddNew();
            paragraph.Contents = textObject.Text.ToFormula();
            paragraph.Font.SetFont(textObject.Font);
            paragraph.Font.Color = textObject.Color.ToFormula();
            return obj;
        }

        private ObjectBase ConvertFieldObject(FieldObject fieldObject)
        {
            ObjectText obj = Project.Objects.AddNewText();
            StaticHelper.SetCommonObjectProperties(obj, fieldObject, _sectionOffset);

            // add a small height tolerance to prevent cropping of font descents
            obj.Position.Height = String.Concat(obj.Position.Height, "+", StaticHelper.ConvertUnit(50).ToUnit());

            obj.Filling.Color = fieldObject.Color.ToFormula();
            StaticHelper.ConvertBorder(obj.Frame, fieldObject.Border);
            Paragraph paragraph = obj.Paragraphs.AddNew();
            paragraph.Contents = StaticHelper.ConvertFormula(fieldObject.DataSource.FormulaName);
            paragraph.Font.SetFont(fieldObject.Font);
            paragraph.Font.Color = fieldObject.Color.ToFormula();
            return obj;
        }

        private ObjectBase ConvertBoxObject(BoxObject boxObject)
        {
            ObjectRectangle obj = Project.Objects.AddNewRectangle();
            StaticHelper.SetCommonObjectProperties(obj, boxObject, _sectionOffset);

            if (boxObject.Border.HasDropShadow)
            {
                obj.Shadow.Style = "1";
                obj.Shadow.Color = boxObject.LineColor.ToFormula();
                obj.Shadow.Width = "UnitFromSCM(1000)";
            }

            obj.Frame.Style = (boxObject.LineStyle != LineStyle.NoLine ? "1" : "0");
            obj.Frame.Color = boxObject.LineColor.ToFormula();
            obj.Frame.Width = StaticHelper.ConvertUnit(boxObject.LineThickness).ToUnit();
            obj.Filling.Color = boxObject.FillColor.ToFormula();
            obj.Filling.Style = "1";
            return obj;
        }

        private ObjectBase ConvertPictureObject(PictureObject pictureObject)
        {
            ObjectDrawing obj = Project.Objects.AddNewDrawing();
            StaticHelper.SetCommonObjectProperties(obj, pictureObject, _sectionOffset);
            StaticHelper.ConvertBorder(obj.Frame, pictureObject.Border);

            PropertyInfo[] props = typeof(ReportObject).GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (PropertyInfo prop in props)
            {
                if (prop.Name == "RasReportObject")
                {
                    // comment out this block if you're using VS2008 or lower
                    dynamic rasReportObject = prop.GetValue(pictureObject, null);
                    if (rasReportObject != null && rasReportObject.GraphicLocationFormula.Text != null)
                    {
                        obj.Source.Formula = String.Format(CultureInfo.InvariantCulture, "Drawing({0})", rasReportObject.GraphicLocationFormula.Text);
                        obj.Source.Mode = "1";
                    }
                    break;
                }
            }

            return obj;
        }

        private ObjectBase ConvertLineObject(LineObject lineObject)
        {
            ObjectLine obj = Project.Objects.AddNewLine();
            StaticHelper.SetCommonObjectProperties(obj, lineObject, _sectionOffset);

            switch (lineObject.LineStyle)
            {
                case LineStyle.SingleLine:
                    obj.LineType = "0";
                    break;
                case LineStyle.DotLine:
                    obj.LineType = "1";
                    break;
                case LineStyle.DashLine:
                    obj.LineType = "2";
                    break;
                default:
                    obj.LineType = "0";
                    break;
            }

            obj.Color = lineObject.LineColor.ToFormula();
            obj.Width = StaticHelper.ConvertUnit(lineObject.LineThickness).ToUnit();
            return obj;
        }
        #endregion

        #region Conversion Functions (Fields)

        private void ConvertPageHeaderSection(Section section, SubItemTable table)
        {
            // step 1: collect top coordinates (determines number of required line definitions)
            ReadOnlyCollection<int> coords = StaticHelper.DistinctTopCoordinates(section);

            // step 2: create suitable header lines
            foreach (int coordinate in coords)
            {
                TableLineHeader header = table.Lines.Header.AddNew();
                header.ReservedSpace.Top = StaticHelper.ConvertUnit(coordinate).ToUnit();
                header.Anchor.Contents = "1";
                var objects = from ReportObject obj in section.ReportObjects
                              where obj.Top == coordinate
                              orderby obj.Left
                              select obj;

                ConvertObjectsToFields(objects, header);
            }

            // finally, ensure the minimal height is at least the section height (while growth is allowed)
            if (table.Lines.Header.Count > 0)
            {
                TableFieldText textField = StaticHelper.AddEmptyField(table.Lines.Header[0], "UnitFromSCM(100)");
                textField.OptimizeSpaces = "False";
                textField.Contents = " ".ToFormula();
                textField.FixedHeight = StaticHelper.ConvertUnit(section.Height - (coords.Count > 0 ? coords[0] : 0)).ToUnit();
            }
        }

        private void ConvertDetailSection(Section section, SubItemTable table)
        {
            // step 1: collect top coordinates (determines number of required line definitions)
            ReadOnlyCollection<int> coords = StaticHelper.DistinctTopCoordinates(section);

            // step 2: create suitable table lines
            foreach (int coordinate in coords)
            {
                TableLineData data = table.Lines.Data.AddNew();
                data.Anchor.Contents = "1";
                data.ReservedSpace.Top = StaticHelper.ConvertUnit(coordinate).ToUnit();

                // find all matching objects
                var objects = from ReportObject obj in section.ReportObjects
                              where obj.Top == coordinate
                              orderby obj.Left
                              select obj;

                ConvertObjectsToFields(objects, data);
            }

            // finally, ensure the minimal height is at least the section height (while growth is allowed)
            if (table.Lines.Data.Count > 0)
            {
                TableFieldText textField = StaticHelper.AddEmptyField(table.Lines.Data[0], "UnitFromSCM(100)");
                textField.OptimizeSpaces = "False";
                textField.Contents = " ".ToFormula();
                textField.FixedHeight = StaticHelper.ConvertUnit(section.Height - (coords.Count > 0 ? coords[0] : 0)).ToUnit();
            }
        }

        private void ConvertReportFooterSection(Section section, SubItemTable table)
        {
            // step 1: collect top coordinates (determines number of required line definitions)
            ReadOnlyCollection<int> coords = StaticHelper.DistinctTopCoordinates(section);

            // step 2: create suitable table lines
            foreach (int coordinate in coords)
            {
                TableLineFooter footer = table.Lines.Footer.AddNew();
                footer.Anchor.Contents = "1";
                footer.Condition = "LastFooterThisTable()";
                footer.ReservedSpace.Top = StaticHelper.ConvertUnit(coordinate).ToUnit();

                // find all matching objects
                var objects = from ReportObject obj in section.ReportObjects
                              where obj.Top == coordinate
                              orderby obj.Left
                              select obj;

                ConvertObjectsToFields(objects, footer);
            }

            // finally, ensure the minimal height is at least the section height (while growth is allowed)
            if (table.Lines.Footer.Count > 0)
            {
                TableFieldText textField = StaticHelper.AddEmptyField(table.Lines.Footer[0], "UnitFromSCM(100)");
                textField.OptimizeSpaces = "False";
                textField.Contents = " ".ToFormula();
                textField.FixedHeight = StaticHelper.ConvertUnit(section.Height - (coords.Count > 0 ? coords[0] : 0)).ToUnit();
            }

        }

        private void ConvertGroupFooterSection(Section section, SubItemTable table)
        {
            // retrieve the grouping field, only single grouping supported (no nested groupings)
            FieldDefinition groupField = ReportDocument.DataDefinition.Groups[0].ConditionField;
            string groupBy = StaticHelper.ConvertGroupFieldDefinition(groupField);


            // step 1: collect top coordinates (determines number of required line definitions)
            ReadOnlyCollection<int> coords = StaticHelper.DistinctTopCoordinates(section);

            // step 2: create suitable table lines
            foreach (int coordinate in coords)
            {
                TableLineGroupFooter groupFooter = table.Lines.GroupFooter.AddNew();
                groupFooter.Anchor.Contents = "1";
                groupFooter.ReservedSpace.Top = StaticHelper.ConvertUnit(coordinate).ToUnit();

                // find all matching objects
                var objects = from ReportObject obj in section.ReportObjects
                              where obj.Top == coordinate
                              orderby obj.Left
                              select obj;

                ConvertObjectsToFields(objects, groupFooter);
                groupFooter.GroupBy = groupBy;
            }

            // finally, ensure the minimal height is at least the section height (while growth is allowed)
            if (table.Lines.GroupFooter.Count > 0)
            {
                TableFieldText textField = StaticHelper.AddEmptyField(table.Lines.GroupFooter[0], "UnitFromSCM(100)");
                textField.OptimizeSpaces = "False";
                textField.Contents = " ".ToFormula();
                textField.FixedHeight = StaticHelper.ConvertUnit(section.Height - (coords.Count > 0 ? coords[0] : 0)).ToUnit();
            }

        }

        private void ConvertGroupHeaderSection(Section section, SubItemTable table)
        {
            // retrieve the grouping field, only single grouping supported (no nested groupings)
            FieldDefinition groupField = ReportDocument.DataDefinition.Groups[0].ConditionField;
            string groupBy = StaticHelper.ConvertGroupFieldDefinition(groupField);

            // step 1: collect top coordinates (determines number of required line definitions)
            ReadOnlyCollection<int> coords = StaticHelper.DistinctTopCoordinates(section);

            // step 2: create suitable table lines
            foreach (int coordinate in coords)
            {
                TableLineGroupHeader groupHeader = table.Lines.GroupHeader.AddNew();
                groupHeader.Anchor.Contents = "1";
                groupHeader.ReservedSpace.Top = StaticHelper.ConvertUnit(coordinate).ToUnit();

                // find all matching objects
                var objects = from ReportObject obj in section.ReportObjects
                              where obj.Top == coordinate
                              orderby obj.Left
                              select obj;

                ConvertObjectsToFields(objects, groupHeader);
                groupHeader.GroupBy = groupBy;
            }

            // finally, ensure the minimal height is at least the section height (while growth is allowed)
            if (table.Lines.GroupHeader.Count > 0)
            {
                TableFieldText textField = StaticHelper.AddEmptyField(table.Lines.GroupHeader[0], "UnitFromSCM(100)");
                textField.OptimizeSpaces = "False";
                textField.Contents = " ".ToFormula();
                textField.FixedHeight = StaticHelper.ConvertUnit(section.Height - (coords.Count > 0 ? coords[0] : 0)).ToUnit();
            }
        }


        private void ConvertObjectsToFields(IEnumerable<ReportObject> objects, TableLineBase tableLine)
        {
            CurrentXCoordinate = 0;
            foreach (ReportObject obj in objects)
            {
                switch (obj.Kind)
                {
                    case ReportObjectKind.FieldHeadingObject:
                        {
                            ConvertFieldHeadingObjectToField(obj as FieldHeadingObject, tableLine);
                            break;
                        }
                    case ReportObjectKind.FieldObject:
                        {
                            ConvertFieldObjectToField(obj as FieldObject, tableLine);
                            break;
                        }
                    case ReportObjectKind.TextObject:
                        {
                            ConvertTextObjectToField(obj as TextObject, tableLine);
                            break;
                        }
                    case ReportObjectKind.PictureObject:
                        {
                            ConvertPictureObjectToField(obj as PictureObject, tableLine);
                            break;
                        }
                }
            }
        }

        private int CurrentXCoordinate
        {
            get;
            set;
        }


        private void ConvertFieldHeadingObjectToField(FieldHeadingObject obj, TableLineBase tableLine)
        {
            TableFieldText textField;
            // add empty field if offset is positive
            int offset = StaticHelper.ConvertUnit(obj.Left) - CurrentXCoordinate;
            if (offset > 0)
            {
                StaticHelper.AddEmptyField(tableLine, offset.ToUnit());
                CurrentXCoordinate += offset;
            }

            // now create the actual field
            textField = tableLine.Fields.AddNewText();
            StaticHelper.SetCommonFieldProperties(textField, obj);
            textField.Font.SetFont(obj.Font);
            textField.Font.Color = obj.Color.ToFormula();
            textField.Contents = StaticHelper.ConvertFormula(obj.Text);
            StaticHelper.ConvertObjectFormat(textField, obj.ObjectFormat);
            CurrentXCoordinate += StaticHelper.ConvertUnit(obj.Width);
        }

        private void ConvertFieldObjectToField(FieldObject obj, TableLineBase tableLine)
        {
            TableFieldText textField;
            // add empty field if offset is positive
            int offset = StaticHelper.ConvertUnit(obj.Left) - CurrentXCoordinate;
            if (offset > 0)
            {
                StaticHelper.AddEmptyField(tableLine, offset.ToUnit());
                CurrentXCoordinate += offset;
            }

            // now create the actual field
            textField = tableLine.Fields.AddNewText();
            StaticHelper.SetCommonFieldProperties(textField, obj);
            textField.Font.SetFont(obj.Font);
            textField.Font.Color = obj.Color.ToFormula();
            if (obj.DataSource != null)
            {
                textField.Contents = StaticHelper.ConvertFormula(obj.DataSource.FormulaName);
            }
            StaticHelper.ConvertObjectFormat(textField, obj.ObjectFormat);
            CurrentXCoordinate += StaticHelper.ConvertUnit(obj.Width);
        }

        private void ConvertTextObjectToField(TextObject obj, TableLineBase tableLine)
        {
            TableFieldText textField;
            // add empty field if offset is positive
            int offset = StaticHelper.ConvertUnit(obj.Left) - CurrentXCoordinate;
            if (offset > 0)
            {
                StaticHelper.AddEmptyField(tableLine, offset.ToUnit());
                CurrentXCoordinate += offset;
            }

            // now create the actual field
            textField = tableLine.Fields.AddNewText();
            StaticHelper.SetCommonFieldProperties(textField, obj);
            textField.Font.SetFont(obj.Font);
            textField.Font.Color = obj.Color.ToFormula();

            if (obj.Text != null)
            {
                textField.Contents = obj.Text.ToFormula();
            }
            StaticHelper.ConvertObjectFormat(textField, obj.ObjectFormat);
            CurrentXCoordinate += StaticHelper.ConvertUnit(obj.Width);
        }


        private void ConvertPictureObjectToField(PictureObject obj, TableLineBase tableLine)
        {
            TableFieldDrawing drawingField;
            // add empty field if offset is positive
            int offset = StaticHelper.ConvertUnit(obj.Left) - CurrentXCoordinate;
            if (offset > 0)
            {
                StaticHelper.AddEmptyField(tableLine, offset.ToUnit());
                CurrentXCoordinate += offset;
            }

            // now create the actual field
            drawingField = tableLine.Fields.AddNewDrawing();
            StaticHelper.SetCommonFieldProperties(drawingField, obj);

            PropertyInfo[] props = typeof(ReportObject).GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (PropertyInfo prop in props)
            {
                if (prop.Name == "RasReportObject")
                {
                    // comment out this block if you're using VS2008 or lower
                    dynamic rasReportObject = prop.GetValue(obj, null);
                    if (rasReportObject != null && rasReportObject.GraphicLocationFormula.Text != null)
                    {
                        drawingField.Contents = String.Format(CultureInfo.InvariantCulture, "Drawing({0})", rasReportObject.GraphicLocationFormula.Text);
                    }
                    break;
                }
            }
            drawingField.Height = StaticHelper.ConvertUnit(obj.Height).ToUnit();
            CurrentXCoordinate += StaticHelper.ConvertUnit(obj.Width);
        }

        #endregion
    }
}
