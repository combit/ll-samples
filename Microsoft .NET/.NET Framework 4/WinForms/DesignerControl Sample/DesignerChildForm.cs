﻿using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
using combit.Reporting;
using Microsoft.Win32;

namespace DesignerControl
{
    public partial class DesignerChildForm : Form
    {
        private DesignerChildForm()
        {
        }
       
        public DesignerChildForm(string fileName, bool showDialog)
        {           
            InitializeComponent();          

            //D: Pfad auf Sample-Hauptverzeichnis setzen, Datenbankpfad auslesen
            //US: Set path to main sample path, read database path
            Directory.SetCurrentDirectory(Application.StartupPath + @"\..\..\..\..\..\Report Files");
            
            try
            {                 
                //D: Diverse List & Label Eigenschaften/Optionen setzen
                //US: Set some List & Label properties/options
                LL.AutoProjectFile = fileName;
                LL.AutoShowSelectFile = showDialog;
                LL.FileExtensions.SetFileExtension(LlProject.List, LlFileType.Project, "srt");
                LL.FileExtensions.SetFileExtension(LlProject.List, LlFileType.PrinterSettings, "srp");
                LL.FileExtensions.SetFileExtension(LlProject.List, LlFileType.Sketch, "srv");
                LL.DataSource = this.CreateDataSet();

            }
            catch (ListLabelException LlException)
            {
                //D: Exception abfangen
                //US: Catch Exceptions
                MessageBox.Show("Information: " + LlException.Message + "\n\nThis information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private DataSet CreateDataSet()
        {
            //D:  Datenbankpfad auslesen
            //US: read database path
            RegistryKey installKey = Registry.CurrentUser.CreateSubKey(@"Software\combit\cmbtll");

            string databasePath = String.Empty;
            if (installKey != null)
                databasePath = (string)installKey.GetValue("NWINDPath", string.Empty);

            if (databasePath.Length == 0)
                MessageBox.Show("Unable to find sample database. Make sure List & Label is installed correctly.", "List & Label");
            
            DataSet ds = new DataSet();

            //D: DataSet Objekt erstellen
            //US: Create the DataSet object
            OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + databasePath);

            conn.Open();

            object[] restrictions = new Object[] { null, null, null, "TABLE" };
            DataTable table = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, restrictions);

            //D: Durch alle Tabellen iterieren und in das DataSet aufnehmen
            //US: Iterate all tabels and add them to the DataSet
            foreach (DataRow dr in table.Rows)
            {
                string tableName = dr["Table_Name"].ToString();
                OleDbDataAdapter dataAdapter;

                //D: Die "Orders" und "Order Details" Tabelle einschränken.
                //US: Limit the "Order" an "Order Details" table. 
                if (tableName == "Orders" || tableName == "Order Details")
                    dataAdapter = new OleDbDataAdapter(new OleDbCommand("SELECT * FROM [" + tableName + "] WHERE OrderID > 11040", conn));
                else
                    dataAdapter = new OleDbDataAdapter(new OleDbCommand("SELECT * FROM [" + tableName + "]", conn));

                dataAdapter.FillSchema(ds, SchemaType.Source, tableName);
                dataAdapter.Fill(ds, tableName);

            }

            object[] restrictions1 = new Object[] { null, null, null, null };
            DataTable table1 = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Foreign_Keys, restrictions1);

            //D: Relationen auslesen
            //US: Get relations
            foreach (DataRow dr in table1.Rows)
            {
                string sChildTable = dr["FK_TABLE_NAME"].ToString();
                string sChildCol = dr["FK_COLUMN_NAME"].ToString();
                // D:  Eltern = Primary
                //US: Parent = primary
                string sParentTable = dr["PK_TABLE_NAME"].ToString();
                string sParentCol = dr["PK_COLUMN_NAME"].ToString();
                string sRelationName = sParentTable + "2" + sChildTable;

                //D: Beziehung zwischen den Tabellen definieren
                //US: Create the relationships between the tables
                ds.Relations.Add(new DataRelation(sRelationName, ds.Tables[sParentTable].Columns[sParentCol], ds.Tables[sChildTable].Columns[sChildCol]));
            }

            //D: Verbindung schliessen
            //US: Close connection
            conn.Close();
            return (ds);
        }

        private void DesignerChildForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!designerControl1.CanClose())
                e.Cancel = true;
        }

        private void DesignerChildForm_Shown(object sender, EventArgs e)
        {
            ParentForm.ControlBox = true;
        }
    }
}
