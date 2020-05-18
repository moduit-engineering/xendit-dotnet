using System;
using Xunit;

namespace Xendit.ApiClient.Tests
{
    public class XenditClientTests
    {
        private const string BaseUrl = "https://api.xendit.co";
        private const string ApiKey = "xnd_test_1234";
        private const string CallbackVerificationToken = "1a2b3c4d5f";

        [Fact]
        public void CreateClientUsingApiKeyConstructor_ReturnsCorrectInstance()
        {
            var xendit = new XenditClient(ApiKey);

            // Assert Configuration
            Assert.Equal(ApiKey, xendit.Configuration.ApiKey);
            Assert.Equal(BaseUrl, xendit.Configuration.BaseUrl);
            Assert.Equal(BaseUrl, xendit.BaseUrl);
            Assert.Null(xendit.Configuration.CallbackVerificationToken);

            // Assert Client
            Assert.NotNull(xendit.VirtualAccount);
            Assert.NotNull(xendit.Disbursement);
            Assert.NotNull(xendit.Invoice);
            Assert.NotNull(xendit.EWallet);
            Assert.NotNull(xendit.SecurityVerificator);
        }

        [Fact]
        public void CreateClientUsingConfigConstructor_ReturnsCorrectInstance()
        {
            var config = new XenditConfiguration
            {
                ApiKey = ApiKey,
                BaseUrl = BaseUrl,
                CallbackVerificationToken = CallbackVerificationToken
            };

            var xendit = new XenditClient(config);

            // Assert Configuration
            Assert.Equal(ApiKey, xendit.Configuration.ApiKey);
            Assert.Equal(BaseUrl, xendit.Configuration.BaseUrl);
            Assert.Equal(BaseUrl, xendit.BaseUrl);
            Assert.Equal(CallbackVerificationToken, xendit.Configuration.CallbackVerificationToken);

            // Assert Client
            Assert.NotNull(xendit.VirtualAccount);
            Assert.NotNull(xendit.Disbursement);
            Assert.NotNull(xendit.Invoice);
            Assert.NotNull(xendit.EWallet);
            Assert.NotNull(xendit.SecurityVerificator);
        }

        [Fact]
        public void CreateClientApiKeyNotProvided_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new XenditClient(apiKey: null));
            Assert.Throws<ArgumentNullException>(() => new XenditClient(""));
            Assert.Throws<ArgumentNullException>(() => new XenditClient(" "));
            Assert.Throws<ArgumentNullException>(() => new XenditClient(configuration: null));
            Assert.Throws<ArgumentNullException>(() => new XenditClient(new XenditConfiguration { ApiKey = null }));
            Assert.Throws<ArgumentNullException>(() => new XenditClient(new XenditConfiguration { ApiKey = "" }));
            Assert.Throws<ArgumentNullException>(() => new XenditClient(new XenditConfiguration { ApiKey = " " }));
        }
    }
}
