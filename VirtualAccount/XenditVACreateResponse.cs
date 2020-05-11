using Newtonsoft.Json;
using System;
using Xendit.ApiClient.Constants;

namespace Xendit.ApiClient.VirtualAccount
{
    public class XenditVACreateResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        [JsonProperty("owner_id")]
        public string OwnerId { get; set; }

        [JsonProperty("bank_code")]
        public XenditVABankCode BankCode { get; set; }

        [JsonProperty("merchant_code")]
        public string MerchantCode { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }

        [JsonProperty("expected_amount")]
        public decimal ExpectedAmount { get; set; }

        [JsonProperty("is_single_use")]
        public bool IsSingleUse { get; set; }

        [JsonProperty("is_closed")]
        public bool IsClosed { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("status")]
        public XenditVAStatus Status { get; set; }

        [JsonProperty("expiration_date")]
        public DateTime ExpirationDate { get; set; }
    }
}
