using System;
using Xendit.ApiClient.Abstracts;
using Xendit.ApiClient.Disbursement;
using Xendit.ApiClient.EWallet;
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

        public IXenditEWalletClient EWallet { get; }

        public XenditClient(XenditConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            if (string.IsNullOrWhiteSpace(configuration.ApiKey))
            {
                throw new ArgumentNullException(nameof(configuration.ApiKey));
            }

            Configuration = configuration;
            BaseUrl = Configuration.BaseUrl;

            var connection = new XenditHttpConnection(Configuration);

            SecurityVerificator = new XenditSecurityVerificator(Configuration);
            VirtualAccount = new XenditVAClient(connection);
            Invoice = new XenditInvoiceClient(connection);
            Disbursement = new XenditDisbursementClient(connection);
            EWallet = new XenditEWalletClient(connection);
        }

        public XenditClient(string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                throw new ArgumentNullException(nameof(apiKey));
            }

            Configuration = new XenditConfiguration
            {
                ApiKey = apiKey
            };

            BaseUrl = Configuration.BaseUrl;

            var connection = new XenditHttpConnection(Configuration);

            SecurityVerificator = new XenditSecurityVerificator(Configuration);
            VirtualAccount = new XenditVAClient(connection);
            Invoice = new XenditInvoiceClient(connection);
            Disbursement = new XenditDisbursementClient(connection);
            EWallet = new XenditEWalletClient(connection);
        }
    }
}
