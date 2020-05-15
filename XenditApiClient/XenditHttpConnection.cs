using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xendit.ApiClient.Abstracts;

namespace Xendit.ApiClient
{
    public class XenditHttpConnection : IXenditHttpConnection
    {
        private readonly XenditConfiguration _config;

        private readonly JsonSerializerSettings _jsonSerializer = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore
        };

        public XenditHttpConnection(XenditConfiguration config)
        {
            _config = config;
        }

        public async Task<TResponse> SendRequestAsync<TResponse>(Method method, string resource)
        {
            return await SendRequestAsync<TResponse>(method, resource, null);
        }

        public async Task<TResponse> SendRequestAsync<TResponse>(Method method, string resource, string idempotencyKey)
        {
            return await SendRequestAsync<TResponse>(method, resource, idempotencyKey, null);
        }

        public async Task<TResponse> SendRequestAsync<TResponse>(Method method, string resource, string idempotencyKey, string forUserId)
        {
            var cts = new CancellationTokenSource();

            var client = new RestClient(_config.BaseUrl)
            {
                Authenticator = new HttpBasicAuthenticator(_config.ApiKey, string.Empty)
            };

            var request = new RestRequest(resource, method);

            if (!string.IsNullOrWhiteSpace(idempotencyKey))
            {
                request.AddHeader("X-Idempotency-Key", idempotencyKey);
            }

            if (!string.IsNullOrWhiteSpace(forUserId))
            {
                request.AddHeader("for-user-id", forUserId);
            }

            var response = await client.ExecuteAsync<TResponse>(request, cts.Token);

            if (!response.IsSuccessful)
            {
                throw new XenditHttpResponseException(response);
            }

            return response.Data;
        }

        public async Task<TResponse> SendRequestBodyAsync<TRequest, TResponse>(Method method,
            string resource, TRequest body)
            where TRequest : XenditBaseRequest
        {
            return await SendRequestBodyAsync<TRequest, TResponse>(method, resource, body, null);
        }

        public async Task<TResponse> SendRequestBodyAsync<TRequest, TResponse>(Method method,
            string resource, TRequest body, string idempotencyKey)
            where TRequest : XenditBaseRequest
        {
            var cts = new CancellationTokenSource();

            var client = new RestClient(_config.BaseUrl)
            {
                Authenticator = new HttpBasicAuthenticator(_config.ApiKey, string.Empty)
            };

            var request = new RestRequest(resource, method);

            if (!string.IsNullOrWhiteSpace(idempotencyKey))
            {
                request.AddHeader("X-Idempotency-Key", idempotencyKey);
            }

            if (!string.IsNullOrWhiteSpace(body.ForUserId))
            {
                request.AddHeader("for-user-id", body.ForUserId);
            }
            
            if (body != null)
            {
                request.AddJsonBody(JsonConvert.SerializeObject(body, _jsonSerializer));
            }

            var response = await client.ExecuteAsync<TResponse>(request, cts.Token);

            if (!response.IsSuccessful)
            {
                throw new XenditHttpResponseException(response);
            }

            return response.Data;
        }

        public async Task<TResponse> SendRequestBodyAsync<TRequest, TResponse>(Method method,
            string resource, Dictionary<string, string> headers, TRequest body)
            where TRequest : XenditBaseRequest
        {
            var cts = new CancellationTokenSource();

            var client = new RestClient(_config.BaseUrl)
            {
                Authenticator = new HttpBasicAuthenticator(_config.ApiKey, string.Empty)
            };

            var request = new RestRequest(resource, method);

            foreach (var header in headers ?? new Dictionary<string, string>())
            {
                request.AddHeader(header.Key, header.Value);
            }

            if (body != null)
            {
                request.AddJsonBody(JsonConvert.SerializeObject(body, _jsonSerializer));
            }

            var response = await client.ExecuteAsync<TResponse>(request, cts.Token);

            if (!response.IsSuccessful)
            {
                throw new XenditHttpResponseException(response);
            }

            return response.Data;
        }
    }
}
