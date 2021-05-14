using System.ServiceModel;
using System.ServiceProcess;
using Test.WindowsServiceWithHealthcheck.Implementations;

namespace Test.WindowsServiceWithHealthcheck
{
    public partial class ServiceWithHealthcheck : ServiceBase
    {

        private ServiceHost _serviceHost = null;
        public ServiceWithHealthcheck()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var healthChecker = new HealthChecker();
            _serviceHost = new ServiceHost(healthChecker);
            _serviceHost.Open();
        }

        protected override void OnStop()
        {
            try
            {
                base.OnStop();
            }
            finally
            {
                if (_serviceHost != null)
                {
                    _serviceHost.Close();
                    _serviceHost = null;
                }
            }
        }
    }
}
