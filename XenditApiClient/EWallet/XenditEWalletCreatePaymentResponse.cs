using Newtonsoft.Json;
using System;
using Xendit.ApiClient.Constants;

namespace Xendit.ApiClient.EWallet
{
    public class XenditEWalletCreatePaymentResponse
    {
        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        [JsonProperty("business_id")]
        public string BusinessId { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("status")]
        public XenditEWalletPaymentStatus Status { get; set; }

        [JsonProperty("checkout_url")]
        public string CheckoutUrl { get; set; }

        [JsonProperty("transaction_date")]
        public DateTime TransactionDate { get; set; }

        [JsonProperty("payment_timestamp")]
        public DateTime PaymentTimestamp { get; set; }

        [JsonProperty("expiration_date")]
        public DateTime ExpirationDate { get; set; }

        [JsonProperty("expired_at")]
        private DateTime ExpiradAt { set { ExpirationDate = value; } }

        [JsonProperty("created")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("ewallet_type")]
        public XenditEWalletType EWalletType { get; set; }
    }
}
