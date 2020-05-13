using System.Threading.Tasks;
using Xendit.ApiClient.Constants;

namespace Xendit.ApiClient.EWallet
{
    public interface IXenditEWalletClient
    {
        Task<XenditEWalletCreatePaymentResponse> CreateOvoPaymentAsync(XenditEWalletCreateOvoPaymentRequest ovo);

        Task<XenditEWalletCreatePaymentResponse> CreateDanaPaymentAsync(XenditEWalletCreateDanaPaymentRequest dana);

        Task<XenditEWalletCreatePaymentResponse> CreateLinkAjaPaymentAsync(XenditEWalletCreateLinkAjaPaymentRequest linkAja);

        Task<XenditEWalletCreatePaymentResponse> GetPaymentStatus(string externalId, XenditEWalletType eWalletType);
    }
}
