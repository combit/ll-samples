Imports combit.Reporting
Imports log4net

Namespace Custom_Logger_Sample
    Public Class ListLabel2Log4NetAdapter
        Inherits LoggerBase

        Private ReadOnly _log4netLogger As ILog
        Private ReadOnly _selectedCategories As LogCategories

        Public Sub New(log4netLogger As ILog, selectedCategories As LogCategories)
            _log4netLogger = log4netLogger
            _selectedCategories = selectedCategories
        End Sub

        ' DE:  Logausgaben erfolgen nur, wenn diese Methode für das gegebene Loglevel (Debug/Info/Warnung/Fehler) und die Logkategorie true zurückliefert.
        '      Um die Performance nicht negativ zu beeinträchtigen, sollten alle nicht benötigten Ausgaben unterdrückt werden (return false).
        ' US:  Log output is only enabled with levels and categories for which this method returns true.
        '      To avoid a negative impact on the performance, all unneeded outputs should be suppressed (return false).
        Public Overrides Function WantOutput(level As LogLevels, category As LogCategory) As Boolean
            Dim isEnabled As Boolean = False

            ' Check if log level is wanted
            Select Case level
                Case LogLevels.Debug
                    isEnabled = _log4netLogger.IsDebugEnabled
                    Exit Select
                Case LogLevels.Info
                    isEnabled = _log4netLogger.IsInfoEnabled
                    Exit Select
                Case LogLevels.Warning
                    isEnabled = _log4netLogger.IsWarnEnabled
                    Exit Select
                Case LogLevels.[Error]
                    isEnabled = _log4netLogger.IsErrorEnabled
                    Exit Select
            End Select

            If Not isEnabled Then
                Return False
            End If

            ' Then check if category is selected
            Select Case category
                Case LogCategory.API
                    Return _selectedCategories.EnableApiCalls
                Case LogCategory.DataProvider
                    Return _selectedCategories.EnableDataProvider
                Case LogCategory.Licensing
                    Return _selectedCategories.EnableLicensing
                Case LogCategory.Net
                    Return _selectedCategories.EnableDotNetComponent
                Case LogCategory.Printer
                    Return _selectedCategories.EnablePrinterInformation
                Case Else

                    Return _selectedCategories.EnableOther
            End Select
        End Function


        Public Overrides Sub Debug(category As LogCategory, message As String, ParamArray args As Object())
            If WantOutput(LogLevels.Debug, category) Then
                _log4netLogger.DebugFormat(message, args)
            End If
        End Sub

        Public Overrides Sub Info(category As LogCategory, message As String, ParamArray args As Object())
            If WantOutput(LogLevels.Info, category) Then
                _log4netLogger.InfoFormat(message, args)
            End If
        End Sub

        Public Overrides Sub Warn(category As LogCategory, message As String, ParamArray args As Object())
            If WantOutput(LogLevels.Warning, category) Then
                _log4netLogger.WarnFormat(message, args)
            End If
        End Sub

        Public Overrides Sub [Error](category As LogCategory, message As String, ParamArray args As Object())
            If WantOutput(LogLevels.[Error], category) Then
                _log4netLogger.ErrorFormat(message, args)
            End If
        End Sub



    End Class
End Namespace

