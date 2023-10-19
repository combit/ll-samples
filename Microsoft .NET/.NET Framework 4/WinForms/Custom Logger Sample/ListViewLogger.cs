using combit.Reporting;
using System;
using System.Windows.Forms;

namespace Custom_Logger_Sample
{


    public class ListViewLogger : LoggerBase
    {

        private readonly ListView _listView;
        private readonly LogCategories _selectedCategories;
        private readonly bool _includeDebugLevel;

        public ListViewLogger(ListView listView, LogCategories selectedCategories, bool includeDebugLevel)
        {
            _listView = listView;
            _selectedCategories = selectedCategories;
            _includeDebugLevel = includeDebugLevel;
        }


        // DE:  Logausgaben erfolgen nur, wenn diese Methode für das gegebene Loglevel (Debug/Info/Warnung/Fehler) und die Logkategorie true zurückliefert.
        //      Um die Performance nicht negativ zu beeinträchtigen, sollten alle nicht benötigten Ausgaben unterdrückt werden (return false).
        // US:  Log output is only enabled with levels and categories for which this method returns true.
        //      To avoid a negative impact on the performance, all unneeded outputs should be suppressed (return false).
        public override bool WantOutput(LogLevels level, LogCategory category)
        {
            if (level == LogLevels.Debug && !_includeDebugLevel)
                return false;

            switch (category)
            {
                case LogCategory.API:
                    return _selectedCategories.EnableApiCalls;
                case LogCategory.DataProvider:
                    return _selectedCategories.EnableDataProvider;
                case LogCategory.Licensing:
                    return _selectedCategories.EnableLicensing;
                case LogCategory.Net:
                    return _selectedCategories.EnableDotNetComponent;
                case LogCategory.Printer:
                    return _selectedCategories.EnablePrinterInformation;

                default:
                    return _selectedCategories.EnableOther;
            }
        }



        // DE:  Erzeuge je eine Zeile je Logausgabe mit passendem Icon. 
        //      Achtung: Der Parameter 'message' kann (!) einen Formatstring enthalten, 'args' die dann passenden Parameter für String.Format().

        // US:  Create one row per log message with a matching icon. 
        //      Note: The parameter 'message' can (!) contain a format string and 'args' the matching parameters for String.Format().

        public override void Debug(LogCategory category, string message, params object[] args)
        {
            if (WantOutput(LogLevels.Debug, category))
                CreateListViewRow(0, category.ToString(), message, args);
        }


        public override void Info(LogCategory category, string message, params object[] args)
        {
            if (WantOutput(LogLevels.Info, category))
                CreateListViewRow(1, category.ToString(), message, args);
        }


        public override void Warn(LogCategory category, string message, params object[] args)
        {
            if (WantOutput(LogLevels.Warning, category))
                CreateListViewRow(2, category.ToString(), message, args);
        }

        public override void Error(LogCategory category, string message, params object[] args)
        {
            if (WantOutput(LogLevels.Error, category))
                CreateListViewRow(3, category.ToString(), message, args);
        }

        private void CreateListViewRow(int imageIndex, string categoryName, string message, object[] formatArgs)
        {
            var formattedMessage = message;

            if (formatArgs != null && formatArgs.Length != 0)
            {
                formattedMessage = String.Format(message, formatArgs);
            }

            _listView.Invoke(new Action(() => {
                _listView.Items.Add(new ListViewItem(
                    /* subItems: */   new string[] { String.Empty, categoryName, formattedMessage },
                    /* imageIndex: */ imageIndex));
            }));
        }


    }
}
