using Moq;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xendit.ApiClient.Abstracts;
using Xendit.ApiClient.Constants;
using Xendit.ApiClient.EWallet;
using Xunit;

namespace Xendit.ApiClient.Tests
{
    public class XenditEWalletClientTests
    {
        [Theory]
        [InlineData(null, null)]
        [InlineData(null, "ovo-xenplatform-user-id")]
        [InlineData(XenditEWalletOvoVersion.V_2020_02_01, null)]
        [InlineData(XenditEWalletOvoVersion.V_2020_02_01, "ovo-xenplatform-user-id")]
        [InlineData(XenditEWalletOvoVersion.V_2019_02_04, null)]
        [InlineData(XenditEWalletOvoVersion.V_2019_02_04, "ovo-xenplatform-user-id")]
        public async Task CreateOvoPayment_ReturnsSuccess(string apiVersion, string forUserId)
        {
            var ovoExternId = "Test:EWallet-OVO:1234:ExternId";

            var connectionMock = new Mock<IXenditHttpConnection>();

            connectionMock
                .Setup(c => c.SendRequestBodyAsync<IXenditBaseRequest, XenditEWalletCreatePaymentResponse>(
                    It.IsAny<Method>(),
                    It.IsAny<string>(),
                    It.IsAny<IXenditBaseRequest>()))
                .ReturnsAsync(new XenditEWalletCreatePaymentResponse());

            var eWalletClient = new XenditEWalletClient(connectionMock.Object);

            // Difference semantic between null and empty string for header.
            var expectedRequestHeader = new Dictionary<string, string>();

            if (apiVersion != null)
            {
                expectedRequestHeader.Add("X-API-VERSION", apiVersion);
            }
            
            if (forUserId != null)
            {
                expectedRequestHeader.Add("for-user-id", forUserId);
            }

            var ovo = new XenditEWalletCreateOvoPaymentRequest
            {
                ApiVersion = apiVersion,
                ForUserId = forUserId,
                ExternalId = ovoExternId,
            };

            var eWalletPayment = await eWalletClient.CreateOvoPaymentAsync(ovo);

            connectionMock.Verify(c => c.SendRequestBodyAsync<XenditEWalletCreateOvoPaymentRequest, XenditEWalletCreatePaymentResponse>(
                Method.POST,
                "/ewallets",
                expectedRequestHeader,
                ovo), Times.Once);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("dana-xenplatform-user-id")]
        public async Task CreateDanaPayment_ReturnsSuccess(string forUserId)
        {
            var danaExternId = "Test:EWallet-Dana:1234:ExternId";

            var connectionMock = new Mock<IXenditHttpConnection>();

            connectionMock
                .Setup(c => c.SendRequestBodyAsync<IXenditBaseRequest, XenditEWalletCreatePaymentResponse>(
                    It.IsAny<Method>(),
                    It.IsAny<string>(),
                    It.IsAny<IXenditBaseRequest>()))
                .ReturnsAsync(new XenditEWalletCreatePaymentResponse());

            var eWalletClient = new XenditEWalletClient(connectionMock.Object);

            // Difference semantic between null and empty string for header.
            var expectedRequestHeader = new Dictionary<string, string>();

            if (forUserId != null)
            {
                expectedRequestHeader.Add("for-user-id", forUserId);
            }

            var dana = new XenditEWalletCreateDanaPaymentRequest
            {
                ForUserId = forUserId,
                ExternalId = danaExternId,
            };

            var eWalletPayment = await eWalletClient.CreateDanaPaymentAsync(dana);

            connectionMock.Verify(c => c.SendRequestBodyAsync<XenditEWalletCreateDanaPaymentRequest, XenditEWalletCreatePaymentResponse>(
                Method.POST,
                "/ewallets",
                expectedRequestHeader,
                dana), Times.Once);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("linkaja-xenplatform-user-id")]
        public async Task CreateLinkAjaPayment_ReturnsSuccess(string forUserId)
        {
            var danaExternId = "Test:EWallet-LinkAja:1234:ExternId";

            var connectionMock = new Mock<IXenditHttpConnection>();

            connectionMock
                .Setup(c => c.SendRequestBodyAsync<IXenditBaseRequest, XenditEWalletCreatePaymentResponse>(
                    It.IsAny<Method>(),
                    It.IsAny<string>(),
                    It.IsAny<IXenditBaseRequest>()))
                .ReturnsAsync(new XenditEWalletCreatePaymentResponse());

            var eWalletClient = new XenditEWalletClient(connectionMock.Object);

            // Difference semantic between null and empty string for header.
            var expectedRequestHeader = new Dictionary<string, string>();

            if (forUserId != null)
            {
                expectedRequestHeader.Add("for-user-id", forUserId);
            }

            var linkAja = new XenditEWalletCreateLinkAjaPaymentRequest
            {
                ForUserId = forUserId,
                ExternalId = danaExternId,
            };

            var eWalletPayment = await eWalletClient.CreateLinkAjaPaymentAsync(linkAja);

            connectionMock.Verify(c => c.SendRequestBodyAsync<XenditEWalletCreateLinkAjaPaymentRequest, XenditEWalletCreatePaymentResponse>(
                Method.POST,
                "/ewallets",
                expectedRequestHeader,
                linkAja), Times.Once);
        }

        [Fact]
        public async Task GetPaymentStatus_ReturnsSuccess()
        {
            var paymentExternId = "Test:EWallet:1234:ExternId";
            var eWalletType = XenditEWalletType.OVO;

            var connectionMock = new Mock<IXenditHttpConnection>();

            connectionMock
                .Setup(c => c.SendRequestAsync<XenditEWalletCreatePaymentResponse>(
                    It.IsAny<Method>(),
                    It.IsAny<string>()))
                .ReturnsAsync(new XenditEWalletCreatePaymentResponse());

            var eWalletClient = new XenditEWalletClient(connectionMock.Object);

            var paymentStatus = await eWalletClient.GetPaymentStatusAsync(paymentExternId, eWalletType);

            connectionMock.Verify(c => c.SendRequestAsync<XenditEWalletCreatePaymentResponse>(
                Method.GET,
                $"/ewallets?external_id={paymentExternId}&ewallet_type={eWalletType}"), Times.Once);
        }
    }
}