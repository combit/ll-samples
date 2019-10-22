Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes

Namespace LLViewer
	''' <summary>
	''' Interaction logic for StartWindow.xaml
	''' </summary>
	Public Partial Class StartWindow
		Inherits Window
		Public Sub New()
			InitializeComponent()
		End Sub

        Private Sub NativeViewerbtn_Click(sender As Object, e As RoutedEventArgs)
            Dim main As New Window1()
            Application.Current.MainWindow = main
            Me.Close()
            main.Show()
        End Sub

        Private Sub HostedViewerbtn_Click(sender As Object, e As RoutedEventArgs)
            Dim main As New Window2()
            Application.Current.MainWindow = main
            Me.Close()
            main.Show()
        End Sub
    End Class
End Namespace
