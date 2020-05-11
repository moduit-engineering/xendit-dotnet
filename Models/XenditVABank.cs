using Newtonsoft.Json;

namespace Xendit.ApiClient.Models
{
    public class XenditVABank
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }
    }
}
