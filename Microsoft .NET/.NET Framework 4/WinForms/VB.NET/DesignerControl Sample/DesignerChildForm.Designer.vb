Partial Class DesignerChildForm
    ''' <summary>
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing
    ''' <summary>
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub
#Region "Windows Form Designer generated code"
    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    ''' 
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.LL = New combit.ListLabel25.ListLabel(Me.components)
        Me.designerControl1 = New combit.ListLabel25.DesignerControl()
        Me.SuspendLayout()
        '
        'LL
        '
        Me.LL.AutoPrinterSettingsStream = Nothing
        Me.LL.AutoProjectStream = Nothing
        Me.LL.DataBindingMode = combit.ListLabel25.DataBindingMode.DelayLoad
        Me.LL.DrilldownAvailable = True
        Me.LL.EMFResolution = 100
        Me.LL.FileRepository = Nothing
        Me.LL.GenericMaximumRecordCount = -1
        Me.LL.LockNextChar = 8288
        Me.LL.MaxRTFVersion = 65280
        Me.LL.PhantomSpace = 8203
        Me.LL.PreviewControl = Nothing
        Me.LL.Unit = combit.ListLabel25.LlUnits.Millimeter_1_100
        Me.LL.UseHardwareCopiesForLabels = False
        Me.LL.UseTableSchemaForDesignMode = False
        '
        'designerControl1
        '
        Me.designerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.designerControl1.Location = New System.Drawing.Point(0, 0)
        Me.designerControl1.Name = "designerControl1"
        Me.designerControl1.ParentComponent = Me.LL
        Me.designerControl1.Size = New System.Drawing.Size(711, 438)
        Me.designerControl1.TabIndex = 0
        Me.designerControl1.Text = "designerControl1"
        '
        'DesignerChildForm
        '
        Me.ClientSize = New System.Drawing.Size(711, 438)
        Me.Controls.Add(Me.designerControl1)
        Me.Name = "DesignerChildForm"
        Me.Text = "Designer Control Form"
        Me.ResumeLayout(False)

    End Sub
#End Region
    Private WithEvents LL As combit.ListLabel25.ListLabel
    Private WithEvents designerControl1 As combit.ListLabel25.DesignerControl
End Class
