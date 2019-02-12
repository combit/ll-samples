Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.IO
Imports System.Windows.Forms
Imports System.Xml
Imports combit.ListLabel24
Imports combit.ListLabel24.Dom
Imports MetroFramework.Forms

Public Partial Class Form1
    Inherits MetroFramework.Forms.MetroForm
	Private _ll As New ListLabel()
	Private _fileName As String = [String].Empty
	Private _typeInfos As New Dictionary(Of String, String)()
	Private _selectedNode As TreeNode

	Public Sub New()
		InitializeComponent()

		Me.GenerateCodeToolStrip.Enabled = False
		Me.SaveCodeToolStrip.Enabled = False
		Me.ListLabelToolStrip.Enabled = False
		Me.ReadInfos()
		Directory.SetCurrentDirectory("..\..\..\")
	End Sub

    Private Sub OpenProjectFileToolStrip_Click(sender As Object, e As EventArgs) Handles OpenProjectFileToolStrip.Click
        'D: Dateiauswahl anzeigen und Projektdatei auswählen
        'US: Show OpenFileDialog to selected a project file
        Dim dialog As New OpenFileDialog()
        dialog.Filter = "List & Label reports (*.lbl;*.lst;*.crd;*.srt)|*.lbl;*.lst;*.crd;*.srt|All files (*.*)|*.*"

        If dialog.ShowDialog() = DialogResult.OK Then
            Try
                rtbCode.Clear()

                If Me.TreeView1.Project IsNot Nothing Then
                    Me.TreeView1.Project.Close()
                    Me.TreeView1.Project.Dispose()
                End If

                Me.TreeView1.Load(dialog.FileName)

                _fileName = dialog.FileName

                Me.GenerateCodeToolStrip.Enabled = True
                Me.ListLabelToolStrip.Enabled = True
            Catch ex As Exception
                MessageBox.Show(ex.Message)
                _fileName = [String].Empty
                Me.ListLabelToolStrip.Enabled = False
                Me.GenerateCodeToolStrip.Enabled = False
            End Try
        End If
    End Sub

    Private Sub ListLabelToolStrip_Click(sender As Object, e As EventArgs) Handles ListLabelToolStrip.Click

        ' D:  Das aktuelle Projekt schliessen.
        ' US: Close the current project.
        Me.TreeView1.Project.Close()
        Me.TreeView1.Project.Dispose()

        'D:  Bevor die Projektdatei im Designer angezeigt werden kann,
        '    wird noch der Projekttyp benötigt
        'US: Before we can display the project we need to know wich is the current project type
        Dim projectType As LlProject = _ll.Core.LlUtilsGetProjectType(_fileName)

        ' D: Um das ausgewähle Projekt im Designer laden zu können, benötigt List & Label eine Dummy-Datenquelle
        ' US: To be able to use the selected project in the designer, we need a dummy-datasource
        _ll.DataSource = New List(Of Integer)()

        'D:  Projekt mit dem Designer laden
        'US: Load project with the Designer
        _ll.Design(projectType, _fileName)

        'D:  Projekt erneut laden
        'US: Reload the project 
        Me.TreeView1.Load(_fileName)

    End Sub

    Private Sub CopyToolStrip_Click(sender As Object, e As EventArgs) Handles CopyToolStrip.Click
        Me.rtbCode.Copy()
    End Sub

    Private Sub CutToolStrip_Click(sender As Object, e As EventArgs) Handles CutToolStrip.Click
        Me.rtbCode.Cut()
    End Sub

	Private Sub ReadInfos()
		'D: Visual Studio Kommentare für List & Label laden
		'US: Load Visual Studio comments

		If Not System.IO.File.Exists("..\..\..\Assemblies\Assemblies 2.0\combit.ListLabel24.xml") Then
			Return
		End If

		Dim helpDoc As New XmlDocument()
		helpDoc.Load("..\..\..\Assemblies\Assemblies 2.0\combit.ListLabel24.xml")

		Dim nodeList As XmlNodeList = helpDoc.SelectNodes("/doc/members/member")

		For Each node As XmlNode In nodeList
			Dim type As String = node.Attributes.Item(0).Value
			If type.StartsWith("T:") Then
				Dim text As String = node.FirstChild.InnerText
				text = text.Replace("     ", " ")
				text = text.Replace("    ", " ")
				text = text.Replace("List & Label", "List && Label")

				If text.StartsWith(" ") Then
					text = text.Substring(1)
				End If
				_typeInfos.Add(type.Substring(2), text)
			End If
		Next
	End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        'D: Kommentar zum aktuell ausgewählten List & List Objekt anzeigen
        'US: Display the comment for the selected List & Label Object

        Me.TreeView1.[Select]()
        Me.label1.Text = ""

        _selectedNode = Me.TreeView1.SelectedNode

        If _selectedNode.Tag IsNot Nothing Then
            Dim type As String = _selectedNode.Tag.ToString()

            If _typeInfos.ContainsKey(type) Then
                Dim info As String = _typeInfos(type)
                Me.label1.Text = info
            End If
        End If

        Me.TreeView1.[Select]()
        Me.GenerateCodeToolStrip.Enabled = (TypeOf _selectedNode.Tag Is DomItem Or TypeOf _selectedNode.Tag Is DomCollectionBase)
        Me.GenerateCodeToolStrip2.Enabled = (TypeOf _selectedNode.Tag Is DomItem Or TypeOf _selectedNode.Tag Is DomCollectionBase)

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CodeLanguageToolStripCombo.SelectedIndex = 0
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles SaveCodeToolStrip.Click

        'D: Dateiauswahldialog anzeigen um erzeugten Code zu speichern
        'US: Display SaveFileDialog to save the generated Code

        Dim dialog As New SaveFileDialog()
        dialog.AddExtension = True
        dialog.DefaultExt = If(Me.CodeLanguageToolStripCombo.Text = "C#", "cs", "vb")
        dialog.Filter = If(Me.CodeLanguageToolStripCombo.Text = "C#", "*.cs | *.cs", "*.vb | *.vb")

        If dialog.ShowDialog() = DialogResult.OK Then
            Me.rtbCode.SaveFile(dialog.FileName, RichTextBoxStreamType.PlainText)
        End If
    End Sub

    Private Sub GenerateCodeToolStrip2_Click(sender As Object, e As EventArgs) Handles GenerateCodeToolStrip2.Click
        If _selectedNode Is Nothing Then
            MessageBox.Show("Please select a Node!")
            Return
        End If

        Me.TreeView1.[Select]()
        Me.GenerateCode(_selectedNode.Tag)
    End Sub

    Private Sub GenerateCodeTooStrip_Click(sender As Object, e As EventArgs) Handles GenerateCodeToolStrip.Click
        If _selectedNode Is Nothing Then
            MessageBox.Show("Please select a Node!")
            Return
        End If

        Me.TreeView1.[Select]()
        Me.GenerateCode(_selectedNode.Tag)
    End Sub

	Private Sub GenerateCode(item As Object)

		If (TypeOf item Is DomItem) Or (TypeOf item Is DomCollectionBase) Then
			Try

				Dim serializer As New ListLabelCodeDomSerializer()

				'D: CodeDomProvider auswählen
				'US: Select CodeDomProvider

				If Me.CodeLanguageToolStripCombo.Text = "C#" Then
					serializer.Provider = System.CodeDom.Compiler.CodeDomProvider.CreateProvider("C#")
				Else
					serializer.Provider = System.CodeDom.Compiler.CodeDomProvider.CreateProvider("VB")
				End If

				Dim code As Object = serializer.Serialize(Nothing, item)

				Me.rtbCode.Text = Convert.ToString(code)

				Me.SaveCodeToolStrip.Enabled = True
			Catch ex As Exception
				MessageBox.Show(ex.Message)
			End Try
		End If
	End Sub

    Private Sub ContextMenuStrip1_Opening(sender As Object, e As CancelEventArgs) Handles contextMenuStrip1.Opening
        If Me.TreeView1.SelectedNode Is Nothing Then
            e.Cancel = True
            Return
        End If
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        If _ll IsNot Nothing Then
            _ll.Dispose()

            _ll = Nothing
        End If

        If Me.TreeView1.Project IsNot Nothing Then
            Me.TreeView1.Project.Close()
            Me.TreeView1.Project.Dispose()
        End If
    End Sub

    Private Sub CutToolStripMenu_Click(sender As Object, e As EventArgs) Handles CutToolStripMenu.Click
        Me.rtbCode.Cut()
    End Sub

    Private Sub CopyToolStripMenu_Click(sender As Object, e As EventArgs) Handles CopyToolStripMenu.Click
        Me.rtbCode.Copy()
    End Sub
End Class




