Imports System.Collections.Generic

Namespace WebReporting.ViewModels
    Public Class StartPageModel

        ''' <summary>
        ''' List of items of the custom repository type defined for this sample
        ''' </summary>
        Public Property RepositoryItems() As IEnumerable(Of CustomizedRepostoryItem)
            Get
                Return m_RepositoryItems
            End Get
            Set
                m_RepositoryItems = Value
            End Set
        End Property
        Private m_RepositoryItems As IEnumerable(Of CustomizedRepostoryItem)
    End Class
End Namespace