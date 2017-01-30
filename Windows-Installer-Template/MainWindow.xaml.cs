// Windows Installer Template
// Author: ngpaladi
// Version: 1.0.0
// Released Under The MIT License

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Windows_Installer_Template
{
    public partial class MainWindow : Window
    {

        // Default Values
        public static string InstallerTitle = "Installer";
        public static string SoftwareTitle = "Software";
        public static bool isX64app = false;
        public static string InstallLocation = "C:\\Program Files\\";
        public static string InstallLocationX86onX64 = "C:\\Program Files (x86)\\";

        //If Downloading From Online Location
        public static bool download = true;
        public static string url = "http://www.noahpaladino.com/";

        //The following assumes what you are downloading/installing will be as you want it in the install location
        public static bool KeepDefaultFilePaths = true;


        int pageCount = 0;
        public MainWindow()
        {
            InitializeComponent();
            frame.ContentRendered += Frame_ContentRendered;
            Back.Visibility = Visibility.Hidden;
            Title = InstallerTitle;
            frame.Content = new StartPage();
            Next.Click += Next_Click;
            Back.Click += Back_Click;

        }

        private void Frame_ContentRendered(object sender, EventArgs e)
        {
            frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            switch (pageCount)
            {
                case 1:
                    frame.Content = new StartPage();
                    Back.Visibility = Visibility.Hidden;
                    break;
                default:
                    frame.Content = new StartPage();
                    break;
            }
            pageCount--;
        }

        public string GetInstallLocation()
        {
            string path = InstallLocation;
            if (Environment.Is64BitOperatingSystem && !isX64app)
            {
                path = InstallLocationX86onX64;
            }
            return path;
        }
        private void Next_Click(object sender, RoutedEventArgs e)
        {
            switch (pageCount)
            {
                case 0:
                    frame.Content = new InstallLocationPage();
                    Back.Visibility = Visibility.Visible;
                    break;
                case 1:
                    frame.Content = new InstallPage();
                    Back.Visibility = Visibility.Hidden;
                    Next.Visibility = Visibility.Hidden;
                    break;
                case 2:
                    frame.Content = new FinishedPage();
                    Back.Visibility = Visibility.Hidden;
                    break;
                default:
                    frame.Content = new StartPage();
                    break;
            }
            pageCount++;
            
        }
    }
}
