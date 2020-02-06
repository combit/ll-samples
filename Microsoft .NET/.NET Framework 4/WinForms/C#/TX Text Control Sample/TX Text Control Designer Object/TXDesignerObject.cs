
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing.Imaging;

using combit.ListLabel25;
using TXTextControl;
using System.IO;


// Hints:
// 
// Please consider the readme.txt in the root folder of this solution for some details.
//


namespace TXTextDesignerObject
{
    public enum DataSource
    {
        FreeText,   // free rtf-text; maybe with formula
        Identifier, // varibale or field
    }

    public class TXDesignerObject : DesignerObject
    {
        #region Declarations

        ListLabel _parentListLabel = null;
        bool _ownsParent = false;

        int _textControlScaleFactorDpiX = 0;
        int _rtfPageNumber = 0;
        int _calculatedHeightInTable = 0;
        Graphics _textControlGraphics = null;
        ExpressionEvaluator _expressionEvaluator = null;
        TXTextControl.ServerTextControl _serverTXTextControl = null;

        #endregion // Declarations

        #region Construction

        public TXDesignerObject()
            : this(null, null, null, null)
        {
        }
        
        public TXDesignerObject(String objectName, String objectDescription, String objectIconFile, ListLabel parentListLabel)
        {
            Parent = parentListLabel;

            // Very important to get multiple pages printed
            AllowPageBreak = true;

            // Set the internal name of the designer object to identify
            if (String.IsNullOrEmpty(objectName))
                ObjectName = "TXTextObjectName";
            else
                ObjectName = objectName;

            // Set the description of the designer object in toolbar/ribbon
            if (String.IsNullOrEmpty(objectDescription))
                Description = "TX Text Control";
            else
                Description = objectDescription;

            // Set the icon of the designer object (old/classic symbolbar)
            if (String.IsNullOrEmpty(objectIconFile) || !File.Exists(objectIconFile))
                Icon = TX_Text_Control_Designer_Object.Properties.Resources.TxText;
            else
                Icon = new Icon(objectIconFile);

            // Set the tooltip description of the designer object
            TooltipDescription = "Insert formatted text by TX Text Control.";

            // Set the icon of the designer object (32x32)
            LargeRibbonImage = TX_Text_Control_Designer_Object.Properties.Resources.TxText_large;

            // Set the icon of the designer object (16 x 16)
            SmallRibbonImage = TX_Text_Control_Designer_Object.Properties.Resources.TxText_small; 
            
            _serverTXTextControl = new ServerTextControl();
            _serverTXTextControl.Create();

            // Remove any margins
            _serverTXTextControl.PageMargins = new PageMargins(0, 0, 0, 0);

            _textControlGraphics = Graphics.FromHwnd(IntPtr.Zero);
            _textControlScaleFactorDpiX = (int)(1440 / _textControlGraphics.DpiX);
        }

        #endregion // Construction

        #region Properties

        /// <summary>
        /// Decide, if table layouts of the RTF content should be adapted if the space is to small.
        /// </summary>
        /// <remarks>
        /// Per default tables in RTF content try to represent the layout 1:1. But if the object is smaller than the original table respectively the RTF document, 
        /// clipping effects may occur. This property 'RecalcTableLayout' forces compensating the table to the smaller space. If this option is active it 
        /// could have an impact on the performance because of the recalculation of the layout is computationally intensive and can modify the resulting table layout.
        /// </remarks>
        [System.ComponentModel.DefaultValue(false)]
        public bool RecalcTableLayout
        {
            get;
            set;
        }

        #endregion // Properties

        #region DesignerObject

        // Is called by List & Label, if the designer object is created (new) for the first time
        protected override void OnCreateDesignerObject(CreateDesignerObjectEventArgs e)
        {
            using (EditDesignerObjectEventArgs editArgs = new EditDesignerObjectEventArgs(e.DesignerWindow.Handle))
            {
                OnEditDesignerObject(editArgs);
                if (editArgs.HasChanged)
                {
                    e.Created = true;
                    UpdateView(true /* changed */, true /* immediate */);
                }
                else
                {
                    e.Created = false;
                    UpdateView(false /* changed */, true /* immediate */);
                }
            }
        }

        // Is called by List & Label to reset a possible data source which the Designer object is linking to
        // This happens e.g. if you call the real data preview in the Designer if you where in the Layout mode before
        bool _contentStillEvaluatedInDesigner = false;
        protected override void OnResetPrintState(EventArgs e)
        {
            String FileContents = DocumentRTFContent;
            if (
                IsPrinting
                || !_contentStillEvaluatedInDesigner
               )
            {
                bool bRTFContentContainsLLFormulas = RTFContentContainsLLFormulas(ref FileContents);
                if (bRTFContentContainsLLFormulas)
                {
                    EvaluateRTFContent(ref FileContents);
                }
            }
            LoadRTFContent(FileContents);

            // PageMargins must be set to 0 so that it fits neatly into the printable area
            _serverTXTextControl.PageMargins = new PageMargins(0, 0, 0, 0);

            //******************************   Kopf und Fusszeilen entfernen --> machen keinen Sinn in diesem Zusammenhang
            if (_serverTXTextControl.HeadersAndFooters != null)
                _serverTXTextControl.HeadersAndFooters.Remove(HeaderFooterType.All);

            _rtfPageNumber = 0;
        }
        
        // This event is only called if the Designer object is located inside a report container and is 
        // used for adjusting the height of the Designer object to print to fit the actual available height
        protected override void OnGetFieldHeightInformation(GetFieldHeightInformationEventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine(string.Format(">>OnGetFieldHeightInformation.AvailableSpace.Height: {0}", e.AvailableSpace.Height));
            
            _rtfPageNumber += 1;

            // do we have something to render?
            if (!ContentExists(1, ContentCheckTypes.Page | ContentCheckTypes.Text | ContentCheckTypes.Graphics))
            {
                e.IdealHeight = e.MinimalHeight = 0;
                return;
            }

            // Fallback to height of 1189mm (DIN A0) to avoid overflows, because in edit mode it is possible to show a scrollbar 
            // in the report-container and we get an endless height
            int usedHeight = e.AvailableSpace.Height;
            if (e.AvailableSpace.Height >= Int32.MaxValue || !IsPrinting)
                usedHeight = Convert.ToInt32(ConvertTXUnitsToLLUnits(UnitSystem, (118900 / 10 / 2.54))); // DIN A0

            PageSize newPageSize = new PageSize();
            newPageSize.Height = ConvertLLUnitsToTXUnits(UnitSystem, usedHeight) + 1;
            newPageSize.Width = ConvertLLUnitsToTXUnits(UnitSystem, e.AvailableSpace.Width) + 1;

            _serverTXTextControl.InputPosition = new TXTextControl.InputPosition(1, 1, 0);
            _serverTXTextControl.Sections[1].Format.PageSize.Height = newPageSize.Height;
            _serverTXTextControl.Sections[1].Format.PageSize.Width = newPageSize.Width;
            _serverTXTextControl.InputPosition = new TXTextControl.InputPosition(1, 1, 0);

            if (RecalcTableLayout)
            {
                foreach (Table table in _serverTXTextControl.Tables)
                {
                    table.SpreadToPage(_serverTXTextControl);
                    table.AutoSize(_serverTXTextControl);
                }
            }

            // Tell List & Label the sizes to use...

            //... the smallest possible size:
            e.MinimalHeight = Convert.ToInt32(CoordinateHelper.ConvertUnit(_serverTXTextControl.Lines.GetItem(_serverTXTextControl.InputPosition.TextPosition).TextBounds.Height, CoordinateHelper.ConversionUnit.Twip, UnitSystem, null));
            if (e.AvailableSpace.Height < e.MinimalHeight)
            {
                // this can happen, if the defined page break seems to be inside of a picture object
                _serverTXTextControl.GetPages()[1].Select();
                if (_serverTXTextControl.Lines.GetItem(_serverTXTextControl.Selection.Length).Number == 2)
                {
                    // we assume the smallest size of a line
                    e.MinimalHeight = 1000;
                }
            }

            //... the best fitting size - otherwise pagebreaks may occur:
            int lintGblHeight = GetPageContentRectFromServerControl(1).Height;
            usedHeight = Convert.ToInt32(CoordinateHelper.ConvertUnit(lintGblHeight, CoordinateHelper.ConversionUnit.Pixel, UnitSystem, _textControlGraphics));
            if (usedHeight > e.AvailableSpace.Height)
            {
                usedHeight = e.AvailableSpace.Height;
            }
            
            e.IdealHeight = _calculatedHeightInTable = usedHeight;

            //System.Diagnostics.Debug.WriteLine(string.Format("<<OnGetFieldHeightInformation.MinimalHeight: {0} - OnGetFieldHeightInformation.IdealHeight: {1}", e.MinimalHeight, e.IdealHeight));
        }

        // After the user has edited the object, you are asked by List & Label to draw the object. 
        // The event DrawDesignerObject is triggered for this purpose. A Graphics object and the rectangle of the object are passed 
        // through EventArguments. Now, you can draw in the work area with the known GDI + methods
        protected override void OnDrawDesignerObject(DrawDesignerObjectEventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine(string.Format(">>OnDrawDesignerObject.ClipRectangle.Height: {0}", e.ClipRectangle.Height));

            // Only in layout mode or printing?
            if (e.IsDesignMode)
            {
                _rtfPageNumber = 1;
                e.PrintFinished = true;
            }
            else
            {
                if (!IsInTableCell)
                    _rtfPageNumber += 1;
            }

            // do we have something to render?
            if (!ContentExists(1, ContentCheckTypes.Page | ContentCheckTypes.Text | ContentCheckTypes.Graphics))
            {
                e.PrintFinished = true;
                return;
            }

            // Calculate the section size - this have to be done also in table-mode (even it is done in OnGetFieldHeightInformation, because of footer lines)
            if (IsInTableCell)
            {
                if (_calculatedHeightInTable > e.ClipRectangle.Height || _rtfPageNumber == 0 || e.IsDesignMode)
                {
                    if (_rtfPageNumber == 0)
                        _rtfPageNumber = 1;
                    
                    PageSize newPageSize = new PageSize();
                    newPageSize.Height = ConvertLLUnitsToTXUnits(UnitSystem, e.ClipRectangle.Height) + 1;
                    newPageSize.Width = ConvertLLUnitsToTXUnits(UnitSystem, e.ClipRectangle.Width) + 1;

                    _serverTXTextControl.InputPosition = new TXTextControl.InputPosition(1, 1, 0);
                    _serverTXTextControl.Sections[1].Format.PageSize.Height = newPageSize.Height;
                    _serverTXTextControl.Sections[1].Format.PageSize.Width = newPageSize.Width;
                    _serverTXTextControl.InputPosition = new TXTextControl.InputPosition(1, 1, 0);

                    if (RecalcTableLayout)
                    {
                        foreach (Table table in _serverTXTextControl.Tables)
                        {
                            table.SpreadToPage(_serverTXTextControl);
                            table.AutoSize(_serverTXTextControl);
                        }
                    }
                }
            }
            else
            {
                PageSize newPageSize = new PageSize();
                newPageSize.Height = ConvertLLUnitsToTXUnits(UnitSystem, e.ClipRectangle.Height) + 1;
                newPageSize.Width = ConvertLLUnitsToTXUnits(UnitSystem, e.ClipRectangle.Width) + 1;

                _serverTXTextControl.InputPosition = new TXTextControl.InputPosition(1, 1, 0);
                _serverTXTextControl.Sections[1].Format.PageSize.Height = newPageSize.Height;
                _serverTXTextControl.Sections[1].Format.PageSize.Width = newPageSize.Width;
                _serverTXTextControl.InputPosition = new TXTextControl.InputPosition(1, 1, 0);

                if (RecalcTableLayout)
                {
                    foreach (Table table in _serverTXTextControl.Tables)
                    {
                        table.SpreadToPage(_serverTXTextControl);
                        table.AutoSize(_serverTXTextControl);
                    }
                }
            }

            Metafile lobjMetafile = _serverTXTextControl.GetPages()[1].GetImage(TXTextControl.Page.PageContent.MainText);
            Rectangle lobjRectangle = new Rectangle(e.ClipRectangle.Left, e.ClipRectangle.Top, Convert.ToInt32(CoordinateHelper.ConvertUnit(Convert.ToDouble(_serverTXTextControl.GetPages()[1].TextBounds.Width), CoordinateHelper.ConversionUnit.Twip, UnitSystem, null)), Convert.ToInt32(CoordinateHelper.ConvertUnit(Convert.ToDouble(_serverTXTextControl.GetPages()[1].TextBounds.Height), CoordinateHelper.ConversionUnit.Twip, UnitSystem, null)));
            e.Graphics.DrawImage(lobjMetafile, lobjRectangle);
            lobjMetafile.Dispose();
            lobjMetafile = null;

            // remember the page height
            int lintGblHeight = GetPageContentRectFromServerControl(1).Height;

            // try to handle/update enumerations if they become broken
            TryUpdateEnumerations(1);

            // try to remove the printed page
            RemovePageFromDocument(1);

            // do we have something to render?
            if (!ContentExists(1, ContentCheckTypes.Page | ContentCheckTypes.Text)) // no not check graphics here, because they are still exists in document
            {
                // No more pages/content to print
                e.PrintFinished = true;
                _rtfPageNumber = 0;
            }
            
            // are we inside of a table or a standalone object?
            if (!IsInTableCell)
            {
                e.ClipRectangle = new Rectangle(e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width, Convert.ToInt32(CoordinateHelper.ConvertUnit(lintGblHeight, CoordinateHelper.ConversionUnit.Pixel, UnitSystem, _textControlGraphics)));
            }

            // While unfinished printing and we know what we are doing (no endless recursion!), we active reset the idle iteration counter for the object if property MaximumIdleIterationsPerObject was set
            if (!e.PrintFinished && IsPrinting && !e.IsDesignMode)
                ResetIdleIterationCounter();

            //System.Diagnostics.Debug.WriteLine(string.Format("<<OnDrawDesignerObject.ClipRectangle.Height: {0} - OnDrawDesignerObject.PrintFinished: {1}", e.ClipRectangle.Height, e.PrintFinished));
        }
        
        // This event is triggered by List & Label if a Designer object is copied. There would be the possibility to copy specific properties (e.g. the data source) of the Designer object.
        // The event is e.g. needed to allow List & Label to revert the last operations in the Designer (Edit > Undo) or if an object is copied by the user within the Designer.
        // It is also called for internal administration purposes - e.g. when the Designer is started. Or if the real data preview or the export is executed.
        protected override void OnPostCloneDesignerObject(PostCloneDesignerObjectEventArgs e)
        {
            TXDesignerObject clone = (TXDesignerObject)e.Clone;
            clone._rtfPageNumber = 0;
            
			// init Parent ListLabel property explicitly to force creating new one later if needed
            clone.Parent = null;
            clone._ownsParent = false;
			
            clone._expressionEvaluator = null;
            clone._contentStillEvaluatedInDesigner = false;

            clone._serverTXTextControl = new ServerTextControl();
            clone._serverTXTextControl.Create();
            clone._serverTXTextControl.PageMargins = new PageMargins(0, 0, 0, 0);

            clone._textControlGraphics = Graphics.FromHwnd(IntPtr.Zero);
            clone._textControlScaleFactorDpiX = (int)(1440 / clone._textControlGraphics.DpiX);

            // We need to now when the object properties for the designer object are fully loaded to
            // be able to evaluate the contents if it contains formulas for updating the containing variables
            // in the used identifiers
            clone.ObjectPropertiesLoaded += clone.TXDesignerObject_ObjectPropertiesLoaded;
        }

        // This event is triggered, when the user double clicks on the newly added object or selects the item "Properties" from the context menu. 
        // Here as well, you can gain access to the Designer window through event arguments, and a separate dialog can be displayed.
        protected override void OnEditDesignerObject(EditDesignerObjectEventArgs e)
        {
            List<string> lstIdentifiers = new List<string>();
            CollectRTFIdentifiers(ref lstIdentifiers);

            string currentRTFDocumentContent = string.Empty;
            if (DataSourceType == DataSource.Identifier)
                currentRTFDocumentContent = Formula;
            else
                currentRTFDocumentContent = DocumentRTFContent;

            using (FormEditTXTextControl editTXTextControlDlg = new FormEditTXTextControl(lstIdentifiers, DataSourceType, currentRTFDocumentContent, Parent))
            {
                DialogResult dialogResult = editTXTextControlDlg.ShowDialog(e.DesignerWindow);
                if (dialogResult == DialogResult.OK)
                {
                    DataSourceType = editTXTextControlDlg.RTFDataSource;
                    DocumentRTFContent = editTXTextControlDlg.RTFDocumentContent;

                    LoadRTFContent(DocumentRTFContent);

                    // Tell List & Label that some modifications were done, so the Designer object will be redrawed with the new information
                    e.HasChanged = true;
                }
            }
        }

        protected override void OnSetOptionString(SetOptionStringEventArgs e)
        {
            base.OnSetOptionString(e);
            switch (e.Option)
            {
                case "TxTextControl.RecalcTableLayout":
                {
                    RecalcTableLayout = e.Text == "1" ? true : false;
                }
                break;
                
                default:
                {
                }
                break;
            }
        }

        /// <summary>
        /// This event is fired if the object properties of the designer objects are collected
        /// </summary>
        private void TXDesignerObject_ObjectPropertiesLoaded(object sender, EventArgs e)
        {
            // If properties are loaded we need to evaluate the expression first to ensure the used identifiers are updated as expected
            if (ObjectProperties.Count > 0)
            {
                if (IsPrinting)
                {
                    String FileContents = DocumentRTFContent;
                    bool bRTFContentContainsLLFormulas = RTFContentContainsLLFormulas(ref FileContents);
                    if (bRTFContentContainsLLFormulas)
                    {
                        EvaluateRTFContent(ref FileContents);
                    }
                }
            }
        }

        #endregion // DesignerObject

        #region Helpers

        private bool IsPrinting
        {
            get
            {
                return ((int)Parent.Core.LlGetOption(337 /* LL_OPTION_IS_PRINTING */) == 1) ? true : false;
            }
        }

        private bool SuppressLoadErrorMessages
        {
            get
            {
                return ((int)Parent.Core.LlGetOption(LlOption.SuppressLoadErrorMessages /* 223 */) == 1) ? true : false;
            }
        }

        private void CollectRTFIdentifiers(ref List<string> lstIdentifiers)
        {
            string name = string.Empty, value = string.Empty;
            IntPtr pos = Parent.Core.LlEnumGetFirstVar(LlFieldType.RTF);
            while (pos != IntPtr.Zero)
            {
                IntPtr handle = IntPtr.Zero;
                LlFieldType type = LlFieldType.Unknown;
                Parent.Core.LlEnumGetEntry(pos, ref name, ref value, ref handle, ref type);
                pos = Parent.Core.LlEnumGetNextEntry(pos, LlFieldType.RTF);

                lstIdentifiers.Add(name);
            }

            if (IsInTableCell)
            {
                pos = Parent.Core.LlEnumGetFirstField(LlFieldType.RTF);
                while (pos != IntPtr.Zero)
                {
                    IntPtr handle = IntPtr.Zero;
                    LlFieldType type = LlFieldType.Unknown;
                    Parent.Core.LlEnumGetEntry(pos, ref name, ref value, ref handle, ref type);
                    pos = Parent.Core.LlEnumGetNextEntry(pos, LlFieldType.RTF);

                    lstIdentifiers.Add(name);
                }
            }

            lstIdentifiers.Add(Parent.Core.LoadString(35)); // "(Freier Text)"
        }

        private void EvaluateRTFContent(ref string sContents)
        {
            // evaluate...
            if (!_contentStillEvaluatedInDesigner)
            {
                // Create the expression evaluator
                if (_expressionEvaluator == null)
                    _expressionEvaluator = new ExpressionEvaluator(Parent);

                // Activate the extended mode of the expression parser to use chevrons
                Parent.Core.LlSetOption(14 /* LL_OPTION_EXTENDEDEVALUATION */, 1);

                // Evaluate the file content - maybe twice, because any content can also hold its own formula
                try
                {
                    sContents = _expressionEvaluator.Evaluate(sContents).ToString();
                    if (RTFContentContainsLLFormulas(ref sContents))
                    {
                        sContents = _expressionEvaluator.Evaluate(sContents).ToString();
                    }
                }
                catch (Exception ecx)
                {
                    // if the display of errors is activated in List & Label or is it suppressed - e.g. DOM access and ignoreErrors=true
                    if (!SuppressLoadErrorMessages)
                    {
                        // reset content
                        sContents = DocumentRTFContent;

                        // show/display error
                        MessageBox.Show(ecx.Message, "error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        // canceling current "print" to avoid further actions with this object
                        Parent.Core.LlPrintAbort();
                    }
                }

                if (!IsPrinting)
                    _contentStillEvaluatedInDesigner = true;

                // Deactivate the extended mode of the expression parser to use chevrons
                Parent.Core.LlSetOption(0 /* LL_OPTION_NEWEXPRESSIONS */, 1);
            }
        }

        private bool RTFContentContainsLLFormulas(ref string sContents, bool bReplace = true)
        {
            bool bRTFContentContainsLLFormulas = false;
            if (
                (sContents.Contains("\\u171\\'ab") || sContents.Contains("\\'ab") || sContents.Contains("\\'ab\\hich\\af0\\dbch\\af0\\loch\\f0 ") || sContents.Contains("\\'ab\\hich\\af1\\dbch\\af1\\loch\\f1 "))
                && (sContents.Contains("\\u187\\'bb") || sContents.Contains("\\'bb") || sContents.Contains("\\loch\\af0\\dbch\\af0\\hich\\f0\\'bb") || sContents.Contains("\\loch\\af1\\dbch\\af1\\hich\\f1\\'bb"))
                )
            {
                // we have detected a List & Label formula inside of the given rtf-stream
                bRTFContentContainsLLFormulas = true;
				
                if (bReplace)
                {
                    sContents = sContents.Replace("\\u171\\'ab", "«"); // neccessary for the LL RTF-Ctrl (uses Microsoft RTF-Control!)
                    sContents = sContents.Replace("\\'ab\\hich\\af0\\dbch\\af0\\loch\\f0 ", " «");
                    sContents = sContents.Replace("\\'ab\\hich\\af1\\dbch\\af1\\loch\\f1 ", " «");
                    sContents = sContents.Replace("\\'ab", "«");
                    sContents = sContents.Replace("\\u187\\'bb", "»"); // neccessary for the LL RTF-Ctrl (uses Microsoft RTF-Control!)
                    sContents = sContents.Replace("\\loch\\af0\\dbch\\af0\\hich\\f0\\'bb", "»");
                    sContents = sContents.Replace("\\loch\\af1\\dbch\\af1\\hich\\f1\\'bb", "»");
                    sContents = sContents.Replace("\\'bb", "»");
					
					// if we are an LL formula we also need to decode special characters like german Umlaute, new line or something similar
                    sContents = sContents.Replace("\\'e4", "ä");
                    sContents = sContents.Replace("\\'f6", "ö");
                    sContents = sContents.Replace("\\'fc", "ü");
                    sContents = sContents.Replace("\\'df", "ß");
                    sContents = sContents.Replace("\\'c4", "Ä");
                    sContents = sContents.Replace("\\'d6", "Ö");
                    sContents = sContents.Replace("\\'dc", "Ü");
					sContents = sContents.Replace("\\u182\\'b6", "\\par "); // new line (neccessary for the LL RTF-Ctrl (uses Microsoft RTF-Control!))
                }
            }

            return bRTFContentContainsLLFormulas;
        }

        private void LoadRTFContent(string documentRTFContent = "")
        {
            try
            {
                if (documentRTFContent == string.Empty)
                    documentRTFContent = DocumentRTFContent;

                if (documentRTFContent != string.Empty)
                {
                    if (documentRTFContent.StartsWith("\""))
                        documentRTFContent = documentRTFContent.Remove(0, 1);

                    if (documentRTFContent.EndsWith("\""))
                        documentRTFContent = documentRTFContent.Remove(documentRTFContent.Length - 1, 1);

                    _serverTXTextControl.Load(documentRTFContent, StringStreamType.RichTextFormat);
                }
            }
            catch (Exception exc)
            {
                System.Diagnostics.Debug.WriteLine(exc.Message);
            }
        }

        private ListLabel Parent
        {
            get
            {
                if (_parentListLabel == null)
                {
                    _parentListLabel = new ListLabel(JobHandle);
                    _ownsParent = true;
                }
                return _parentListLabel;
            }

            set { _parentListLabel = value; }
        }

        private DataSource DataSourceType
        {
            get
            {
                return (DataSource)Enum.ToObject(typeof(DataSource), Convert.ToInt32(ObjectProperties["DataSourceType"]));
            }
            set
            {
                ObjectProperties["DataSourceType"] = value;
            }
        }

        private string SolidContent
        {
            get
            {
                string content = string.Empty;
                if (ObjectProperties.Contains("DataSourceType.SolidContent"))
                {
                    content = ObjectProperties["DataSourceType.SolidContent"].ToString();
                }
                return content;
            }
            set
            {
                ObjectProperties["DataSourceType.SolidContent"] = value;
            }
        }

        private string Formula
        {
            get
            {
                string formula = string.Empty;
                if (ObjectProperties.Contains("DataSourceType.Variable"))
                {
                    formula = ObjectProperties["DataSourceType.Variable"].ToString();
                }
                return formula;
            }
            set
            {
                ObjectProperties["DataSourceType.Variable"] = value;
            }
        }

        private string DocumentRTFContent
        {
            get
            {
                string result = string.Empty;
                DataSource dataSourceType = DataSourceType;
                switch (dataSourceType)
                {
                    case DataSource.FreeText:
                        {
                            result = SolidContent;
                        }
                        break;

                    case DataSource.Identifier:
                        {
                            result = Formula;

                            // we need the evaluated content
                            if (IsInTableCell)
                            {
                                result = Parent.Core.LlGetFieldContents(result);
                            }
                            else
                            {
                                result = Parent.Core.LlGetVariableContents(result);
                            }
                        }
                        break;

                    default:
                        {
                            System.Diagnostics.Debug.Assert(false, string.Format("error - get: DataSourceType {0} is unknown!", dataSourceType));
                        }
                        break;
                }

                return result;
            }

            set
            {
                DataSource dataSourceType = DataSourceType;
                switch (dataSourceType)
                {
                    case DataSource.FreeText:
                        {
                            SolidContent = value;
                        }
                        break;

                    case DataSource.Identifier:
                        {
                            Formula = value;
                        }
                        break;

                    default:
                        {
                            System.Diagnostics.Debug.Assert(false, string.Format("error - set: DataSourceType {0} is unknown!", dataSourceType));
                        }
                        break;
                }
            }
        }

        // Helper to convert List & Label units into TX Text Control units (100th inch)
        static double ConvertLLUnitsToTXUnits(LlUnits units, double unitsToConvert)
        {
            double tXUnits = 0;
            switch (units)
            {
                case LlUnits.Inch_1_100:
                    tXUnits = unitsToConvert;
                    break;

                case LlUnits.Inch_1_1000:
                    tXUnits = unitsToConvert / 10.0;
                    break;

                case LlUnits.Millimeter_1_10:
                    tXUnits = unitsToConvert / 100.0 / 2.54 * 100.0;
                    break;

                case LlUnits.Millimeter_1_100:
                    tXUnits = unitsToConvert / 1000.0 / 2.54 * 100.0;
                    break;

                case LlUnits.Millimeter_1_1000:
                    tXUnits = unitsToConvert / 10000.0 / 2.54 * 100.0;
                    break;
            }
            return tXUnits;
        }

        // Helper to convert TX Text Control units (100th inch) into List & Label units
        static double ConvertTXUnitsToLLUnits(LlUnits units, double unitsToConvert)
        {
            double llUnits = 0;
            switch (units)
            {
                case LlUnits.Inch_1_100:
                    llUnits = unitsToConvert;
                    break;

                case LlUnits.Inch_1_1000:
                    llUnits = unitsToConvert * 10.0;
                    break;

                case LlUnits.Millimeter_1_10:
                    llUnits = unitsToConvert / 100.0 * 2.54 * 100.0;
                    break;

                case LlUnits.Millimeter_1_100:
                    llUnits = unitsToConvert / 100.0 * 2.54 * 1000.0;
                    break;

                case LlUnits.Millimeter_1_1000:
                    llUnits = unitsToConvert / 100.0 * 2.54 * 10000.0;
                    break;
            }
            return llUnits;
        }

        // Returns the Rectangle of the main content
        private Rectangle GetPageContentRectFromServerControl(int Page)
        {
            TXTextControl.Page page = _serverTXTextControl.GetPages()[Page];
            TXTextControl.Line lastLine = _serverTXTextControl.Lines.GetItem(page.Start + page.Length - 2);

            Rectangle rRect = new Rectangle(
                                            page.TextBounds.X / _textControlScaleFactorDpiX,
                                            page.TextBounds.Y / _textControlScaleFactorDpiX,
                                            page.TextBounds.Width / _textControlScaleFactorDpiX,
                                            (lastLine.TextBounds.Bottom / _textControlScaleFactorDpiX) - (page.TextBounds.Top / _textControlScaleFactorDpiX)
                                            );
            return rRect;
        }

        // Updates the enumartions while page breaks
        private void TryUpdateEnumerations(int Page)
        {
            // Select the concerning page
            _serverTXTextControl.GetPages()[Page].Select();

            // Check, if we have an enumeration at the end of the given page
            _serverTXTextControl.Selection.Start = _serverTXTextControl.Selection.Length;
            _serverTXTextControl.Selection.Length = 0;
            if (_serverTXTextControl.Selection.ListFormat.Type == TXTextControl.ListType.Numbered || _serverTXTextControl.Selection.ListFormat.Type == TXTextControl.ListType.Structured)
            {
                if (!_serverTXTextControl.Selection.ListFormat.RestartNumbering)
                {
                    TXTextControl.Line lobjLastLine = _serverTXTextControl.Lines.GetItem(_serverTXTextControl.Selection.Start);

                    // Define start position of the enumeration
                    int lintLineNumber = 0;
                    int lintLastLevel = 0;
                    int[] lintNum = new int[1];
                    for (int lintLine = lobjLastLine.Number - 1; lintLine >= 1; lintLine += -1)
                    {
                        _serverTXTextControl.Selection.Start = _serverTXTextControl.Lines[lintLine].Start - 1;
                        _serverTXTextControl.Selection.Length = _serverTXTextControl.Lines[lintLine].Length;
                        if (_serverTXTextControl.Selection.ListFormat.Type == TXTextControl.ListType.Numbered || _serverTXTextControl.Selection.ListFormat.Type == TXTextControl.ListType.Structured)
                        {
                            lintLineNumber = lintLine;
                            lintLastLevel = _serverTXTextControl.Selection.ListFormat.Level;
                            lintNum[0] = _serverTXTextControl.Selection.ListFormat.FirstNumber - 1;
                            if (_serverTXTextControl.Selection.ListFormat.RestartNumbering)
                            {
                                _serverTXTextControl.Selection.ListFormat.RestartNumbering = false;
                                break;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }

                    // Set new without automatic enumeration
                    for (int lintLine = (lintLineNumber == 0 ? 1 : lintLineNumber); lintLine <= _serverTXTextControl.Lines.Count; lintLine++)
                    {
                        _serverTXTextControl.Selection.Start = _serverTXTextControl.Lines[lintLine].Start - 1;
                        _serverTXTextControl.Selection.Length = _serverTXTextControl.Lines[lintLine].Length;
                        if (_serverTXTextControl.Selection.ListFormat.Type == TXTextControl.ListType.Numbered || _serverTXTextControl.Selection.ListFormat.Type == TXTextControl.ListType.Structured)
                        {
                            if (_serverTXTextControl.Selection.ListFormat.RestartNumbering)
                                break;

                            if (_serverTXTextControl.Selection.ListFormat.Level > lintLastLevel)
                            {
                                Array.Resize(ref lintNum, _serverTXTextControl.Selection.ListFormat.Level + 1);
                                lintNum[_serverTXTextControl.Selection.ListFormat.Level - 1] = 0;
                            }
                            lintNum[_serverTXTextControl.Selection.ListFormat.Level - 1] += 1;
                            _serverTXTextControl.Selection.ListFormat.RestartNumbering = true;
                            _serverTXTextControl.Selection.ListFormat.FirstNumber = lintNum[_serverTXTextControl.Selection.ListFormat.Level - 1];
                            lintLastLevel = _serverTXTextControl.Selection.ListFormat.Level;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            _serverTXTextControl.GetPages()[Page].Select();
        }

        // Updates the enumartions while page breaks
        private void RemovePageFromDocument(int Page)
        {
            // remember the current page-count to check, if the given page could be removed
            int currentPageCount = _serverTXTextControl.GetPages().Count;

            _serverTXTextControl.GetPages()[Page].Select();

            // insert page-break if first element on given page is a valid table
            TXTextControl.Table lobjTable = _serverTXTextControl.Tables.GetItem();
            if (lobjTable != null)
            {
                if (lobjTable.Cells.GetItem() != null && lobjTable.Cells.GetItem().Row == 0)
                {
                    _serverTXTextControl.Selection.Start = 0;
                    _serverTXTextControl.Selection.Length = 0;
                    _serverTXTextControl.Sections.Add(TXTextControl.SectionBreakKind.BeginAtNewLine);
                    _serverTXTextControl.Selection.Start = 0;
                    _serverTXTextControl.Selection.Length = 1;
                    _serverTXTextControl.Selection.FontSize = 1;
                }
                _serverTXTextControl.GetPages()[Page].Select();
            }
            _serverTXTextControl.Clear();

            // was removing the given page successful?
            if (currentPageCount == _serverTXTextControl.GetPages().Count)
            {
                // remember the current page-count to check, if the given page could now be removed
                currentPageCount = _serverTXTextControl.GetPages().Count;

                _serverTXTextControl.GetPages()[Page].Select();
                _serverTXTextControl.Selection.Text = string.Empty;

                // was removing the given page successful?
                // not: look if it is a table to insert manual a page-break
                if (currentPageCount == _serverTXTextControl.GetPages().Count)
                {
                    // remember the current page-count to check, if the given page could now be removed
                    currentPageCount = _serverTXTextControl.GetPages().Count;

                    _serverTXTextControl.Selection.Start = _serverTXTextControl.Selection.Length;
                    _serverTXTextControl.Selection.Length = 0;
                    _serverTXTextControl.InputPosition = new InputPosition(1, 1, 0);
                    TXTextControl.Table table = _serverTXTextControl.Tables.GetItem();
                    if (table != null)
                    {
                        int row = table.Cells.GetItem().Row;
                        table.Split(TableAddPosition.Before);

                        _serverTXTextControl.GetPages()[Page].Select();
                        _serverTXTextControl.Selection.Text = string.Empty;

                        // was removing the given page successful?
                        // not: we need to insert manually a page-break
                        if (currentPageCount == _serverTXTextControl.GetPages().Count)
                        {
                            // remember the current page-count to check, if the given page could now be removed
                            currentPageCount = _serverTXTextControl.GetPages().Count;

                            if (_serverTXTextControl.Selection.Length == 0)
                            {
                                _serverTXTextControl.GetPages()[Page].Select();
                                _serverTXTextControl.Selection.Start = _serverTXTextControl.Selection.Length - 1;
                            }
                            else
                            {
                                _serverTXTextControl.Selection.Start = _serverTXTextControl.Selection.Length - 1;
                            }

                            _serverTXTextControl.Selection.Length = 0;
                            _serverTXTextControl.Sections.Add(SectionBreakKind.BeginAtNewPage);
                            _serverTXTextControl.InputPosition = new InputPosition(1, 1, 0);
                            _serverTXTextControl.GetPages()[Page].Select();
                            _serverTXTextControl.Selection.Text = string.Empty;

                            // last try/solution to delete the page!!!
                            if (currentPageCount == _serverTXTextControl.GetPages().Count)
                            {
                                _serverTXTextControl.GetPages()[Page].Select();
                                _serverTXTextControl.Text = string.Empty;
                            }
                        }
                    }
                   }
            }
        }

        // checks, if more data to print exists

        private enum ContentCheckTypes
        {
            None = 0,
            Page = 1,
            Text = 2,
            Graphics = 4
        }
        bool ContentExists(int nPageNo, ContentCheckTypes contentTypeToCheck = ContentCheckTypes.Page | ContentCheckTypes.Text | ContentCheckTypes.Graphics)
        {
            bool contentExists = true;

            // page-check: exists more pages with data?
            if (
                contentTypeToCheck.HasFlag(ContentCheckTypes.Page)
                && (_serverTXTextControl.GetPages() == null 
                || _serverTXTextControl.GetPages()[nPageNo] == null))
            {
                // no more pages exists - skip content-check
                contentExists = false;
            }

            if (contentExists)
            {
                // pages exists - check content
                if (
                    contentTypeToCheck.HasFlag(ContentCheckTypes.Text)
                    && _serverTXTextControl.Text == string.Empty
                    )
                {
                    contentExists = false;

                    // this could be e.g. if the document only has got graphics without any text!
                    if (contentTypeToCheck.HasFlag(ContentCheckTypes.Graphics))
                    {
                        if(_serverTXTextControl.Images.Count > 0
                            || _serverTXTextControl.Drawings.Count > 0)
                        {
                            contentExists = true;
                        }
                    }
                }
            }

            return contentExists;
        }

        #endregion // Helpers

        // Dispose pattern to "clean-up" resources
        private bool disposed = false; // To detect redundant calls
        protected override void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                // Clean up
                _textControlGraphics.Dispose();

                if (_serverTXTextControl != null)
                    _serverTXTextControl.Dispose();

                if (_expressionEvaluator != null)
                    _expressionEvaluator.Dispose();

                if (_ownsParent)
                    _parentListLabel.Dispose();

                // Shared cleanup logic
                disposed = true;
                GC.SuppressFinalize(this);
            }
            base.Dispose(disposing);
        }
    }
}
