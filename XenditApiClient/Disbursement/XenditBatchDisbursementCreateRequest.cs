using Newtonsoft.Json;
using System.Collections.Generic;
using Xendit.ApiClient.Abstracts;
using Xendit.ApiClient.Constants;

namespace Xendit.ApiClient.Disbursement
{
    public class XenditBatchDisbursementCreateRequest : XenditBaseRequest
    {
        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("disbursements")]
        public IEnumerable<XenditBatchDisbursementCreateRequestItem> Disbursements { get; set; }
    }

    public class XenditBatchDisbursementCreateRequestItem
    {
        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("bank_code")]
        public XenditDisbursementBankCode BankCode { get; set; }

        [JsonProperty("bank_account_name")]
        public string AccountHolderName { get; set; }

        [JsonProperty("bank_account_number")]
        public string AccountNumber { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("email_to")]
        public string[] EmailTo { get; set; }

        [JsonProperty("email_cc")]
        public string[] EmailCc { get; set; }

        [JsonProperty("email_bcc")]
        public string[] EmailBcc { get; set; }
    }
}
