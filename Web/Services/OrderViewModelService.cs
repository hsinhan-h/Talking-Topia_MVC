using ApplicationCore.Interfaces;
using Humanizer;

namespace Web.Services
{
    public class OrderViewModelService
    {
        private readonly IRepository _repository;
        private readonly IOrderService _orderService;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<OrderDetail> _orderDetailRepository;
        private readonly IRepository<Course> _courseRepository;
        private readonly IRepository<Member> _memberRepository;
        private readonly IRepository<Booking> _bookingRepository;

        public OrderViewModelService(IRepository repository, IOrderService orderService, IRepository<Order> orderRepository, IRepository<OrderDetail> orderDetailRepository, IRepository<Course> courseRepository, IRepository<Member> memberRepository, IRepository<Booking> bookingRepository)
        {
            _repository = repository;
            _orderService = orderService;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _courseRepository = courseRepository;
            _memberRepository = memberRepository;
            _bookingRepository = bookingRepository;
        }

        /// <summary>
        /// ApplicationCore版
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        //public async Task<OrderResultListViewModel> GetData(int orderId)
        //{
        //    var orders = await _orderRepository.GetByIdAsync(orderId);
        //    var orderDetails = await _orderDetailRepository.ListAsync(od => od.OrderId == orders.OrderId);
        //    var result = new OrderResultListViewModel();
        //    foreach (var item in orderDetails)
        //    {
        //        var courses = await _courseRepository.ListAsync(c => c.CourseId == item.CourseId);
        //        foreach (var course in courses)
        //        {
        //            var tutor = await _memberRepository.GetByIdAsync(course.TutorId);
        //            var booking = await _bookingRepository.GetByIdAsync(course.CourseId);
        //            var orderResult = new OrderResultViewModel()
        //            {
        //                CourseId = item.CourseId,
        //                //TrackingNumber = orders.MerchantTradeNo,
        //                FullName = tutor.FirstName + " " + tutor.LastName,
        //                CourseTitle = course.Title,
        //                CourseQuantity = item.Quantity,
        //                SubtotalNTD = item.TotalPrice,
        //                TaxIdNumber = orders.TaxIdNumber,
        //                OrderDatetime = orders.TransactionDate.ToString("yyyy-MM-dd hh-mm"),
        //                BookingDate = booking.BookingDate,
        //                BookingTime = booking.BookingTime,
        //            };
        //            result.OrderResult.Add(orderResult);
        //        }   
        //    }
        //    return result;
        //}

        /// <summary>
        /// Web版
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public async Task<List<OrderResultViewModel>> GetOrderResultViewModelAsync(int orderId)
        {
            var result = await (from item in _repository.GetAll<Order>()
                                where item.OrderId == orderId
                                join orderDetail in _repository.GetAll<OrderDetail>() on item.OrderId equals orderDetail.OrderId
                                join course in _repository.GetAll<Course>() on orderDetail.CourseId equals course.CourseId
                                join tutor in _repository.GetAll<Member>() on course.TutorId equals tutor.MemberId
                                join booking in _repository.GetAll<Booking>() on course.CourseId equals booking.CourseId
                                select new OrderResultViewModel
                                {
                                    CourseId = course.CourseId,
                                    //TrackingNumber = item.MerchantTradeNo,
                                    FullName = tutor.FirstName + " " + tutor.LastName,
                                    CourseTitle = course.Title,
                                    CourseQuantity = orderDetail.Quantity,
                                    SubtotalNTD = orderDetail.TotalPrice,
                                    TaxIdNumber = item.TaxIdNumber,
                                    OrderDatetime = item.TransactionDate.ToString("yyyy-MM-dd hh-mm"),
                                    BookingDate = booking.BookingDate,
                                    BookingTime = booking.BookingTime,
                                }).ToListAsync();
            return result;
        }
    }
}

