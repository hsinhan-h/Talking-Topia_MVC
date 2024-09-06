
using Humanizer;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.AccessControl;
using System.Security.Policy;
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
        public async Task<ShoppingCartListViewModel> GetShoppingCartData(int memberId, int courseId,
                                                                         int courseLength, int quantity)
        {
            if (!HasMemberData(memberId)) //應跳轉至登入頁面
            { throw new Exception("會員不存在，請重新操作"); }
            if (!HasCourseData(courseId))
            { throw new Exception("課程不存在，請重新操作"); }

            //從前端傳入的value抓db.Course的單價
            var unitPrice = GetUnitPrice(courseId, courseLength);
            if (!HasCartData(memberId, courseId)) //沒有就要新增
            {
                //新增資料塞到db，儲存
                CreateShoppingCartData(memberId, courseId, courseLength, quantity, unitPrice);
            }
            //todo: return View Model to View
            var shoppingCart = await (from item in _repository.GetAll<ShoppingCart>()
                                      join member in _repository.GetAll<Member>() on item.MemberId equals member.MemberId
                                      join course in _repository.GetAll<Course>() on item.CourseId equals course.CourseId
                                      join subject in _repository.GetAll<CourseSubject>() on course.SubjectId equals subject.SubjectId
                                      join category in _repository.GetAll<CourseCategory>() on course.CategoryId equals category.CourseCategoryId
                                      join memberCoupon in _repository.GetAll<MemberCoupon>() on member.MemberId equals memberCoupon.MemberId
                                      join coupon in _repository.GetAll<Coupon>() on memberCoupon.CouponId equals coupon.CouponId
                                      select new ShoppingCartViewModel
                                      {
                                          CourseId = item.CourseId,
                                          TrackingNumber = "",
                                          HeadShotImage = member.HeadShotImage,
                                          FullName = member.FirstName + " " + member.LastName,
                                          CourseTitle = course.Title,
                                          CourseSubject = subject.SubjectName,
                                          CourseCategory = category.CategorytName,
                                          CourseLength = courseLength.ToString(),
                                          CourseQuantity = quantity,
                                          UnitPrice = unitPrice,
                                          SubtotalNTD = quantity * unitPrice,
                                          Coupon = coupon.CouponName,
                                          PaymentType = ""
                                      }).ToListAsync();

            return new ShoppingCartListViewModel
            {
                ShoppingCartList = shoppingCart
            };
        }

        public void CreateShoppingCartData(int memberId, int courseId, int courseLength, int quantity, decimal unitPrice)
        {
            //todo: VM塞DM -> Create -> SaveChange
            var result = from member in _repository.GetAll<Member>()
                         where member.MemberId == memberId
                         join course in _repository.GetAll<Course>() on courseId equals course.CourseId
                         select new ShoppingCart
                         {
                             CourseId = courseId,
                             UnitPrice = unitPrice,
                             Quantity = (short)quantity,
                             TotalPrice = unitPrice * quantity,
                             MemberId = memberId,
                             CourseType = courseLength == 25 ? (short)CourseTypes.TwentyFiveMinUnitPrice : (short)CourseTypes.FiftyMinUnitPrice,
                             Cdate = DateTime.Now,
                         };
            _repository.Create(result);
            _repository.SaveChanges();
        }

        public enum CourseTypes
        {
            TwentyFiveMinUnitPrice = 1,
            FiftyMinUnitPrice = 2,
        }
    }
}
