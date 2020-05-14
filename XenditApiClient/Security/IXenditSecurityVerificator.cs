namespace Xendit.ApiClient.Security
{
    public interface IXenditSecurityVerificator
    {
        bool IsWebhookCallbackVerified(string incomingToken);
    }
}
