using System;
using Newtonsoft.Json;
using Xendit.ApiClient.Abstracts;
using Xendit.ApiClient.Constants;

namespace Xendit.ApiClient.Disbursement
{
    public class XenditDisbursementSentCallbackPayload : IXenditBaseCallbackPayload
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("user_id")]
        public string XenditUserId { get; set; }

        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("bank_code")]
        public XenditDisbursementBankCode BankCode { get; set; }

        [JsonProperty("account_holder_name")]
        public string AccountHolderName { get; set; }

        [JsonProperty("transaction_id")]
        public string TransactionId { get; set; }

        [JsonProperty("transaction_sequence")]
        public string TransactionSequence { get; set; }

        [JsonProperty("disbursement_id")]
        public string DisbursementId { get; set; }

        [JsonProperty("disbursement_description")]
        public string DisbursementDescription { get; set; }

        [JsonProperty("failure_code")]
        public string FailureCode { get; set; }

        [JsonProperty("is_instant")]
        public bool IsInstant { get; set; }

        [JsonProperty("status")]
        public XenditDisbursementStatus Status { get; set; }

        [JsonProperty("updated")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("created")]
        public DateTime CreatedAt { get; set; }
    }
}
