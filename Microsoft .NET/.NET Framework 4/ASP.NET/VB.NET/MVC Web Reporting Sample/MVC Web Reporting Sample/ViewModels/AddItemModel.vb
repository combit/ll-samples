Imports combit.Reporting
Imports System.ComponentModel.DataAnnotations
Imports System.Web

Namespace WebReporting.ViewModels
    Public Class AddItemModel

        Public WasCreated As Boolean

        <Required, MaxLength(100)>
        Public Property ProjectName() As String
            Get
                Return m_ProjectName
            End Get
            Set
                m_ProjectName = Value
            End Set
        End Property
        Private m_ProjectName As String

        <Required>
        Public Property ProjectType() As String
            Get
                Return m_ProjectType
            End Get
            Set
                m_ProjectType = Value
            End Set
        End Property
        Private m_ProjectType As String

        Public Property File1() As HttpPostedFileBase
            Get
                Return m_File1
            End Get
            Set
                m_File1 = Value
            End Set
        End Property
        Private m_File1 As HttpPostedFileBase

        Public Property File2() As HttpPostedFileBase
            Get
                Return m_File2
            End Get
            Set
                m_File2 = Value
            End Set
        End Property
        Private m_File2 As HttpPostedFileBase

        Public Property ShowInToolbar() As Boolean
            Get
                Return m_ShowInToolbar
            End Get
            Set
                m_ShowInToolbar = Value
            End Set
        End Property
        Private m_ShowInToolbar As Boolean

    End Class
End Namespace
