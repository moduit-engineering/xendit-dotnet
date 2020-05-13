using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Xendit.ApiClient.Constants
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum XenditBatchDisbursementStatus
    {
        // Batch disbursement is created but needs to be approved to be processed further.
        NEEDS_APPROVAL,

        // Uploading disbursements.
        UPLOADING,

        // All disbursements are successfully paid.
        COMPLETED,

        // Some disbursements are successfully paid.
        CHECK,

        // Batch disbursement has been deleted.
        DELETED,

        // All disbursements are not successfully paid.
        FAILED
    }
}
