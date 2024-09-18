using ApplicationCore.Entities;

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
                         join OrderDetail in _repository.GetAll<Entities.OrderDetail>() on Order.OrderId equals OrderDetail.OrderId
                         join member in _repository.GetAll<Entities.Member>() on Order.MemberId equals member.MemberId

                         select new AppointmentDetailVM
                         {
                             MemberId = Order.MemberId,          // 會員ID
                             CourseId = OrderDetail.CourseId,   // 課程ID
                             TrackingNumber = "",              // 訂單編號
                             FullName = member.FirstName + " " + member.LastName, // 教師名稱
                             CourseTitle = OrderDetail.CourseTitle,        // 課程名稱
                             CourseLength = "",                 // 購買時長
                             Quantity = OrderDetail.Quantity,  // 購買堂數
                             TotalPrice = OrderDetail.TotalPrice, // 總價
                             TaxIdNumber = Order.TaxIdNumber,  // 統一編號
                             OrderDatetime = Order.TransactionDate.ToString("yyyy-MM-dd HH:mm:ss") // 格式化交易時間

                         };

            // 返回包含訂單資訊的 ViewModel
            return new AppointmentDetailsViewModel()
            {
                AppointmentDetailsList = await orders.ToListAsync(), // 使用非同步處理
            };
        }
    }
}
