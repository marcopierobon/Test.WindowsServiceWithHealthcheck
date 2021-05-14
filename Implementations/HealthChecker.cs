using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Web;
using Test.WindowsServiceWithHealthcheck.Extensions;
using Test.WindowsServiceWithHealthcheck.Interfaces;

namespace Test.WindowsServiceWithHealthcheck.Implementations
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
            ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class HealthChecker : IHealthChecker
    {
        private ConcurrentBag<string> failedValidationData;
        private int? _configFileContentHashed;
        private TimeSpan? _healthCheckCacheResultTimespan = new TimeSpan(0, 5, 0);
        private DateTime? _healthCheckExecutionTime;

        public HealthChecker()
        {

        }

        public string Health()
        {
            var appSettingsContentConfiguration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (_configFileContentHashed == default)
            {
                _configFileContentHashed = System.IO.File.ReadAllText(appSettingsContentConfiguration.FilePath).GetHashCode();
            }
            else if (_configFileContentHashed != System.IO.File.ReadAllText(appSettingsContentConfiguration.FilePath).GetHashCode())
            {
                failedValidationData = new ConcurrentBag<string>();
                failedValidationData.AddRange(new List<string>() { $"The configuration file {appSettingsContentConfiguration.FilePath} has changed since the service was started. " +
                        $"Please restart the service."});
            }

            if (!ArePreviousValidationsResultStillValid(failedValidationData, _healthCheckCacheResultTimespan, _healthCheckExecutionTime))
            {
                failedValidationData = new ConcurrentBag<string>();



                _healthCheckExecutionTime = DateTime.UtcNow;
            }

            if (failedValidationData.Any())
            {
                throw new WebFaultException<string>($"Unhealthy: {string.Join("\n", failedValidationData)}", HttpStatusCode.InternalServerError);
            }
            else
            {
                var context = WebOperationContext.Current;
                context.OutgoingResponse.StatusCode = HttpStatusCode.OK;
                context.OutgoingResponse.StatusDescription = "Status OK";
                return context.OutgoingResponse.StatusDescription;
            }
        }

        private bool ArePreviousValidationsResultStillValid(ConcurrentBag<string> failedValidationData,
                TimeSpan? _healthCheckCacheResultTimespan, DateTime? _lastHealthCheckExecutionTime)
        {
            return failedValidationData != null && _lastHealthCheckExecutionTime != null
                && DateTime.UtcNow < _lastHealthCheckExecutionTime + _healthCheckCacheResultTimespan;
        }

    }
}