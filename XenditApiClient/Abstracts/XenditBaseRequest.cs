using Newtonsoft.Json;

namespace Xendit.ApiClient.Abstracts
{
    public abstract class XenditBaseRequest 
    {
        /// <summary>
        /// The sub-account user-id that you want to make this transaction for.
        /// This parameter (in header) is only used if you have access to xenPlatform.
        /// </summary>
        /// <see href="https://xendit.github.io/apireference/#xenplatform"/>
        [JsonIgnore]
        public string ForUserId { get; set; }
    }

    public interface IXenditBaseCallbackPayload { }
}
