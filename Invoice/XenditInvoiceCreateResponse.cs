using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Xendit.ApiClient.Constants;
using Xendit.ApiClient.Models;

namespace Xendit.ApiClient.Invoice
{
    public class XenditInvoiceCreateResponse
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        [JsonProperty("user_id")]
        public string XenditUserId { get; set; }

        [JsonProperty("status")]
        public XenditInvoiceStatus Status { get; set; }

        [JsonProperty("merchant_name")]
        public string MerchantName { get; set; }

        [JsonProperty("merchant_profile_picture_url")]
        public string MerchantProfilePictureUrl { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("payer_email")]
        public string PayerEmail { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("expiry_date")]
        public DateTime ExpiryDate { get; set; }

        [JsonProperty("invoice_url")]
        public string InvoiceUrl { get; set; }

        [JsonProperty("available_banks")]
        public IEnumerable<XenditBank> AvailableBanks { get; set; }

        [JsonProperty("should_exclude_credit_card")]
        public bool ShouldExcludeCreditCard { get; set; }

        [JsonProperty("should_send_email")]
        public bool ShouldSendEmail { get; set; }

        [JsonProperty("created")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }
    }
}
