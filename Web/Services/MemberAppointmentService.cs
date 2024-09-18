namespace Web.Services
{
    public class MemberAppointmentService
    {
        private readonly IRepository _repository;

        public MemberAppointmentService(IRepository repository)
        {
            _repository = repository;
        }

        public decimal GetUnitPrice(int courseId, int courseLength)
        {
            var price = _repository.GetAll<Course>()
                       .Where(x => x.CourseId == courseId)
                       .Select(x => courseLength == 25 ? x.TwentyFiveMinUnitPrice : x.FiftyMinUnitPrice)
                       .FirstOrDefault();

            return price;
        }
        //Logic 

        public async Task<MemberAppointmentViewModel> GetAppointmentData(int memberId)
        {

            var orders = from Order in _repository.GetAll<Order>()
                         where Order.MemberId == memberId
                         join OrderDetail in _repository.GetAll<OrderDetail>() on Order.OrderId equals OrderDetail.OrderId
                         join member in _repository.GetAll<Member>() on Order.MemberId equals member.MemberId
                         join course in _repository.GetAll<Course>() on OrderDetail.CourseId equals course.CourseId
                         join booking in _repository.GetAll<Booking>() on OrderDetail.CourseId equals booking.CourseId

                         select new MemberAppointmentVM
                         {
                             MemberId = Order.MemberId,          // 會員ID
                             CourseId = OrderDetail.CourseId,   // 課程ID
                             TrackingNumber = "",              // 訂單編號
                             FullName = member.FirstName + " " + member.LastName, // 教師名稱
                             CourseTitle = OrderDetail.CourseTitle,        // 課程名稱
                             Subtitle = course.SubTitle,//課程副標題
                             CourseLength = OrderDetail.CourseType == 1 ? "25分鐘" : "50分鐘",// 購買時長
                             Quantity = OrderDetail.Quantity,  // 購買堂數
                             TotalPrice = OrderDetail.TotalPrice, // 總價
                             TaxIdNumber = Order.TaxIdNumber,  // 統一編號
                             OrderDatetime = Order.TransactionDate.ToString("yyyy-MM-dd"), // 格式化交易時間
                             BookingDate = booking.BookingDate,//預約上課日期

                         };

            // 返回包含訂單資訊的 ViewModel
            return new MemberAppointmentViewModel()
            {
                MemberAppointmentList = await orders.ToListAsync(), // 使用非同步處理
            };
        }
    }
}
