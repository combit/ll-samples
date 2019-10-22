Namespace combit.Services
    Public NotInheritable Class [Error]
        Friend Sub New()
            Code = 0
        End Sub

        Friend Sub New(newDescription As String)
            Me.New(-1, newDescription)
        End Sub

        Friend Sub New(newCode As Integer, newDescription As String)
            Code = newCode
            Description = newDescription
        End Sub

        Public Property Code() As Integer
            Get
                Return m_Code
            End Get
            Set(value As Integer)
                m_Code = value
            End Set
        End Property
        Private m_Code As Integer
        Public Property Description() As String
            Get
                Return m_Description
            End Get
            Set(value As String)
                m_Description = value
            End Set
        End Property
        Private m_Description As String
        Public ReadOnly Property Succeeded() As Boolean
            Get
                Return (Code = 0)
            End Get
        End Property
    End Class

    Public NotInheritable Class Response(Of T)
        Friend Sub New()
            Status = New [Error]()
        End Sub

        Friend Sub New(value__1 As T)
            Status = New [Error]()
            Value = value__1
        End Sub

        Friend Sub New(status__1 As [Error])
            Status = status__1
        End Sub

        Public Property Status() As [Error]
            Get
                Return m_Status
            End Get
            Set(value As [Error])
                m_Status = value
            End Set
        End Property
        Private m_Status As [Error]
        Public Property Value() As T
            Get
                Return m_Value
            End Get
            Set(value As T)
                m_Value = value
            End Set
        End Property
        Private m_Value As T
        Public Property RequesterID() As String
            Get
                Return m_RequesterID
            End Get
            Set(value As String)
                m_RequesterID = value
            End Set
        End Property
        Private m_RequesterID As String
    End Class

    Public NotInheritable Class Response
        Friend Sub New()
            Status = New [Error]()
        End Sub

        Friend Sub New(status__1 As [Error])
            Status = status__1
        End Sub

        Public Property Status() As [Error]
            Get
                Return m_Status
            End Get
            Set(value As [Error])
                m_Status = value
            End Set
        End Property
        Private m_Status As [Error]
    End Class

    Public NotInheritable Class DataSource
        Friend Sub New(newId As String, newName As String, newDescripton As String, newImage As String)
            Id = newId
            Name = newName
            Description = newDescripton
            Image = newImage
        End Sub

        Public Property Id() As String
            Get
                Return m_Id
            End Get
            Set(value As String)
                m_Id = value
            End Set
        End Property
        Private m_Id As String
        Public Property Name() As String
            Get
                Return m_Name
            End Get
            Set(value As String)
                m_Name = value
            End Set
        End Property
        Private m_Name As String
        Public Property Description() As String
            Get
                Return m_Description
            End Get
            Set(value As String)
                m_Description = value
            End Set
        End Property
        Private m_Description As String
        Public Property Image() As String
            Get
                Return m_Image
            End Get
            Set(value As String)
                m_Image = value
            End Set
        End Property
        Private m_Image As String
    End Class

    Public NotInheritable Class Report
        Friend Sub New(newDatasource As String, newName As String, newDescripton As String, newImage As String)
            Datasource = newDatasource
            Name = newName
            Description = newDescripton
            Image = newImage
        End Sub

        Public Property Datasource() As String
            Get
                Return m_Datasource
            End Get
            Set(value As String)
                m_Datasource = value
            End Set
        End Property
        Private m_Datasource As String
        Public Property Name() As String
            Get
                Return m_Name
            End Get
            Set(value As String)
                m_Name = value
            End Set
        End Property
        Private m_Name As String
        Public Property Description() As String
            Get
                Return m_Description
            End Get
            Set(value As String)
                m_Description = value
            End Set
        End Property
        Private m_Description As String
        Public Property Image() As String
            Get
                Return m_Image
            End Get
            Set(value As String)
                m_Image = value
            End Set
        End Property
        Private m_Image As String
    End Class

    Public Class ReportFormat
        Friend Sub New(newId As String, newDescripton As String, newImage As String)
            Id = newId
            Description = newDescripton
            Image = newImage
        End Sub

        Public Property Id() As String
            Get
                Return m_Id
            End Get
            Set(value As String)
                m_Id = value
            End Set
        End Property
        Private m_Id As String
        Public Property Description() As String
            Get
                Return m_Description
            End Get
            Set(value As String)
                m_Description = value
            End Set
        End Property
        Private m_Description As String
        Public Property Image() As String
            Get
                Return m_Image
            End Get
            Set(value As String)
                m_Image = value
            End Set
        End Property
        Private m_Image As String
    End Class
End Namespace
