using Xendit.ApiClient.Disbursement;
using Xendit.ApiClient.EWallet;
using Xendit.ApiClient.Invoice;
using Xendit.ApiClient.Security;
using Xendit.ApiClient.VirtualAccount;

namespace Xendit.ApiClient.Abstracts
{
    public interface IXenditClient
    {
        XenditConfiguration Configuration { get; }

        string BaseUrl { get; }

        IXenditSecurityVerificator SecurityVerificator { get; }

        IXenditVAClient VirtualAccount { get; }

        IXenditInvoiceClient Invoice { get; }

        IXenditDisbursementClient Disbursement { get; }

        IXenditEWalletClient EWallet { get; }
    }
}
