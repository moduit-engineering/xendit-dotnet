using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Xendit.ApiClient.Constants
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum XenditEWalletPaymentStatus
    {
        // Payment transaction for specified `external_id` is awaiting approval.
        PENDING,

        // Payment transaction for specified `external_id` is successfully.
        COMPLETED,

        // Payment transaction for specified `external_id` is successfully (DANA).
        PAID,

        // Payment creation for specified `external_id` failed.
        // (and is not completed (e.g. user did not complete the payment process or payment session timed out for OVO).
        FAILED,

        // Payment transaction URL for specified external_id has expired
        // (e.g. user did not access payment link or complete the payment process).
        EXPIRED
    }
}
