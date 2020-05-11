using Xendit.ApiClient.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Xendit.ApiClient.VirtualAccount
{
    public interface IXenditVAClient
    {
        Task<IEnumerable<XenditVABank>> GetAvailableBanksAsync();

        Task<XenditVACreateResponse> GetAsync(string vaId);

        Task<XenditVACreateResponse> CreateAsync(XenditVACreateRequest va);

        Task<XenditVACreateResponse> ExpireAsync(string vaId);
    }
}
