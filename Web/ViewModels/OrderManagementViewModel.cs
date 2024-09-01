using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels
{
    public class OrderManagementViewModel
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
        /// 教師頭像
        /// </summary>
        public string HeadShotImage { get; set; }

        /// <summary>
        /// 教師名字
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 課程名稱
        /// </summary>
        public string CourseTitle { get; set; }

        /// <summary>
        /// 課程科目
        /// </summary>
        public string CourseSubject { get; set; }

        /// <summary>
        /// 課程類別
        /// </summary>
        public string CourseCategory { get; set; }

        /// <summary>
        /// 分鐘數
        /// </summary>
        public string CourseLength { get; set; }

        /// <summary>
        /// 堂數
        /// </summary>
        public int CourseQuantity { get; set; }

        /// <summary>
        /// 單價
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// 小計
        /// </summary>
        public decimal SubtotalNTD { get; set; }

        /// <summary>
        /// 優惠券
        /// </summary>
        public string Coupon { get; set; }

        /// <summary>
        /// 付款方式
        /// </summary>
        public string PaymentType { get; set; }

        /// <summary>
        /// 統一編號
        /// </summary>
        public string TaxIdNumber { get; set; }

        /// <summary>
        /// 交易時間
        /// </summary>
        public string OrderDatetime { get; set; }

        /// <summary>
        ///  預約時間
        /// </summary>
        public DateTime BookingDate { get; set; }

        /// <summary>
        /// 預約時段
        /// </summary>
        public DateTime BookingTime { get; set; }

        /// <summary>
        /// 訂單狀態
        /// </summary>
        public string OrderStatus { get; set; }
    }

    public class OrderManagementListViewModel
    {
        public List<OrderManagementViewModel> OrderManagementList { get; set; }
    }

    public class ShoppingCartInfoViewModel
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
        public DateTime BookingTime { get; set; }
    }

    public class ShoppingCartInfoListViewModel
    {
        public List<ShoppingCartInfoViewModel> ShoppingCartInfoList { get; set; }
    }
}
