using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Xendit.ApiClient.Abstracts;
using Xendit.ApiClient.Constants;

namespace Xendit.ApiClient.EWallet
{
    public class XenditEWalletPaymentCallbackPayload : IXenditBaseCallbackPayload
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("event")]
        public string Event { get; set; }

        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        [JsonProperty("business_id")]
        public string BusinessId { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("ewallet_type")]
        public XenditEWalletType EWalletType { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        /// <summary>
        /// Only applies if e-wallet type is Link Aja (`EWalletType = XenditEWalletType.LINKAJA`).
        /// </summary>
        [JsonProperty("items")]
        public List<XenditEWalletCreateLinkAjaPaymentRequestItem> LinkAjaItems { get; set; }

        [JsonProperty("created")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("transaction_date")]
        public DateTime TransactionDate { get; set; }

        [JsonProperty("status")]
        public XenditEWalletPaymentStatus Status { get; set; }

        [JsonProperty("payment_status")]
        public XenditEWalletPaymentStatus PaymentStatus { set { Status = value; } }

        [JsonProperty("callback_authentication_token")]
        public string CallbackAuthenticationToken { get; set; }

        [JsonProperty("failure_code")]
        public string FailureCode { get; set; }
    }
}
