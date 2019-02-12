using combit.ListLabel24;
using NLog;

namespace Custom_Logger_Sample
{

    /// <summary>
    /// ILlLogger implementation which forwards debug output of ListLabel to a logger object of the NLog Framework.
    /// </summary>
    public class ListLabel2NLogAdapter : LoggerBase
    {
        private readonly ILogger _nlogInstance;
        private readonly LogCategories _selectedCategories;

        public ListLabel2NLogAdapter(ILogger nlogLogger, LogCategories selectedCategories)
        {
            _nlogInstance = nlogLogger;
            _selectedCategories = selectedCategories;
        }

        // DE:  Logausgaben erfolgen nur, wenn diese Methode für das gegebene Loglevel (Debug/Info/Warnung/Fehler) und die Logkategorie true zurückliefert.
        //      Um die Performance nicht negativ zu beeinträchtigen, sollten alle nicht benötigten Ausgaben unterdrückt werden (return false).
        // US:  Log output is only enabled with levels and categories for which this method returns true.
        //      To avoid a negative impact on the performance, all unneeded outputs should be suppressed (return false).
        public override bool WantOutput(LogLevels level, LogCategory category)
        {
            bool isEnabled = false;

            // Check if log level is wanted
            switch (level)
            {
                case LogLevels.Debug:
                    isEnabled = _nlogInstance.IsDebugEnabled;
                    break;
                case LogLevels.Info:
                    isEnabled = _nlogInstance.IsInfoEnabled;
                    break;
                case LogLevels.Warning:
                    isEnabled = _nlogInstance.IsWarnEnabled;
                    break;
                case LogLevels.Error:
                    isEnabled = _nlogInstance.IsErrorEnabled;
                    break;
            }

            if (!isEnabled)
                return false;

            // Then check if category is selected
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




        // DE:  Achtung: Der Parameter 'message' enthält einen Formatstring, 'args' die passenden Parameter für String.Format().
        // US:  Note: The parameter 'message' contains a format string and 'args' the matching parameters for String.Format().

        public override void Debug(LogCategory category, string message, params object[] args)
        {
            if (WantOutput(LogLevels.Debug, category))
                _nlogInstance.Debug(message, args);
        }

        public override void Info(LogCategory category, string message, params object[] args)
        {
            if (WantOutput(LogLevels.Info, category))
                _nlogInstance.Info(message, args);
        }

        public override void Warn(LogCategory category, string message, params object[] args)
        {
            if (WantOutput(LogLevels.Warning, category))
                _nlogInstance.Warn(message, args);
        }

        public override void Error(LogCategory category, string message, params object[] args)
        {
            if (WantOutput(LogLevels.Error, category))
                _nlogInstance.Error(message, args);
        }



    }
}
