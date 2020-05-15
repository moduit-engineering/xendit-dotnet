using Xunit;

namespace Xendit.ApiClient.Tests
{
    public class XenditSecurityVerificatorTests
    {
        private const string ApiKey = "xnd_test_1234";
        private const string CallbackVerificationToken = "1a2b3c4d5f";

        [Fact]
        public void UsingClientApiKeyConstructorWithEmptyToken_ReturnsTrue()
        {
            var xendit = new XenditClient(ApiKey);

            var isVerifiedWithNullIncomingToken = xendit.SecurityVerificator.IsWebhookCallbackVerified(null);
            var isVerifiedEmptyIncomingToken = xendit.SecurityVerificator.IsWebhookCallbackVerified("");
            var isVerifiedNonEmptyIncomingToken = xendit.SecurityVerificator.IsWebhookCallbackVerified("incoming_token_123");

            Assert.True(isVerifiedWithNullIncomingToken);
            Assert.True(isVerifiedEmptyIncomingToken);
            Assert.True(isVerifiedNonEmptyIncomingToken);
        }

        [Fact]
        public void UsingClientConfigConstructorWithToken_ReturnsCorrectVerification()
        {
            var config = new XenditConfiguration
            {
                ApiKey = ApiKey,
                CallbackVerificationToken = CallbackVerificationToken
            };

            var xendit = new XenditClient(config);

            var isVerifiedWithNullIncomingToken = xendit.SecurityVerificator.IsWebhookCallbackVerified(null);
            var isVerifiedEmptyIncomingToken = xendit.SecurityVerificator.IsWebhookCallbackVerified("");
            var isVerifiedNonEmptyIncomingToken = xendit.SecurityVerificator.IsWebhookCallbackVerified("wrong_incoming_token");
            var isVerified = xendit.SecurityVerificator.IsWebhookCallbackVerified(CallbackVerificationToken);

            Assert.False(isVerifiedWithNullIncomingToken);
            Assert.False(isVerifiedEmptyIncomingToken);
            Assert.False(isVerifiedNonEmptyIncomingToken);
            Assert.True(isVerified);
        }
    }
}
