using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LLViewer
{
    /// <summary>
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
        }

        private void NativeViewerbtn_Click(object sender, RoutedEventArgs e)
        {
            NativeWpfViewerWindow main = new NativeWpfViewerWindow(this);
            App.Current.MainWindow = main;
            this.Visibility = Visibility.Hidden;
            main.Show();
        }

        private void HostedViewerbtn_Click(object sender, RoutedEventArgs e)
        {
            HostedPreviewControlWindow main = new HostedPreviewControlWindow(this);
            App.Current.MainWindow = main;
            this.Visibility = Visibility.Hidden;
            main.Show();
        }
    }
}
