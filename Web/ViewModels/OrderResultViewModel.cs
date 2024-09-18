namespace Web.ViewModels
{
    /// <summary>
    /// ShoppingCart-交易完成後的訂單明細
    /// </summary>
    public class OrderResultViewModel
    {
        /// <summary>
        /// 課程ID
        /// </summary>
        public int CourseId { get; set; }

        /// <summary>
        /// 訂單編號
        /// </summary>
        public string TrackingNumber { get; set; }

        /// <summary>
        /// 教師名字
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 課程名稱
        /// </summary>
        public string CourseTitle { get; set; }

        /// <summary>
        /// 堂數
        /// </summary>
        public int CourseQuantity { get; set; }

        /// <summary>
        /// 小計
        /// </summary>
        public decimal SubtotalNTD { get; set; }

        /// <summary>
        /// 統一編號
        /// </summary>
        public string TaxIdNumber { get; set; }

        /// <summary>
        /// 交易時間
        /// </summary>
        public string OrderDatetime { get; set; }

        /// <summary>
        /// 預約日期
        /// </summary>
        public DateTime BookingDate { get; set; }

        /// <summary>
        /// 預約時段
        /// </summary>
        public short BookingTime { get; set; }
    }
    public class OrderResultListViewModel
    {
        public List<OrderResultViewModel> OrderResult { get; set; }
    }
}
