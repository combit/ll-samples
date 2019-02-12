using combit.ListLabel24;
using combit.ListLabel24.Dom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using MetroFramework.Forms;
using System.Drawing.Drawing2D;

namespace CodeDomSample
{
    public partial class Form1 : MetroForm
    {
        private ListLabel _ll = new ListLabel();
        private string _fileName = String.Empty;
        private Dictionary<string, string> _typeInfos = new Dictionary<string, string>();
        private TreeNode _selectedNode;

        public Form1()
        {
            InitializeComponent();

            ReadInfos();
            Directory.SetCurrentDirectory(@"..\..\..\");

            CustomToolStripRenderer r = new CustomToolStripRenderer();
            r.RoundedEdges = false;
            

            toolStrip1.Renderer = r;
        }

        private void OpenProjectFileToolStrip_Click(object sender, EventArgs e)
        {
            //D: Dateiauswahl anzeigen und Projektdatei auswählen
            //US: Show OpenFileDialog to selected a project file
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "List & Label reports (*.lbl;*.lst;*.crd;*.srt;*.lsr)|*.lbl;*.lst;*.crd;*.srt;*.lsr|All files (*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                rtbCode.Clear();

                try
                {
                    if (this.llDomTreeView.Project != null)
                    {
                        this.llDomTreeView.Project.Close();
                        this.llDomTreeView.Project.Dispose();
                    }

                    this.llDomTreeView.Load(dialog.FileName);

                    _fileName = dialog.FileName;

                    this.GenerateCodeToolStrip.Enabled = true;
                    this.ListLabelToolStrip.Enabled = true;
                    this.searchToolStripButton.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    _fileName = String.Empty;
                    this.ListLabelToolStrip.Enabled = false;
                    this.GenerateCodeToolStrip.Enabled = false;
                }
            }
        }

        private void ListLabelToolStrip_Click(object sender, EventArgs e)
        {
            // D:  Das aktuelle Projekt schliessen.
            // US: Close the current project.
            this.llDomTreeView.Project.Close();
            this.llDomTreeView.Project.Dispose();

            //D:  Bevor die Projektdatei im Designer angezeigt werden kann,
            //    wird noch der Projekttyp benötigt
            //US: Before we can display the project we need to know wich is the current project type
            LlProject projectType = _ll.Core.LlUtilsGetProjectType(_fileName);

            // D: Um das ausgewähle Projekt im Designer laden zu können, benötigt List & Label eine Dummy-Datenquelle
            // US: To be able to use the selected project in the designer, we need a dummy-datasource
            _ll.DataSource = new List<int>();

            //D:  Projekt mit dem Designer laden
            //US: Load project with the Designer
            _ll.Design(projectType, _fileName);

            //D:  Projekt erneut laden
            //US: Reload the project 
            this.llDomTreeView.Load(_fileName);

        }

        private void CopyToolStrip_Click(object sender, EventArgs e)
        {
            this.rtbCode.Copy();
        }

        private void CutToolStrip_Click(object sender, EventArgs e)
        {
            this.rtbCode.Cut();
        }

        private void ReadInfos()
        {
            //D: Visual Studio Kommentare für List & Label laden
            //US: Load Visual Studio comments

            if (!System.IO.File.Exists(@"..\..\..\Assemblies\Assemblies 2.0\combit.ListLabel24.xml"))
            {
                return;
            }

            XmlDocument helpDoc = new XmlDocument();
            helpDoc.Load(@"..\..\..\Assemblies\Assemblies 2.0\combit.ListLabel24.xml");

            XmlNodeList nodeList = helpDoc.SelectNodes("/doc/members/member");

            foreach (XmlNode node in nodeList)
            {
                string type = node.Attributes.Item(0).Value;
                if (type.StartsWith("T:"))
                {
                    string text = node.FirstChild.InnerText;
                    text = text.Replace("     ", " ");
                    text = text.Replace("    ", " ");
                    text = text.Replace("List & Label", "List && Label");

                    if (text.StartsWith(" "))
                    {
                        text = text.Substring(1);
                    }
                    _typeInfos.Add(type.Substring(2), text);
                }
            }
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //D: Kommentar zum aktuell ausgewählten List & List Objekt anzeigen
            //US: Display the comment for the selected List & Label Object

            this.llDomTreeView.Select();
            this.label1.Text = "";

            _selectedNode = this.llDomTreeView.SelectedNode;

            if (_selectedNode.Tag != null)
            {
                string type = _selectedNode.Tag.ToString();

                if (_typeInfos.ContainsKey(type))
                {
                    string info = _typeInfos[type];
                    this.label1.Text = info;
                }
            }

            this.llDomTreeView.Select();
            this.GenerateCodeToolStrip.Enabled = (_selectedNode.Tag is DomItem | _selectedNode.Tag is DomCollectionBase);
            this.GenerateCodeToolStrip2.Enabled = (_selectedNode.Tag is DomItem | _selectedNode.Tag is DomCollectionBase);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.CodeLanguageToolStripCombo.SelectedIndex = 0;
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            //D: Dateiauswahldialog anzeigen um erzeugten Code zu speichern
            //US: Display SaveFileDialog to save the generated Code

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.AddExtension = true;
            dialog.DefaultExt = this.CodeLanguageToolStripCombo.Text == "C#" ? "cs" : "vb";
            dialog.Filter = this.CodeLanguageToolStripCombo.Text == "C#" ? "*.cs | *.cs" : "*.vb | *.vb";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.rtbCode.SaveFile(dialog.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void GenerateCodeToolStrip2_Click(object sender, EventArgs e)
        {
            if (_selectedNode == null)
            {
                MessageBox.Show("Please select a Node!");
                return;
            }

            this.llDomTreeView.Select();
            this.GenerateCode(_selectedNode.Tag);
        }

        private void GenerateCodeTooStrip_Click(object sender, EventArgs e)
        {
            if (_selectedNode == null)
            {
                MessageBox.Show("Please select a Node!");
                return;
            }

            this.llDomTreeView.Select();
            this.GenerateCode(_selectedNode.Tag);
        }

        private void GenerateCode(object item)
        {
            if ((item is DomItem) | (item is DomCollectionBase))
            {
                try
                {
                    ListLabelCodeDomSerializer serializer = new ListLabelCodeDomSerializer();

                    //D: CodeDomProvider auswählen
                    //US: Select CodeDomProvider
                    if (this.CodeLanguageToolStripCombo.Text == "C#")
                    {
                        serializer.Provider = System.CodeDom.Compiler.CodeDomProvider.CreateProvider("C#");
                    }
                    else
                    {
                        serializer.Provider = System.CodeDom.Compiler.CodeDomProvider.CreateProvider("VB");
                    }

                    object code = serializer.Serialize(null, item);

                    this.rtbCode.Text = Convert.ToString(code);
                    this.SaveCodeToolStrip.Enabled = true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (this.llDomTreeView.SelectedNode == null)
            {
                e.Cancel = true;
                return;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_ll != null)
            {
                _ll.Dispose();
                _ll = null;
            }

            if (this.llDomTreeView.Project != null)
            {
                this.llDomTreeView.Project.Close();
                this.llDomTreeView.Project.Dispose();
            }
        }

        private void CutToolStripMenu_Click(object sender, EventArgs e)
        {
            this.rtbCode.Cut();
        }

        private void CopyToolStripMenu_Click(object sender, EventArgs e)
        {
            this.rtbCode.Copy();
        }

        //Code for searching the node with entered text
        private List<TreeNode> _currentNodeMatches = new List<TreeNode>();
        private int _lastNodeIndex;
        private string _lastSearchText;

        private void SearchToolStripButton_Click(object sender, EventArgs e)
        {
            string searchText = this.searchToolStripTextBox.Text;
            if (String.IsNullOrEmpty(searchText) || llDomTreeView.Nodes.Count == 0)
                return;

            if (_lastSearchText != searchText)
            {
                //It's a new Search
                _currentNodeMatches.Clear();
                _lastSearchText = searchText;
                _lastNodeIndex = 0;
                SearchNodesR(searchText, llDomTreeView.Nodes[0]);
            }

            if (_currentNodeMatches.Count == 0)
            {
                MessageBox.Show("No matches found");
                return;
            }

            if (_lastNodeIndex == _currentNodeMatches.Count)
                _lastNodeIndex = 0;

            this.llDomTreeView.SelectedNode = _currentNodeMatches[_lastNodeIndex];
            _lastNodeIndex++;
            this.llDomTreeView.SelectedNode.Expand();
            this.llDomTreeView.Select();
        }

        private void SearchNodesR(string searchText, TreeNode startNode)
        {
            while (startNode != null)
            {
                if (startNode.Text.ToLower().Contains(searchText.ToLower()))
                {
                    _currentNodeMatches.Add(startNode);
                }
                if (startNode.Nodes.Count != 0)
                {
                    SearchNodesR(searchText, startNode.Nodes[0]);
                }
                startNode = startNode.NextNode;
            }
        }

        private void SearchToolStripTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                searchToolStripButton.PerformClick();
            }
        }

        public class CustomToolStripRenderer : ToolStripProfessionalRenderer
        {
            public CustomToolStripRenderer() { }

            protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
            {
                LinearGradientMode mode = LinearGradientMode.Horizontal;

                using (LinearGradientBrush b = new LinearGradientBrush(e.AffectedBounds, System.Drawing.Color.White, System.Drawing.Color.White, mode))
                {
                    e.Graphics.FillRectangle(b, e.AffectedBounds);
                }
            }
        }

    }
}




