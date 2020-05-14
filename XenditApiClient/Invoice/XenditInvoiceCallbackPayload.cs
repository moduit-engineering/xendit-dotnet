using Newtonsoft.Json;
using System;
using Xendit.ApiClient.Abstracts;
using Xendit.ApiClient.Constants;

namespace Xendit.ApiClient.Invoice
{
    public class XenditInvoiceCallbackPayload : IXenditBaseCallbackPayload
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        [JsonProperty("user_id")]
        public string XenditUserId { get; set; }

        [JsonProperty("payment_method")]
        public XenditInvoicePaidPaymentMethod PaymentMethod { get; set; }

        [JsonProperty("status")]
        public XenditInvoiceStatus Status { get; set; }

        [JsonProperty("merchant_name")]
        public string MerchantName { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("paid_amount")]
        public decimal PaidAmount { get; set; }

        [JsonProperty("bank_code")]
        public XenditVABankCode BankCode { get; set; }

        [JsonProperty("paid_at")]
        public DateTime PaidAt { get; set; }

        [JsonProperty("payer_email")]
        public string PayerEmail { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("adjusted_received_amount")]
        public decimal AdjustedReceivedAmount { get; set; }

        [JsonProperty("fees_paid_amount")]
        public decimal FeePaidAmount { get; set; }

        [JsonProperty("updated")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("created")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("payment_channel")]
        public XenditPaymentChannel PaymentChannel { get; set; }

        [JsonProperty("payment_destination")]
        public string PaymentDestination { get; set; }
    }
}
