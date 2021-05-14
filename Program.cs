using System.ServiceProcess;

namespace Test.WindowsServiceWithHealthcheck
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            //Uncomment to debug - start from inside VS as a regular debugging session
            System.Diagnostics.Debugger.Launch();

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new ServiceWithHealthcheck()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
