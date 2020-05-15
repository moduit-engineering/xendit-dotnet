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
            if (string.IsNullOrWhiteSpace(_config.CallbackVerificationToken))
            {
                return true;
            }

            return (_config.CallbackVerificationToken == incomingToken);
        }
    }
}
