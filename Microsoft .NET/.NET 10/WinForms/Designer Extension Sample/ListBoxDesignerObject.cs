using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;


namespace combit.Reporting.CSharpSample.DesignerExtensionsSample
{
    class ListBoxDesignerObject : DesignerObject
    {
        Dictionary<int, ListBoxItem> _lstListBoxItems = new Dictionary<int, ListBoxItem>();
        Dictionary<int, ListBoxItem> _lstListBoxItemsToPrint = new Dictionary<int, ListBoxItem>();

        ListBox _listBox;
        Graphics _graphics;
        IntPtr _handle;

        int _currentPrintingLineIndex = -1;
        bool _lastPage = false;

        ListLabel _parentListLabel = null;
        bool _ownsParent = false;

        // this constructor should not be called
        private ListBoxDesignerObject()
        {
        }

        // 
        public ListBoxDesignerObject(String objectName, String objectDescription, Icon designerIcon, Dictionary<int, ListBoxItem> lstListBoxItems, ListBox listBox)
        {
            System.Diagnostics.Debug.Assert(!String.IsNullOrEmpty(objectName), "'objectName' can't be null nor empty");
            System.Diagnostics.Debug.Assert(!String.IsNullOrEmpty(objectDescription), "'objectDescription' can't be null nor empty");

            // copy owner drawn listbox items
            _lstListBoxItems = lstListBoxItems;

            // create a local copy of the listbox
            _listBox = new ListBox();
            _listBox.CreateControl();
            foreach (object item in listBox.Items)
                _listBox.Items.Add(item);

            //
            _handle = listBox.Handle;
            _graphics = Graphics.FromHwnd(_handle);

            // very important to get multiple pages printed
            AllowPageBreak = true;

            // set the name of the designer object
            ObjectName = objectName;

            // set the description of the designer object
            Description = objectDescription;

            // set the icon of the designer object
            Icon = new Icon(designerIcon, 32, 32);
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

        private bool IsPrinting
        {
            get
            {
                return ((int)Parent.Core.LlGetOption(337 /* LL_OPTION_IS_PRINTING */) == 1) ? true : false;
            }
        }

        #region DesignerObject

        // 
        protected override void OnResetPrintState(EventArgs e)
        {
            // reset datasource to work with
            _currentPrintingLineIndex = -1;
            _lastPage = false;
            _lstListBoxItemsToPrint.Clear();
        }

        // 
        protected override void OnPostCloneDesignerObject(PostCloneDesignerObjectEventArgs e)
        {
            // cloning the designer object
            ListBoxDesignerObject clone = (ListBoxDesignerObject)e.Clone;

            clone._currentPrintingLineIndex = _currentPrintingLineIndex;
            clone._lastPage = _lastPage;
            clone._lstListBoxItems = _lstListBoxItems;
            clone._handle = _handle;
            clone._graphics = Graphics.FromHwnd(_handle);

            clone._listBox = new ListBox();
            clone._listBox.CreateControl();
            foreach (object item in _listBox.Items)
                clone._listBox.Items.Add(item);
        }

        // 
        protected override void OnGetFieldHeightInformation(GetFieldHeightInformationEventArgs e)
        {
            int heightToDraw = 0;
            int sumHeights = 0;
            int itemHeight = 0;
            int lstItemCount = _lstListBoxItems.Count; // the count is pending on the drawn (visible) listbox items!
            ++_currentPrintingLineIndex;
            for (int index = _currentPrintingLineIndex; index < lstItemCount; ++index)
            {
                // get listbox item
                ListBoxItem listBoxItem = _lstListBoxItems[index];

                // get the height of the listbox item
                itemHeight = Convert.ToInt32(CoordinateHelper.ConvertUnit(listBoxItem.Rect.Height, CoordinateHelper.ConversionUnit.Pixel, UnitSystem, _graphics)); // hint: itemHeigth are pixel; but have to be LL units!

                // add the item height to the previous height
                sumHeights += itemHeight;

                // last page?
                if (index == lstItemCount - 1)
                    _lastPage = true;

                // verify the new height fits into the available height
                if (sumHeights <= e.AvailableSpace.Height) // current item of the listbox fits to the available space
                {
                    _currentPrintingLineIndex = index;
                    _lstListBoxItemsToPrint[_currentPrintingLineIndex] = listBoxItem;
                    heightToDraw = sumHeights;
                }
                else
                    break; // leave loop
            }

            // set the result values for list & label
            // hint: have to be in LL units!
            e.MinimalHeight = Convert.ToInt32(CoordinateHelper.ConvertUnit(_lstListBoxItems[_currentPrintingLineIndex].Rect.Height, CoordinateHelper.ConversionUnit.Pixel, UnitSystem, _graphics));
            e.IdealHeight = heightToDraw;
        }

        // 
        protected override void OnDrawDesignerObject(DrawDesignerObjectEventArgs e)
        {
            // only layout-mode or printing?
            if (e.IsDesignMode)
                e.PrintFinished = true;
            else
                e.PrintFinished = _lastPage; // last page?

            // 
            int topPositionToDraw = e.ClipRectangle.Top;
            if (IsInTableCell)
            {
                foreach (ListBoxItem listBoxItem in _lstListBoxItemsToPrint.Values)
                {
                    // Printing strings using the .NET component's event
                    // https://www.combit.net/en/kb/KBTE000580
                    Font font = new Font(listBoxItem.Font.Name, (float)CoordinateHelper.ConvertUnit(listBoxItem.Font.Size, CoordinateHelper.ConversionUnit.Point, UnitSystem, _graphics));

                    // calc the rect for drawing
                    Rectangle rectToDraw = new Rectangle(e.ClipRectangle.Left, topPositionToDraw, Convert.ToInt32(CoordinateHelper.ConvertUnit(listBoxItem.Rect.Width, CoordinateHelper.ConversionUnit.Pixel, UnitSystem, _graphics)), Convert.ToInt32(CoordinateHelper.ConvertUnit(listBoxItem.Rect.Height, CoordinateHelper.ConversionUnit.Pixel, UnitSystem, _graphics)));
                    topPositionToDraw += rectToDraw.Height;

                    // draw the string
                    e.Graphics.DrawString(listBoxItem.Text, font, listBoxItem.Brush, rectToDraw);
                }

                // cleanup printed listbox items
                _lstListBoxItemsToPrint.Clear();
            }
            else
            {
                int heightToDraw = 0;
                int sumHeights = 0;
                int itemHeight = 0;
                int lstItemCount = _lstListBoxItems.Count; // the count is pending on the drawn (visible) listbox items!
                ++_currentPrintingLineIndex;
                for (int index = _currentPrintingLineIndex; index < lstItemCount; ++index)
                {
                    // get listbox item
                    ListBoxItem listBoxItem = _lstListBoxItems[index];

                    // get the height of the listbox item
                    itemHeight = Convert.ToInt32(CoordinateHelper.ConvertUnit(listBoxItem.Rect.Height, CoordinateHelper.ConversionUnit.Pixel, UnitSystem, _graphics)); // hint: itemHeigth are pixel; but have to be LL units!

                    // add the item height to the previous height
                    sumHeights += itemHeight;

                    // last page?
                    if (index == lstItemCount - 1)
                        e.PrintFinished = _lastPage = true;

                    // verify the new height fits into the available height
                    if (sumHeights <= e.ClipRectangle.Height) // current item of the listbox fits to the available space
                    {
                        _currentPrintingLineIndex = index;

                        // Printing strings using the .NET component's event
                        // https://www.combit.net/en/kb/KBTE000580
                        Font font = new Font(listBoxItem.Font.Name, (float)CoordinateHelper.ConvertUnit(listBoxItem.Font.Size, CoordinateHelper.ConversionUnit.Point, UnitSystem, _graphics));

                        // calc the rect for drawing
                        Rectangle rectToDraw = new Rectangle(e.ClipRectangle.Left, topPositionToDraw, Convert.ToInt32(CoordinateHelper.ConvertUnit(listBoxItem.Rect.Width, CoordinateHelper.ConversionUnit.Pixel, UnitSystem, _graphics)), Convert.ToInt32(CoordinateHelper.ConvertUnit(listBoxItem.Rect.Height, CoordinateHelper.ConversionUnit.Pixel, UnitSystem, _graphics)));
                        topPositionToDraw += rectToDraw.Height;

                        // draw the string
                        e.Graphics.DrawString(listBoxItem.Text, font, listBoxItem.Brush, rectToDraw);
                        heightToDraw = sumHeights;
                    }
                    else
                        break; // leave loop
                }

                // 
                e.ClipRectangle = new Rectangle(e.ClipRectangle.Left, e.ClipRectangle.Top, e.ClipRectangle.Width, heightToDraw);
            }

            // While unfinished printing and we know what we are doing (no endless recursion!), we active reset the idle iteration counter for the object if property MaximumIdleIterationsPerObject was set
            if (!e.PrintFinished && IsPrinting && !e.IsDesignMode)
                ResetIdleIterationCounter();
        }

        #endregion

        #region IDisposable

        private bool disposed = false; // to detect redundant calls
        protected override void Dispose(bool disposing)
        {
            if (!disposed && disposing)
            {
                // dispose-only, i.e. non-finalizable logic
                _graphics.Dispose();

                if (_ownsParent)
                    _parentListLabel.Dispose();

                // shared cleanup logic
                disposed = true;
            }
        }

        #endregion
    }

    class ListBoxItem
    {
        public String Text { get; set; }
        public Font Font { get; set; }
        public SolidBrush Brush { get; set; }
        public Rectangle Rect { get; set; }

        private ListBoxItem()
        {
        }

        public ListBoxItem(String text, Font font, SolidBrush brush, Rectangle rect)
        {
            Text = text;
            Font = font;
            Brush = brush;
            Rect = rect;
        }
    }
}
