using Moq;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xendit.ApiClient.Abstracts;
using Xendit.ApiClient.Disbursement;
using Xendit.ApiClient.Models;
using Xunit;

namespace Xendit.ApiClient.Tests
{
    public class XenditDisbursementClientTests
    {
        [Fact]
        public async Task GetAvailableBanks_ReturnsSuccess()
        {
            var connectionMock = new Mock<IXenditHttpConnection>();

            connectionMock
                .Setup(c => c.SendRequestAsync<IEnumerable<XenditDisbursementBank>>(
                    It.IsAny<Method>(),
                    It.IsAny<string>()))
                .ReturnsAsync(new List<XenditDisbursementBank>());

            var disbursementClient = new XenditDisbursementClient(connectionMock.Object);

            var availableBanks = await disbursementClient.GetAvailableBanksAsync();

            connectionMock.Verify(c => c.SendRequestAsync<IEnumerable<XenditDisbursementBank>>(
                Method.GET,
                "/available_disbursements_banks"), Times.Once);
        }

        [Fact]
        public async Task GetDisbursementById_ReturnsSuccess()
        {
            var disbId = "Test:Disb:1234:Id:Get";

            var connectionMock = new Mock<IXenditHttpConnection>();

            connectionMock
                .Setup(c => c.SendRequestAsync<XenditDisbursementCreateResponse>(
                    It.IsAny<Method>(),
                    It.IsAny<string>()))
                .ReturnsAsync(new XenditDisbursementCreateResponse());

            var disbursementClient = new XenditDisbursementClient(connectionMock.Object);

            var availableBanks = await disbursementClient.GetByIdAsync(disbId);

            connectionMock.Verify(c => c.SendRequestAsync<XenditDisbursementCreateResponse>(
                Method.GET,
                $"/disbursements/{disbId}"), Times.Once);
        }

        [Fact]
        public async Task GetDisbursementByExternalId_ReturnsSuccess()
        {
            var disbExternalId = "Test:Disb:1234:EnternId:Get";

            var connectionMock = new Mock<IXenditHttpConnection>();

            connectionMock
                .Setup(c => c.SendRequestAsync<XenditDisbursementCreateResponse>(
                    It.IsAny<Method>(),
                    It.IsAny<string>()))
                .ReturnsAsync(new XenditDisbursementCreateResponse());

            var disbursementClient = new XenditDisbursementClient(connectionMock.Object);

            var availableBanks = await disbursementClient.GetByExternalIdAsync(disbExternalId);

            connectionMock.Verify(c => c.SendRequestAsync<XenditDisbursementCreateResponse>(
                Method.GET,
                $"/disbursements?external_id={disbExternalId}"), Times.Once);
        }

        [Fact]
        public async Task CreateDisbursement_ReturnsSuccess()
        {
            var connectionMock = new Mock<IXenditHttpConnection>();

            connectionMock
                .Setup(c => c.SendRequestBodyAsync<IXenditBaseRequest, XenditDisbursementCreateResponse>(
                    It.IsAny<Method>(),
                    It.IsAny<string>(),
                    It.IsAny<IXenditBaseRequest>(),
                    It.IsAny<string>()))
                .ReturnsAsync(new XenditDisbursementCreateResponse());

            var disbursementClient = new XenditDisbursementClient(connectionMock.Object);

            var requestedDisbursement = new XenditDisbursementCreateRequest
            {
                ExternalId = "Test_Disb_1234"
            };

            var disb = await disbursementClient.CreateAsync(requestedDisbursement);

            connectionMock.Verify(c => c.SendRequestBodyAsync<XenditDisbursementCreateRequest, XenditDisbursementCreateResponse>(
                Method.POST,
                "/disbursements",
                requestedDisbursement,
                requestedDisbursement.ExternalId), Times.Once);
        }

        [Fact]
        public async Task CreateBatchDisbursement_ReturnsSuccess()
        {
            var connectionMock = new Mock<IXenditHttpConnection>();

            connectionMock
                .Setup(c => c.SendRequestBodyAsync<IXenditBaseRequest, XenditBatchDisbursementCreateResponse>(
                    It.IsAny<Method>(),
                    It.IsAny<string>(),
                    It.IsAny<IXenditBaseRequest>(),
                    It.IsAny<string>()))
                .ReturnsAsync(new XenditBatchDisbursementCreateResponse());

            var disbursementClient = new XenditDisbursementClient(connectionMock.Object);

            var requestedBatchDisb = new XenditBatchDisbursementCreateRequest
            {
                Reference = "Test_Disb_1234"
            };

            var batchDisb = await disbursementClient.CreateBatchAsync(requestedBatchDisb);

            connectionMock.Verify(c => c.SendRequestBodyAsync<XenditBatchDisbursementCreateRequest, XenditBatchDisbursementCreateResponse>(
                Method.POST,
                "/batch_disbursements",
                requestedBatchDisb,
                requestedBatchDisb.Reference), Times.Once);
        }
    }
}
