using ApplicationCore.Entities;
using ApplicationCore.Interfaces;

namespace Web.Services
{
    public class ShoppingCartViewModelService
    {
        private readonly IRepository _repository;
        private readonly IRepository<ApplicationCore.Entities.Course> _courseRepository;
        private readonly IRepository<ApplicationCore.Entities.Member> _memberRepository;
        private readonly IRepository<ApplicationCore.Entities.ShoppingCart> _shoppingCartRepository;
        private readonly IRepository<ApplicationCore.Entities.CourseSubject> _courseSubjectRepository;
        private readonly IRepository<ApplicationCore.Entities.CourseCategory> _courseCategoryRepository;
        private readonly IRepository<ApplicationCore.Entities.MemberCoupon> _memberCouponRepository;
        private readonly IRepository<ApplicationCore.Entities.Coupon> _couponRepository;
        //private List<Entities.Coupon> _coupon;

        public ShoppingCartViewModelService(IRepository repository,
                                            IRepository<ApplicationCore.Entities.Course> courseRepository,
                                            IRepository<ApplicationCore.Entities.Member> memberRepository,
                                            IRepository<ApplicationCore.Entities.ShoppingCart> shoppingCartRepository,
                                            IRepository<ApplicationCore.Entities.CourseSubject> courseSubjectRepository,
                                            IRepository<ApplicationCore.Entities.CourseCategory> courseCategoryRepository,
                                            IRepository<ApplicationCore.Entities.MemberCoupon> memberCouponRepository,
                                            IRepository<ApplicationCore.Entities.Coupon> couponRepository)
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
        /// ApplicationCore版
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public async Task<List<ShoppingCartViewModel>> GetShoppingCartViewModelsAsync(int memberId)
        {
            var member = await _memberRepository.GetByIdAsync(memberId);
            //var memberCoupon = await _memberCouponRepository.ListAsync(mc => mc.MemberId == member.MemberId);
            //foreach (var mc in memberCoupon)
            //{
            //    if (!mc.IsUsed)
            //    {
            //        var couponName = await _couponRepository.GetByIdAsync(mc.CouponId);
            //        _coupon.Add(couponName);
            //    }
            //}

            var shoppingCart = await _shoppingCartRepository.ListAsync(item => item.MemberId == member.MemberId);
            var result = new List<ShoppingCartViewModel>();
            foreach (var item in shoppingCart)
            {
                var course = await _courseRepository.GetByIdAsync(item.CourseId);
                var tutor = await _memberRepository.GetByIdAsync(course.TutorId);
                var subject = await _courseSubjectRepository.GetByIdAsync(course.SubjectId);
                var category = await _courseCategoryRepository.GetByIdAsync(course.CategoryId);
                double discount = 0;
                if (item.Quantity == 1) discount = 0;
                if (item.Quantity == 5) discount = 0.95;
                if (item.Quantity == 10) discount = 0.9;
                if (item.Quantity == 20) discount = 0.85;
                //foreach (var coupon in _coupon)
                //{
                var shoppingResult = new ShoppingCartViewModel
                {
                    CourseId = item.CourseId,
                    TrackingNumber = "",
                    HeadShotImage = tutor.HeadShotImage,
                    FullName = tutor.FirstName + " " + tutor.LastName,
                    CourseTitle = course.Title,
                    CourseSubject = subject.SubjectName,
                    CourseCategory = category.CategorytName,
                    CourseLength = item.CourseType == 1 ? 25 : 50,
                    CourseQuantity = item.Quantity,
                    UnitPrice = (int)item.UnitPrice,
                    TFUnitPrice = (int)course.TwentyFiveMinUnitPrice,
                    FTUnitPrice = (int)course.FiftyMinUnitPrice,
                    Discount = item.Quantity * (int)item.UnitPrice * (1 - discount),
                    SubtotalNTD = item.Quantity * (int)item.UnitPrice,
                    //Coupon = _coupon != null ? coupon.CouponName : "==========",
                    Coupon = "",
                    PaymentType = ""
                };
                result.Add(shoppingResult);
                //}
            }
            return result;
        }
    }
}
