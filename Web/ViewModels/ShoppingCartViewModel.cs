using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels
{
    public class ShoppingCartViewModel
    {
        /// <summary>
        /// 課程ID from CoursePage
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
    }
    public class ShoppingCartListViewModel
    {
        public List<ShoppingCartViewModel> ShoppingCartCheckList { get; set; }
    }

}
