using Newtonsoft.Json;

namespace Xendit.ApiClient.EWallet
{
    public abstract class XenditEWalletBaseRequest
    {
        /// <summary>
        /// The sub-account user-id that you want to make this transaction for.
        /// This parameter (in header) is only used if you have access to xenPlatform.
        /// </summary>
        /// <see href="https://xendit.github.io/apireference/#xenplatform"/>
        [JsonIgnore]
        public string ForUserId { get; set; }

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
    }
}