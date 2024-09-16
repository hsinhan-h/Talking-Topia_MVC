using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Runtime.InteropServices;
using Web.Data;
using Web.ViewModels;

namespace Web.Services
{
    public class OrderViewModelService
    {

        private readonly IOrderService _orderService;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<OrderDetail> _orderDetailRepository;
        private readonly IRepository<Course> _courseRepository;
        private readonly IRepository<Member> _memberRepository;
        private readonly IRepository<Booking> _bookingRepository;

        public OrderViewModelService(IOrderService orderService, IRepository repository, IRepository<Order> orderRepository, IRepository<OrderDetail> orderDetailRepository, IRepository<Course> courseRepository, IRepository<Member> memberRepository, IRepository<Booking> bookingRepository)
        {
            _orderService = orderService;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _courseRepository = courseRepository;
            _memberRepository = memberRepository;
            _bookingRepository = bookingRepository;
        }

        public async Task<ShoppingCartInfoListViewModel> GetData(int orderId)
        {
            var orders = await _orderRepository.GetByIdAsync(orderId);
            var orderDetails = await _orderDetailRepository.ListAsync(od => od.OrderId == orders.OrderId);
            var result = new ShoppingCartInfoViewModel();
            foreach (var orderDetail in orderDetails)
            {
               var course = await _courseRepository.ListAsync(c => c.CourseId == orderDetail.CourseId);

                //result.Add( new 
                //{
                //    CourseId = course.Course,
                //    TrackingNumber = ,
                //    FullName = ,
                //    CourseTitle = ,
                //    CourseQuantity = ,
                //    SubtotalNTD = ,
                //    TaxIdNumber = ,
                //    OrderDatetime = .ToString("yyyy-MM-dd hh-mm"),
                //    BookingDate = ,
                //    BookingTime = ,
                //})).ToListAsync();
            }

            return new ShoppingCartInfoListViewModel
            {
                ShoppingCartInfoList = null
            };
        }
    }
}

