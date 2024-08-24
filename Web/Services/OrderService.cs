using Web.ViewModels;

namespace Web.Services
{
    public class OrderService
    {
        public async Task<BookingListViewModel> GetOrderList()
        { 
        
        var order = new List<OrderManagementViewModel>
        {
            new OrderManagementViewModel
            { 
                HeadShotImage ="",
                FullName="",
                WorkExperience="",
                CourseTitle="",
                CourseSubject="",
                CourseCategory="",
                CourseLength="",
                CourseQuantity=10,
                UnitPrice=800,
                SubtotalNTD=8000,
                Coupon="",
                PaymentType="",
                TaxIdNumber="",
                OrderDatetime="",
                OrderStatus="",
                BookingDate=2024/8/24,
                BookingTime=2307,
            }
        };
        }
    }
}
