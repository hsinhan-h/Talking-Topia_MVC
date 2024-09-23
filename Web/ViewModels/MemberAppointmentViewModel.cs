namespace Web.ViewModels
{
    public class MemberAppointmentViewModel
    {
        public List<MemberAppointmentVM> MemberAppointmentList { get; set; }
    }
    public class MemberAppointmentVM
    {
        /// <summary>
        /// 會員Id
        /// </summary>
        public int MemberId { get; set; }
        /// <summary>
        /// 課程ID 
        /// </summary>
        public int CourseId { get; set; }

        /// <summary>
        /// BookingID
        /// </summary>
        public int BookingId { get; set; }

        /// <summary>
        /// 訂單編號
        /// </summary>
        public string TrackingNumber { get; set; }

        /// <summary>
        /// 交易時間
        /// </summary>
        public string OrderDatetime { get; set; }
        /// <summary>
        /// 教師名字
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// 課程名稱
        /// </summary>
        public string CourseTitle { get; set; }


        /// <summary>
        /// 課程單價
        /// </summary>
        public decimal UnitPrice { get; set; }
        /// <summary>
        /// 購買時長  應該要改寫? 25or50
        /// </summary>
        public string CourseLength { get; set; }


        /// <summary>
        /// 購買堂數
        /// </summary>
        public short Quantity { get; set; }

        /// <summary>
        /// 折扣金額
        /// </summary>
        public decimal? DiscountPrice { get; set; }

        /// <summary>
        /// 總價
        /// </summary>
        public decimal TotalPrice { get; set; }
        /// <summary>
        /// 統一編號
        /// </summary>
        public string TaxIdNumber { get; set; }
        /// <summary>
        /// 交易時間
        /// </summary>
        public DateTime TransactionDate { get; set; }
        /// <summary>
        /// 課程副標題
        /// </summary>
        public string Subtitle { get; set; }
        /// <summary>
        /// 預約上課日期
        /// </summary>
        public DateTime BookingDate { get; set; }

        /// <summary>
        /// 預約上課時間
        /// </summary>
        public int BookingTime { get; set; }
    }
}
