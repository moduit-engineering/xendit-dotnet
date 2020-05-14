using Newtonsoft.Json;
using Xendit.ApiClient.Abstracts;
using Xendit.ApiClient.Constants;

namespace Xendit.ApiClient.EWallet
{
    public class XenditEWalletCreateOvoPaymentRequest : XenditEWalletBaseRequest, IXenditBaseRequest
    {
        /// <summary>
        /// OVO API Version from Xendit.
        /// </summary>
        /// <seealso cref="XenditEWalletOvoVersion"/>
        [JsonIgnore]
        public string ApiVersion { get; set; } = XenditEWalletOvoVersion.V_2020_02_01;

        /// <summary>
        /// Note:
        /// End-customer must have an active ewallet account registered to Indonesian phone number prior to payment request.
        /// Phone number format should always be "088889998888" (not using "+62").
        /// </summary>
        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("ewallet_type")]
        public XenditEWalletType Type { get; } = XenditEWalletType.OVO;
    }
}
