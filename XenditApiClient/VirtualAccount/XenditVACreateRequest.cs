using Newtonsoft.Json;
using System;
using Xendit.ApiClient.Abstracts;
using Xendit.ApiClient.Constants;

namespace Xendit.ApiClient.VirtualAccount
{
    public class XenditVACreateRequest : XenditBaseRequest
    {
        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        [JsonProperty("bank_code")]
        public XenditVABankCode BankCode { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("virtual_account_number")]
        public string VirtualAccountNumber { get; set; }

        /// <summary>
        /// If this property is set to `true`, property `ExpectedAmount` must be set.
        /// </summary>
        [JsonProperty("is_closed")]
        public bool IsClosedVA { get; set; }

        /// <summary>
        /// Only applied if IsClosedVA is `true`.
        /// </summary>
        [JsonProperty("expected_amount")]
        public decimal? ExpectedAmount { get; set; }

        [JsonProperty("expiration_date")]
        public DateTime? ExpirationDate { get; set; }
    }
}
