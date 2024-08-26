using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels
{
    public class OrderManagementViewModel
    {
        [Display(Name = "課程ID")]
        public int CourseId { get; set; } 

        [Display(Name = "訂單編號")]
        public string TrackingNumber { get; set; }

        [Display(Name = "教師頭像")]
        public string HeadShotImage { get; set; }

        [Display(Name = "教師名字")]
        public string FullName { get; set; }

        [Display(Name = "課程名稱")]
        public string CourseTitle { get; set; }

        [Display(Name = "課程科目")]
        public string CourseSubject { get; set; }

        [Display(Name = "課程類別")]
        public string CourseCategory { get; set; }

        [Display(Name = "分鐘數")]
        public string CourseLength { get; set; }

        [Display(Name = "堂數")]
        public int CourseQuantity { get; set; }

        [Display(Name = "單價")]
        public decimal UnitPrice { get; set; }

        [Display(Name = "小計")]
        public decimal SubtotalNTD { get; set; }

        [Display(Name = "優惠券")]
        public string Coupon { get; set; }

        [Display(Name = "付款方式")]
        public string PaymentType { get; set; }

        [Display(Name = "統一編號")]
        public string TaxIdNumber { get; set; }

        [Display(Name = "交易時間")]
        public string OrderDatetime { get; set; }

        [Display(Name = "預約日期")]
        public DateTime BookingDate { get; set; }

        [Display(Name = "預約時段")]
        public DateTime BookingTime { get; set; }

        [Display(Name = "訂單狀態")]
        public string OrderStatus { get; set; }
    }

    public class OrderManagementListViewModel
    {
        public List<OrderManagementViewModel> OrderManagementList { get; set; }
    }

    public class ShoppingCartCheckViewModel
    {
        [Display(Name = "課程ID")]
        public int CourseId { get; set; }
        [Display(Name = "訂單編號")]
        public string TrackingNumber { get; set; }

        [Display(Name = "教師頭像")]
        public string HeadShotImage { get; set; }

        [Display(Name = "教師名字")]
        public string FullName { get; set; }

        [Display(Name = "課程名稱")]
        public string CourseTitle { get; set; }

        [Display(Name = "課程科目")]
        public string CourseSubject { get; set; }

        [Display(Name = "課程類別")]
        public string CourseCategory { get; set; }

        [Display(Name = "分鐘數")]
        public string CourseLength { get; set; }

        [Display(Name = "堂數")]
        public int CourseQuantity { get; set; }

        [Display(Name = "小計")]
        public decimal SubtotalNTD { get; set; }

        [Display(Name = "優惠券")]
        public string Coupon { get; set; }

        [Display(Name = "付款方式")]
        public string PaymentType { get; set; }
    }

    public class ShoppingCartCheckListViewModel
    {
        public List<ShoppingCartCheckViewModel> ShoppingCartCheckList { get; set; }
    }

    public class ShoppingCartInfoViewModel
    {
        [Display(Name = "課程ID")]
        public int CourseId { get; set; }
        [Display(Name = "訂單編號")]
        public string TrackingNumber { get; set; }

        [Display(Name = "教師名字")]
        public string FullName { get; set; }

        [Display(Name = "課程名稱")]
        public string CourseTitle { get; set; }

        [Display(Name = "堂數")]
        public int CourseQuantity { get; set; }

        [Display(Name = "小計")]
        public decimal SubtotalNTD { get; set; }

        [Display(Name = "統一編號")]
        public string TaxIdNumber { get; set; }

        [Display(Name = "交易時間")]
        public string OrderDatetime { get; set; }

        [Display(Name = "預約日期")]
        public DateTime BookingDate { get; set; }

        [Display(Name = "預約時段")]
        public DateTime BookingTime { get; set; }
    }

    public class ShoppingCartInfoListViewModel
    {
        public List<ShoppingCartInfoViewModel> ShoppingCartInfoList { get; set; }
    }
}
