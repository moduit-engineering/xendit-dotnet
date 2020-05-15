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
        [InlineData(null)]
        [InlineData(XenditEWalletOvoVersion.V_2020_02_01)]
        [InlineData(XenditEWalletOvoVersion.V_2019_02_04)]
        public async Task CreateOvoPayment_ReturnsSuccess(string apiVersion)
        {
            var ovoExternId = "Test:EWallet-OVO:1234:ExternId";

            var connectionMock = new Mock<IXenditHttpConnection>();

            connectionMock
                .Setup(c => c.SendRequestBodyAsync<XenditBaseRequest, XenditEWalletCreatePaymentResponse>(
                    It.IsAny<Method>(),
                    It.IsAny<string>(),
                    It.IsAny<XenditBaseRequest>()))
                .ReturnsAsync(new XenditEWalletCreatePaymentResponse());

            var eWalletClient = new XenditEWalletClient(connectionMock.Object);

            // Difference semantic between null and empty string for header.
            var expectedRequestHeader = new Dictionary<string, string>();

            if (apiVersion != null)
            {
                expectedRequestHeader.Add("X-API-VERSION", apiVersion);
            }

            var ovo = new XenditEWalletCreateOvoPaymentRequest
            {
                ApiVersion = apiVersion,
                ExternalId = ovoExternId,
            };

            var eWalletPayment = await eWalletClient.CreateOvoPaymentAsync(ovo);

            connectionMock.Verify(c => c.SendRequestBodyAsync<XenditEWalletCreateOvoPaymentRequest, XenditEWalletCreatePaymentResponse>(
                Method.POST,
                "/ewallets",
                expectedRequestHeader,
                ovo), Times.Once);
        }

        [Fact]
        public async Task CreateDanaPayment_ReturnsSuccess()
        {
            var danaExternId = "Test:EWallet-Dana:1234:ExternId";

            var connectionMock = new Mock<IXenditHttpConnection>();

            connectionMock
                .Setup(c => c.SendRequestBodyAsync<XenditBaseRequest, XenditEWalletCreatePaymentResponse>(
                    It.IsAny<Method>(),
                    It.IsAny<string>(),
                    It.IsAny<XenditBaseRequest>()))
                .ReturnsAsync(new XenditEWalletCreatePaymentResponse());

            var eWalletClient = new XenditEWalletClient(connectionMock.Object);

            var dana = new XenditEWalletCreateDanaPaymentRequest
            {
                ExternalId = danaExternId,
            };

            var eWalletPayment = await eWalletClient.CreateDanaPaymentAsync(dana);

            connectionMock.Verify(c => c.SendRequestBodyAsync<XenditEWalletCreateDanaPaymentRequest, XenditEWalletCreatePaymentResponse>(
                Method.POST,
                "/ewallets",
                dana), Times.Once);
        }

        [Fact]
        public async Task CreateLinkAjaPayment_ReturnsSuccess()
        {
            var danaExternId = "Test:EWallet-LinkAja:1234:ExternId";

            var connectionMock = new Mock<IXenditHttpConnection>();

            connectionMock
                .Setup(c => c.SendRequestBodyAsync<XenditBaseRequest, XenditEWalletCreatePaymentResponse>(
                    It.IsAny<Method>(),
                    It.IsAny<string>(),
                    It.IsAny<XenditBaseRequest>()))
                .ReturnsAsync(new XenditEWalletCreatePaymentResponse());

            var eWalletClient = new XenditEWalletClient(connectionMock.Object);

            var linkAja = new XenditEWalletCreateLinkAjaPaymentRequest
            {
                ExternalId = danaExternId,
            };

            var eWalletPayment = await eWalletClient.CreateLinkAjaPaymentAsync(linkAja);

            connectionMock.Verify(c => c.SendRequestBodyAsync<XenditEWalletCreateLinkAjaPaymentRequest, XenditEWalletCreatePaymentResponse>(
                Method.POST,
                "/ewallets",
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