using ApplicationCore.Entities;
using Web.Entities;
using Web.Repository;
using Web.ViewModels;
using Booking = Web.Entities.Booking;
using Course = Web.Entities.Course;
using Member = Web.Entities.Member;
using OrderDetail = Web.Entities.OrderDetail;

namespace Web.Services
{
    public class AppointmentDetailService
    {
        private readonly IRepository _repository;

        public AppointmentDetailService(IRepository repository)
        {
            _repository = repository;
        }

        //Logic 

        public async Task<AppointmentDetailsViewModel> GetAppointmentData(int memberId)
        {

            var orders = from booking in _repository.GetAll<Booking>()
                         where booking.StudentId == memberId
                         join course in _repository.GetAll<Course>() on booking.CourseId equals course.CourseId
                         join tutor in _repository.GetAll<Member>() on course.TutorId equals tutor.MemberId
                         join order in _repository.GetAll<Entities.Order>() on memberId equals order.MemberId
                         join orderDetail in _repository.GetAll<OrderDetail>() on order.OrderId equals orderDetail.OrderId
                         //group new { booking, course, tutor, order, orderDetail } by booking.BookingId into gp

                         select new AppointmentDetailVM
                         {
                             MemberId = memberId,          // 會員ID
                             CourseId = booking.CourseId,   // 課程ID
                             //TrackingNumber = "",              // 訂單編號
                             FullName = tutor.FirstName + " " +tutor.LastName, // 教師名稱
                             CourseTitle = course.Title,        // 課程名稱
                             Subtitle = course.SubTitle,//課程副標題
                             CourseLength = orderDetail.CourseType == 1 ? "25分鐘" : "50分鐘",// 購買時長
                             Quantity = orderDetail.Quantity,  // 購買堂數
                             TotalPrice = orderDetail.TotalPrice, // 總價
                             TaxIdNumber = order.TaxIdNumber,  // 統一編號
                             OrderDatetime = order.TransactionDate.ToString("yyyy-MM-dd"), // 格式化交易時間
                             BookingDate = booking.BookingDate,//預約上課日期
                             BookingTime = booking.BookingTime
                         };
            var AppointmentDetails = orders.OrderByDescending(o => o.BookingDate);

            // 返回包含訂單資訊的 ViewModel
            return new AppointmentDetailsViewModel()
            {
                AppointmentDetailsList = await AppointmentDetails.ToListAsync(), // 使用非同步處理
            };
        }
    }
}
