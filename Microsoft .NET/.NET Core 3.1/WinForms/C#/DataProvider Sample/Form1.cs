﻿using System;
using System.IO;
using System.Windows.Forms;

namespace combit.Reporting.Samples
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //D: Pfad auf Sample-Hauptverzeichnis setzen
            //US: Set path to main sample path
            Directory.SetCurrentDirectory(Application.StartupPath + @"\..\..\..\..\..\..\..\Report Files");
        }

        private void DesignBtn_Click(object sender, EventArgs e)
        {
			CsvDataProvider provider = new CsvDataProvider(Path.Combine(Application.StartupPath,"test.txt"));
            ListLabel ll = new ListLabel();
            ll.DataSource = provider;
            ll.AutoProjectFile = "CsvDataProvider.lst";
            try
            {
                ll.Design();
            }
            catch (ListLabelException LlException)
            {
                // Catch Exceptions
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ll.Dispose();
        }

        private void PrintBtn_Click(object sender, EventArgs e)
        {
			CsvDataProvider provider = new CsvDataProvider(Path.Combine(Application.StartupPath,"test.txt"));
            ListLabel ll = new ListLabel();            
            ll.DataSource = provider;
            ll.AutoProjectFile = "CsvDataProvider.lst";
            try
            {
                ll.Print();
            }
            catch (ListLabelException LlException)
            {
                // Catch Exceptions
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            ll.Dispose();
        }
    }
}