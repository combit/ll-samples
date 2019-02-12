Imports System.Collections
Imports System.Windows.Forms
Imports combit.ListLabel24.Dom
Imports combit.ListLabel24
Imports System.IO
Imports System.ComponentModel
Imports System.Collections.Generic

Public Class ListLabelDomTreeView
    Inherits TreeView
    Private _project As ProjectBase
    Private _components As IContainer
    Private _filterAttributes As Attribute()
    Private _fileName As String
    Private _ll As ListLabel

    Public Sub New()
        MyBase.New()
        _filterAttributes = New Attribute() {New BrowsableAttribute(True)}
    End Sub

    Public ReadOnly Property Project() As ProjectBase
        Get
            Return _project
        End Get
    End Property

    Public Sub Load(fileName As String)
        Dim containsDatabaseStructure As Boolean = False

        'D: Projekt mit angegebenen Dateinamen laden
        'US: Load project with the specified filename

        _fileName = [String].Empty
        If _ll Is Nothing Then
            _ll = New ListLabel()
        End If

        ' D: Welcher Projekttyp wird geladen? Card, Label oder List
        ' US: Which project type will be load? Card, Label or List
        Dim projectType As LlProject = _ll.Core.LlUtilsGetProjectType(fileName)

        Select Case projectType
            Case LlProject.Label
                _project = New ProjectLabel(_ll)
            Case LlProject.Card
                _project = New ProjectCard(_ll)
            Case LlProject.List
                _project = New ProjectList(_ll)
            Case LlProject.TableOfContents
                _project = New ProjectTableOfContents(_ll)
            Case LlProject.Index
                _project = New ProjectIndex(_ll)
            Case LlProject.ReverseSide
                _project = New ProjectReverseSide(_ll)
        End Select

        Using sr As New StreamReader(fileName)
            Dim line As String
            While (Not sr.EndOfStream) AndAlso (Not containsDatabaseStructure)
                line = sr.ReadLine()

                If line.Contains("[@DatabaseStructure]") Then
                    containsDatabaseStructure = True
                End If
            End While

            _project.ParentComponent.Core.LlDbAddTable("")

            If containsDatabaseStructure Then
                _project.ParentComponent.DataSource = New List(Of String)()
            End If
        End Using

        _project.Open(fileName, LlDomFileMode.Open, LlDomAccessMode.[ReadOnly], True)
        _fileName = fileName

        Me.BuildTree()
    End Sub

    Private Sub BuildTree()
        Me.Nodes.Clear()
        Me.SuspendLayout()

        Dim rootNode As New TreeNode(_fileName)
        rootNode.Tag = _project
        rootNode.ImageIndex = 17
        rootNode.SelectedImageIndex = 17

        For Each pd As PropertyDescriptor In TypeDescriptor.GetProperties(_project, _filterAttributes)
            Me.AddNode(pd, rootNode)
        Next

        MyBase.Nodes.Add(rootNode)
        Me.ResumeLayout()
        rootNode.Expand()
    End Sub

    Private Sub AddNode(pd As PropertyDescriptor, parentNode As TreeNode)
        Dim propertyType As Type = Nothing
        Dim propertyName As String = String.Empty

        Dim childNode As TreeNode = Nothing

        propertyName = pd.Name
        propertyType = pd.PropertyType

        If propertyType Is GetType(System.String) Or propertyType.IsPrimitive Or propertyType.IsEnum Then
            Dim item As DomItem = DirectCast(parentNode.Tag, DomItem)
            If (TypeOf item Is PropertyOutputFormatterBase) OrElse item.PropertyExists(propertyName) Then
                Dim propertyValue As Object = pd.GetValue(parentNode.Tag)
                Dim value As String = Convert.ToString(propertyValue)
                Dim nodeText As String = If(value = "", propertyName & " = <empty>", propertyName & " = " & value)

                childNode = parentNode.Nodes.Add(nodeText)
                childNode.Tag = propertyValue

                If value = "False" Then
                    childNode.ImageIndex = 4
                    childNode.SelectedImageIndex = 4
                ElseIf value = "True" Then
                    childNode.ImageIndex = 5
                    childNode.SelectedImageIndex = 5
                Else
                    childNode.ImageIndex = 18
                    childNode.SelectedImageIndex = 18
                End If
            End If
        ElseIf propertyType.IsSubclassOf(GetType(DomItem)) Then
            Dim propertyValue As Object = pd.GetValue(parentNode.Tag)

            If propertyValue IsNot Nothing Then
                childNode = parentNode.Nodes.Add(propertyName)
                childNode.Tag = propertyValue
                childNode.ImageIndex = 6
                childNode.SelectedImageIndex = 6

                For Each [property] As PropertyDescriptor In Me.GetProperties(propertyValue)
                    Me.AddNode([property], childNode)
                Next

            End If
        ElseIf propertyType.IsSubclassOf(GetType(CollectionBase)) Then
            Dim propertyValue As Object = pd.GetValue(parentNode.Tag)

            Dim collection As ICollection = TryCast(propertyValue, ICollection)
            childNode = parentNode.Nodes.Add(propertyName)
            childNode.Tag = propertyValue
            childNode.ImageIndex = 6
            childNode.SelectedImageIndex = 6

            For Each obj As Object In collection
                If obj.[GetType]().IsSubclassOf(GetType(DomItem)) Then
                    Dim objNode As TreeNode = childNode.Nodes.Add(Me.GetObjectName(obj))
                    objNode.Tag = obj
                    Me.SetNodeImage(objNode)

                    For Each [property] As PropertyDescriptor In Me.GetProperties(obj)
                        Me.AddNode([property], objNode)
                    Next
                ElseIf obj.[GetType]().IsSubclassOf(GetType(CollectionBase)) Then
                    Dim childCollection As ICollection = TryCast(obj, ICollection)

                    For Each childObj As Object In childCollection
                        Dim objChildNode As TreeNode = childNode.Nodes.Add(Me.GetObjectName(childObj))
                        objChildNode.Tag = obj
                        Me.SetNodeImage(objChildNode)

                        For Each childProperty As PropertyDescriptor In Me.GetProperties(childObj)
                            Me.AddNode(childProperty, objChildNode)
                        Next
                    Next
                ElseIf TypeOf obj Is System.String Then
                    childNode.Nodes.Add(Convert.ToString(obj))
                End If
            Next
        End If
    End Sub

    Protected Overrides Sub OnAfterExpand(e As TreeViewEventArgs)
        MyBase.OnAfterExpand(e)

        If e.Node.ImageIndex = 6 Then
            e.Node.ImageIndex = 7
        End If
    End Sub

    Private Sub SetNodeImage(node As TreeNode)
        If TypeOf node.Tag Is ObjectLine Then
            node.SelectedImageIndex = 0
            node.ImageIndex = 0
        ElseIf TypeOf node.Tag Is ObjectChart Then
            node.SelectedImageIndex = 3
            node.ImageIndex = 3
        ElseIf TypeOf node.Tag Is ObjectRtf Then
            node.ImageIndex = 9
            node.SelectedImageIndex = 9
        ElseIf TypeOf node.Tag Is ObjectReportContainer Then
            node.ImageIndex = 10
            node.SelectedImageIndex = 10
        ElseIf TypeOf node.Tag Is ObjectDrawing Then
            node.ImageIndex = 2
            node.SelectedImageIndex = 2
        ElseIf TypeOf node.Tag Is ObjectInputButton Then
            node.ImageIndex = 3
            node.SelectedImageIndex = 3
        ElseIf TypeOf node.Tag Is ObjectText Then
            node.ImageIndex = 8
            node.SelectedImageIndex = 8
        ElseIf TypeOf node.Tag Is ObjectGauge Then
            node.ImageIndex = 19
            node.SelectedImageIndex = 19
        Else
            node.ImageIndex = 18
            node.SelectedImageIndex = 18
        End If

    End Sub

    Private Function GetObjectName(obj As Object) As [String]

        Dim domItem As DomItem = TryCast(obj, DomItem)
        Dim name As String = ""

        If domItem.PropertyExists("Name") Then
            name = domItem.GetProperty("Name")
        End If

        If name = "" Then
            If domItem.PropertyExists("ObjectType") Then
                name = domItem.GetProperty("ObjectType")
            End If
        End If

        If name = "" Then
            Dim tmp As String = obj.[GetType]().Name

            tmp = tmp.Replace("DomItem", "")
            tmp = tmp.Replace("Property", "")
            name = tmp
        End If

        Return name
    End Function

    Private Function GetProperties(obj As Object) As PropertyDescriptorCollection
        If TypeOf obj Is Type Then
            Return TypeDescriptor.GetProperties(TryCast(obj, Type), _filterAttributes)
        End If
        Return TypeDescriptor.GetProperties(obj, _filterAttributes)
    End Function

    Private Sub InitializeComponent()
        Me._components = New System.ComponentModel.Container()
        Dim resources As New ComponentResourceManager(GetType(ListLabelDomTreeView))
        Me.ImageList = New ImageList(Me._components)
        Me.SuspendLayout()
        ' 
        ' imageList1
        ' 
        Me.ImageList.ImageStream = DirectCast(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Magenta
        Me.ImageList.Images.SetKeyName(0, "Line.bmp")
        Me.ImageList.Images.SetKeyName(1, "Mail_Front.bmp")
        Me.ImageList.Images.SetKeyName(2, "Picture2.bmp")
        Me.ImageList.Images.SetKeyName(3, "Chart.bmp")
        Me.ImageList.Images.SetKeyName(4, "Doc_OK2.bmp")
        Me.ImageList.Images.SetKeyName(5, "Doc_OK.bmp")
        Me.ImageList.Images.SetKeyName(6, "Folder.bmp")
        Me.ImageList.Images.SetKeyName(7, "Folder_Open.bmp")
        Me.ImageList.Images.SetKeyName(8, "Insert_Text.bmp")
        Me.ImageList.Images.SetKeyName(9, "RichTextBox.bmp")
        Me.ImageList.Images.SetKeyName(10, "ShowGridlines.bmp")
        Me.ImageList.Images.SetKeyName(11, "ShowRulelines.bmp")
        Me.ImageList.Images.SetKeyName(12, "ShowRuler.bmp")
        Me.ImageList.Images.SetKeyName(13, "Button.bmp")
        Me.ImageList.Images.SetKeyName(14, "Checkbox.bmp")
        Me.ImageList.Images.SetKeyName(15, "Combobox.bmp")
        Me.ImageList.Images.SetKeyName(16, "Groupbox.bmp")
        ' 
        ' ListLabelDomTreeView
        ' 
        Me.LineColor = System.Drawing.Color.Black
        Me.ResumeLayout(False)

    End Sub

    Protected Overrides Sub Dispose(disposing As Boolean)

        If disposing Then

            If _project IsNot Nothing Then
                _project.Dispose()
                _project = Nothing
            End If
            If _ll IsNot Nothing Then
                _ll.Dispose()
                _ll = Nothing
            End If
        End If
        MyBase.Dispose(disposing)

    End Sub

End Class












