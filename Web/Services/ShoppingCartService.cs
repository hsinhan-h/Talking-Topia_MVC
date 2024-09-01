
using Humanizer;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.AccessControl;
using Web.Entities;

namespace Web.Services
{
    public class ShoppingCartService
    {
        private readonly IRepository _repository;
        public ShoppingCartService(IRepository repository)
        {
            _repository = repository;
        }
        public bool HasMemberData(int memberId)
        {
            return _repository.GetAll<Member>().Any(x => x.MemberId == memberId);
        }
        public bool HasCourseData(int courseId)
        {
            return _repository.GetAll<Course>().Any(x => x.CourseId == courseId);
        }
        public bool HasCartData(int memberId, int courseId)
        {
            return _repository.GetAll<ShoppingCart>().Any(x => x.MemberId == memberId && x.CourseId == courseId);
        }
        public decimal GetUnitPrice(int courseId, int courseLength)
        {
            var price = _repository.GetAll<Course>()
                       .Where(x => x.CourseId == courseId)
                       .Select(x => courseLength == 25 ? x.TwentyFiveMinUnitPrice : x.FiftyMinUnitPrice)
                       .FirstOrDefault();

            return price;
        }
        public ShoppingCart ShoppingCartVMToDM(ShoppingCartViewModel scVM)
        {
            // 感覺哪裡怪怪的
            ShoppingCart cart = new ShoppingCart()
            {
                CourseId = scVM.CourseId,
                UnitPrice = scVM.UnitPrice,
                Quantity = (short)scVM.CourseQuantity,
                TotalPrice = scVM.CourseQuantity * scVM.UnitPrice,
                // MemberId = scVM.MemberId, //少這個= =?
                CourseType = 1, // 用enum設定?
                Cdate = DateTime.Now,
                Udate = DateTime.Now,
                // BookingDate = scVM.BookingDate,
                // BookingTime = scVM.BookingTime,
                //Course
                //Member
                //ShoppingCartBookings
            };
            return cart;
        }

        public async Task<ShoppingCartListViewModel> GetShoppingCartData(int memberId, int courseId,
                                                                         int courseLength, int quantity)
        {
            //todo: 確認是否為有效member及course (感覺要統一寫在member跟course的service)
            if (!HasMemberData(memberId))
            { throw new Exception("會員不存在，請重新操作"); }
            if (!HasCourseData(courseId))
            { throw new Exception("課程不存在，請重新操作"); }

            //todo: 確認購物車是否已有課程/相同課程
            if (!HasCartData(memberId, courseId)) //沒有就新增
            {
                //從前端傳入的value抓db.Course的單價
                var unitPrice = GetUnitPrice(courseId, courseLength);

                //究級join然後將抓到的值塞進VM
                var shoppingCart = from cartItem in _repository.GetAll<ShoppingCart>()
                                       //如果沒有要怎麼從購物車抓資料 = = 我思考思考...
                                   join member in _repository.GetAll<Member>() on cartItem.MemberId equals member.MemberId
                                   join course in _repository.GetAll<Course>() on cartItem.CourseId equals course.CourseId
                                   join subject in _repository.GetAll<CourseSubject>() on course.SubjectId equals subject.SubjectId
                                   join category in _repository.GetAll<CourseCategory>() on course.CategoryId equals category.CourseCategoryId
                                   select new ShoppingCartViewModel
                                   {
                                       CourseId = course.CourseId,
                                       TrackingNumber = "",
                                       HeadShotImage = member.HeadShotImage,
                                       FullName = member.FirstName + " " + member.LastName,
                                       CourseTitle = course.Title,
                                       CourseSubject = subject.SubjectName,
                                       CourseCategory = category.CategorytName,
                                       CourseLength = "",
                                       CourseQuantity = quantity,
                                       UnitPrice = unitPrice,
                                       SubtotalNTD = quantity * unitPrice,
                                       Coupon = "",
                                       PaymentType = ""
                                   };
                return new ShoppingCartListViewModel
                {
                    ShoppingCartList = await shoppingCart.ToListAsync(),
                };

            }
            else
            {
                //有就更新同筆課程的明細
                return null;
            }
        }

        //public async Task<ShoppingCartListViewModel> GetShoppingCartCheckList(int memberId)
        //{
        //    List<ShoppingCartViewModel> order = new List<ShoppingCartViewModel>
        //{
        //        new ShoppingCartViewModel
        //    {
        //            CourseId = 1,
        //            TrackingNumber="17123456789",
        //            HeadShotImage = "https://example.com/images/headshot123.jpg",
        //            FullName = "John Doe",
        //            CourseTitle = "英文生活會話",
        //            CourseSubject = "英文",
        //            CourseCategory = "語言",
        //            CourseLength = "25",
        //            CourseQuantity = 10,
        //            UnitPrice = 800,
        //            SubtotalNTD = 8000,
        //            Coupon = "DISCOUNT2024",
        //            PaymentType = "Credit Card",
        //    },
        //        new ShoppingCartViewModel
        //    {
        //            CourseId = 2,
        //            TrackingNumber="17987654321",
        //            HeadShotImage = "https://example.com/images/headshot456.jpg",
        //            FullName = "Jane Smith",
        //            CourseTitle = "商務英文會話",
        //            CourseSubject = "英文",
        //            CourseCategory = "語言",
        //            CourseLength = "25",
        //            CourseQuantity = 20,
        //            UnitPrice = 1000,
        //            SubtotalNTD = 20000,
        //            Coupon = "BUSINESS2024",
        //            PaymentType = "Bank Transfer",
        //    },
        //        new ShoppingCartViewModel
        //        {
        //            CourseId = 3,
        //            TrackingNumber = "17246813579",
        //            HeadShotImage = "https://example.com/images/headshot789.jpg",
        //            FullName = "Michael Johnson",
        //            CourseTitle = "基礎英文聽力與發音",
        //            CourseSubject = "英文",
        //            CourseCategory = "語言",
        //            CourseLength = "50",
        //            CourseQuantity = 10,
        //            UnitPrice = 700,
        //            SubtotalNTD = 7000,
        //            Coupon = "LEARN2024",
        //            PaymentType = "PayPal",
        //        }
        //};
        //    return new ShoppingCartListViewModel()
        //    {
        //        ShoppingCartCheckList = order,
        //    };
        //}

    }
}
