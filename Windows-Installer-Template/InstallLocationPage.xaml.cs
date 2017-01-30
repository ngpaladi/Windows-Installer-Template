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
    /// <summary>
    /// Interaction logic for InstallLocationPage.xaml
    /// </summary>
    public partial class InstallLocationPage : Page
    {
        public InstallLocationPage()
        {
            InitializeComponent();
            TitleBlock.Text = MainWindow.InstallerTitle;
            ContentBlock.Text = MainWindow.SoftwareTitle + " will now be installed to " + GetInstallLocation() + " . Please click 'Next' to continue, or close this window to cancel.";
        }

        private string GetInstallLocation()
        {
            string path = MainWindow.InstallLocation;
            if (Environment.Is64BitOperatingSystem && !MainWindow.isX64app)
            {
                path = MainWindow.InstallLocationX86onX64;
            }
            return path;
        }
    }
}
