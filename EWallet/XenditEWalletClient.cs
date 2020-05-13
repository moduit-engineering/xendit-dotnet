using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xendit.ApiClient.Abstracts;
using Xendit.ApiClient.Constants;

namespace Xendit.ApiClient.EWallet
{
    public class XenditEWalletClient : IXenditEWalletClient
    {
        private readonly IXenditHttpConnection _conn;

        public XenditEWalletClient(IXenditHttpConnection conn)
        {
            _conn = conn;
        }

        public async Task<XenditEWalletCreatePaymentResponse> CreateOvoPaymentAsync(XenditEWalletCreateOvoPaymentRequest ovo)
        {
            var resource = "/ewallets";

            var headers = new Dictionary<string, string>();

            if (!string.IsNullOrWhiteSpace(ovo.ApiVersion))
            {
                headers.Add("X-API-VERSION", ovo.ApiVersion);
            }

            if (!string.IsNullOrWhiteSpace(ovo.ForUserId))
            {
                headers.Add("for-user-id", ovo.ForUserId);
            }

            return await _conn.SendRequestBodyAsync<XenditEWalletCreateOvoPaymentRequest, XenditEWalletCreatePaymentResponse>(
                Method.POST, resource, headers, ovo);
        }

        public async Task<XenditEWalletCreatePaymentResponse> CreateDanaPaymentAsync(XenditEWalletCreateDanaPaymentRequest dana)
        {
            var resource = "/ewallets";

            var headers = new Dictionary<string, string>();

            if (!string.IsNullOrWhiteSpace(dana.ForUserId))
            {
                headers.Add("for-user-id", dana.ForUserId);
            }

            return await _conn.SendRequestBodyAsync<XenditEWalletCreateDanaPaymentRequest, XenditEWalletCreatePaymentResponse>(
                Method.POST, resource, headers, dana);
        }

        public async Task<XenditEWalletCreatePaymentResponse> CreateLinkAjaPaymentAsync(XenditEWalletCreateLinkAjaPaymentRequest linkAja)
        {
            var resource = "/ewallets";

            var headers = new Dictionary<string, string>();

            if (!string.IsNullOrWhiteSpace(linkAja.ForUserId))
            {
                headers.Add("for-user-id", linkAja.ForUserId);
            }

            return await _conn.SendRequestBodyAsync<XenditEWalletCreateLinkAjaPaymentRequest, XenditEWalletCreatePaymentResponse>(
                Method.POST, resource, headers, linkAja);
        }

        public async Task<XenditEWalletCreatePaymentResponse> GetPaymentStatus(string externalId, XenditEWalletType eWalletType)
        {
            var resource = $"/ewallets?external_id={externalId}&ewallet_type={eWalletType}";

            return await _conn.SendRequestAsync<XenditEWalletCreatePaymentResponse>(
                Method.GET, resource);
        }
    }
}
