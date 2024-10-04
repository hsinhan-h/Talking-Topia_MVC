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

        public async Task<List<OrderDto>> GetAllOrders()
        {
            // 整張表撈出來
            var orders = (await _orderRepository.ListAsync());

            var result = new List<OrderDto>();

            foreach (var order in orders)
            {
                var member = await _memberRepository.GetByIdAsync(order.MemberId);
                var orderDetails = await _orderDetailRepository.ListAsync(od => od.OrderId == order.OrderId);
                foreach (var od in orderDetails)
                { 
                    var course = await _courseRepository.GetByIdAsync(od.CourseId);

                    var discount = od.DiscountPrice ?? 0;


                    var oResult = new OrderDto
                    {
                        MerchantTradeNo = order.MerchantTradeNo,
                        TransactionDate = order.TransactionDate.ToString("yyyy-MM-dd hh:mm:ss"),
                        FullName = member.FirstName + " " + member.LastName,
                        Email = member.Email,
                        OrderStatusId = order.OrderStatusId,
                        PaymentType = order.PaymentType,
                        CourseTitle = course.Title,
                        CourseType = od.CourseType == 1 ? 25 : 50,
                        Quantity = od.Quantity,
                        UnitPrice = (int)od.UnitPrice,
                        DiscountPrice = (int)discount,
                        SubTotal = (int)od.TotalPrice,
                        TotalPrice = (int)order.TotalPrice,
                    };
                    result.Add(oResult);
                }
            }
            return result;
        }

        public async Task<int> UpdateOrder(UpdateOrderDto request)
        {
            var entity = await _orderRepository.GetByIdAsync(request.OrderId);
            entity.MemberId = request.MemberId;
            entity.OrderStatusId = request.OrderStatusId;
            var result = await _orderRepository.UpdateAsync(entity);

            if (result != null) return 1;
            else return 0;
        }
    }
}
