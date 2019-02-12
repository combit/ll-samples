using combit.ListLabel24;
using log4net;

namespace Custom_Logger_Sample
{
    public class ListLabel2Log4NetAdapter : LoggerBase
    {

        private readonly ILog _log4netLogger;
        private readonly LogCategories _selectedCategories;

        public ListLabel2Log4NetAdapter(ILog log4netLogger, LogCategories selectedCategories)
        {
            _log4netLogger = log4netLogger;
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
                    isEnabled = _log4netLogger.IsDebugEnabled;
                    break;
                case LogLevels.Info:
                    isEnabled = _log4netLogger.IsInfoEnabled;
                    break;
                case LogLevels.Warning:
                    isEnabled = _log4netLogger.IsWarnEnabled;
                    break;
                case LogLevels.Error:
                    isEnabled = _log4netLogger.IsErrorEnabled;
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


        public override void Debug(LogCategory category, string message, params object[] args)
        {
            if (WantOutput(LogLevels.Debug, category))
                _log4netLogger.DebugFormat(message, args);
        }

        public override void Info(LogCategory category, string message, params object[] args)
        {
            if (WantOutput(LogLevels.Info, category))
                _log4netLogger.InfoFormat(message, args);
        }

        public override void Warn(LogCategory category, string message, params object[] args)
        {
            if (WantOutput(LogLevels.Warning, category))
                _log4netLogger.WarnFormat(message, args);
        }

        public override void Error(LogCategory category, string message, params object[] args)
        {
            if (WantOutput(LogLevels.Error, category))
                _log4netLogger.ErrorFormat(message, args);
        }



    }
}
