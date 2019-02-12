Imports combit.ListLabel24
Imports System.Windows.Forms

Namespace Custom_Logger_Sample


    Public Class ListViewLogger
        Inherits LoggerBase

        Private ReadOnly _listView As ListView
        Private ReadOnly _selectedCategories As LogCategories
        Private ReadOnly _includeDebugLevel As Boolean

        Public Sub New(listView As ListView, selectedCategories As LogCategories, includeDebugLevel As Boolean)
            _listView = listView
            _selectedCategories = selectedCategories
            _includeDebugLevel = includeDebugLevel
        End Sub


        ' DE:  Logausgaben erfolgen nur, wenn diese Methode für das gegebene Loglevel (Debug/Info/Warnung/Fehler) und die Logkategorie true zurückliefert.
        '      Um die Performance nicht negativ zu beeinträchtigen, sollten alle nicht benötigten Ausgaben unterdrückt werden (return false).
        ' US:  Log output is only enabled with levels and categories for which this method returns true.
        '      To avoid a negative impact on the performance, all unneeded outputs should be suppressed (return false).
        Public Overrides Function WantOutput(level As LogLevels, category As LogCategory) As Boolean
            If level = LogLevels.Debug AndAlso Not _includeDebugLevel Then
                Return False
            End If

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



        ' DE:  Erzeuge je eine Zeile je Logausgabe mit passendem Icon. 
        '      Achtung: Der Parameter 'message' kann (!) einen Formatstring enthalten, 'args' die dann passenden Parameter für String.Format().

        ' US:  Create one row per log message with a matching icon. 
        '      Note: The parameter 'message' can (!) contain a format string and 'args' the matching parameters for String.Format().

        Public Overrides Sub Debug(category As LogCategory, message As String, ParamArray args As Object())
            If WantOutput(LogLevels.Debug, category) Then
                CreateListViewRow(0, category.ToString(), message, args)
            End If
        End Sub


        Public Overrides Sub Info(category As LogCategory, message As String, ParamArray args As Object())
            If WantOutput(LogLevels.Info, category) Then
                CreateListViewRow(1, category.ToString(), message, args)
            End If
        End Sub


        Public Overrides Sub Warn(category As LogCategory, message As String, ParamArray args As Object())
            If WantOutput(LogLevels.Warning, category) Then
                CreateListViewRow(2, category.ToString(), message, args)
            End If
        End Sub

        Public Overrides Sub [Error](category As LogCategory, message As String, ParamArray args As Object())
            If WantOutput(LogLevels.[Error], category) Then
                CreateListViewRow(3, category.ToString(), message, args)
            End If
        End Sub

        Private Sub CreateListViewRow(imageIndex As Integer, categoryName As String, message As String, formatArgs As Object())
            Dim formattedMessage = message

            If formatArgs IsNot Nothing AndAlso formatArgs.Length <> 0 Then
                formattedMessage = [String].Format(message, formatArgs)
            End If

            _listView.Invoke(New Action(Function()
                                            ' subItems: 
                                            ' imageIndex: 
                                            _listView.Items.Add(New ListViewItem(New String() {[String].Empty, categoryName, formattedMessage}, imageIndex))

                                        End Function))
        End Sub


    End Class
End Namespace



