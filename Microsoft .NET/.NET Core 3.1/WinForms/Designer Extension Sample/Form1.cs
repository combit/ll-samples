using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using combit.Reporting;
using combit.Reporting.CSharpSample.DesignerExtensionsSample;
using combit.Reporting.Dom;
using Microsoft.Win32;
using Microsoft.VisualBasic;

namespace C_
{
    public partial class Form1 : Form
    {
        string _pictureFileName;
        string _projectFileName;
        Dictionary<int, ListBoxItem> _lstListBoxItems = new Dictionary<int, ListBoxItem>();

        public Form1()
        {
            InitializeComponent();

            // Change Directory
            Directory.SetCurrentDirectory(@"..\..\..\..\..\..\Report Files");

            // init listbox data
            for (int index = 1; index <= 60; ++index)
                listBox1.Items.Add("Test-Zeile " + index.ToString() + ".");
            // read some information from registry and set some general information
            RegistryKey regKey = Registry.CurrentUser.CreateSubKey(@"Software\combit\cmbtll", RegistryKeyPermissionCheck.ReadSubTree);
            if (regKey != null)
            {
                string _resourcePath = (String)regKey.GetValue("LL" + LlCore.LlGetVersion(LlVersion.Major) + "SampleDir", String.Empty);
                _resourcePath = Path.Combine(_resourcePath, @"Microsoft .NET\Report Files\");

                _pictureFileName = Path.Combine(_resourcePath, "logo.bmp");
                _projectFileName = Path.Combine(_resourcePath, "desext.lst");
            }
            else
                MessageBox.Show("Unable to read correct information from registry.");
        }

        //  D: Implementierung der neuen Designer Add-Funktion
        // US: Implementation of the new designer add-function
        private void DesignerFunction1_EvaluateFunction(object sender, EvaluateFunctionEventArgs e)
        {
            e.ResultValue = (double.Parse(e.Parameter1.ToString()) + double.Parse(e.Parameter2.ToString())).ToString();
        }

        //  D: Die hier spezifizierten Parameter Werte (1 - 20), werden beim Eintippen der Formel im Designer vorgeschlagen
        // US: The specified parameter values (1 - 20), are suggested while typeing the formula in the designer 
        private void DesignerFunction1_ParameterAutoComplete(object sender, combit.Reporting.ParameterAutoCompleteEventArgs e)
        {
            for (int i = 1; i <= 20; i++)
                e.Values.Add(i.ToString());
        }

        //  D: Implementierung eines Designer Objektes, welches ein Bild beinhaltet
        // US: Implementation of a designer object, which contains an image
        private void DesignerObject1_DrawDesignerObject(object sender, combit.Reporting.DrawDesignerObjectEventArgs e)
        {
            DesignerObject desobj = (DesignerObject)sender;
            if (desobj.ObjectProperties.Contains("imagefile"))
            {
                string imagefile = desobj.ObjectProperties["imagefile"].ToString();
                e.Graphics.DrawImage(new Bitmap(imagefile), e.ClipRectangle);
            }
        }

        //  D: Implementierung der Bearbeiten-Funktion, des neuen Objektes
        // US: Implementation of the new edit function for the new object
        private void DesignerObject1_EditDesignerObject(object sender, combit.Reporting.EditDesignerObjectEventArgs e)
        {
            DesignerObject desobj = (DesignerObject)sender;

            System.Windows.Forms.OpenFileDialog dialog = new System.Windows.Forms.OpenFileDialog();
            dialog.Filter = "All Picture Files (*.jpg;*.bmp;*.png;*.wmf;*.gif)|*.jpg;*.bmp;*.png;*.wmf;*.gif|All Files (*.*)|*.*";

            if (desobj.ObjectProperties.Contains("imagefile"))
                dialog.FileName = desobj.ObjectProperties["imagefile"].ToString();

            if (dialog.ShowDialog((System.Windows.Forms.IWin32Window)e.DesignerWindow) == System.Windows.Forms.DialogResult.OK)
            {
                desobj.ObjectProperties["imagefile"] = dialog.FileName;
                e.HasChanged = true;
            }
        }

        //  D: Das standard Verhalten eines dem Report neu hinzugefügten Objekts festlegen
        // US: Define the default behaviour of a new added object to a report
        private void DesignerObject1_CreateDesignerObject(object sender, combit.Reporting.CreateDesignerObjectEventArgs e)
        {
            DesignerObject desobj = (DesignerObject)sender;
            desobj.ObjectProperties["imagefile"] = _pictureFileName;
        }

        //  D: Dem Designer wird eine Such-Funktion in der "Aktionen" Toolbar hinzugefügt
        // US: A search function is added to the designer in the "Actions" toolbar
        private void DesignerAction1_ExecuteAction(object sender, EventArgs e)
        {
            using (ProjectList proj = new ProjectList(LL))
            {
                proj.GetFromParent();

                Point point = PointToScreen(new Point(100, 100));
                string message = "Which object are you looking for?";
                InputBox inputBox = new InputBox(message, "Find Object", "Upper Text",
                                           point.X, point.Y);
                string objName = inputBox.GetReturnValue();

                proj.DesignerRedraw = "False";
                bool found = false;

                foreach (ObjectBase obj in proj.Objects)
                {
                    if (obj.Name.Contains(objName))
                    {
                        found = true;
                        obj.Selected = "True";
                    }
                    else
                        obj.Selected = "False";
                }

                proj.DesignerRedraw = "True";

                if (!found)
                {
                    MessageBox.Show("The object could not be found.", "Info", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // Hint:
            // Because while using a owner drawn ListBox, each element has
            // to be made visible so all items will be drawn and are available!

            try
            {
                // 
                ListBoxDesignerObject designerObjectListBox = new ListBoxDesignerObject("ListBox", "ListBox Object", designerObject1.Icon, _lstListBoxItems, listBox1);
                LL.DesignerObjects.Add(designerObjectListBox);

                // enable data-binding for easy usage of the report-container with static table
                List<int> lstData = new List<int>();
                lstData.Add(1);
                LL.SetDataBinding(lstData);

                LL.AutoFileAlsoNew = true;
                LL.Design("Designer Extensions with List & Label", LlProject.List, _projectFileName, true);
            }
            catch (ListLabelException exc)
            {
                MessageBox.Show("Information: " + exc.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ListBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Draw the background of the ListBox control for each item.
            e.DrawBackground();

            // Draw the current item text based on the current Font and the custom brush settings.
            ListBoxItem listBoxItem = _lstListBoxItems[e.Index];
            e.Graphics.DrawString(listBox1.Items[e.Index].ToString(), listBoxItem.Font, listBoxItem.Brush, e.Bounds, StringFormat.GenericDefault);
        }

        private void ListBox1_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            // Define the default color of the brush as black.
            SolidBrush itemBrush = new SolidBrush(Color.Black);
            Font itemFont = listBox1.Font;
            e.ItemHeight = itemFont.Height;
            // Determine the color of the brush to draw each item based on the index of the item to draw.
            if (((e.Index + 1) % 10) == 0)
            {
                itemFont = new Font("Tahoma", 12);
                e.ItemHeight = itemFont.Height;
                itemBrush = new SolidBrush(Color.Red);
            }
            else if (((e.Index + 12) % 10) == 0)
            {
                itemFont = new Font("Tahoma", 14);
                e.ItemHeight = itemFont.Height;
                itemBrush = new SolidBrush(Color.Orange);
            }
            else if (((e.Index + 13) % 10) == 0)
            {
                itemFont = new Font("Tahoma", 16);
                e.ItemHeight = itemFont.Height;
                itemBrush = new SolidBrush(Color.Purple);
            }

            // create item and add it to list
            ListBoxItem listBoxItem = new ListBoxItem(listBox1.Items[e.Index].ToString(), itemFont, itemBrush, new Rectangle(0, 0, e.ItemWidth, e.ItemHeight));
            _lstListBoxItems[e.Index] = listBoxItem;
        }
    }
}
