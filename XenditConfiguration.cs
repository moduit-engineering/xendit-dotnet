using System;

namespace Xendit.ApiClient
{
    public class XenditConfiguration
    {
        public string BaseUrl { get; set; }

        public string ApiKey { get; set; }

        public string PublicKey { get; set; }

        public string CallbackVerificationToken { get; set; }

        // Transaction Fee + VAT
        public decimal TransactionFee { get; set; }

        // Disbursement Fee + VAT
        public decimal DisbursementFee { get; set; }

        public string FixedVANumberInfix { get; set; }

        public TimeSpan? PaymentExpiredTime { get; set; }
    }
}
