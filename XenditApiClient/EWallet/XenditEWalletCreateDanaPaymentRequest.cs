using Newtonsoft.Json;
using System;
using Xendit.ApiClient.Abstracts;
using Xendit.ApiClient.Constants;

namespace Xendit.ApiClient.EWallet
{
    public class XenditEWalletCreateDanaPaymentRequest : XenditBaseRequest
    {
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
