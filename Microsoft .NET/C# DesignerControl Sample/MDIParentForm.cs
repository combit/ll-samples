using System;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace DesignerControl
{
    public partial class MdiParentForm : MetroForm
    {
        DesignerChildForm designerForm;

        public MdiParentForm()
        { 
           InitializeComponent();
        }

        private void CreateMdiChild(string fileName, bool showDialog)
        {
            //D: Childform erstellen
            //US: Create the Childform
            designerForm = new DesignerChildForm(fileName, showDialog);
            designerForm.MdiParent = this;
            designerForm.Show();
        }

        private void Menu_itm_proj1_Click(object sender, EventArgs e)
        { 
            //D: schliessen der Hauptform verhindern
            //US:prohibit to close the parenform
            this.ControlBox = false;
            //D: Childform oeffnen mit Projekt 1
            //US:Open the Childform with Project 1
            CreateMdiChild("Sub reports and relations with expandable region.srt", false);
        }

        private void Menu_itm_proj2_Click(object sender, EventArgs e)
        {
            //D: schliessen der Hauptform verhindern
            //US:prohibit to close the parenform
            this.ControlBox = false;
            //D: Childform oeffnen mit Projekt 2
            //US:Open the Childform with Project 2
            CreateMdiChild("Sub reports and relations.srt", false);
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
