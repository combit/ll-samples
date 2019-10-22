Imports combit.ListLabel25.Web
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Namespace WebReporting.ViewModels
    Public Class Html5ViewerModel

        Public Sub New()
            ViewerOptions = New Html5ViewerOptions()
        End Sub

        Public Property ReportName() As String
            Get
                Return m_ReportName
            End Get
            Set
                m_ReportName = Value
            End Set
        End Property
        Private m_ReportName As String

        Public Property ViewerOptions() As Html5ViewerOptions
            Get
                Return m_ViewerOptions
            End Get
            Set
                m_ViewerOptions = Value
            End Set
        End Property
        Private m_ViewerOptions As Html5ViewerOptions

    End Class
End Namespace
