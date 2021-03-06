Imports System.Collections.Generic
Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Imports combit.Reporting

Public Partial Class Form1
    Inherits Form

    Public Sub New()
		InitializeComponent()

		'
		' TODO: Add any constructor code after InitializeComponent call
		'
		If Not File.Exists("rtf.crd") Then
			Directory.SetCurrentDirectory("..\..\")
		End If

		' Preload initial file
		LoadFileInRTFControl(Path.Combine(Directory.GetCurrentDirectory(), "infodlg.rtf"))
	End Sub

    ''' <summary>
    ''' The main entry point for the application.
    ''' </summary>
    <STAThread>
    Friend Shared Sub Main()
        SetProcessDPIAware()
        Application.EnableVisualStyles()
        Application.Run(New Form1())
    End Sub
    <System.Runtime.InteropServices.DllImport("user32.dll")>
    Private Shared Function SetProcessDPIAware() As Boolean
    End Function

    Private Sub LoadFileInRTFControl(FileName As String)
		' Set the contents
		listLabelRTFControl1.Content = File.ReadAllText(FileName, Encoding.ASCII)
	End Sub

	''' <summary>
	''' Property to to get the rtf content. It's read only.
	''' </summary>
	Private ReadOnly Property RtfDataSource() As List(Of RtfContent)
		Get
			listLabelRTFControl1.ContentMode = LlRTFContentMode.Evaluated
			Dim result As New List(Of RtfContent)()
			result.Add(New RtfContent(Me.listLabelRTFControl1.Content))
			Return result
		End Get
	End Property

    Private Sub MenuItem2_Click(sender As Object, e As System.EventArgs) Handles button1.Click
        ' Let user choose file and display
        If ofd.ShowDialog() = DialogResult.OK Then
            LoadFileInRTFControl(ofd.FileName)
        End If
    End Sub

    Private Sub MenuItem6_Click(sender As Object, e As System.EventArgs) Handles button2.Click
        Try
            ' Call designer for project "rtf.crd"
            listLabel1.DataSource = RtfDataSource
            listLabel1.Design("Define RTF Layout", LlProject.Card, "rtf.crd", True)
        Catch LlException As ListLabelException
            ' Catch Exceptions
            MessageBox.Show("Information: " & LlException.Message & vbLf & vbLf & "This information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub MenuItem3_Click(sender As Object, e As System.EventArgs) Handles button3.Click
        Try
            ' Print project "rtf.crd"
            listLabel1.DataSource = RtfDataSource
            listLabel1.Print(LlProject.Card, "rtf.crd", False, LlPrintMode.Export, LlBoxType.StandardWait, "Printing...",
                True, "")
        Catch LlException As ListLabelException
            ' Catch Exceptions
            MessageBox.Show("Information: " & LlException.Message & vbLf & vbLf & "This information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

End Class


' helper class for holding the rtf content
Class RtfContent
	Public Sub New(content__1 As String)
		Content = content__1
	End Sub

	Public Property Content() As String
		Get
			Return m_Content
		End Get
		Set
			m_Content = Value
		End Set
	End Property
	Private m_Content As String
End Class
