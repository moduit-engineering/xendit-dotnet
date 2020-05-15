using Newtonsoft.Json;
using Xendit.ApiClient.Abstracts;
using Xendit.ApiClient.Constants;

namespace Xendit.ApiClient.EWallet
{
    public class XenditEWalletCreateOvoPaymentRequest : XenditBaseRequest
    {
        /// <summary>
        /// OVO API Version from Xendit.
        /// </summary>
        /// <seealso cref="XenditEWalletOvoVersion"/>
        [JsonIgnore]
        public string ApiVersion { get; set; } = XenditEWalletOvoVersion.V_2020_02_01;

        /// <summary>
        /// Note:
        /// The only allowed punctuation is -.
        /// Maximum length allowed is 1000 characters.
        /// It has to be unique per payment request.
        /// </summary>
        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        /// <summary>
        /// Note: Minimum amount is 1 IDR and maximum is 10,000,000 IDR.
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount { get; set; }

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
