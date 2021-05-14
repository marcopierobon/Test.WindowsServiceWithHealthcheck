namespace Test.WindowsServiceWithHealthcheck
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            _serviceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            _serviceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // ServiceProcessInstaller configuration
            // 
            _serviceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalService;
            _serviceProcessInstaller.Password = null;
            _serviceProcessInstaller.Username = null;
            // 
            // ServiceInstaller configuration
            // 
            _serviceInstaller.Description = "Test.WindowsServiceWithHealthcheck";
            _serviceInstaller.DisplayName = "Test.WindowsServiceWithHealthcheck";
            _serviceInstaller.ServiceName = "Test.WindowsServiceWithHealthcheck";
            _serviceInstaller.AfterInstall += new System.Configuration.Install.InstallEventHandler(WindowsServiceWithHealthcheck_AfterInstall);
            // 
            // ServiceInstaller registration
            // 
            Installers.AddRange(new System.Configuration.Install.Installer[] {
                _serviceProcessInstaller,
                _serviceInstaller
            });

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller _serviceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller _serviceInstaller;
    }
}