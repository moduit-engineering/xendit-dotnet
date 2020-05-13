using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xendit.ApiClient.Abstracts;
using Xendit.ApiClient.Models;

namespace Xendit.ApiClient.VirtualAccount
{
    public class XenditVAClient : IXenditVAClient
    {
        private readonly IXenditHttpConnection _conn;

        public XenditVAClient(IXenditHttpConnection conn)
        {
            _conn = conn;
        }

        public async Task<IEnumerable<XenditVABank>> GetAvailableBanksAsync()
        {
            const string resource = "/available_virtual_account_banks";

            return await _conn.SendRequestAsync<IEnumerable<XenditVABank>>(
                Method.GET, resource);
        }

        public async Task<XenditVACreateResponse> GetAsync(string vaId)
        {
            var resource = $"/callback_virtual_accounts/{vaId}";

            return await _conn.SendRequestAsync<XenditVACreateResponse>(
                Method.GET, resource);
        }

        public async Task<XenditVACreateResponse> CreateAsync(XenditVACreateRequest va)
        {
            const string resource = "/callback_virtual_accounts";

            return await _conn.SendRequestBodyAsync<XenditVACreateRequest, XenditVACreateResponse>(
                Method.POST, resource, va, va.ExternalId);
        }

        public async Task<XenditVACreateResponse> ExpireAsync(string vaId)
        {
            var resource = $"callback_virtual_accounts/{vaId}";

            var request = new XenditVACreateExpireRequest
            {
                ExpirationDate = DateTime.Now
            };

            return await _conn.SendRequestBodyAsync<XenditVACreateExpireRequest, XenditVACreateResponse>(
                Method.PATCH, resource, request);
        }
    }
}
