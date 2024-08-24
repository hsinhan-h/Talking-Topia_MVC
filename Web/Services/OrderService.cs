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
                    HeadShotImage = "https://example.com/images/headshot123.jpg",
                    FullName = "John Doe",
                    WorkExperience = "5 years teaching experience in English language schools.",
                    CourseTitle = "英文生活會話",
                    CourseSubject = "英文",
                    CourseCategory = "語言",
                    CourseLength = "25",
                    CourseQuantity = 10,
                    UnitPrice = 800,
                    SubtotalNTD = 8000,
                    Coupon = "DISCOUNT2024",
                    PaymentType = "Credit Card",
                    TaxIdNumber = "12345678",
                    OrderDatetime = "2024/08/24 14:35:00",
                    OrderStatus = "Confirmed",
                    BookingDate = new DateTime(2024, 8, 24),
                    BookingTime = new DateTime(23,00),
            },
                new OrderManagementViewModel
            {
                    HeadShotImage = "https://example.com/images/headshot456.jpg",
                    FullName = "Jane Smith",
                    WorkExperience = "3 years experience in corporate English training.",
                    CourseTitle = "商務英文會話",
                    CourseSubject = "英文",
                    CourseCategory = "語言",
                    CourseLength = "25",
                    CourseQuantity = 20,
                    UnitPrice = 1000,
                    SubtotalNTD = 20000,
                    Coupon = "BUSINESS2024",
                    PaymentType = "Bank Transfer",
                    TaxIdNumber = "87654321",
                    OrderDatetime = "2024/08/23 10:15:00",
                    OrderStatus = "Pending",
                    BookingDate = new DateTime(2024, 8, 25),
                    BookingTime = new DateTime(14,00),
            },
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
                    TaxIdNumber = "13572468",
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
