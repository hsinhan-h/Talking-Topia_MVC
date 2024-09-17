using ApplicationCore.Interfaces;

namespace Web.Services
{
    public class ShoppingCartViewModelService
    {
        private readonly IRepository _repository;
        private readonly IRepository<Course> _courseRepository;
        private readonly IRepository<Member> _memberRepository;
        private readonly IRepository<ShoppingCart> _shoppingCartRepository;
        private readonly IRepository<CourseSubject> _courseSubjectRepository;
        private readonly IRepository<CourseCategory> _courseCategoryRepository;
        private readonly IRepository<MemberCoupon> _memberCouponRepository;
        private readonly IRepository<Coupon> _couponRepository;
        private List<Coupon> _coupon;

        public ShoppingCartViewModelService(IRepository repository, IRepository<Course> courseRepository, IRepository<Member> memberRepository, IRepository<ShoppingCart> shoppingCartRepository, IRepository<CourseSubject> courseSubjectRepository, IRepository<CourseCategory> courseCategoryRepository, IRepository<MemberCoupon> memberCouponRepository, IRepository<Coupon> couponRepository)
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

            var result = await (from item in _repository.GetAll<ShoppingCart>()
                                where item.MemberId == memberId
                                join course in _repository.GetAll<Course>() on item.CourseId equals course.CourseId
                                join member in _repository.GetAll<Member>() on item.MemberId equals member.MemberId
                                join tutor in _repository.GetAll<Member>() on course.TutorId equals tutor.MemberId
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
