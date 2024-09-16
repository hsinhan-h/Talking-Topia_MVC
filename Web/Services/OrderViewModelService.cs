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
        private readonly IRepository _repository;

        public OrderViewModelService(IOrderService orderService, IRepository repository)
        {
            _orderService = orderService;
            _repository = repository;
        }

        public async Task<ShoppingCartInfoListViewModel> GetData(int memberId)
        {
            var result = await (from item in (from lo in _repository.GetAll<Order>()
                                              where lo.MemberId == memberId
                                              //orderby lo.Cdate descending
                                              select lo).Take(1)
                                join od in _repository.GetAll<OrderDetail>() on item.OrderId equals od.OrderId
                                join course in _repository.GetAll<Course>() on od.CourseId equals course.CourseId
                                join tutor in _repository.GetAll<Member>() on course.TutorId equals tutor.MemberId
                                join booking in _repository.GetAll<Booking>() on memberId equals booking.StudentId
                                where booking.CourseId == course.CourseId
                                orderby booking.Cdate descending
                                select new ShoppingCartInfoViewModel
                                {
                                    CourseId = od.CourseId,
                                    TrackingNumber = "",
                                    FullName = tutor.FirstName + " " + tutor.LastName,
                                    CourseTitle = od.CourseTitle,
                                    CourseQuantity = od.Quantity,
                                    SubtotalNTD = od.TotalPrice,
                                    TaxIdNumber = item.TaxIdNumber,
                                    OrderDatetime = item.TransactionDate.ToString("yyyy-MM-dd hh-mm"),
                                    BookingDate = booking.BookingDate,
                                    //BookingTime = ConvertSmallintToTime((short)booking.BookingTime),
                                }).ToListAsync();

            return new ShoppingCartInfoListViewModel
            {
                ShoppingCartInfoList = result
            };
        }
    }
}

