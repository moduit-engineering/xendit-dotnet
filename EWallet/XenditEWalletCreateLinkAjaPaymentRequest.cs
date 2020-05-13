using Newtonsoft.Json;
using System.Collections.Generic;
using Xendit.ApiClient.Abstracts;
using Xendit.ApiClient.Constants;

namespace Xendit.ApiClient.EWallet
{
    public class XenditEWalletCreateLinkAjaPaymentRequest : XenditEWalletBaseRequest, IXenditBaseRequest
    {
        /// <summary>
        /// Phone number of end-customer, e.g. 08123123123.<br />
        /// For testing purpose:<br />
        ///  1. Use "089911111111" for successful PaymentResponse for a successfully paid e-wallet transaction.<br />
        ///  2. Use "089922222222 for failed PaymentThere is an error on when the payment processed.
        /// </summary>
        /// <seealso href="https://docs.xendit.co/xenpayments/ewallet/testing-ew/index.html"/>
        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("items")]
        public List<XenditEWalletCreateLinkAjaPaymentRequestItem> Items { get; set; }

        [JsonProperty("callback_url")]
        public string CallbackUrl { get; set; }

        [JsonProperty("redirect_url")]
        public string RedirectUrl { get; set; }

        [JsonProperty("ewallet_type")]
        public XenditEWalletType Type { get; } = XenditEWalletType.LINKAJA;
    }

    public class XenditEWalletCreateLinkAjaPaymentRequestItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
}
