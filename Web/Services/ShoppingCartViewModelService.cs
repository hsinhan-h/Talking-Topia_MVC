namespace Web.Services
{
    public class ShoppingCartViewModelService
    {
        private readonly IRepository _repository;
        public ShoppingCartViewModelService(IRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// 轉成View Model
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
    }
}
