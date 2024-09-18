using ApplicationCore.Entities;
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
       
        public decimal GetUnitPrice(int courseId, int courseLength)
        {
            var price = _repository.GetAll<Entities.Course>()
                       .Where(x => x.CourseId == courseId)
                       .Select(x => courseLength == 25 ? x.TwentyFiveMinUnitPrice : x.FiftyMinUnitPrice)
                       .FirstOrDefault();

            return price;
        }
        //Logic 

        public async Task<AppointmentDetailsViewModel> GetAppointmentData(int memberId)
        {

            var orders = from Order in _repository.GetAll<Entities.Order>()
                         where Order.MemberId == memberId
                         join OrderDetail in _repository.GetAll<OrderDetail>() on Order.OrderId equals OrderDetail.OrderId
                         join member in _repository.GetAll<Member>() on Order.MemberId equals member.MemberId                  
                         join course in _repository.GetAll<Course>() on OrderDetail.CourseId equals course.CourseId
                         join booking in _repository.GetAll<Booking>() on OrderDetail.CourseId equals booking.CourseId

                         select new AppointmentDetailVM
                         {
                             MemberId = Order.MemberId,          // 會員ID
                             CourseId = OrderDetail.CourseId,   // 課程ID
                             TrackingNumber = "",              // 訂單編號
                             FullName = member.FirstName + " " + member.LastName, // 教師名稱
                             CourseTitle = OrderDetail.CourseTitle,        // 課程名稱
                             CourseLength = OrderDetail.CourseType == 1 ? "25分鐘" : "50分鐘",   // 購買時長
                             Quantity = OrderDetail.Quantity,  // 購買堂數
                             TotalPrice = OrderDetail.TotalPrice, // 總價
                             TaxIdNumber = Order.TaxIdNumber,  // 統一編號
                             OrderDatetime = Order.TransactionDate.ToString("yyyy-MM-dd"), // 格式化交易時間
                             Subtitle = course.SubTitle,//課程副標題
                             BookingDate= booking.BookingDate,//預約上課日期
                         };

            // 返回包含訂單資訊的 ViewModel
            return new AppointmentDetailsViewModel()
            {
                AppointmentDetailsList = await orders.ToListAsync(), // 使用非同步處理
            };
        }
    }
}
