using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels
{
    public class BookingListViewModel
    {
        public List<BookingViewModel> BookingList { get; set; }
    }
    public class BookingViewModel
    {
        public int BookingId { get; set; }
        public int CourseId { get; set; }
        [DisplayName("課程名稱")]
        public string Title { get; set; }
        [DisplayName("課程內容")]
        public string SubTitle { get; set; }
        [DisplayName("上課時間")]
        public DateTime BookingDate { get; set; }
        public int BookingTime { get; set; }
        public int MemberId { get; set; }
        [DisplayName("學員名稱")]
        public string MemberName { get; set; }
        [DisplayName("金額(台幣)")]
        public decimal TotalPriceNTD { get; set; }
    }
}
