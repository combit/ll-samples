using System;
using System.IO;
using System.Windows.Forms;

namespace csharpviewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            Directory.SetCurrentDirectory(@"..\..\..\..\..\..\Report Files");
            

            // Preload initial file
            PreviewControl.FileName = statusBarPanel1.Text = Directory.GetCurrentDirectory() + "\\invoice.ll";
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SetProcessDPIAware();
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

        private void PreviewControl_PageChanged(object sender, combit.Reporting.ListLabelPreviewControl.PageChangedEventArgs e)
        {
            // refresh status text
            statusBarPanel2.Text = String.Format("Page {0}/{1}", e.NewIndex + 1, PreviewControl.PageCount);
        }

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = !PreviewControl.CanClose();
        }
    }
}
