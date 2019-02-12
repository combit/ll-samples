Imports System.IO
Imports System.Windows.Forms
Imports MetroFramework.Forms

Public Partial Class Form1
    Inherits MetroFramework.Forms.MetroForm
	Public Sub New()
		InitializeComponent()

		'
		' TODO: Add any constructor code after InitializeComponent call
		'
		If Not File.Exists("invoice.ll") Then
			Directory.SetCurrentDirectory("..\..\")
		End If

		' Preload initial file
		PreviewControl.FileName = InlineAssignHelper(statusBarPanel1.Text, Directory.GetCurrentDirectory() & "\invoice.ll")
	End Sub

	''' <summary>
	''' The main entry point for the application.
	''' </summary>
	<STAThread> _
	Friend Shared Sub Main()
		Application.EnableVisualStyles()
		Application.Run(New Form1())
	End Sub

    Private Sub PreviewControl_PageChanged(sender As Object, e As combit.ListLabel24.ListLabelPreviewControl.PageChangedEventArgs) Handles PreviewControl.PageChanged
        ' refresh status text
        statusBarPanel2.Text = [String].Format("Page {0}/{1}", e.NewIndex + 1, PreviewControl.PageCount)
    End Sub

    Private Sub Form1_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        e.Cancel = Not PreviewControl.CanClose()
    End Sub
	Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
		target = value
		Return value
	End Function
End Class
