namespace Api.Dtos
{
    public class OrderDto
    {
        /// <summary>
        /// 訂單ID
        /// </summary>
        public int OrderID { get; set; }
        /// <summary>
        /// 訂單編號
        /// </summary>
        public string MerchantTradeNo { get; set; }
        /// <summary>
        /// 訂單日期
        /// </summary>
        public string TransactionDate { get; set; }
        /// <summary>
        /// 顧客名稱
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// 電子信箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 訂單狀態
        /// </summary>
        public string OrderStatusId { get; set; }
        /// <summary>
        /// 付款方式
        /// </summary>
        public string PaymentType { get; set; }
        /// <summary>
        /// 課程名稱
        /// </summary>
        public string CourseTitle { get; set; }
        /// <summary>
        /// 課程時長
        /// </summary>
        public int CourseType { get; set; }
        /// <summary>
        /// 購買堂數
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// 課程單價
        /// </summary>
        public int UnitPrice { get; set; }
        /// <summary>
        /// 小計金額
        /// </summary>
        public int SubTotal { get; set; }
        /// <summary>
        /// 訂單總額
        /// </summary>
        public int TotalPrice { get; set; }
        /// <summary>
        /// 本月訂單數量
        /// </summary>
        public int MonthCount { get; set; }
        /// <summary>
        /// 年度訂單數量
        /// </summary>
        public int YearCount { get; set; }
    }
}
