using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Xendit.ApiClient.Constants
{
    /// <summary>
    /// Call `IXenditVAClient.GetAvailableVirtualAccountBanksAsync()` 
    ///  for complete list of Xendit Virtual Account Bank Code.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum XenditVABankCode
    {
        BNI,
        MANDIRI,
        BRI,
        BCA,
        PERMATA
    }
}
