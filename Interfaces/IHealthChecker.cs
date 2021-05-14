using System.ServiceModel;
using System.ServiceModel.Web;

namespace Test.WindowsServiceWithHealthcheck.Interfaces
{
	// Define a service contract.
	[ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples")]
	public interface IHealthChecker
	{
		[OperationContract]
		[WebInvoke(Method = "GET",
		ResponseFormat = WebMessageFormat.Json,
		BodyStyle = WebMessageBodyStyle.Bare,
		UriTemplate = "Health")]
		string Health();
	}
}
