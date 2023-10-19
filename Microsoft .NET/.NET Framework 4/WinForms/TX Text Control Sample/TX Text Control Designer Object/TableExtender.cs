using System;
using System.Collections.Generic;
using System.Text;
using TXTextControl;

namespace TXTextControl
{
    public static class TableExtender
    {
        public static void AutoSize(this TXTextControl.Table table, TXTextControl.ServerTextControl TextControl)
        {
            int[] iColWidths = new int[table.Columns.Count];

            foreach (TXTextControl.TableCell tc in table.Cells)
            {
                int iTextBounds = 0;

                // check the width of every line in a cell
                for (int i = tc.Start; i <= tc.Start + tc.Length - 1; i++)
                {
                    // pick width, if the current one is the longest
                    if (TextControl.Lines.GetItem(i).TextBounds.Width > iTextBounds)
                    {
                        iTextBounds = TextControl.Lines.GetItem(i).TextBounds.Width;
                    }
                }

                // pick the width, if it is the longest in the whole column
                if (iTextBounds > (int)iColWidths.GetValue(tc.Column - 1))
                    iColWidths.SetValue(iTextBounds, tc.Column - 1);
            }

            // resize the table according to the filled array
            for (int iColCount = 1; iColCount <= table.Columns.Count; iColCount++)
            {
                if ((int)iColWidths.GetValue(iColCount - 1) != 0)
                {
                    TableColumn tcColumn = table.Columns.GetItem(iColCount);

                    tcColumn.Width =
                        (int)iColWidths.GetValue(iColCount - 1) +
                        tcColumn.CellFormat.RightTextDistance +
                        tcColumn.CellFormat.LeftTextDistance +
                        tcColumn.CellFormat.RightBorderWidth +
                        tcColumn.CellFormat.LeftBorderWidth;
                }
            }
        }

        public static void SpreadToPage(this Table table, TXTextControl.ServerTextControl TextControl)
        {
            TextControl.InputPosition = new InputPosition(table.Cells.GetItem(1, 1).Start - 1);

            double iAvailableWidth = TextControl.Sections.GetItem().Format.PageSize.Width -
                TextControl.Sections.GetItem().Format.PageMargins.Left -
                TextControl.Sections.GetItem().Format.PageMargins.Right;

            foreach (TableColumn column in table.Columns)
            {
                column.Width = (int)(iAvailableWidth * 14.4) / table.Columns.Count;
            }
        }
    }
}