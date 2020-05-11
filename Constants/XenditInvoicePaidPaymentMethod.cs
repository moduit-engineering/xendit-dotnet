using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Xendit.ApiClient.Constants
{
    /// <summary>
    /// Payment method that is used when a customer pays the invoice.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum XenditInvoicePaidPaymentMethod
    {
        BANK_TRANSFER,
        CREDIT_CARD,
        RETAIL_OUTLET,
        EWALLET
    }
}
