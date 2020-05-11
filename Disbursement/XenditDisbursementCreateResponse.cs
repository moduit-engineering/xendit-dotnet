using Newtonsoft.Json;
using Xendit.ApiClient.Constants;

namespace Xendit.ApiClient.Disbursement
{
    public class XenditDisbursementCreateResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        [JsonProperty("user_id")]
        public string XenditUserId { get; set; }

        [JsonProperty("status")]
        public XenditDisbursementStatus Status { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("bank_code")]
        public XenditDisbursementBankCode BankCode { get; set; }

        [JsonProperty("account_holder_name")]
        public string AccountHolderName { get; set; }

        [JsonProperty("disbursement_description")]
        public string Description { get; set; }
        
        [JsonProperty("email_to")]
        public string[] EmailTo { get; set; }

        [JsonProperty("email_cc")]
        public string[] EmailCc { get; set; }

        [JsonProperty("email_bcc")]
        public string[] EmailBcc { get; set; }
    }
}
