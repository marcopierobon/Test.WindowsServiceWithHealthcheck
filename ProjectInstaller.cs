using System.ComponentModel;
using System.Configuration.Install;

namespace Test.WindowsServiceWithHealthcheck
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }

        private void WindowsServiceWithHealthcheck_AfterInstall(object sender, InstallEventArgs e)
        {

        }
    }
}
