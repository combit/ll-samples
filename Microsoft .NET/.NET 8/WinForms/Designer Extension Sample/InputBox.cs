using System;
using System.Drawing;
using System.Windows.Forms;

namespace C_
{
    public partial class InputBox : Form
    {
        private bool OK = false;
        public InputBox(string Prompt, string Title, string DefaultResponse, int XPos, int YPos)
        {
            InitializeComponent();
            LabelPrompt.Text = Prompt;
            Text = Title;
            TextBoxEntry.Text = DefaultResponse;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(XPos, YPos);
            this.ShowDialog();
        }
        public string GetReturnValue()
        {
            if (OK)
            {
                return TextBoxEntry.Text;
            }
            else
            {
                return "";
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            OK = false;
            this.Close();
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            OK = true;
            this.Close();
        }

        private void TextBoxEntry_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                OK = true;
                this.Close();
            }
        }

        private void InputBox_Shown(object sender, EventArgs e)
        {
            TextBoxEntry.SelectAll();
            TextBoxEntry.Focus();
        }
    }
}
