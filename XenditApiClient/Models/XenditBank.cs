using Newtonsoft.Json;

namespace Xendit.ApiClient.Models
{
    public class XenditBank
    {
        [JsonProperty("bank_code")]
        public string Code { get; set; }

        [JsonProperty("collection_type")]
        public string CollectionType { get; set; }

        [JsonProperty("bank_account_number")]
        public string BankAccountNumber { get; set; }

        [JsonProperty("transfer_amount")]
        public decimal TransferAmount { get; set; }

        [JsonProperty("bank_branch")]
        public string BankBranch { get; set; }

        [JsonProperty("account_holder_name")]
        public string AccountHolderName { get; set; }

        [JsonProperty("identity_amount")]
        public decimal IdentityAmount { get; set; }
    }
}
