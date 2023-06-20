using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using VuelingExam.Transversal.Models;

namespace VuelingExam.WCF
{
    [ServiceContract]
    public interface IVuelingWcfService
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/WriteData", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string WriteData(StudentDto student);

        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "/ReadData", BodyStyle = WebMessageBodyStyle.Bare, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<StudentDto> ReadData();

    }
}
