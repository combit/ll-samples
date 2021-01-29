Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports combit.Reporting
Imports combit.Reporting.Dom
Imports Microsoft.Win32
Imports System.Collections.Generic
'Namespace VBSample.DesignerExtensionsSample
Public Class Form1
    Inherits Form
    Private MyDataReader As OleDbDataReader
    Friend WithEvents DesignerAction1 As combit.Reporting.DesignerAction
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Dim resourcePath As [String]
    Dim pictureFileName As [String]
    Dim projectFileName As [String]
    Private WithEvents Button2 As System.Windows.Forms.Button
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents Label4 As System.Windows.Forms.Label
    Private WithEvents Label3 As System.Windows.Forms.Label
    Dim lstListBoxItems As New Dictionary(Of Integer, ListBoxItem)()
#Region " Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Change Directory
        Directory.SetCurrentDirectory("..\..\..\..\..\Report Files")
        ' init listbox data
        For index As Integer = 1 To 60
            ListBox1.Items.Add("Test-Zeile " + index.ToString() + ".")
        Next
        ' read some information from registry and set some general information
        Dim regKey As RegistryKey = Registry.CurrentUser.CreateSubKey("Software\combit\cmbtll", RegistryKeyPermissionCheck.ReadSubTree)
        If regKey IsNot Nothing Then
            resourcePath = DirectCast(regKey.GetValue("LL" + LlCore.LlGetVersion(LlVersion.Major).ToString + "SampleDir", [String].Empty), [String])
            If resourcePath.EndsWith("\") Then
                resourcePath = resourcePath + "Microsoft .NET\Report Files\"
            Else
                resourcePath = resourcePath + "\Microsoft .NET\Report Files\"
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
    Friend WithEvents DesignerFunction1 As combit.Reporting.DesignerFunction
    Friend WithEvents DesignerObject1 As combit.Reporting.DesignerObject
    Friend WithEvents LL As combit.Reporting.ListLabel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.DesignerFunction1 = new combit.Reporting.DesignerFunction()
        Me.DesignerObject1 = new combit.Reporting.DesignerObject()
        Me.LL = new combit.Reporting.ListLabel(Me.components)
        Me.DesignerAction1 = new combit.Reporting.DesignerAction()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'DesignerFunction1
        '
        Me.DesignerFunction1.Description = "Add two numeric values"
        Me.DesignerFunction1.FunctionName = "Add"
        Me.DesignerFunction1.GroupName = "Operators"
        Me.DesignerFunction1.MaximumParameters = 2
        Me.DesignerFunction1.MinimalParameters = 2
        Me.DesignerFunction1.Parameter1.Description = "First Value"
        Me.DesignerFunction1.Parameter1.Type = combit.Reporting.LlParamType.[Double]
        Me.DesignerFunction1.Parameter2.Description = "Second Value"
        Me.DesignerFunction1.Parameter2.Type = combit.Reporting.LlParamType.[Double]
        Me.DesignerFunction1.Parameter3.Description = "Parameter 3"
        Me.DesignerFunction1.Parameter4.Description = "Parameter 4"
        Me.DesignerFunction1.ResultType = combit.Reporting.LlParamType.[Double]
        '
        'DesignerObject1
        '
        Me.DesignerObject1.Description = "Sample Object"
        Me.DesignerObject1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.DesignerObject1.Icon = CType(resources.GetObject("DesignerObject1.Icon"), System.Drawing.Icon)
        Me.DesignerObject1.ObjectName = "SampleObject"
        Me.DesignerObject1.SupportsContentDialog = True
        Me.DesignerObject1.TooltipDescription = Nothing
        '
        'LL
        '
        Me.LL.AutoPrinterSettingsStream = Nothing
        Me.LL.AutoProjectStream = Nothing
        Me.LL.CompressStorage = True
        Me.LL.DataBindingMode = combit.Reporting.DataBindingMode.DelayLoad
        Me.LL.DesignerActions.AddRange(New combit.Reporting.DesignerAction() {Me.DesignerAction1})
        Me.LL.DesignerFunctions.AddRange(New combit.Reporting.DesignerExtensions.IDesignerFunction() {Me.DesignerFunction1})
        Me.LL.DesignerObjects.AddRange(New combit.Reporting.DesignerObject() {Me.DesignerObject1})
        Me.LL.DrilldownAvailable = True
        Me.LL.EMFResolution = 100
        Me.LL.FileRepository = Nothing
        Me.LL.GenericMaximumRecordCount = -1
        Me.LL.LockNextChar = 8288
        Me.LL.MaxRTFVersion = 65280
        Me.LL.PhantomSpace = 8203
        Me.LL.PreviewControl = Nothing
        Me.LL.Unit = combit.Reporting.LlUnits.Millimeter_1_100
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
        Me.ListBox1.Location = New System.Drawing.Point(10, 61)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.ScrollAlwaysVisible = True
        Me.ListBox1.Size = New System.Drawing.Size(489, 303)
        Me.ListBox1.TabIndex = 9
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(424, 370)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 16
        Me.Button2.Text = "Design..."
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(10, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 16)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "US:"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(10, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(24, 16)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "D:  "
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(40, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(410, 16)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "This sample shows the extension of the designer with VB.NET."
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(40, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(410, 22)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Dieses Beispiel zeigt die Erweiterung des Designers mit VB.NET."
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(512, 405)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.ListBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "List & Label VB.NET Designer Extension Sample"
        Me.ResumeLayout(False)

    End Sub
#End Region
    <STAThread>
    Public Shared Sub Main()
        SetProcessDPIAware()
        Application.EnableVisualStyles()
        Application.Run(New Form1())
    End Sub
    <System.Runtime.InteropServices.DllImport("user32.dll")>
    Private Shared Function SetProcessDPIAware() As Boolean
    End Function
    ' D: Implementierung der neuen Designer Add-Funktion
    'US: Implementation of the new designer add-function
    Private Sub DesignerFunction1_EvaluateFunction(ByVal sender As System.Object, ByVal e As combit.Reporting.EvaluateFunctionEventArgs) Handles DesignerFunction1.EvaluateFunction
        e.ResultValue = (Double.Parse(e.Parameter1.ToString()) + Double.Parse(e.Parameter2.ToString()))
    End Sub
    ' D: Die hier spezifizierten Parameter Werte (1 - 20), werden beim Eintippen der Formel im Designer vorgeschlagen
    'US: The specified parameter values (1 - 20), are suggested while typeing the formula in the designer 
    Private Sub DesignerFunction1_ParameterAutoComplete(ByVal sender As Object, ByVal e As combit.Reporting.ParameterAutoCompleteEventArgs) Handles DesignerFunction1.ParameterAutoComplete
        Dim i As Int16
        For i = 1 To 20
            e.Values.Add(i.ToString())
        Next
    End Sub
    ' D: Implementierung eines Designer Objektes, welches ein Bild beinhaltet
    'US: Implementation of a designer object, which contains an image
    Private Sub DesignerObject1_DrawDesignerObject(ByVal sender As System.Object, ByVal e As combit.Reporting.DrawDesignerObjectEventArgs) Handles DesignerObject1.DrawDesignerObject
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
    Private Sub DesignerObject1_EditDesignerObject(ByVal sender As Object, ByVal e As combit.Reporting.EditDesignerObjectEventArgs) Handles DesignerObject1.EditDesignerObject
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
    Private Sub DesignerObject1_CreateDesignerObject(ByVal sender As Object, ByVal e As combit.Reporting.CreateDesignerObjectEventArgs) Handles DesignerObject1.CreateDesignerObject
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
