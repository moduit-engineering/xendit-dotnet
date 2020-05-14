using Newtonsoft.Json;
using System;
using Xendit.ApiClient.Abstracts;
using Xendit.ApiClient.Constants;

namespace Xendit.ApiClient.EWallet
{
    public class XenditEWalletCreateDanaPaymentRequest : XenditEWalletBaseRequest, IXenditBaseRequest
    {
        /// <summary>
        /// Note: Default expiry is 24 hours unless specified.
        /// </summary>
        [JsonProperty("expiration_date")]
        public DateTime? ExpirationDate { get; set; }

        [JsonProperty("callback_url")]
        public string CallbackUrl { get; set; }

        [JsonProperty("redirect_url")]
        public string RedirectUrl { get; set; }

        [JsonProperty("ewallet_type")]
        public XenditEWalletType Type { get; } = XenditEWalletType.DANA;
    }
}
