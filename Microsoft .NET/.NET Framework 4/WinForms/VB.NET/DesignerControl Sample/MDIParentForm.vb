Imports System.Windows.Forms


Public Partial Class MdiParentForm
    Inherits Form
    Private designerForm As DesignerChildForm

	Public Sub New()
		InitializeComponent()
	End Sub

	Private Sub CreateMdiChild(fileName As String, showDialog As Boolean)
		'D: Childform erstellen
		'US: Create the Childform
		designerForm = New DesignerChildForm(fileName, showDialog)
		designerForm.MdiParent = Me
		designerForm.Show()
	End Sub

    Private Sub Menu_itm_proj1_Click(sender As Object, e As EventArgs) Handles menu_itm_proj1.Click
        'D: schliessen der Hauptform verhindern
        'US:prohibit to close the parenform
        Me.ControlBox() = False
        'D: Childform oeffnen mit Projekt 1
        'US:Open the Childform with Project 1
        CreateMdiChild("Sub reports and relations with expandable region.srt", False)
    End Sub

    Private Sub Menu_itm_proj2_Click(sender As Object, e As EventArgs) Handles menu_itm_proj2.Click
        'D: schliessen der Hauptform verhindern
        'US:prohibit to close the parenform
        Me.ControlBox() = False
        'D: Childform oeffnen mit Projekt 2
        'US:Open the Childform with Project 2
        CreateMdiChild("Sub reports and relations.srt", False)

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles exitToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class
