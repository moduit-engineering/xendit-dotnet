using Moq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xendit.ApiClient.Abstracts;
using Xendit.ApiClient.Models;
using Xendit.ApiClient.Tests.Helpers;
using Xendit.ApiClient.VirtualAccount;
using Xunit;

namespace Xendit.ApiClient.Tests
{
    public class XenditVAClientTests
    {
        [Fact]
        public async Task GetAvailableBanks_ReturnsSuccess()
        {
            var connectionMock = new Mock<IXenditHttpConnection>();

            connectionMock
                .Setup(c => c.SendRequestAsync<IEnumerable<XenditVABank>>(
                    It.IsAny<Method>(),
                    It.IsAny<string>()))
                .ReturnsAsync(new List<XenditVABank>());

            var vaClient = new XenditVAClient(connectionMock.Object);

            var availableBanks = await vaClient.GetAvailableBanksAsync();

            connectionMock.Verify(c => c.SendRequestAsync<IEnumerable<XenditVABank>>(
                Method.GET,
                "/available_virtual_account_banks"), Times.Once);
        }

        [Fact]
        public async Task GetVirtualAccount_ReturnsSuccess()
        {
            var vaId = "Test:VA:1234:Get";

            var connectionMock = new Mock<IXenditHttpConnection>();

            connectionMock
                .Setup(c => c.SendRequestAsync<XenditVACreateResponse>(
                    It.IsAny<Method>(),
                    It.IsAny<string>()))
                .ReturnsAsync(new XenditVACreateResponse());

            var vaClient = new XenditVAClient(connectionMock.Object);

            var va = await vaClient.GetAsync(vaId);

            connectionMock.Verify(c => c.SendRequestAsync<XenditVACreateResponse>(
                Method.GET,
                $"/callback_virtual_accounts/{vaId}"), Times.Once);
        }

        [Fact]
        public async Task CreateVirtualAccount_ReturnsSuccess()
        {
            var connectionMock = new Mock<IXenditHttpConnection>();

            connectionMock
                .Setup(c => c.SendRequestBodyAsync<XenditBaseRequest, XenditVACreateResponse>(
                    It.IsAny<Method>(),
                    It.IsAny<string>(),
                    It.IsAny<XenditBaseRequest>(),
                    It.IsAny<string>()))
                .ReturnsAsync(new XenditVACreateResponse());

            var vaClient = new XenditVAClient(connectionMock.Object);

            var requestedVA = new XenditVACreateRequest
            {
                ExternalId = "Test_VA_1234",
                VirtualAccountNumber = "1234"
            };

            var va = await vaClient.CreateAsync(requestedVA);

            connectionMock.Verify(c => c.SendRequestBodyAsync<XenditVACreateRequest, XenditVACreateResponse>(
                Method.POST,
                "/callback_virtual_accounts",
                requestedVA,
                requestedVA.ExternalId), Times.Once);
        }

        [Fact]
        public async Task CreateVirtualAccount_ThrowsExceptionNotSuccess()
        {
            var connectionMock = new Mock<IXenditHttpConnection>();

            connectionMock
                .Setup(c => c.SendRequestBodyAsync<XenditBaseRequest, XenditVACreateResponse>(
                    It.IsAny<Method>(),
                    It.IsAny<string>(),
                    It.IsAny<XenditBaseRequest>(),
                    It.IsAny<string>()))
                .ThrowsAsync(XenditTestHelpers.GetTestResponseException());

            var vaClient = new XenditVAClient(connectionMock.Object);

            var requestedVA = new XenditVACreateRequest
            {
                ExternalId = "Test_VA_1234",
                VirtualAccountNumber = "1234"
            };

            await Assert.ThrowsAsync<XenditHttpResponseException>(() => vaClient.CreateAsync(requestedVA));

            connectionMock.Verify(c => c.SendRequestBodyAsync<XenditVACreateRequest, XenditVACreateResponse>(
                Method.POST,
                "/callback_virtual_accounts",
                requestedVA,
                requestedVA.ExternalId), Times.Once);
        }

        [Fact]
        public async Task ExpireVirtualAccount_ReturnsSuccess()
        {
            var vaId = "Test:VA:1234:Expire";

            var connectionMock = new Mock<IXenditHttpConnection>();

            connectionMock
                .Setup(c => c.SendRequestBodyAsync<XenditBaseRequest, XenditVACreateResponse>(
                    It.IsAny<Method>(),
                    It.IsAny<string>(),
                    It.IsAny<XenditBaseRequest>()))
                .ReturnsAsync(new XenditVACreateResponse());

            var vaClient = new XenditVAClient(connectionMock.Object);

            var va = await vaClient.ExpireAsync(vaId);

            connectionMock.Verify(c => c.SendRequestBodyAsync<XenditVACreateExpireRequest, XenditVACreateResponse>(
                Method.PATCH,
                $"/callback_virtual_accounts/{vaId}",
                It.Is<XenditVACreateExpireRequest>(c => c.ExpirationDate <= DateTime.Now)), Times.Once);
        }
    }
}
