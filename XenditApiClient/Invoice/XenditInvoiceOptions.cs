using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Xendit.ApiClient.Abstracts;
using Xendit.ApiClient.Constants;

namespace Xendit.ApiClient.Invoice
{
    public class XenditInvoiceOptions : XenditBaseRequest
    {
        [JsonProperty("statuses")]
        public IEnumerable<XenditInvoiceStatus> Statuses { get; set; }

        /// <summary>
        /// A limit on the number of invoice objects to be returned.
        /// Limit can range between 1 and 100. Default is 10 if it's null.
        /// </summary>
        [JsonProperty("limit")]
        public int? Limit { get; set; }

        [JsonProperty("created_after")]
        public DateTime? CreatedAfter { get; set; }

        [JsonProperty("created_before")]
        public DateTime? CreatedBefore { get; set; }

        [JsonProperty("paid_after")]
        public DateTime? PaidAfter { get; set; }

        [JsonProperty("paid_before")]
        public DateTime? PaidBefore { get; set; }

        [JsonProperty("expired_after")]
        public DateTime? ExpiredAfter { get; set; }

        [JsonProperty("expired_before")]
        public DateTime? ExpiredBefore { get; set; }

        /// <summary>
        /// last_invoice_id is an invoice ID that defines your starting point for the list. 
        /// For instance, if you make a list request and receive 10 objects, starting with obj_bar, 
        /// your subsequent call can include last_invoice_id=obj_bar in order to fetch the previous page of the list.
        /// </summary>
        [JsonProperty("last_invoice_id")]
        public string LastInvoiceId { get; set; }

        [JsonProperty("payment_channels")]
        public IEnumerable<XenditPaymentChannel> PaymentChannels { get; set; }
    }
}
