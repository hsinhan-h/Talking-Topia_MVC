using Web.Entities;
using Web.ViewModels;

namespace Web.Services
{
    public class OrderService
    {
        public async Task<OrderManagementListViewModel> GetOrderList()
        {
            List<OrderManagementViewModel> order = new List<OrderManagementViewModel>
        {
                new OrderManagementViewModel
            {
                    CourseId = 1,
                    TrackingNumber="17123456789",
                    HeadShotImage = "https://example.com/images/headshot123.jpg",
                    FullName = "John Doe",
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
                    CourseId = 2,
                    TrackingNumber="17987654321",
                    HeadShotImage = "https://example.com/images/headshot456.jpg",
                    FullName = "Jane Smith",
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
                    CourseId = 3,
                    TrackingNumber = "17246813579",
                    HeadShotImage = "https://example.com/images/headshot789.jpg",
                    FullName = "Michael Johnson",
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
                    BookingTime = new DateTime(09, 00),
                }
        };
            return new OrderManagementListViewModel()
            {
                OrderManagementList = order,
            };
        }
        public async Task<ShoppingCartInfoListViewModel> GetShoppingCartInfoList()
        {
            List<ShoppingCartInfoViewModel> order = new List<ShoppingCartInfoViewModel>
        {
                new ShoppingCartInfoViewModel
            {
                    CourseId = 1,
                    TrackingNumber="17123456789",
                    FullName = "John Doe",
                    CourseTitle = "英文生活會話",
                    CourseQuantity = 10,
                    SubtotalNTD = 8000,
                    TaxIdNumber = "12345678",
                    OrderDatetime = "2024/08/24 14:35:00",
                    BookingDate = new DateTime(2024, 8, 24),
                    BookingTime = new DateTime(23,00),
            },
                new ShoppingCartInfoViewModel
            {
                    CourseId = 2,
                    TrackingNumber="17987654321",
                    FullName = "Jane Smith",
                    CourseTitle = "商務英文會話",
                    CourseQuantity = 20,
                    SubtotalNTD = 20000,
                    TaxIdNumber = "87654321",
                    OrderDatetime = "2024/08/23 10:15:00",
                    BookingDate = new DateTime(2024, 8, 25),
                    BookingTime = new DateTime(14,00),
            },
                new ShoppingCartInfoViewModel
                {
                    CourseId = 3,
                    TrackingNumber = "17246813579",
                    FullName = "Michael Johnson",
                    CourseTitle = "基礎英文聽力與發音",
                    CourseQuantity = 10,
                    SubtotalNTD = 7000,
                    TaxIdNumber = "13572468",
                    OrderDatetime = "2024/08/22 08:45:00",
                    BookingDate = new DateTime(2024, 8, 26),
                    BookingTime = new DateTime(09, 00),
                }
        };
            return new ShoppingCartInfoListViewModel()
            {
                ShoppingCartInfoList = order,
            };
        }
    }
}
