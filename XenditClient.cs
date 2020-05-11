using Xendit.ApiClient.Abstracts;
using Xendit.ApiClient.Disbursement;
using Xendit.ApiClient.Invoice;
using Xendit.ApiClient.Security;
using Xendit.ApiClient.VirtualAccount;

namespace Xendit.ApiClient
{
    public sealed class XenditClient : IXenditClient
    {
        public XenditConfiguration Configuration { get; }

        public string BaseUrl { get; }

        public IXenditSecurityVerificator SecurityVerificator { get; }

        public IXenditVAClient VirtualAccount { get; }

        public IXenditInvoiceClient Invoice { get; }

        public IXenditDisbursementClient Disbursement { get; }

        public XenditClient(XenditConfiguration configuration)
        {
            Configuration = configuration;
            BaseUrl = Configuration.BaseUrl;

            var connection = new XenditHttpConnection(Configuration);

            SecurityVerificator = new XenditSecurityVerificator(Configuration);
            VirtualAccount = new XenditVAClient(connection);
            Invoice = new XenditInvoiceClient(connection);
            Disbursement = new XenditDisbursementClient(connection);
        }

        public XenditClient(string apiKey)
        {
            Configuration = new XenditConfiguration
            {
                BaseUrl = "https://api.xendit.co",
                ApiKey = apiKey
            };

            BaseUrl = Configuration.BaseUrl;

            var connection = new XenditHttpConnection(Configuration);

            SecurityVerificator = new XenditSecurityVerificator(Configuration);
            VirtualAccount = new XenditVAClient(connection);
            Invoice = new XenditInvoiceClient(connection);
            Disbursement = new XenditDisbursementClient(connection);
        }
    }
}
