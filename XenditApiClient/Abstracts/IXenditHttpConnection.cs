using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Xendit.ApiClient.Abstracts
{
    public interface IXenditHttpConnection
    {

        /// <summary>
        /// Sends simple request to Xendit API.
        /// </summary>
        /// <param name="method">HTTP Method</param>
        /// <param name="resource">Resource or endpoint.</param>
        /// <exception cref="XenditHttpResponseException">Returned when the response is not successful (non 2xx http status code)</exception>

        Task<TResponse> SendRequestAsync<TResponse>(Method method, string resource);

        /// <summary>
        /// Sends simple request to Xendit API with specified idempotency key.
        /// </summary>
        /// <param name="method">HTTP Method</param>
        /// <param name="resource">Resource or endpoint.</param>
        /// <param name="idempotencyKey">Indempotency key.</param>
        /// <exception cref="XenditHttpResponseException">Returned when the response is not successful (non 2xx http status code)</exception>
        Task<TResponse> SendRequestAsync<TResponse>(Method method, string resource, string idempotencyKey);

        /// <summary>
        /// Sends simple request to Xendit API with specified idempotency key.
        /// </summary>
        /// <param name="method">HTTP Method</param>
        /// <param name="resource">Resource or endpoint.</param>
        /// <param name="idempotencyKey">Indempotency key.</param>
        /// <param name="forUserId">The sub-account user-id that you want to make this transaction for (xendPlatform).</param>
        /// <exception cref="XenditHttpResponseException">Returned when the response is not successful (non 2xx http status code)</exception>
        Task<TResponse> SendRequestAsync<TResponse>(Method method, string resource, string idempotencyKey, string forUserId);

        /// <summary>
        /// Sends request to Xendit API with request body object.
        /// </summary>
        /// <param name="method">HTTP Method.</param>
        /// <param name="resource">Resource or endpoint.</param>
        /// <param name="body">Request body object.</param>
        /// <exception cref="XenditHttpResponseException">Returned when the response is not successful (non 2xx http status code)</exception>
        Task<TResponse> SendRequestBodyAsync<TRequest, TResponse>(Method method,
            string resource, TRequest body)
            where TRequest : XenditBaseRequest;

        /// <summary>
        /// Sends request to Xendit API with request body object and specified idempotency key.
        /// </summary>
        /// <param name="method">HTTP Method.</param>
        /// <param name="resource">Resource or endpoint.</param>
        /// <param name="body">Request body object.</param>
        /// <param name="idempotencyKey">Indempotency key.</param>
        /// <exception cref="XenditHttpResponseException">Returned when the response is not successful (non 2xx http status code)</exception>
        Task<TResponse> SendRequestBodyAsync<TRequest, TResponse>(Method method,
            string resource, TRequest body, string idempotencyKey)
            where TRequest : XenditBaseRequest;

        /// <summary>
        /// Sends request to Xendit API with headers and request body object.
        /// This method only includes 'for-user-id' header if provided from `TRequest`,
        /// but does not include idempotency key in header, you need to manually assign it in headers if you need it.
        /// </summary>
        /// <param name="method">HTTP Method.</param>
        /// <param name="resource">Resource or endpoint.</param>
        /// <param name="headers">Custom request headers (key: header name, value: header value).</param>
        /// <param name="body">Request body object.</param>
        /// <exception cref="XenditHttpResponseException">Returned when the response is not successful (non 2xx http status code)</exception>
        Task<TResponse> SendRequestBodyAsync<TRequest, TResponse>(Method method,
            string resource, Dictionary<string, string> headers, TRequest body)
            where TRequest : XenditBaseRequest;
    }
}
