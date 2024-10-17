using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.IO.Packaging;
using System.Windows.Xps.Packaging;
using System.Windows.Media.Animation;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.ComponentModel;
using combit.Reporting.Wpf;

namespace LLViewer
{
    /// <summary>
    /// Interaction logic for NativeViewerWindow.xaml
    /// </summary>
    /// 

    public partial class NativeViewerWindow : Window
    {
        private Window _mainWindow;

        public NativeViewerWindow(Window mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            _mainWindow.Visibility = Visibility.Visible;
        }
    }
}
