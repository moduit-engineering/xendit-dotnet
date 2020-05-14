using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Xendit.ApiClient.Abstracts;
using Xendit.ApiClient.Constants;

namespace Xendit.ApiClient.Disbursement
{
    public class XenditBatchDisbursementSentCallbackPayload : IXenditBaseCallbackPayload
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("created")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("reference")]
        public string Reference { get; set; }

        [JsonProperty("total_uploaded_count")]
        public int TotalUploadedCount { get; set; }

        [JsonProperty("total_uploaded_amount")]
        public decimal TotalUploadedAmount { get; set; }

        [JsonProperty("approved_at")]
        public DateTime ApprovedAt { get; set; }

        [JsonProperty("approver_id")]
        public string ApproverId { get; set; }

        [JsonProperty("status")]
        public XenditBatchDisbursementStatus Status { get; set; }

        [JsonProperty("user_id")]
        public string XenditBusinessUserId { get; set; }

        [JsonProperty("total_error_count")]
        public int TotalErrorCount { get; set; }

        [JsonProperty("total_error_amount")]
        public decimal TotalErrorAmount { get; set; }

        [JsonProperty("total_disbursed_count")]
        public int TotalDisbursedCount { get; set; }

        [JsonProperty("total_disbursed_amount")]
        public decimal TotalDisbursedAmount { get; set; }

        [JsonProperty("disbursements")]
        public IEnumerable<XenditBatchDisbursementSentCallbackItem> Disbursements { get; set; }
    }

    public class XenditBatchDisbursementSentCallbackItem
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("created")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("updated")]
        public DateTime UpdatedAt { get; set; }

        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        [JsonProperty("amount")]
        public decimal Amount { get; set; }

        [JsonProperty("bank_code")]
        public XenditDisbursementBankCode BankCode { get; set; }

        [JsonProperty("bank_account_number")]
        public string BankAccountNumber { get; set; }

        [JsonProperty("bank_account_name")]
        public string BankAccountName { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("status")]
        public XenditDisbursementStatus Status { get; set; }

        /// <summary>
        /// Transaction reference number from the bank.
        /// </summary>
        [JsonProperty("bank_reference")]
        public string BankReference { get; set; }

        /// <summary>
        /// Valid receiving account holder name according to receiving bank.
        /// </summary>
        [JsonProperty("valid_name")]
        public string ValidName { get; set; }

        [JsonProperty("failure_code")]
        public string FailureCode { get; set; }

        [JsonProperty("failure_message")]
        public string FailureMessage { get; set; }

        [JsonProperty("email_to")]
        public string[] EmailTo { get; set; }

        [JsonProperty("email_cc")]
        public string[] EmailCc { get; set; }

        [JsonProperty("email_bcc")]
        public string[] EmailBcc { get; set; }
    }
}
