
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
        public bool HasCartData(int memberId)
        {
            return _repository.GetAll<ShoppingCart>().Any(x => x.MemberId == memberId);
        }
        public bool HasCartData(int memberId, int courseId)
        {
            return _repository.GetAll<ShoppingCart>().Any(x => x.MemberId == memberId && x.CourseId == courseId);
        }
        public decimal GetUnitPrice(int courseId, int courseLength)
        {
            decimal price = _repository.GetAll<Course>()
                       .Where(x => x.CourseId == courseId)
                       .Select(x => courseLength == 25 ? x.TwentyFiveMinUnitPrice : x.FiftyMinUnitPrice)
                       .FirstOrDefault();

            return price;
        }
        public async Task<ShoppingCartListViewModel> GetShoppingCartData(int memberId, int courseId,
                                                                         int courseLength, int quantity)
        {
            decimal unitPrice = GetUnitPrice(courseId, courseLength);
            if (memberId < 1 || courseId < 1 || courseLength < 1 || quantity < 1 || unitPrice < 1)
            {
                throw new ArgumentException("Invalid input data");
            }
            if (!HasCartData(memberId, courseId))
            {
                CreateShoppingCartData(memberId, courseId, courseLength, quantity, unitPrice);
            }
            //todo: return View Model to View (這步是不是多餘)
            var shoppingCart = await GetShoppingCartViewModelsAsync(memberId);

            return new ShoppingCartListViewModel
            {
                ShoppingCartList = shoppingCart
            };
        }
        /// <summary>
        /// 讀取資料以渲染頁面
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public async Task<List<ShoppingCartViewModel>> GetShoppingCartViewModelsAsync(int memberId)
        {

            var result = await (from item in _repository.GetAll<ShoppingCart>()
                                where item.MemberId == memberId
                                join member in _repository.GetAll<Member>() on item.MemberId equals member.MemberId
                                join course in _repository.GetAll<Course>() on item.CourseId equals course.CourseId
                                join subject in _repository.GetAll<CourseSubject>() on course.SubjectId equals subject.SubjectId
                                join category in _repository.GetAll<CourseCategory>() on course.CategoryId equals category.CourseCategoryId
                                join memberCoupon in _repository.GetAll<MemberCoupon>() on member.MemberId equals memberCoupon.MemberId into mcGroup
                                from mc in mcGroup.DefaultIfEmpty()
                                join coupon in _repository.GetAll<Coupon>() on mc.CouponId equals coupon.CouponId into cGroup
                                from co in cGroup.DefaultIfEmpty()
                                select new ShoppingCartViewModel
                                {
                                    CourseId = item.CourseId,
                                    TrackingNumber = "",
                                    HeadShotImage = member.HeadShotImage,
                                    FullName = member.FirstName + " " + member.LastName,
                                    CourseTitle = course.Title,
                                    CourseSubject = subject.SubjectName,
                                    CourseCategory = category.CategorytName,
                                    CourseLength = item.CourseType == 1 ? "25分鐘" : "50分鐘",
                                    CourseQuantity = item.Quantity,
                                    UnitPrice = item.UnitPrice,
                                    SubtotalNTD = item.Quantity * item.UnitPrice,
                                    Coupon = co != null ? co.CouponName : "==========",
                                    PaymentType = ""
                                }).ToListAsync();

            return result;
        }

        public void CreateShoppingCartData(int memberId, int courseId, int courseLength, int quantity, decimal unitPrice)
        {
            try
            {
                var shoppingCart = new ShoppingCart
                {
                    CourseId = courseId,
                    UnitPrice = unitPrice,
                    Quantity = (short)quantity,
                    TotalPrice = unitPrice * quantity,
                    MemberId = memberId,
                    CourseType = courseLength == 25 ? (short)CourseTypes.TwentyFiveMinUnitPrice : (short)CourseTypes.FiftyMinUnitPrice,
                    Cdate = DateTime.Now,
                };
                _repository.Create(shoppingCart);
                _repository.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"無法存入ShoppingCart: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                throw;
            }
        }

        public void DeleteCartItem(int memberId, int courseId)
        {
            try
            {
                var target = _repository.GetAll<ShoppingCart>()
                                        .FirstOrDefault(x => x.MemberId == memberId && x.CourseId == courseId);
                _repository.Delete(target);
                _repository.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"無法存入ShoppingCart: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                throw;
            }
        }

        public enum CourseTypes
        {
            TwentyFiveMinUnitPrice = 1,
            FiftyMinUnitPrice = 2,
        }
    }
}
