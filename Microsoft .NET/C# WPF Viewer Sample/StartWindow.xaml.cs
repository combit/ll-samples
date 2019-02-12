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
            Window1 main = new Window1();
            App.Current.MainWindow = main;
            this.Close();
            main.Show();
        }

        private void HostedViewerbtn_Click(object sender, RoutedEventArgs e)
        {
            Window2 main = new Window2();
            App.Current.MainWindow = main;
            this.Close();
            main.Show();
        }
    }
}
