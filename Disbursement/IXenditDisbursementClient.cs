using System.Collections.Generic;
using System.Threading.Tasks;
using Xendit.ApiClient.Models;

namespace Xendit.ApiClient.Disbursement
{
    public interface IXenditDisbursementClient
    {
        Task<IEnumerable<XenditDisbursementBank>> GetAvailableBanksAsync();

        Task<XenditDisbursementCreateResponse> GetByIdAsync(string disbursementId);

        Task<XenditDisbursementCreateResponse> GetByExternalIdAsync(string externalDisbursementId);

        Task<XenditDisbursementCreateResponse> CreateAsync(XenditDisbursementCreateRequest disbursement);
        
        Task<XenditBatchDisbursementCreateResponse> CreateBatchAsync(XenditBatchDisbursementCreateRequest disbursement);
    }
}
