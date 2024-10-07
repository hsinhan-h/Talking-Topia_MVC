using Api.Dtos;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;

namespace Api.Services
{
    public class OrderApiService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Member> _memberRepository;
        private readonly IRepository<Course> _courseRepository;
        private readonly IRepository<OrderDetail> _orderDetailRepository;

        public OrderApiService(IRepository<Order> orderRepository,
                               IRepository<Member> memberRepository,
                               IRepository<Course> courseRepository,
                               IRepository<OrderDetail> orderDetailRepository)
        {
            _orderRepository = orderRepository;
            _memberRepository = memberRepository;
            _courseRepository = courseRepository;
            _orderDetailRepository = orderDetailRepository;
        }

        //public async Task<List<OrderDto>> GetAllOrders()
        //{
        //    // 整張表撈出來
        //    var orders = (await _orderRepository.ListAsync());

        //    var orderCount = CalculateOrders(orders);

        //    var result = new List<OrderDto>();

        //    foreach (var order in orders)
        //    {
        //        var member = await _memberRepository.GetByIdAsync(order.MemberId);
        //        var orderDetails = await _orderDetailRepository.ListAsync(od => od.OrderId == order.OrderId);
        //        foreach (var od in orderDetails)
        //        {
        //            var course = await _courseRepository.GetByIdAsync(od.CourseId);

        //            var discount = od.DiscountPrice ?? 0;

        //            var oResult = new OrderDto
        //            {
        //                OrderID = order.OrderId,
        //                MerchantTradeNo = order.MerchantTradeNo,
        //                TransactionDate = order.TransactionDate.ToString("yyyy-MM-dd hh:mm:ss"),
        //                FullName = member.FirstName + " " + member.LastName,
        //                Email = member.Email,
        //                OrderStatusId = order.OrderStatusId == 1 ? "已成功" : "待付款",
        //                PaymentType = order.PaymentType,
        //                CourseTitle = course.Title,
        //                CourseType = od.CourseType == 1 ? 25 : 50,
        //                Quantity = od.Quantity,
        //                UnitPrice = (int)od.UnitPrice,
        //                SubTotal = (int)od.TotalPrice,
        //                TotalPrice = (int)order.TotalPrice,
        //                MonthCount = orderCount["Month"],
        //                YearCount = orderCount["Year"]
        //            };
        //            result.Add(oResult);
        //        }
        //    }
        //    return result;
        //}

        public async Task<List<OrderDto>> GetAllOrders()
        {
            // 整張表一次撈出來
            var orders = await _orderRepository.ListAsync();
            var orderIds = orders.Select(o => o.OrderId).ToList();
            var memberIds = orders.Select(o => o.MemberId).Distinct().ToList();

            // 一次查詢出所有相關的資料
            var members = await _memberRepository.ListAsync(m => memberIds.Contains(m.MemberId));
            var orderDetails = await _orderDetailRepository.ListAsync(od => orderIds.Contains(od.OrderId));
            var courseIds = orderDetails.Select(od => od.CourseId).Distinct().ToList();
            var courses = await _courseRepository.ListAsync(c => courseIds.Contains(c.CourseId));

            // 快速查詢資料用的 Dictionary
            var memberDictionary = members.ToDictionary(m => m.MemberId);
            var courseDictionary = courses.ToDictionary(c => c.CourseId);
            var orderDetailDictionary = orderDetails.GroupBy(od => od.OrderId).ToDictionary(g => g.Key, g => g.ToList());

            var orderCount = CalculateOrders(orders);

            var result = new List<OrderDto>();

            foreach (var order in orders)
            {
                if (memberDictionary.TryGetValue(order.MemberId, out var member) &&
                    orderDetailDictionary.TryGetValue(order.OrderId, out var details))
                {
                    foreach (var od in details)
                    {
                        if (courseDictionary.TryGetValue(od.CourseId, out var course))
                        {
                            var discount = od.DiscountPrice ?? 0;
                            var oResult = new OrderDto
                            {
                                OrderID = order.OrderId,
                                MerchantTradeNo = order.MerchantTradeNo,
                                TransactionDate = order.TransactionDate.ToString("yyyy-MM-dd hh:mm:ss"),
                                FullName = member.FirstName + " " + member.LastName,
                                Email = member.Email,
                                OrderStatusId = order.OrderStatusId == 1 ? "已成功" : "待付款",
                                PaymentType = order.PaymentType,
                                CourseTitle = course.Title,
                                CourseType = od.CourseType == 1 ? 25 : 50,
                                Quantity = od.Quantity,
                                UnitPrice = (int)od.UnitPrice,
                                SubTotal = (int)od.TotalPrice,
                                TotalPrice = (int)order.TotalPrice,
                                MonthCount = orderCount["Month"],
                                YearCount = orderCount["Year"]
                            };
                            result.Add(oResult);
                        }
                    }
                }
            }
            return result;
        }



        public async Task<int> UpdateOrder(UpdateOrderDto request)
        {
            if (request == null || request.OrderId <= 0 || string.IsNullOrWhiteSpace(request.OrderStatusId))
            {
                throw new ArgumentException("Invalid order update request.");
            }

            var entity = await _orderRepository.GetByIdAsync(request.OrderId);
            var orderStatusId = request.OrderStatusId.Trim() == "1" ? 1 : 0;
            entity.OrderStatusId = (short)orderStatusId;
            var result = await _orderRepository.UpdateAsync(entity);

            if (result != null) return 1;
            else return 0;
        }

        public Dictionary<string,int> CalculateOrders(List<Order> orders)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();

            var currentYear = DateTime.Now.Year;
            var currentMonth = DateTime.Now.Month;

            int monthCount =  orders.Count(order => order.TransactionDate.Year == currentYear && order.TransactionDate.Month == currentMonth);
            int yearCount = orders.Count(order => order.TransactionDate.Year == currentYear);

            result.Add("Month", monthCount);
            result.Add("Year", yearCount);

            return result;
        }
    }
}
