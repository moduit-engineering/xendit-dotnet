﻿using Newtonsoft.Json;
using System;
using Xendit.ApiClient.Abstracts;

namespace Xendit.ApiClient.VirtualAccount
{
    public class XenditVACreateExpireRequest : IXenditBaseRequest
    {
        [JsonProperty("expiration_date")]
        public DateTime ExpirationDate { get; set; }
    }
}
