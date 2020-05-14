using System.Collections.Generic;
using System.Threading.Tasks;

namespace Xendit.ApiClient.Invoice
{
    public interface IXenditInvoiceClient
    {
        Task<IEnumerable<XenditInvoiceCreateResponse>> GetAllAsync();

        Task<IEnumerable<XenditInvoiceCreateResponse>> GetAllAsync(XenditInvoiceOptions options);

        Task<XenditInvoiceCreateResponse> GetAsync(string invoiceId);

        Task<XenditInvoiceCreateResponse> CreateAsync(XenditInvoiceCreateRequest invoice);

        /// <summary>
        /// Cancels an already created invoice by expiring it immediately.
        /// </summary>
        Task<XenditInvoiceCreateResponse> ExpireAsync(string invoiceId);
    }
}
