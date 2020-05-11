using RestSharp;
using System.Threading.Tasks;

namespace Xendit.ApiClient.Abstracts
{
    public interface IXenditHttpConnection
    {

        /// <summary>
        /// Send simple request to Xendit API.
        /// </summary>
        /// <param name="method">HTTP Method</param>
        /// <param name="resource">Resource or endpoint.</param>
        /// <exception cref="XenditHttpResponseException">Returned when the response is not successful (non 2xx http status code)</exception>

        Task<TResponse> SendRequestAsync<TResponse>(Method method, string resource);

        /// <summary>
        /// Send simple request to Xendit API with specified idempotency key.
        /// </summary>
        /// <param name="method">HTTP Method</param>
        /// <param name="resource">Resource or endpoint.</param>
        /// <param name="idempotencyKey">Indempotency key.</param>
        /// <exception cref="XenditHttpResponseException">Returned when the response is not successful (non 2xx http status code)</exception>
        Task<TResponse> SendRequestAsync<TResponse>(Method method, string resource, string idempotencyKey);

        /// <summary>
        /// Sends request to Xendit API with request body object.
        /// </summary>
        /// <param name="method">HTTP Method.</param>
        /// <param name="resource">Resource or endpoint.</param>
        /// <param name="body">Request body object.</param>
        /// <exception cref="XenditHttpResponseException">Returned when the response is not successful (non 2xx http status code)</exception>
        Task<TResponse> SendRequestBodyAsync<TRequest, TResponse>(Method method,
            string resource, TRequest body)
            where TRequest : IXenditBaseRequest;

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
            where TRequest : IXenditBaseRequest;
    }
}
