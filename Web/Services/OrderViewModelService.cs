using ApplicationCore.Interfaces;

namespace Web.Services
{
    public class OrderViewModelService
    {
        private readonly IOrderService _orderService;
        private readonly IRepository<ApplicationCore.Entities.Order> _orderRepository;
        private readonly IRepository<ApplicationCore.Entities.OrderDetail> _orderDetailRepository;
        private readonly IRepository<ApplicationCore.Entities.Course> _courseRepository;
        private readonly IRepository<ApplicationCore.Entities.Member> _memberRepository;
        private readonly IRepository<ApplicationCore.Entities.Booking> _bookingRepository;

        public OrderViewModelService(IOrderService orderService,
                                     IRepository<ApplicationCore.Entities.Order> orderRepository,
                                     IRepository<ApplicationCore.Entities.OrderDetail> orderDetailRepository,
                                     IRepository<ApplicationCore.Entities.Course> courseRepository,
                                     IRepository<ApplicationCore.Entities.Member> memberRepository,
                                     IRepository<ApplicationCore.Entities.Booking> bookingRepository)
        {
            _orderService = orderService;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _courseRepository = courseRepository;
            _memberRepository = memberRepository;
            _bookingRepository = bookingRepository;
        }

        public async Task<List<OrderResultViewModel>> GetOrderResultViewModelAsync(int memberId)
        {
            var latestOrderId = _orderService.GetLatestOrder(memberId);
            var latestOrder = await _orderRepository.GetByIdAsync(latestOrderId);
            if (latestOrder == null) return null;

            var orderDetails = await _orderDetailRepository.ListAsync(od => od.OrderId == latestOrder.OrderId);
            var result = new List<OrderResultViewModel>();
            foreach (var item in orderDetails)
            {
                var course = await _courseRepository.GetByIdAsync(item.CourseId);
                var tutor = await _memberRepository.GetByIdAsync(course.TutorId);
                var bookings = await _bookingRepository.ListAsync(b => b.CourseId == course.CourseId);
                ApplicationCore.Entities.Booking booking = null;
                if (bookings.Count != 0)
                {
                    booking = bookings.OrderByDescending(b => b.Cdate).FirstOrDefault();
                }
                var orderResult = new OrderResultViewModel()
                {
                    CourseId = item.CourseId,
                    TrackingNumber = latestOrder.MerchantTradeNo,
                    FullName = tutor.FirstName + " " + tutor.LastName,
                    CourseTitle = course.Title,
                    CourseQuantity = item.Quantity,
                    SubtotalNTD = item.TotalPrice,
                    TaxIdNumber = latestOrder.TaxIdNumber,
                    OrderDatetime = latestOrder.TransactionDate.ToString("yyyy-MM-dd hh-mm"),
                    BookingDate = (booking != null) ? booking.BookingDate.ToString("yyyy-MM-dd") : "無",
                    BookingTime = (booking != null) ? BookingTimeConvert(booking.BookingTime) : "無",
                };
                result.Add(orderResult);

            }

            if (result.Count == 0) return null;
            else
            {
                return result;
            }
        }
        public string BookingTimeConvert(int bookingtime)
        {
            if (bookingtime < 0) return null;
            else
            {
                string bookingtimeResult = bookingtime + ":00";
                return bookingtimeResult;
            }
        }
    }
}

