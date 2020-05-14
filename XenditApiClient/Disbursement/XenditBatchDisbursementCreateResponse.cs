using Newtonsoft.Json;
using System;
using Xendit.ApiClient.Constants;

namespace Xendit.ApiClient.Disbursement
{
    public class XenditBatchDisbursementCreateResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("created")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("total_uploaded_count")]
        public int TotalUploadedCount { get; set; }

        [JsonProperty("total_uploaded_amount")]
        public decimal TotalUploadedAmount { get; set; }

        [JsonProperty("status")]
        public XenditBatchDisbursementStatus Status { get; set; }
    }
}
