using Web.Entities;
using Web.ViewModels;

namespace Web.Services
{
    public class OrderService
    {
        public async Task<OrderManagementListViewModel> GetOrderList()
        {
                var order = new List<OrderManagementViewModel>
                {
                new OrderManagementViewModel
            {
                HeadShotImage = "https://example.com/images/headshot789.jpg",
                FullName = "Michael Johnson",
                WorkExperience = "8 years of experience teaching ESL to adults.",
                CourseTitle = "基礎英文聽力與發音",
                CourseSubject = "英文",
                CourseCategory = "語言",
                CourseLength = "50",
                CourseQuantity = 10,
                UnitPrice = 700,
                SubtotalNTD = 7000,
                Coupon = "LEARN2024",
                PaymentType = "PayPal",
                TaxIdNumber = "C135792468",
                OrderDatetime = "2024/08/22 08:45:00",
                OrderStatus = "Completed",
                BookingDate = new DateTime(2024, 8, 26),
                BookingTime = new DateTime(09,00),
            }
                };
            return new OrderManagementListViewModel()
            {
                OrderManagementList = order,
            };
        }
    }
}
