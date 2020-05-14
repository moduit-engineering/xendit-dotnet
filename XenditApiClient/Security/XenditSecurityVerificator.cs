namespace Xendit.ApiClient.Security
{
    public class XenditSecurityVerificator : IXenditSecurityVerificator
    {
        private readonly XenditConfiguration _config;

        public XenditSecurityVerificator(XenditConfiguration config)
        {
            _config = config;
        }

        public bool IsWebhookCallbackVerified(string incomingToken)
        {
            return (_config.CallbackVerificationToken == incomingToken);
        }
    }
}
