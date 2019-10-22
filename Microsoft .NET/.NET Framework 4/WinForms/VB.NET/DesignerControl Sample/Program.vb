Imports System.Collections.Generic
Imports System.Linq
Imports System.Windows.Forms

NotInheritable Class Program
	Private Sub New()
	End Sub
    ''' <summary>
    ''' The main entry point for the application.
    ''' </summary>
    <STAThread>
    Friend Shared Sub Main()
        SetProcessDPIAware()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New MdiParentForm())
    End Sub
    <System.Runtime.InteropServices.DllImport("user32.dll")>
    Private Shared Function SetProcessDPIAware() As Boolean
    End Function
End Class
