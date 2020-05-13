namespace Xendit.ApiClient.Constants
{
    /// <summary>
    /// Xendit date-semantic API version for OVO.
    /// </summary>
    public static class XenditEWalletOvoVersion
    {
        /// <summary>
        /// New OVO payment flow will process payments asynchronously vs previous synchronous flow.
        /// </summary>
        public const string V_2020_02_01 = "2020-02-01";

        /// <summary>
        /// Returns a response immediately without any callbacks returned.
        /// </summary>
        public const string V_2019_02_04 = "2019-02-04";
    }
}
