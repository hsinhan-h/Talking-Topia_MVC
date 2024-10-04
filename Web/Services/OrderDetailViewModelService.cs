using ApplicationCore.Interfaces;
using ApplicationCore.Enums;

namespace Web.Services
{
    public class OrderDetailViewModelService
    {
        private readonly ILogger<OrderDetailViewModelService> _logger;
        private readonly IRepository<ApplicationCore.Entities.Order> _orderRepository;
        private readonly IRepository<ApplicationCore.Entities.Member> _memberRepository;
        private readonly IRepository<ApplicationCore.Entities.Course> _courseRepository;
        private readonly IRepository<ApplicationCore.Entities.OrderDetail> _orderDetailRepository;
        private readonly IRepository<ApplicationCore.Entities.CourseSubject> _courseSubjectRepository;

        public OrderDetailViewModelService(IRepository<ApplicationCore.Entities.Order> orderRepository,
                                           IRepository<ApplicationCore.Entities.Member> memberRepository,
                                           IRepository<ApplicationCore.Entities.Course> courseRepository,
                                           IRepository<ApplicationCore.Entities.OrderDetail> orderDetailRepository,
                                           IRepository<ApplicationCore.Entities.CourseSubject> courseSubjectRepository,
                                           ILogger<OrderDetailViewModelService> logger)
        {
            _orderRepository = orderRepository;
            _memberRepository = memberRepository;
            _courseRepository = courseRepository;
            _orderDetailRepository = orderDetailRepository;
            _courseSubjectRepository = courseSubjectRepository;
            _logger = logger;
        }

        public async Task<MemberOrderViewModel> GetOrderData(int memberId)
        {
            // 唯一的會員
            var member = await _memberRepository.GetByIdAsync(memberId);

            // 這位會員的所有訂單資料
            var theOrders = await _orderRepository.ListAsync(o => o.MemberId == memberId);

            if (theOrders.Count < 1) { return null; }

            var orders = theOrders.OrderByDescending(o => o.TransactionDate);

            // 三種回傳結果
            var memberOrderList = new List<MemberOrderVM>();
            var pendingOrders = new List<MemberOrderVM>();
            var failedOrders = new List<MemberOrderVM>();

            // 從所有訂單資料撈訂單明細及與其關聯的其他資料表內容
            foreach (var order in orders)
            {
                // 訂單資料內所有訂單明細(因為一筆訂單裡有一到多筆不等的課程產品)
                var orderDetails = await _orderDetailRepository.ListAsync(od => od.OrderId == order.OrderId);
                foreach (var orderDetail in orderDetails)
                {
                    // 從訂單明細中找出對應關聯的資料內容
                    var course = await _courseRepository.GetByIdAsync(orderDetail.CourseId);
                    var tutor = await _memberRepository.GetByIdAsync(course.TutorId);
                    var subject = await _courseSubjectRepository.GetByIdAsync(course.SubjectId);

                    int discountPrice = 0;
                    int totalPrice = 0;

                    if (orderDetail.DiscountPrice.HasValue && orderDetail.DiscountPrice != 0) { discountPrice = (int)orderDetail.DiscountPrice; }
                    if (orderDetail.TotalPrice != 0)
                    {
                        totalPrice = (int)orderDetail.TotalPrice;
                    }

                    var orderDetailResult = new MemberOrderVM
                    {
                        CourseId = course.CourseId,
                        TrackingNumber = order.MerchantTradeNo ?? "",
                        OrderDatetime = order.TransactionDate.ToString("yyyy-MM-dd hh:mm"),
                        FullName = tutor.FirstName + " " + tutor.LastName,
                        CourseTitle = course.Title,
                        DiscountPrice = discountPrice,
                        SubTotal = totalPrice,
                        TaxIdNumber = order.TaxIdNumber ?? "",
                        CourseSubject = subject.SubjectName,
                        CourseLength = orderDetail.CourseType == 1 ? 25 : 50,
                        UnitPrice = (int)orderDetail.UnitPrice,
                        CourseQuantity = orderDetail.Quantity,
                        OrderStatusId = order.OrderStatusId,
                    }; ;

                    // 判斷交易狀態
                    if (orderDetailResult.OrderStatusId == (int)EOrderStatus.Success) { memberOrderList.Add(orderDetailResult); }
                    if (orderDetailResult.OrderStatusId == (int)EOrderStatus.Outstanding) { pendingOrders.Add(orderDetailResult); }
                    if (orderDetailResult.OrderStatusId == (int)EOrderStatus.Failed) { failedOrders.Add(orderDetailResult); }
                }
            }

            var result = new MemberOrderViewModel
            {
                MemberOrderList = memberOrderList,
                PendingOrders = pendingOrders,
                FailedOrders = failedOrders
            };

            return result;
        }
    }
}
