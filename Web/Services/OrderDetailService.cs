using ApplicationCore.Entities;
using Web.Entities;
using Web.ViewModels;

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
        public decimal GetUnitPrice(int courseId, int courseLength)
        {
            var price = _repository.GetAll<Entities.Course>()
                       .Where(x => x.CourseId == courseId)
                       .Select(x => courseLength == 25 ? x.TwentyFiveMinUnitPrice : x.FiftyMinUnitPrice)
                       .FirstOrDefault();

            return price;
        }
        //Logic 

        public async Task<MemberOrderViewModel> GetOrderData(int memberId)
        {
          
            var orders = from Order in _repository.GetAll<Entities.Order>()
                         where Order.MemberId == memberId 
                         join OrderDetail in _repository.GetAll<Entities.OrderDetail>() on Order.OrderId equals OrderDetail.OrderId
                         join member in _repository.GetAll<Entities.Member>() on Order.MemberId equals member.MemberId
                         
                         select new MemberOrderVM
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
            return new MemberOrderViewModel()
            {
                MemberOderList = await orders.ToListAsync(), // 使用非同步處理
            };
        }
    }

 }
