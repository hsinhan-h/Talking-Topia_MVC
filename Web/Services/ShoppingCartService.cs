namespace Web.Services
{
    public class ShoppingCartService
    {
        public async Task<ShoppingCartCheckListViewModel> GetShoppingCartCheckList()
        {
            List<ShoppingCartCheckViewModel> order = new List<ShoppingCartCheckViewModel>
        {
                new ShoppingCartCheckViewModel
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
            },
                new ShoppingCartCheckViewModel
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
            },
                new ShoppingCartCheckViewModel
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
                }
        };
            return new ShoppingCartCheckListViewModel()
            {
                ShoppingCartCheckList = order,
            };
        }

    }
}
