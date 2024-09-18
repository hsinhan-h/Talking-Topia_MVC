using ApplicationCore.Entities;
using ApplicationCore.Interfaces;

namespace Web.Services
{
    public class ShoppingCartViewModelService
    {
        private readonly IRepository _repository;
        private readonly IRepository<Entities.Course> _courseRepository;
        private readonly IRepository<Entities.Member> _memberRepository;
        private readonly IRepository<Entities.ShoppingCart> _shoppingCartRepository;
        private readonly IRepository<Entities.CourseSubject> _courseSubjectRepository;
        private readonly IRepository<Entities.CourseCategory> _courseCategoryRepository;
        private readonly IRepository<Entities.MemberCoupon> _memberCouponRepository;
        private readonly IRepository<Entities.Coupon> _couponRepository;
        private List<Entities.Coupon> _coupon;

        public ShoppingCartViewModelService(IRepository repository, IRepository<Entities.Course> courseRepository, IRepository<Entities.Member> memberRepository, IRepository<Entities.ShoppingCart> shoppingCartRepository, IRepository<Entities.CourseSubject> courseSubjectRepository, IRepository<Entities.CourseCategory> courseCategoryRepository, IRepository<Entities.MemberCoupon> memberCouponRepository, IRepository<Entities.Coupon> couponRepository)
        {
            _repository = repository;
            _courseRepository = courseRepository;
            _memberRepository = memberRepository;
            _shoppingCartRepository = shoppingCartRepository;
            _courseSubjectRepository = courseSubjectRepository;
            _courseCategoryRepository = courseCategoryRepository;
            _memberCouponRepository = memberCouponRepository;
            _couponRepository = couponRepository;
        }

        /// <summary>
        /// Web版
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public async Task<List<ShoppingCartViewModel>> GetShoppingCartViewModelsAsync(int memberId)
        {
            var discountMapping = new Dictionary<int, decimal>
                                  {
                                      { 1, 1.0m },
                                      { 5, 0.95m },
                                      { 10, 0.9m },
                                      { 20, 0.85m }
                                  };

            var result = await (from item in _repository.GetAll<Entities.ShoppingCart>()
                                where item.MemberId == memberId
                                join course in _repository.GetAll<Entities.Course>() on item.CourseId equals course.CourseId
                                join member in _repository.GetAll<Entities.Member>() on item.MemberId equals member.MemberId
                                join tutor in _repository.GetAll<Entities.Member>() on course.TutorId equals tutor.MemberId
                                join subject in _repository.GetAll<Entities.CourseSubject>() on course.SubjectId equals subject.SubjectId
                                join category in _repository.GetAll<Entities.CourseCategory>() on course.CategoryId equals category.CourseCategoryId
                                join memberCoupon in _repository.GetAll<Entities.MemberCoupon>() on member.MemberId equals memberCoupon.MemberId into mcGroup
                                from mc in mcGroup.DefaultIfEmpty()
                                join coupon in _repository.GetAll<Entities.Coupon>() on mc.CouponId equals coupon.CouponId into cGroup
                                from co in cGroup.DefaultIfEmpty()
                                select new ShoppingCartViewModel
                                {
                                    CourseId = item.CourseId,
                                    TrackingNumber = "",
                                    HeadShotImage = tutor.HeadShotImage,
                                    FullName = tutor.FirstName + " " + tutor.LastName,
                                    CourseTitle = course.Title,
                                    CourseSubject = subject.SubjectName,
                                    CourseCategory = category.CategorytName,
                                    CourseLength = item.CourseType == 1 ? "25分鐘" : "50分鐘",
                                    CourseQuantity = item.Quantity,
                                    UnitPrice = (int)item.UnitPrice,
                                    TFUnitPrice = (int)course.TwentyFiveMinUnitPrice,
                                    FTUnitPrice = (int)course.FiftyMinUnitPrice,
                                    Discount = discountMapping.ContainsKey(item.Quantity) ? discountMapping[item.Quantity] : 1.0m,
                                    SubtotalNTD = item.Quantity * item.UnitPrice,
                                    Coupon = co != null ? co.CouponName : "==========",
                                    PaymentType = ""
                                }).ToListAsync();

            return result;
        }

        /// <summary>
        /// ApplicationCore版
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        //public async Task<List<ShoppingCartViewModel>> GetShoppingCartViewModelsAsync(int memberId)
        //{
        //    var member = await _memberRepository.GetByIdAsync(memberId);
        //    var memberCoupon = await _memberCouponRepository.ListAsync(mc => mc.MemberId == member.MemberId);
        //    foreach (var mc in memberCoupon)
        //    {
        //        if (!mc.IsUsed)
        //        {
        //            var couponName = await _couponRepository.GetByIdAsync(mc.CouponId);
        //            _coupon.Add(couponName);
        //        }
        //    }

        //    var shoppingCart = await _shoppingCartRepository.ListAsync(item => item.MemberId == member.MemberId);
        //    var result = new List<ShoppingCartViewModel>();
        //    foreach (var item in shoppingCart)
        //    {
        //        var courses = await _courseRepository.ListAsync(c => c.CourseId == item.CourseId);
        //        foreach (var course in courses)
        //        {
        //            var tutor = await _memberRepository.GetByIdAsync(course.TutorId);
        //            var subject = await _courseSubjectRepository.GetByIdAsync(course.SubjectId);
        //            var category = await _courseCategoryRepository.GetByIdAsync(course.CategoryId);
        //            foreach (var coupon in _coupon)
        //            {
        //                var shoppingResult = new ShoppingCartViewModel
        //                {
        //                    CourseId = item.CourseId,
        //                    TrackingNumber = "",
        //                    HeadShotImage = tutor.HeadShotImage,
        //                    FullName = tutor.FirstName + " " + tutor.LastName,
        //                    CourseTitle = course.Title,
        //                    CourseSubject = subject.SubjectName,
        //                    CourseCategory = category.CategorytName,
        //                    CourseLength = item.CourseType == 1 ? "25分鐘" : "50分鐘",
        //                    CourseQuantity = item.Quantity,
        //                    UnitPrice = item.UnitPrice,
        //                    TFUnitPrice = (int) course.TwentyFiveMinUnitPrice,
        //                    FTUnitPrice= (int)course.FiftyMinUnitPrice,
        //                    SubtotalNTD = item.Quantity * item.UnitPrice,
        //                    Coupon = _coupon != null ? coupon.CouponName : "==========",
        //                    PaymentType = ""
        //                };
        //                result.Add(shoppingResult);
        //            }
        //        }
        //    }
        //    return result;
        //}
    }
}
