using ApplicationCore.Dtos;
using ApplicationCore.Entities;
using ApplicationCore.Enums;
using ApplicationCore.Interfaces;
using System.Runtime.CompilerServices;


namespace ApplicationCore.Services
{
    public class OrderService : IOrderService
    {

        private readonly ITransaction _transaction;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Member> _memberRepository;
        private readonly IRepository<OrderDetail> _orderDetailRepository;
        private readonly IRepository<ShoppingCart> _shoppingCartRepository;
        private readonly IRepository<Course> _courseRepository;
        private readonly IRepository<Booking> _bookingRepository;
        private readonly IRepository<CourseSubject> _courseSubjectRepository;
        private readonly IRepository<CourseCategory> _courseCategoryRepository;
        private int _orderId;
        private List<ShoppingCart> _shoppingCartItem;

        public OrderService(ITransaction transaction, IRepository<Order> orderRepository, IRepository<Member> memberRepository, IRepository<OrderDetail> orderDetailRepository, IRepository<ShoppingCart> shoppingCartRepository, IRepository<Course> courseRepository, IRepository<Booking> bookingRepository, IRepository<CourseSubject> courseSubjectRepository, IRepository<CourseCategory> courseCategoryRepository)
        {
            _transaction = transaction;
            _orderRepository = orderRepository;
            _memberRepository = memberRepository;
            _orderDetailRepository = orderDetailRepository;
            _shoppingCartRepository = shoppingCartRepository;
            _courseRepository = courseRepository;
            _bookingRepository = bookingRepository;
            _courseSubjectRepository = courseSubjectRepository;
            _courseCategoryRepository = courseCategoryRepository;
        }

        public async Task<GetAllOrderResultDto> GetAllOrder(int memberId)
        {
            var orders = await _orderRepository.ListAsync(item => item.MemberId == memberId);
            var getOrderItem = new List<GetOrderItem>();
            foreach (var order in orders)
            {
                getOrderItem.Add
                (new GetOrderItem
                {
                    OrderId = order.OrderId,
                    MemberId = order.MemberId,
                    PaymentType = order.PaymentType,
                    TotalPrice = order.TotalPrice,
                    TransactionDate = order.TransactionDate,
                    CouponPrice = order.CouponPrice,
                    TaxIdNumber = order.TaxIdNumber,
                    InvoiceType = order.InvoiceType,
                    VATNumber = order.VATNumber,
                    SentVatemail = order.SentVatemail,
                    OrderStatusId = order.OrderStatusId,
                }
                );
            }
            var result = new GetAllOrderResultDto
            {
                GetOrderItems = getOrderItem,
            };
            return result;
        }

        /// <summary>
        /// 建單並串至綠界(callback後會再呼叫Update刷新OrderStatusId)
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="paymentType"></param>
        /// <param name="taxIdNumber"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<int> CreateOrderAsync(int memberId, string paymentType, string taxIdNumber)
        {

            try
            {
                // 把購物車品項全撈出來，並計算總額
                _shoppingCartItem = await _shoppingCartRepository.ListAsync(m => m.MemberId == memberId);
                var totalPrice = _shoppingCartItem.Sum(item => item.Quantity * item.UnitPrice);
                var member = await _memberRepository.GetByIdAsync(memberId);

                // 成功或失敗都應先寫入資料庫，由訂單狀態去判定成功與否就好
                var orders = new Order()
                {
                    MemberId = memberId,
                    PaymentType = paymentType,
                    TotalPrice = totalPrice,
                    TransactionDate = DateTime.Now,
                    CouponPrice = 0,
                    TaxIdNumber = taxIdNumber,
                    InvoiceType = taxIdNumber == null ? (short)EInvoiceType.NormalInvoice : (short)EInvoiceType.GUIInvoice,
                    VATNumber = "",
                    SentVatemail = member.Email,
                    OrderStatusId = (short)EOrderStatus.Outstanding,
                    Cdate = DateTime.Now,
                };

                var orderResult = await _orderRepository.AddAsync(orders);

                foreach (var item in _shoppingCartItem)
                {
                    var course = await _courseRepository.GetByIdAsync(item.CourseId);
                    var subject = await _courseSubjectRepository.GetByIdAsync(course.SubjectId);
                    var category = await _courseCategoryRepository.GetByIdAsync(subject.CourseCategoryId);
                    var orderDetails = new OrderDetail()
                    {
                        OrderId = orderResult.OrderId,
                        CourseId = item.CourseId,
                        UnitPrice = item.UnitPrice,
                        Quantity = item.Quantity,
                        //DiscountPrice = item.
                        TotalPrice = item.TotalPrice,
                        CourseType = item.CourseType,
                        CourseTitle = course.Title,
                        CourseSubject = subject.SubjectName,
                        CourseCategory = category.CategorytName,
                    };
                    var orderDetailResult = await _orderDetailRepository.AddAsync(orderDetails);
                }
                if (await _orderRepository.FirstOrDefaultAsync(x => x.OrderId == orderResult.OrderId) == null)
                {
                    throw new Exception("Order could not be created");
                }
                else
                {
                    return orderResult.OrderId;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Unexpected error: {ex.Message}");
            }
        }

        public async void UpdateOrderTransactionAndStatus(int orderId, string merchantTradeNo, string tradeNo, EOrderStatus orderStatus)
        {
            try
            {
                var order = await _orderRepository.GetByIdAsync(orderId);

                if (orderStatus == EOrderStatus.Success)
                {
                    order.OrderStatusId = (short)EOrderStatus.Success;
                    order.Udate = DateTime.Now;
                    //oreder.MerchantTradeNo = merchantTradeNo;
                    //order.TradeNo = tradeNo;
                    await _orderRepository.UpdateAsync(order);
                    foreach (var item in _shoppingCartItem)
                    {
                        if (item.BookingDate.HasValue && item.BookingTime.HasValue)
                        {
                            var booking = new Booking()
                            {
                                CourseId = item.CourseId,
                                BookingDate = item.BookingDate.Value,
                                //BookingTime =  (short)item.BookingTime,
                                StudentId = item.MemberId,
                            };
                            await _bookingRepository.UpdateAsync(booking);
                        }
                        await _shoppingCartRepository.DeleteAsync(item);
                    }
                }
                else if (orderStatus == EOrderStatus.Failed)
                {
                    throw new Exception("Order Status is Failed");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"UpDate error: {ex.Message}");
            }
        }

        public TimeSpan ConvertSmallintToTime(short timeValue)
        {
            int hours = timeValue / 100;
            int minutes = timeValue % 100;

            return new TimeSpan(hours, minutes, 0);
        }


    }
}
