using Newtonsoft.Json;

namespace Xendit.ApiClient.Models
{
    public class XenditDisbursementBank
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("can_disburse")]
        public bool CanDisburse { get; set; }

        [JsonProperty("can_name_validate")]
        public bool CanNameValidate { get; set; }
    }
}
