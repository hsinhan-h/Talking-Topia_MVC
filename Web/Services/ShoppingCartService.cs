
using Humanizer;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.AccessControl;
using Web.Entities;

namespace Web.Services
{
    public class ShoppingCartService
    {
        private readonly GeneralRepository _generalRepository;
        public ShoppingCartService(GeneralRepository generalRepository)
        {
            _generalRepository = generalRepository;
        }
        public async Task<int> GetMemberData(int memberId)
        {
            var member = await _generalRepository.GetAll<Member>()
                                           .Where(x => x.MemberId == memberId)
                                           .FirstOrDefaultAsync();
            if (member == null)
            {
                throw new Exception("會員不存在");
            }
            else
            {
                return member.MemberId;
            }
        }
        public async Task<int> GetCourseData(int courseId)
        {
            var course = await _generalRepository.GetAll<Course>()
                                           .Where(x => x.CourseId == courseId)
                                           .FirstOrDefaultAsync();
            if (course == null)
            {
                throw new Exception("課程不存在");
            }
            else
            {
                return course.CourseId;
            }
        }

        public async Task<ShoppingCartListViewModel> GetShoppingCartData(int memberId, int courseId,
                                                                         int courseLength, int quantity)
        {
            //已確認有member及course
            //todo: 先確認購物車是否已有課程/相同課程
            bool exists = await _generalRepository.GetAll<ShoppingCart>()
                                                  .AnyAsync(x => x.MemberId == memberId
                                                         && x.CourseId == courseId);
            if (!exists)
            {
                throw new Exception("資料不存在，請重新操作");
            }
            else
            { 
                var shoppingCart = from cartItem in _generalRepository.GetAll<ShoppingCart>()
                                   join member in _generalRepository.GetAll<Member>() on cartItem.MemberId equals member.MemberId
                                   join course in _generalRepository.GetAll<Course>() on cartItem.CourseId equals course.CourseId
                                   join subject in _generalRepository.GetAll<CourseSubject>() on course.SubjectId equals subject.SubjectId
                                   join category in _generalRepository.GetAll<CourseCategory>() on course.CategoryId equals category.CourseCategoryId
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
                                       CourseQuantity = 10,
                                       UnitPrice = 1000,
                                       SubtotalNTD = 10 * 1000, 
                                       Coupon = "",
                                       PaymentType = ""
                                   };
                return new ShoppingCartListViewModel
                {
                    ShoppingCartList = await shoppingCart.ToListAsync(),
                };
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
