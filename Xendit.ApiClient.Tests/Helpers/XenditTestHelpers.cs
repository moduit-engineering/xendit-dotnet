using Moq;
using RestSharp;
using System;
using System.Net;

namespace Xendit.ApiClient.Tests.Helpers
{
    public static class XenditTestHelpers
    {
        public static XenditHttpResponseException GetTestResponseException()
        {
            var responseMock = new Mock<IRestResponse>();

            var req = new RestRequest();
            req.AddJsonBody(new { name = "value" });
            req.AddParameter("name", "value", ParameterType.HttpHeader);

            responseMock
                .SetupProperty(r => r.StatusCode, HttpStatusCode.BadRequest)
                .SetupProperty(r => r.Request.Resource, "/some_resource")
                .SetupProperty(r => r.ResponseUri, new Uri("https://someresponse.uri"))
                .SetupProperty(r => r.Request.Method, Method.POST)
                .SetupProperty(r => r.ErrorException, null);
            responseMock
                .SetupGet(r => r.Request.Parameters)
                .Returns(req.Parameters.FindAll(p => p.Type == ParameterType.RequestBody));

            responseMock
                .SetupGet(r => r.Headers)
                .Returns(req.Parameters.FindAll(p => p.Type == ParameterType.HttpHeader));

            return new XenditHttpResponseException(responseMock.Object);
        }
    }
}
