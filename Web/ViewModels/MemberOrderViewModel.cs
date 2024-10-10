using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels
{
    public class MemberOrderViewModel

    {
        public List<MemberOrderVM> MemberOrderList { get; set; }// 已付款訂單
        public List<MemberOrderVM> PendingOrders { get; set; }// 待付款訂單
        public List<MemberOrderVM> FailedOrders { get; set; }// 失敗訂單
    }

    public class MemberOrderVM
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
        /// 交易時間
        /// </summary>
        public string OrderDatetime { get; set; }
        /// <summary>
        /// 教師名稱
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// 課程名稱
        /// </summary>
        public string CourseTitle { get; set; }
        /// <summary>
        /// 折扣金額
        /// </summary>
        public int DiscountPrice { get; set; }
        /// <summary>
        /// 小計金額
        /// </summary>
        public int SubTotal { get; set; }
        /// <summary>
        /// 統一編號
        /// </summary>
        public string TaxIdNumber { get; set; }
        /// <summary>
        /// 課程科目
        /// </summary>
        public string CourseSubject { get; set; }
        /// <summary>
        /// 購買時長
        /// </summary>
        public int CourseLength { get; set; }
        /// <summary>
        /// 課程單價
        /// </summary>
        public int UnitPrice { get; set; }
        /// <summary>
        /// 購買堂數
        /// </summary>
        public int CourseQuantity { get; set; }
        /// <summary>
        /// 訂單狀態
        /// </summary>
        public short OrderStatusId { get; set; }
    }
}
