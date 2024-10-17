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
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class HostedPreviewControlWindow : Window
    {
        private Window _mainWindow;
		
        public HostedPreviewControlWindow(Window mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _mainWindow.Visibility = Visibility.Visible;
        }
    }
}
