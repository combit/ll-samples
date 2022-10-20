using System;
using System.Collections;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using combit.Reporting.Dom;
using combit.Reporting;
using System.IO;
using System.ComponentModel;
using System.Reflection;
using System.Collections.Generic;

namespace CodeDomSample
{
    public class ListLabelDomTreeView : TreeView
    {
        private ProjectBase _project;
        private int subCellCount;
        private IContainer _components;
        private Attribute[] _filterAttributes;
        private string _fileName;
        private ListLabel _ll;
        private SubItemCrosstab tmpCrossTabSubItem;
        private ObjectCrosstab tmpCrossTabStandAlone;
        private bool isSubItemCrossTab = true;
        private int columnsCount;
        private int rowsCount;

        public ListLabelDomTreeView()
            : base()
        {
            _filterAttributes = new Attribute[] { new BrowsableAttribute(true) };
        }

        public ProjectBase Project
        {
            get { return _project; }
        }

        public void Load(string fileName)
        {
            bool containsDatabaseStructure = false;

            //D: Projekt mit angegebenen Dateinamen laden
            //US: Load project with the specified filename

            _fileName = String.Empty;
            if (_ll == null)
            {
                _ll = new ListLabel();
            }

            LlProject projectType = _ll.Core.LlUtilsGetProjectType(fileName);

            switch (projectType)
            {
                // D: Welcher Projekttyp wird geladen? Card, Label oder List
                // US: Which project type will be load? Card, Label or List               
                case LlProject.Label:
                    _project = new ProjectLabel(_ll);
                    break;
                case LlProject.List:
                    _project = new ProjectList(_ll);
                    break;
                case LlProject.Card:
                    _project = new ProjectCard(_ll);
                    break;
                case LlProject.TableOfContents:
                    _project = new ProjectTableOfContents(_ll);
                    break;
                case LlProject.Index:
                    _project = new ProjectIndex(_ll);
                    break;
                case LlProject.ReverseSide:
                    _project = new ProjectReverseSide(_ll);
                    break;
            }

            using (StreamReader sr = new StreamReader(fileName))
            {
                while ((!sr.EndOfStream) && (!containsDatabaseStructure))
                {
                    string line = sr.ReadLine();

                    if (line.Contains("[@DatabaseStructure]"))
                    {
                        containsDatabaseStructure = true;
                    }
                }

                _ll.Core.LlDbAddTable("");

                if (containsDatabaseStructure)
                {
                    _ll.DataSource = new List<string>();
                }
            }

            _project.Open(fileName, LlDomFileMode.Open, LlDomAccessMode.ReadOnly, true);
            _fileName = fileName;

            this.BuildTree();
        }

        private void BuildTree()
        {
            this.Nodes.Clear();
            this.SuspendLayout();

            TreeNode rootNode = new TreeNode(_fileName);
            rootNode.Tag = _project;
            rootNode.ImageIndex = 17;
            rootNode.SelectedImageIndex = 17;

            foreach (PropertyDescriptor pd in TypeDescriptor.GetProperties(_project, _filterAttributes))
            {
                this.AddNode(pd, rootNode);
            }

            base.Nodes.Add(rootNode);
            //this.Sort();
            this.ResumeLayout();
            rootNode.Expand();
        }

        private void AddNode(PropertyDescriptor pd, TreeNode parentNode)
        {
            Type propertyType = pd.PropertyType;
            string propertyName = pd.Name;

            TreeNode childNode = null;

            if (propertyType == typeof(System.String) | propertyType.IsPrimitive | propertyType.IsEnum)
            {
                DomItem item = (DomItem)(parentNode.Tag);

                //if ((item is PropertyOutputFormatterBase) || item.PropertyExists(propertyName))
                try
                {
                    object propertyValue = pd.GetValue(parentNode.Tag);
                    string value = Convert.ToString(propertyValue);
                    string nodeText = value == "" ? propertyName + " = <empty>" : propertyName + " = " + value;

                    childNode = parentNode.Nodes.Add(nodeText);
                    childNode.Tag = propertyValue;

                    if (value == "False")
                    {
                        childNode.ImageIndex = 4;
                        childNode.SelectedImageIndex = 4;
                    }
                    else if (value == "True")
                    {
                        childNode.ImageIndex = 5;
                        childNode.SelectedImageIndex = 5;
                    }
                    else
                    {
                        childNode.ImageIndex = 18;
                        childNode.SelectedImageIndex = 18;
                    }
                }
                catch { }
            }
            else if (propertyType.BaseType.IsGenericType && 
                (propertyType.BaseType.GetGenericTypeDefinition() == typeof(DomArrayBase<>) || propertyType.BaseType.GetGenericTypeDefinition() == typeof(SettableDomArray<>)))
            {
                object propertyValue = pd.GetValue(parentNode.Tag);
                int dimension = Int32.Parse(propertyValue.GetType().GetProperty("Length").GetValue(propertyValue, null).ToString());

                childNode = parentNode.Nodes.Add(propertyName);
                childNode.Tag = propertyValue;
                childNode.ImageIndex = 6;
                childNode.SelectedImageIndex = 6;

                
                foreach (PropertyInfo pi in propertyValue.GetType().GetProperties())
                {
                    if (pi.GetIndexParameters().Length > 0)
                    {
                        for (int i = 0; i < dimension; i++)
                        {
                            object targetItem = pi.GetValue(propertyValue, new object[] { i });
                            if (targetItem == null)
                                continue;

                            if (typeof(DomItem).IsAssignableFrom(targetItem.GetType()))
                            {
                                TreeNode objNode = childNode.Nodes.Add(this.GetObjectName(targetItem));
                                objNode.Tag = targetItem;
                                this.SetNodeImage(objNode);

                                foreach (PropertyDescriptor property in this.GetProperties(targetItem))
                                {
                                    this.AddNode(property, objNode);
                                }
                            }
                            else
                            {
                                TreeNode objNode = childNode.Nodes.Add(targetItem.ToString());
                                objNode.Tag = null;
                                objNode.ImageIndex = 18;
                                objNode.SelectedImageIndex = 18;
                            }
                        }

                        break;
                    }
                }
            }
            else if (propertyType.IsSubclassOf(typeof(DomItem)))
            {
                object propertyValue = pd.GetValue(parentNode.Tag);
                if (propertyType == typeof(PropertyCrosstabDefinition))
                {
                    foreach (object item in this._project.Objects)
                    {
                        if (item.GetType() == typeof(ObjectReportContainer) | item.GetType() == typeof(ObjectCrosstab))
                        {
                            if (item.GetType() == typeof(ObjectReportContainer))
                            {
                                ObjectReportContainer container = (ObjectReportContainer)item;
                                foreach (SubItemBase subItem in container.SubItems)
                                {
                                    if (subItem.GetType() == typeof(SubItemCrosstab))
                                    {
                                        tmpCrossTabSubItem = (SubItemCrosstab)subItem;
                                        subCellCount = Convert.ToInt32(tmpCrossTabSubItem.Definition.SubCellCount);
                                        columnsCount = tmpCrossTabSubItem.Definition.Columns.Groupings.Count + 1;
                                        rowsCount = tmpCrossTabSubItem.Definition.Rows.Groupings.Count + 1;
                                    }
                                }
                            }
                            else
                            {
                                tmpCrossTabStandAlone = (ObjectCrosstab)item;
                                subCellCount = Convert.ToInt32(tmpCrossTabStandAlone.Definition.SubCellCount);
                                columnsCount = tmpCrossTabStandAlone.Definition.Columns.Groupings.Count + 1;
                                rowsCount = tmpCrossTabStandAlone.Definition.Rows.Groupings.Count + 1;
                                isSubItemCrossTab = false;
                            }
                        }

                    }
                }
                if (propertyType == typeof(CrosstabCellContent))
                {
                    CrosstabCellContent cellContent;
                    //rows and cells
                    for (int i = 0; i < rowsCount; i++)
                    {
                        for (int j = 0; j < columnsCount; j++)
                        {
                            cellContent = isSubItemCrossTab ? tmpCrossTabSubItem.Definition.Cells[i, j] : tmpCrossTabStandAlone.Definition.Cells[i, j];
                            childNode = parentNode.Nodes.Add("Cell");
                            childNode.Tag = cellContent;// pd.GetValue(parentNode.Tag);
                            childNode.ImageIndex = 6;
                            childNode.SelectedImageIndex = 6;
                            childNode.Text = String.Format("{0}[{1},{2}]", "Cell", i, j);

                            foreach (PropertyDescriptor property in this.GetProperties(cellContent))
                            {
                                this.AddNode(property, childNode);
                            }
                        }
                    }

                    //SubCells
                    for (int row = 0; row < rowsCount; row++)
                    {
                        for (int column = 0; column < columnsCount; column++)
                        {
                            for (int subCell = 1; subCell < subCellCount; subCell++)
                            {
                                cellContent = isSubItemCrossTab ? tmpCrossTabSubItem.Definition.Cells[row, column, subCell]
                                                                : tmpCrossTabStandAlone.Definition.Cells[row, column, subCell];
                                childNode = parentNode.Nodes.Add("Cell");
                                childNode.Tag = cellContent;//pd.GetValue(parentNode.Tag);
                                childNode.ImageIndex = 6;
                                childNode.SelectedImageIndex = 6;
                                childNode.Text = String.Format("{0}[{1},{2},{3}]", "Cell", row, column, subCell);

                                foreach (PropertyDescriptor property in this.GetProperties(cellContent))
                                {
                                    this.AddNode(property, childNode);
                                }
                            }
                        }
                    }
                }
                else
                {
                    childNode = parentNode.Nodes.Add(propertyName);
                    childNode.Tag = propertyValue;
                    childNode.ImageIndex = 6;
                    childNode.SelectedImageIndex = 6;

                    foreach (PropertyDescriptor property in this.GetProperties(propertyValue))
                    {
                        this.AddNode(property, childNode);
                    }
                }

            }
            else if (typeof(IEnumerable<DomItem>).IsAssignableFrom(propertyType))
            {
                object propertyValue = pd.GetValue(parentNode.Tag);

                ICollection collection = propertyValue as ICollection;
                childNode = parentNode.Nodes.Add(propertyName);
                childNode.Tag = propertyValue;
                childNode.ImageIndex = 6;
                childNode.SelectedImageIndex = 6;

                foreach (object obj in collection)
                {
                    if (obj.GetType().IsSubclassOf(typeof(DomItem)))
                    {
                        TreeNode objNode = childNode.Nodes.Add(this.GetObjectName(obj));
                        objNode.Tag = obj;
                        this.SetNodeImage(objNode);

                        foreach (PropertyDescriptor property in this.GetProperties(obj))
                        {
                            this.AddNode(property, objNode);
                        }
                    }
                    else if (obj.GetType().IsSubclassOf(typeof(CollectionBase)))
                    {
                        ICollection childCollection = obj as ICollection;

                        foreach (object childObj in childCollection)
                        {
                            TreeNode objChildNode = childNode.Nodes.Add(this.GetObjectName(childObj));
                            objChildNode.Tag = obj;
                            this.SetNodeImage(objChildNode);

                            foreach (PropertyDescriptor childProperty in this.GetProperties(childObj))
                            {
                                this.AddNode(childProperty, objChildNode);
                            }
                        }
                    }
                    else if (obj is System.String)
                    {
                        childNode.Nodes.Add(Convert.ToString(obj));
                    }
                }
            }
        }

        protected override void OnAfterExpand(TreeViewEventArgs e)
        {
            base.OnAfterExpand(e);

            if (e.Node.ImageIndex == 6)
            {
                e.Node.ImageIndex = 7;
            }
        }

        private void SetNodeImage(TreeNode node)
        {
            if (node.Tag is ObjectLine)
            {
                node.SelectedImageIndex = 0;
                node.ImageIndex = 0;
            }
            else if (node.Tag is ObjectChart)
            {
                node.SelectedImageIndex = 3;
                node.ImageIndex = 3;
            }
            else if (node.Tag is ObjectRtf)
            {
                node.ImageIndex = 9;
                node.SelectedImageIndex = 9;
            }
            else if (node.Tag is ObjectReportContainer)
            {
                node.ImageIndex = 10;
                node.SelectedImageIndex = 10;
            }
            else if (node.Tag is ObjectDrawing)
            {
                node.ImageIndex = 2;
                node.SelectedImageIndex = 2;
            }
            else if (node.Tag is ObjectInputButton)
            {
                node.ImageIndex = 3;
                node.SelectedImageIndex = 3;
            }
            else if (node.Tag is ObjectText)
            {
                node.ImageIndex = 8;
                node.SelectedImageIndex = 8;
            }
            else if (node.Tag is ObjectGauge)
            {
                node.ImageIndex = 19;
                node.SelectedImageIndex = 19;
            }
            else
            {
                node.ImageIndex = 18;
                node.SelectedImageIndex = 18;
            }

        }

        private String GetObjectName(object obj)
        {

            DomItem domItem = obj as DomItem;
            string name = "";

            if (domItem.PropertyExists("Name"))
            {
                name = domItem.GetProperty("Name");
            }

            if (name == "")
            {
                if (domItem.PropertyExists("ObjectType"))
                {
                    name = domItem.GetProperty("ObjectType");
                }
            }

            if (name == "")
            {
                string tmp = obj.GetType().Name;

                tmp = tmp.Replace("DomItem", "");
                tmp = tmp.Replace("Property", "");
                name = tmp;
            }

            return name;
        }

        private PropertyDescriptorCollection GetProperties(object obj)
        {
            if (obj is Type)
            {
                return TypeDescriptor.GetProperties(obj as Type, _filterAttributes);
            }
            return TypeDescriptor.GetProperties(obj, _filterAttributes);
        }

        private void InitializeComponent()
        {
            this._components = new System.ComponentModel.Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(ListLabelDomTreeView));
            this.ImageList = new ImageList(this._components);
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.ImageList.TransparentColor = System.Drawing.Color.Magenta;
            this.ImageList.Images.SetKeyName(0, "Line.bmp");
            this.ImageList.Images.SetKeyName(1, "Mail_Front.bmp");
            this.ImageList.Images.SetKeyName(2, "Picture2.bmp");
            this.ImageList.Images.SetKeyName(3, "Chart.bmp");
            this.ImageList.Images.SetKeyName(4, "Doc_OK2.bmp");
            this.ImageList.Images.SetKeyName(5, "Doc_OK.bmp");
            this.ImageList.Images.SetKeyName(6, "Folder.bmp");
            this.ImageList.Images.SetKeyName(7, "Folder_Open.bmp");
            this.ImageList.Images.SetKeyName(8, "Insert_Text.bmp");
            this.ImageList.Images.SetKeyName(9, "RichTextBox.bmp");
            this.ImageList.Images.SetKeyName(10, "ShowGridlines.bmp");
            this.ImageList.Images.SetKeyName(11, "ShowRulelines.bmp");
            this.ImageList.Images.SetKeyName(12, "ShowRuler.bmp");
            this.ImageList.Images.SetKeyName(13, "Button.bmp");
            this.ImageList.Images.SetKeyName(14, "Checkbox.bmp");
            this.ImageList.Images.SetKeyName(15, "Combobox.bmp");
            this.ImageList.Images.SetKeyName(16, "Groupbox.bmp");
            // 
            // ListLabelDomTreeView
            // 
            this.LineColor = System.Drawing.Color.Black;
            this.ResumeLayout(false);

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_project != null)
                {
                    _project.Dispose();
                    _project = null;
                }
                if (_ll != null)
                {
                    _ll.Dispose();
                    _ll = null;
                }
            }
            base.Dispose(disposing);
        }

    }
}












