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
            return _repository.GetAll<Member>().Any(x => x.MemberId == memberId);
        }
        public bool HasOrderData(int memberId)
        {
            return _repository.GetAll<Order>().Any(x =>x.MemberId == memberId);
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

        public async Task<MemberOrderViewModel> GetOrderData(int memberId)
        {
          
            var orders = from Order in _repository.GetAll<Order>()
                         where Order.MemberId == memberId 
                         join OrderDetail in _repository.GetAll<OrderDetail>() on Order.OrderId equals OrderDetail.OrderId
                         join member in _repository.GetAll<Member>() on Order.MemberId equals member.MemberId
                         
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
        //public async Task<MemberOrderViewModel> GetOrderData(int memberId, int orderId)
        //{

            //todo: 確認是否為有效member及course (感覺要統一寫在member跟course的service)
            //if (!HasMemberData(memberId))
            //{ throw new Exception("會員不存在，請重新操作"); }
            //if (!HasOrderData(orderId))
            //{ throw new Exception("訂單不存在，請重新操作"); }
            //    //todo: 確認是否已有會員ID/訂單
            //    if (!HasOrderData(memberId)) //沒有就新增
            //{
                //從前端傳入的value抓db.Course的單價
                //var unitPrice = GetUnitPrice(courseId, courseLength);

                //join然後將抓到的值塞進VM
            //    var orders = from Order in _repository.GetAll<Order>( )
            //                 join OrderDetail in _repository.GetAll<OrderDetail>() on Order.OrderId equals OrderDetail.OrderId
            //                 join member in _repository.GetAll<Member>() on Order.MemberId equals member.MemberId
            //                 join course in _repository.GetAll<Course>() on OrderDetail.CourseId equals course.CourseId
            //                 select new MemberOrderVM
            //                 {
            //                            MemberId = Order.MemberId, //會員ID
            //                            CourseId = OrderDetail.CourseId, //課程ID
            //                            TrackingNumber = "", //訂單編號
            //                            FullName = member.FirstName + " " + member.LastName,//教師名稱
            //                            CourseTitle = course.Title, //課程名稱
            //                            CourseLength = "", //購買時長
            //                           //  CourseQuantity = quantity,  //購買堂數
            //                           TotalPrice = OrderDetail.TotalPrice, //總價
            //                           TaxIdNumber = Order.TaxIdNumber,  //統一編號
            //                  }; 
            //    return new MemberOrderViewModel()
            //    {
            //        MemberOderList = orders.ToList(),
            //    };

            //}
            //else
            //{
            //    //有就更新同筆課程的明細
            //    return null;
            //}
        }

        //public async Task<OrderManagementListViewModel> GetOrderList()
        //{
        //    List<OrderManagementViewModel> order = new List<OrderManagementViewModel>
        //{
        //        new OrderManagementViewModel
        //    {

        //    },
               

        //};
        //    return new OrderManagementListViewModel()
        //    {
        //        OrderManagementList = order,
        //    };

        //}


    }
