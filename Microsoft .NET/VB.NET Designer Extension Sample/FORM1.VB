Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports combit.ListLabel24
Imports combit.ListLabel24.Dom
Imports Microsoft.Win32
Imports System.Collections.Generic
Imports MetroFramework.Forms

'Namespace VBSample.DesignerExtensionsSample

Public Class Form1

    Inherits MetroFramework.Forms.MetroForm
    Private MyDataReader As OleDbDataReader
    Friend WithEvents DesignerAction1 As combit.ListLabel24.DesignerAction
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox

    Dim resourcePath As [String]
    Dim pictureFileName As [String]
    Dim projectFileName As [String]
    Private WithEvents Button2 As MetroFramework.Controls.MetroButton
    Private WithEvents CheckBox1 As MetroFramework.Controls.MetroCheckBox
    Private WithEvents Label1 As MetroFramework.Controls.MetroLabel
    Private WithEvents Label5 As MetroFramework.Controls.MetroLabel
    Private WithEvents Label4 As MetroFramework.Controls.MetroLabel
    Private WithEvents Label3 As MetroFramework.Controls.MetroLabel
    Dim lstListBoxItems As New Dictionary(Of Integer, ListBoxItem)()
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Change Directory
        Directory.SetCurrentDirectory("..\..\..\")

        ' init listbox data
        For index As Integer = 1 To 60
            ListBox1.Items.Add("Test-Zeile " + index.ToString() + ".")
        Next

        ' read some information from registry and set some general information
        Dim regKey As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\combit\cmbtll", RegistryKeyPermissionCheck.ReadSubTree)
        If regKey IsNot Nothing Then
            resourcePath = DirectCast(regKey.GetValue("LL" + LlCore.LlGetVersion(LlVersion.Major).ToString + "SampleDir", [String].Empty), [String])
            If resourcePath.EndsWith("\") Then
                resourcePath = resourcePath + "Microsoft .NET\"
            Else
                resourcePath = resourcePath + "\Microsoft .NET\"
            End If
        Else
            MessageBox.Show("Unable to read correct information from registry.")
        End If

        pictureFileName = resourcePath + "sunshine.gif"
        projectFileName = resourcePath + "desext.lst"
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents DesignerFunction1 As combit.ListLabel24.DesignerFunction
    Friend WithEvents DesignerObject1 As combit.ListLabel24.DesignerObject
    Friend WithEvents LL As combit.ListLabel24.ListLabel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.DesignerFunction1 = New combit.ListLabel24.DesignerFunction()
        Me.DesignerObject1 = New combit.ListLabel24.DesignerObject()
        Me.LL = New combit.ListLabel24.ListLabel(Me.components)
        Me.DesignerAction1 = New combit.ListLabel24.DesignerAction()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Button2 = New MetroFramework.Controls.MetroButton()
        Me.CheckBox1 = New MetroFramework.Controls.MetroCheckBox()
        Me.Label1 = New MetroFramework.Controls.MetroLabel()
        Me.Label5 = New MetroFramework.Controls.MetroLabel()
        Me.Label4 = New MetroFramework.Controls.MetroLabel()
        Me.Label3 = New MetroFramework.Controls.MetroLabel()
        Me.SuspendLayout()
        '
        'designerFunction1
        '
        Me.DesignerFunction1.Description = "Add two numeric values"
        Me.DesignerFunction1.FunctionName = "Add"
        Me.DesignerFunction1.GroupName = "Operators"
        Me.DesignerFunction1.MaximumParameters = 2
        Me.DesignerFunction1.MinimalParameters = 2
        Me.DesignerFunction1.Parameter1.Description = "First Value"
        Me.DesignerFunction1.Parameter1.Type = combit.ListLabel24.LlParamType.[Double]
        Me.DesignerFunction1.Parameter2.Description = "Second Value"
        Me.DesignerFunction1.Parameter2.Type = combit.ListLabel24.LlParamType.[Double]
        Me.DesignerFunction1.Parameter3.Description = "Parameter 3"
        Me.DesignerFunction1.Parameter4.Description = "Parameter 4"
        Me.DesignerFunction1.ResultType = combit.ListLabel24.LlParamType.[Double]
        '
        'designerObject1
        '
        Me.DesignerObject1.Description = "Sample Object"
        Me.DesignerObject1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DesignerObject1.Icon = CType(resources.GetObject("designerObject1.Icon"), System.Drawing.Icon)
        Me.DesignerObject1.ObjectName = "SampleObject"
        Me.DesignerObject1.SupportsContentDialog = True
        Me.DesignerObject1.TooltipDescription = Nothing
        '
        'LL
        '
        Me.LL.AutoPrinterSettingsStream = Nothing
        Me.LL.AutoProjectStream = Nothing
        Me.LL.CompressStorage = True
        Me.LL.DesignerActions.AddRange(New combit.ListLabel24.DesignerAction() {Me.DesignerAction1})
        Me.LL.DesignerFunctions.AddRange(New combit.ListLabel24.DesignerFunction() {Me.DesignerFunction1})
        Me.LL.DesignerObjects.AddRange(New combit.ListLabel24.DesignerObject() {Me.DesignerObject1})
        Me.LL.DrilldownAvailable = True
        Me.LL.EMFResolution = 100
        Me.LL.LockNextChar = 8288
        Me.LL.MaxRTFVersion = 65280
        Me.LL.PhantomSpace = 8203
        Me.LL.PreviewControl = Nothing
        Me.LL.Unit = combit.ListLabel24.LlUnits.Millimeter_1_100
        Me.LL.UseHardwareCopiesForLabels = False
        Me.LL.UseTableSchemaForDesignMode = False
        '
        'DesignerAction1
        '
        Me.DesignerAction1.IconId = 642
        Me.DesignerAction1.MenuHierarchy = "1.1"
        Me.DesignerAction1.MenuText = "Find object"
        Me.DesignerAction1.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.DesignerAction1.TooltipText = "Find object"
        '
        'ListBox1
        '
        Me.ListBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(23, 120)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.ScrollAlwaysVisible = True
        Me.ListBox1.Size = New System.Drawing.Size(489, 303)
        Me.ListBox1.TabIndex = 9
        '
        'button2
        '
        Me.Button2.Location = New System.Drawing.Point(437, 429)
        Me.Button2.Name = "button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 16
        Me.Button2.Text = "Design..."
        Me.Button2.UseSelectable = True
        '
        'checkBox1
        '
        Me.CheckBox1.Location = New System.Drawing.Point(23, 429)
        Me.CheckBox1.Name = "checkBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(144, 24)
        Me.CheckBox1.Style = MetroFramework.MetroColorStyle.Blue
        Me.CheckBox1.TabIndex = 15
        Me.CheckBox1.Text = "Enable Debug Output"
        Me.CheckBox1.UseSelectable = True
        '
        'label1
        '
        Me.Label1.FontSize = MetroFramework.MetroLabelSize.Small
        Me.Label1.Location = New System.Drawing.Point(23, 91)
        Me.Label1.Name = "label1"
        Me.Label1.Size = New System.Drawing.Size(24, 16)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "US:"
        '
        'label5
        '
        Me.Label5.FontSize = MetroFramework.MetroLabelSize.Small
        Me.Label5.Location = New System.Drawing.Point(23, 69)
        Me.Label5.Name = "label5"
        Me.Label5.Size = New System.Drawing.Size(24, 16)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "D:  "
        '
        'label4
        '
        Me.Label4.FontSize = MetroFramework.MetroLabelSize.Small
        Me.Label4.Location = New System.Drawing.Point(53, 91)
        Me.Label4.Name = "label4"
        Me.Label4.Size = New System.Drawing.Size(410, 16)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "This sample shows the extension of the designer with VB.NET."
        Me.Label4.WrapToLine = True
        '
        'label3
        '
        Me.Label3.FontSize = MetroFramework.MetroLabelSize.Small
        Me.Label3.Location = New System.Drawing.Point(53, 69)
        Me.Label3.Name = "label3"
        Me.Label3.Size = New System.Drawing.Size(410, 22)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Dieses Beispiel zeigt die Erweiterung des Designers mit VB.NET."
        Me.Label3.WrapToLine = True
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(535, 470)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ListBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(535, 470)
        Me.Name = "Form1"
        Me.Style = MetroFramework.MetroColorStyle.Blue
        Me.Text = "List & Label VB.NET Designer Extension Sample"
        Me.ResumeLayout(False)

    End Sub

#End Region

    ' D: Implementierung der neuen Designer Add-Funktion
    'US: Implementation of the new designer add-function
    Private Sub DesignerFunction1_EvaluateFunction(ByVal sender As System.Object, ByVal e As combit.ListLabel24.EvaluateFunctionEventArgs) Handles DesignerFunction1.EvaluateFunction
        e.ResultValue = (Double.Parse(e.Parameter1.ToString()) + Double.Parse(e.Parameter2.ToString()))
    End Sub

    ' D: Die hier spezifizierten Parameter Werte (1 - 20), werden beim Eintippen der Formel im Designer vorgeschlagen
    'US: The specified parameter values (1 - 20), are suggested while typeing the formula in the designer 
    Private Sub DesignerFunction1_ParameterAutoComplete(ByVal sender As Object, ByVal e As combit.ListLabel24.ParameterAutoCompleteEventArgs) Handles DesignerFunction1.ParameterAutoComplete
        Dim i As Int16
        For i = 1 To 20
            e.Values.Add(i.ToString())
        Next
    End Sub

    ' D: Implementierung eines Designer Objektes, welches ein Bild beinhaltet
    'US: Implementation of a designer object, which contains an image
    Private Sub DesignerObject1_DrawDesignerObject(ByVal sender As System.Object, ByVal e As combit.ListLabel24.DrawDesignerObjectEventArgs) Handles DesignerObject1.DrawDesignerObject
        Dim desobj As DesignerObject
        Dim imagefile As String
        Dim bm As Bitmap

        desobj = sender
        If desobj.ObjectProperties.Contains("imagefile") Then
            Directory.SetCurrentDirectory(resourcePath)
            imagefile = desobj.ObjectProperties("imagefile")
            bm = New Bitmap(imagefile)
            e.Graphics.DrawImage(bm, e.ClipRectangle)
        End If
    End Sub

    ' D: Implementierung der Bearbeiten-Funktion, des neuen Objektes
    'US: Implementation of the new edit function for the new object
    Private Sub DesignerObject1_EditDesignerObject(ByVal sender As Object, ByVal e As combit.ListLabel24.EditDesignerObjectEventArgs) Handles DesignerObject1.EditDesignerObject
        Dim desobj As DesignerObject
        Dim dialog As OpenFileDialog

        desobj = sender
        dialog = New OpenFileDialog()
        dialog.Filter = "All Picture Files (*.jpg;*.bmp;*.png;*.wmf;*.gif)|*.jpg;*.bmp;*.png;*.wmf;*.gif|All Files (*.*)|*.*"

        If desobj.ObjectProperties.Contains("imagefile") Then
            dialog.FileName = desobj.ObjectProperties("imagefile")
        End If

        If dialog.ShowDialog(e.DesignerWindow) = System.Windows.Forms.DialogResult.OK Then
            desobj.ObjectProperties("imagefile") = dialog.FileName
            e.HasChanged = True
        End If
    End Sub


    ' D: Das standard Verhalten eines dem Report neu hinzugefügten Objekts festlegen
    'US: Define the default behaviour of a new added object to a report
    Private Sub DesignerObject1_CreateDesignerObject(ByVal sender As Object, ByVal e As combit.ListLabel24.CreateDesignerObjectEventArgs) Handles DesignerObject1.CreateDesignerObject
        Dim desobj As DesignerObject
        desobj = sender
        desobj.ObjectProperties("imagefile") = "logo.bmp"
    End Sub

    ' D: Dem Designer wird eine Such-Funktion in der "Aktionen" Toolbar hinzugefügt
    'US: A search function is added to the designer in the "Actions" toolbar
    Private Sub DesignerAction1_ExecuteAction(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DesignerAction1.ExecuteAction
        Dim proj As New ProjectList(LL)
        proj.GetFromParent()

        Dim message As String = "Which object are you looking for?"
        Dim returnValue As Object = InputBox(message, "Find Object", "Upper Text")
        Dim objName As String = returnValue.ToString()

        proj.DesignerRedraw = "False"
        Dim found As Boolean = False

        For Each obj As ObjectBase In proj.Objects
            If obj.Name.Contains(objName) Then
                found = True
                obj.Selected = "True"
            Else
                obj.Selected = "False"
            End If
        Next

        proj.DesignerRedraw = "True"

        If Not found Then
            MessageBox.Show("The object could not be found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    ' Button "Design"
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ' Hint:
        ' Because while using a owner drawn ListBox, each element have
        ' to be made visible so all items becomes drawn and are available!

        Try
            ' 
            Dim designerObjectListBox As New ListBoxDesignerObject("ListBox", "ListBox Object", DesignerObject1.Icon, lstListBoxItems, ListBox1)
            LL.DesignerObjects.Add(designerObjectListBox)

            ' enable data-binding for easy usage of the report-container with static table
            Dim lstData As New List(Of Integer)()
            lstData.Add(1)
            LL.SetDataBinding(lstData)

            LL.AutoFileAlsoNew = True
            LL.Design("Designer Extensions with List & Label", LlProject.List, projectFileName, True)
        Catch exc As ListLabelException
            MessageBox.Show("Information: " + exc.Message + vbLf & vbLf & "This information was generated by a List & Label custom exception.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    ' Checkbox  "Debug"
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If CheckBox1.Checked Then
            LL.Debug = LlDebug.Enabled
            MessageBox.Show("D:   DEBWIN muss zur Anzeige von Debugausgaben gestartet werden" + vbCrLf + "US: Start DEBWIN to receive debug messages")
        Else
            LL.Debug = LlDebug.Disabled
        End If
    End Sub

    Private Sub ListBox1_DrawItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles ListBox1.DrawItem
        ' Draw the background of the ListBox control for each item.
        e.DrawBackground()

        ' Draw the current item text based on the current Font and the custom brush settings.
        Dim listBoxItem As ListBoxItem = lstListBoxItems(e.Index)
        e.Graphics.DrawString(ListBox1.Items(e.Index).ToString(), listBoxItem.Font, listBoxItem.Brush, e.Bounds, StringFormat.GenericDefault)
    End Sub

    Private Sub ListBox1_MeasureItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MeasureItemEventArgs) Handles ListBox1.MeasureItem
        ' Define the default color of the brush as black.
        Dim itemBrush As New SolidBrush(Color.Black)
        Dim itemFont As Font = ListBox1.Font

        ' Determine the color of the brush to draw each item based on the index of the item to draw.
        If ((e.Index + 1) Mod 10) = 0 Then
            e.ItemHeight = 20
            itemBrush = New SolidBrush(Color.Red)
            itemFont = New Font("Tahoma", 12)
        ElseIf ((e.Index + 12) Mod 10) = 0 Then
            e.ItemHeight = 22
            itemBrush = New SolidBrush(Color.Orange)
            itemFont = New Font("Tahoma", 14)
        ElseIf ((e.Index + 13) Mod 10) = 0 Then
            e.ItemHeight = 24
            itemBrush = New SolidBrush(Color.Purple)
            itemFont = New Font("Tahoma", 16)
        End If

        ' create item and add it to list
        Dim listBoxItem As New ListBoxItem(ListBox1.Items(e.Index).ToString(), itemFont, itemBrush, New Rectangle(0, 0, e.ItemWidth, e.ItemHeight))
        lstListBoxItems(e.Index) = listBoxItem
    End Sub
End Class
'End Namespace
