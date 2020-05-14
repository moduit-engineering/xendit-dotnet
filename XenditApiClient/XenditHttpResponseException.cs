using Newtonsoft.Json;
using RestSharp;
using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Xendit.ApiClient
{
    [Serializable]
    public class XenditHttpResponseException : Exception
    {
        public XenditHttpResponseException(IRestResponse response)
            : base("Xendit API response is not successful.") 
        {
            StatusCode = (int)response.StatusCode;
            Content = response.Content;
            Resource = response.Request.Resource;
            ResponseUri = response.ResponseUri.ToString();
            HttpMethod = response.Request.Method.ToString();
            RequestBody = JsonConvert.SerializeObject(response.Request.Body);
            ResponseHeaders = JsonConvert.SerializeObject(response.Headers);
            ResponseException = response.ErrorException;
        }

        public int StatusCode { get; }
        public string Content { get; }
        public string Resource { get; }
        public string ResponseUri { get; }
        public string HttpMethod { get; }
        public string RequestBody { get; }
        public string ResponseHeaders { get; }
        public Exception ResponseException { get; }


        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        protected XenditHttpResponseException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            StatusCode = info.GetInt32(nameof(StatusCode));
            Content = info.GetString(nameof(Content));
            Resource = info.GetString(nameof(Resource));
            ResponseUri = info.GetString(nameof(ResponseUri));
            HttpMethod = info.GetString(nameof(HttpMethod));
            RequestBody = info.GetString(nameof(RequestBody));
            ResponseHeaders = info.GetString(nameof(ResponseHeaders));
            ResponseException = (Exception)info.GetValue(nameof(ResponseException), typeof(Exception));
        }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            info.AddValue(nameof(StatusCode), StatusCode);
            info.AddValue(nameof(Content), Content);
            info.AddValue(nameof(Resource), Resource);
            info.AddValue(nameof(ResponseUri), ResponseUri);
            info.AddValue(nameof(HttpMethod), HttpMethod);
            info.AddValue(nameof(RequestBody), RequestBody);
            info.AddValue(nameof(ResponseHeaders), ResponseHeaders);
            info.AddValue(nameof(ResponseException), ResponseException, typeof(Exception));

            base.GetObjectData(info, context);
        }
    }
}
