using ApplicationCore.Entities;
using Web.Entities;
using Web.ViewModels;
using Course = Web.Entities.Course;
using Order = Web.Entities.Order;

namespace Web.Services
{
    public class OrderDetailService
    {
        private readonly IRepository _repository;

        public OrderDetailService(IRepository repository)
        {
            _repository = repository;
        }
        public bool HasMemberData(int memberId)
        {
            return _repository.GetAll<Entities.Member>().Any(x => x.MemberId == memberId);
        }
        public bool HasOrderData(int memberId)
        {
            return _repository.GetAll<Entities.Order>().Any(x =>x.MemberId == memberId);
        }
        //Logic 

        public async Task<MemberOrderViewModel> GetOrderData(int memberId)
        {
          
            var orders = from booking in _repository.GetAll<Entities.Booking>()
                         where booking.StudentId == memberId
                         join course in _repository.GetAll<Course>() on booking.CourseId equals course.CourseId
                         join tutor in _repository.GetAll<Entities.Member>() on course.TutorId equals tutor.MemberId
                         join order in _repository.GetAll<Order>() on memberId equals order.MemberId
                         join orderDetail in _repository.GetAll<Entities.OrderDetail>() on order.OrderId equals orderDetail.OrderId
                         group new { booking, course, tutor, order, orderDetail } by booking.BookingId into gp
                         select new MemberOrderVM
                         {
                             MemberId = memberId,       // 會員ID
                             CourseId = gp.FirstOrDefault().booking.CourseId,   // 課程ID
                             TrackingNumber = "",              // 訂單編號
                             FullName = gp.FirstOrDefault().tutor.FirstName + " " + gp.FirstOrDefault().tutor.LastName, // 教師名稱
                             CourseTitle = gp.FirstOrDefault().course.Title,         // 課程名稱
                             CourseLength = gp.FirstOrDefault().orderDetail.CourseType == 1 ? "25分鐘" : "50分鐘",// 購買時長
                             Quantity = gp.FirstOrDefault().orderDetail.Quantity,  // 購買堂數
                             TotalPrice = gp.FirstOrDefault().orderDetail.TotalPrice, // 總價
                             TaxIdNumber = gp.FirstOrDefault().order.TaxIdNumber,  // 統一編號
                             OrderDatetime = gp.FirstOrDefault().order.TransactionDate.ToString("yyyy-MM-dd"), // 格式化交易時間
                         };

            // 返回包含訂單資訊的 ViewModel
            return new MemberOrderViewModel()
            {
                MemberOrderList = await orders.ToListAsync(), // 使用非同步處理
            };
        }
    }

 }
