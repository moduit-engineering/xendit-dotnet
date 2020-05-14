using Newtonsoft.Json;
using Xendit.ApiClient.Abstracts;

namespace Xendit.ApiClient.Invoice
{
    public class XenditInvoiceCreateRequest : IXenditBaseRequest
    {
        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("payer_email")]
        public string PayerEmail { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("callback_virtual_account_id")]
        public string VANumberId { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("invoice_duration")]
        public double? InvoiceDurationInSecondSinceCreation { get; set; }
    }
}
