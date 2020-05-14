using Moq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace Xendit.ApiClient.Tests.Helpers
{
    public static class XenditTestHelpers
    {
        public static XenditHttpResponseException GetTestResponseException()
        {
            var responseMock = new Mock<IRestResponse>();

            responseMock
                .SetupProperty(r => r.StatusCode, HttpStatusCode.BadRequest)
                .SetupProperty(r => r.Request.Resource, "/some_resource")
                .SetupProperty(r => r.ResponseUri, new Uri("https://someresponse.uri"))
                .SetupProperty(r => r.Request.Method, Method.POST)
                .SetupProperty(r => r.Request.Body, new RequestBody("application/json", "name", "value"))
                .SetupProperty(r => r.ErrorException, null);

            responseMock
                .SetupGet(r => r.Headers)
                .Returns(new List<Parameter> { new Parameter("name", "value", ParameterType.HttpHeader) });

            return new XenditHttpResponseException(responseMock.Object);
        }
    }
}
