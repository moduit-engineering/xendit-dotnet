using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Xendit.ApiClient.Constants
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum XenditInvoiceStatus
    {
        // The invoice has yet to be paid.
        PENDING,

        // The invoice has successfully been paid.
        PAID,

        // The amount of paid invoice has been settled to cash balance.
        SETTLED,

        // The invoice has been expired.
        EXPIRED
    }
}
