using ApplicationCore.Dtos;
using ApplicationCore.Entities;
using ApplicationCore.Enums;
using ApplicationCore.Interfaces;



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

        public OrderService(ITransaction transaction, IRepository<Order> orderRepository,
                            IRepository<Member> memberRepository, IRepository<OrderDetail> orderDetailRepository,
                            IRepository<ShoppingCart> shoppingCartRepository, IRepository<Course> courseRepository,
                            IRepository<Booking> bookingRepository, IRepository<CourseSubject> courseSubjectRepository,
                            IRepository<CourseCategory> courseCategoryRepository)
        {
            _transaction = transaction ?? throw new ArgumentNullException(nameof(transaction));
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _memberRepository = memberRepository ?? throw new ArgumentNullException(nameof(memberRepository));
            _orderDetailRepository = orderDetailRepository ?? throw new ArgumentNullException(nameof(orderDetailRepository));
            _shoppingCartRepository = shoppingCartRepository ?? throw new ArgumentNullException(nameof(shoppingCartRepository));
            _courseRepository = courseRepository ?? throw new ArgumentNullException(nameof(courseRepository));
            _bookingRepository = bookingRepository ?? throw new ArgumentNullException(nameof(bookingRepository));
            _courseSubjectRepository = courseSubjectRepository ?? throw new ArgumentNullException(nameof(courseSubjectRepository));
            _courseCategoryRepository = courseCategoryRepository ?? throw new ArgumentNullException(nameof(courseCategoryRepository));
        }


        /// <summary>
        /// 建單並串至綠界(callback後會再呼叫Update刷新OrderStatusId)
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="paymentType"></param>
        /// <param name="taxIdNumber"></param>
        /// <returns></returns>+		shoppingCartItem	null	System.Collections.Generic.List<ApplicationCore.Entities.ShoppingCart>

        /// <exception cref="Exception"></exception>
        public async Task<int> CreateOrderAsync(int memberId, string paymentType, string taxIdNumber)
        {

            try
            {
                await _transaction.BeginTransactionAsync();
                var shoppingCartItem = await _shoppingCartRepository.ListAsync(m => m.MemberId == memberId);
                var totalPrice = shoppingCartItem.Sum(item => item.TotalPrice);
                var member = await _memberRepository.FirstOrDefaultAsync(m => m.MemberId == memberId);

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
                    Vatnumber = "",
                    SentVatemail = member.Email,
                    OrderStatusId = (short)EOrderStatus.Success,
                    MerchantTradeNo = "",
                    TradeNo = "",
                };

                var orderResult = await _orderRepository.AddAsync(orders);

                foreach (var item in shoppingCartItem)
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
                    await _transaction.RollbackAsync();
                    throw new Exception("Order could not be created");
                }
                else
                {
                    await _transaction.CommitAsync();
                    return orderResult.OrderId;
                }
            }
            catch (Exception ex)
            {
                await _transaction.RollbackAsync();
                throw new Exception($"Unexpected error: {ex.Message}");
            }
            finally
            {
                _transaction.Dispose();
            }
        }

        public async Task UpdateOrderTransactionAndStatus(int orderId, string merchantTradeNo, string tradeNo, EOrderStatus orderStatus)
        {
            try
            {
                await _transaction.BeginTransactionAsync();
                var order = await _orderRepository.GetByIdAsync(orderId);
                var shoppingCartItem = await _shoppingCartRepository.ListAsync(m => m.MemberId == order.MemberId);

                if (orderStatus == EOrderStatus.Success)
                {
                    order.OrderStatusId = (short)EOrderStatus.Success;
                    order.Udate = DateTime.Now;
                    order.MerchantTradeNo = merchantTradeNo;
                    //order.TradeNo = tradeNo;
                    var updateResult = await _orderRepository.UpdateAsync(order);
                    foreach (var item in shoppingCartItem)
                    {
                        if (item.BookingDate.HasValue && item.BookingTime.HasValue)
                        {
                            var booking = new Booking()
                            {
                                CourseId = item.CourseId,
                                BookingDate = item.BookingDate.Value,
                                BookingTime = (short)item.BookingTime,
                                StudentId = item.MemberId,
                                Cdate = DateTime.Now,
                            };
                            await _bookingRepository.AddAsync(booking);
                        }
                        await _shoppingCartRepository.DeleteAsync(item);
                    }
                    await _transaction.CommitAsync();
                }
                else if (orderStatus == EOrderStatus.Failed)
                {
                    await _transaction.RollbackAsync();
                    throw new Exception("Order Status is Failed");
                }
            }
            catch (Exception ex)
            {
                await _transaction.RollbackAsync();
                throw new Exception($"UpDate error: {ex.Message}");
            }
            finally
            {
                _transaction.Dispose();
            }
        }

        public int GetLatestOrder(int memberId)
        {
            var memberOrders = _orderRepository.List(o => o.MemberId == memberId);
            var latestOrder = memberOrders.OrderByDescending(o => o.TransactionDate).FirstOrDefault();
            return latestOrder == null ? 0 : latestOrder.OrderId;
        }

        public TimeSpan ConvertSmallintToTime(short timeValue)
        {
            int hours = timeValue / 100;
            int minutes = timeValue % 100;

            return new TimeSpan(hours, minutes, 0);
        }
    }
}
