using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xendit.ApiClient.Abstracts;

namespace Xendit.ApiClient.Invoice
{
    public class XenditInvoiceClient : IXenditInvoiceClient
    {
        private readonly IXenditHttpConnection _conn;

        public XenditInvoiceClient(IXenditHttpConnection conn)
        {
            _conn = conn;
        }

        public async Task<IEnumerable<XenditInvoiceCreateResponse>> GetAllAsync()
        {
            return await GetAllAsync(null);
        }

        public async Task<IEnumerable<XenditInvoiceCreateResponse>> GetAllAsync(XenditInvoiceOptions options)
        {
            var resource = "/v2/invoices";

            return await _conn.SendRequestBodyAsync<XenditInvoiceOptions, IEnumerable<XenditInvoiceCreateResponse>>(
                Method.POST, resource, options);
        }

        public async Task<XenditInvoiceCreateResponse> GetAsync(string invoiceId)
        {
            var resource = $"/v2/invoices/{invoiceId}";

            return await _conn.SendRequestAsync<XenditInvoiceCreateResponse>(
                Method.GET, resource);
        }

        public async Task<XenditInvoiceCreateResponse> CreateAsync(XenditInvoiceCreateRequest invoice)
        {
            var resource = "/v2/invoices";

            return await _conn.SendRequestBodyAsync<XenditInvoiceCreateRequest, XenditInvoiceCreateResponse>(
                Method.POST, resource, invoice, invoice.ExternalId);
        }

        public async Task<XenditInvoiceCreateResponse> ExpireAsync(string invoiceId)
        {
            var resource = $"/invoices/{invoiceId}/expire!";

            return await _conn.SendRequestAsync<XenditInvoiceCreateResponse>(
                Method.POST, resource);
        }
    }
}
