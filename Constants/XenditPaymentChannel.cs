using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Xendit.ApiClient.Constants
{
    /// <summary>
    /// The payment channel used when a customer pays the invoice.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum XenditPaymentChannel
    {
        BCA,
        BRI,
        MANDIRI,
        BNI,
        PERMATA,
        ALFAMART,
        OVO,
        CREDIT_CARD
    }
}
