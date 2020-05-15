using Moq;
using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xendit.ApiClient.Abstracts;
using Xendit.ApiClient.Constants;
using Xendit.ApiClient.Invoice;
using Xunit;

namespace Xendit.ApiClient.Tests
{
    public class XenditInvoiceClientTests
    {
        [Fact]
        public async Task GetAllInvoices_ReturnsSuccess()
        {
            var connectionMock = new Mock<IXenditHttpConnection>();

            connectionMock
                .Setup(c => c.SendRequestAsync<IEnumerable<XenditInvoiceCreateResponse>>(
                    It.IsAny<Method>(),
                    It.IsAny<string>()))
                .ReturnsAsync(new List<XenditInvoiceCreateResponse>());

            var invoiceClient = new XenditInvoiceClient(connectionMock.Object);

            var allInvoices = await invoiceClient.GetAllAsync();

            connectionMock.Verify(c => c.SendRequestBodyAsync<XenditInvoiceOptions, IEnumerable<XenditInvoiceCreateResponse>>(
                Method.POST,
                "/v2/invoices",
                null), Times.Once);
        }

        [Fact]
        public async Task GetAllInvoicesByFilters_ReturnsSuccess()
        {
            var connectionMock = new Mock<IXenditHttpConnection>();

            connectionMock
                .Setup(c => c.SendRequestAsync<IEnumerable<XenditInvoiceCreateResponse>>(
                    It.IsAny<Method>(),
                    It.IsAny<string>()))
                .ReturnsAsync(new List<XenditInvoiceCreateResponse>());

            var invoiceClient = new XenditInvoiceClient(connectionMock.Object);

            var filter = new XenditInvoiceOptions
            {
                Statuses = new List<XenditInvoiceStatus> { XenditInvoiceStatus.SETTLED }
            };

            var allInvoices = await invoiceClient.GetAllAsync(filter);

            connectionMock.Verify(c => c.SendRequestBodyAsync<XenditInvoiceOptions, IEnumerable<XenditInvoiceCreateResponse>>(
                Method.POST,
                "/v2/invoices",
                filter), Times.Once);
        }

        [Fact]
        public async Task GetInvoiceById_ReturnsSuccess()
        {
            var invoiceId = "Test:Inv:1234:Id:Get";

            var connectionMock = new Mock<IXenditHttpConnection>();

            connectionMock
                .Setup(c => c.SendRequestAsync<XenditInvoiceCreateResponse>(
                    It.IsAny<Method>(),
                    It.IsAny<string>()))
                .ReturnsAsync(new XenditInvoiceCreateResponse());

            var invoiceClient = new XenditInvoiceClient(connectionMock.Object);

            var invoice = await invoiceClient.GetAsync(invoiceId);

            connectionMock.Verify(c => c.SendRequestAsync<XenditInvoiceCreateResponse>(
                Method.GET,
                $"/v2/invoices/{invoiceId}"), Times.Once);
        }

        [Fact]
        public async Task CreateInvoice_ReturnsSuccess()
        {
            var invoiceExternId = "Test:Inv:1234:ExternId:Get";

            var connectionMock = new Mock<IXenditHttpConnection>();

            connectionMock
                .Setup(c => c.SendRequestBodyAsync<XenditBaseRequest, XenditInvoiceCreateResponse>(
                    It.IsAny<Method>(),
                    It.IsAny<string>(),
                    It.IsAny<XenditBaseRequest>(),
                    It.IsAny<string>()))
                .ReturnsAsync(new XenditInvoiceCreateResponse());

            var invoiceClient = new XenditInvoiceClient(connectionMock.Object);

            var requestedInvoice = new XenditInvoiceCreateRequest
            {
                ExternalId = invoiceExternId
            };

            var invoice = await invoiceClient.CreateAsync(requestedInvoice);

            connectionMock.Verify(c => c.SendRequestBodyAsync<XenditInvoiceCreateRequest, XenditInvoiceCreateResponse>(
                Method.POST,
                "/v2/invoices",
                requestedInvoice,
                requestedInvoice.ExternalId), Times.Once);
        }

        [Fact]
        public async Task ExpireInvoice_ReturnsSuccess()
        {
            var invoiceId = "Test:Inv:1234:Expire"; ;

            var connectionMock = new Mock<IXenditHttpConnection>();

            connectionMock
                .Setup(c => c.SendRequestAsync<XenditInvoiceCreateResponse>(
                    It.IsAny<Method>(),
                    It.IsAny<string>()))
                .ReturnsAsync(new XenditInvoiceCreateResponse());

            var invoiceClient = new XenditInvoiceClient(connectionMock.Object);

            var invoice = await invoiceClient.ExpireAsync(invoiceId);

            connectionMock.Verify(c => c.SendRequestAsync<XenditInvoiceCreateResponse>(
                Method.POST,
                $"/invoices/{invoiceId}/expire!"), Times.Once);
        }
    }
}
