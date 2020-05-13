using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xendit.ApiClient.Abstracts;
using Xendit.ApiClient.Models;

namespace Xendit.ApiClient.Disbursement
{
    public class XenditDisbursementClient : IXenditDisbursementClient
    {
        private readonly IXenditHttpConnection _conn;

        public XenditDisbursementClient(IXenditHttpConnection conn)
        {
            _conn = conn;
        }

        public async Task<IEnumerable<XenditDisbursementBank>> GetAvailableBanksAsync()
        {
            const string resource = "/available_disbursements_banks";

            return await _conn.SendRequestAsync<IEnumerable<XenditDisbursementBank>>(
                Method.GET, resource);
        }

        public async Task<XenditDisbursementCreateResponse> GetByIdAsync(string disbursementId)
        {
            var resource = $"/disbursements/{disbursementId}";

            return await _conn.SendRequestAsync<XenditDisbursementCreateResponse>(
                Method.GET, resource);
        }

        public async Task<XenditDisbursementCreateResponse> GetByExternalIdAsync(string externalDisbursementId)
        {
            var resource = $"/disbursements?external_id={externalDisbursementId}";

            return await _conn.SendRequestAsync<XenditDisbursementCreateResponse>(
                Method.GET, resource);
        }

        public async Task<XenditDisbursementCreateResponse> CreateAsync(XenditDisbursementCreateRequest disbursement)
        {
            const string resource = "disbursements";

            return await _conn.SendRequestBodyAsync<XenditDisbursementCreateRequest, XenditDisbursementCreateResponse>(
                Method.POST, resource, disbursement, disbursement.ExternalId);
        }
        
        public async Task<XenditBatchDisbursementCreateResponse> CreateBatchAsync(XenditBatchDisbursementCreateRequest disbursement)
        {
            const string resource = "batch_disbursements";

            return await _conn.SendRequestBodyAsync<XenditBatchDisbursementCreateRequest, XenditBatchDisbursementCreateResponse>(
                Method.POST, resource, disbursement, disbursement.Reference);
        }
    }
}
