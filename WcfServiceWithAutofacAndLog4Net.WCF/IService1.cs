using System;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace WcfServiceWithAutofacAndLog4Net.WCF
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/WriteData/{text}", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string WriteData(string text);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/ReadData/", BodyStyle = WebMessageBodyStyle.Wrapped, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string ReadData();
    }
}
