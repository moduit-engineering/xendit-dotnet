using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Xendit.ApiClient.Constants
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum XenditDisbursementStatus
    {
        // Transfer is initiated.
        PENDING,

        // Bank has confirmed transmission of funds.
        COMPLETED,

        // Bank rejected disbursement. We will not retry.
        FAILED
    }
}
