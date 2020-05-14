using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Xendit.ApiClient.Constants
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum XenditEWalletType
    {
        DANA,
        OVO,
        LINKAJA
    }
}