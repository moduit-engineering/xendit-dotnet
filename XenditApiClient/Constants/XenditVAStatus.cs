using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Xendit.ApiClient.Constants
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum XenditVAStatus
    {
        // Status is PENDING if virtual account creation request has been sent and request is being processed by the bank.
        PENDING,

        // Status is INACTIVE either the single use virtual account has been paid or already expired.
        INACTIVE,

        // If status is ACTIVE the virtual account is ready to be used by the end user.
        ACTIVE
    }
}
