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

        /// <summary>
        /// Read Data
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="courseId"></param>
        /// <param name="courseLength"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
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

        /// <summary>
        /// Create Data
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="courseId"></param>
        /// <param name="courseLength"></param>
        /// <param name="quantity"></param>
        /// <param name="unitPrice"></param>
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
                throw new DbUpdateException($"無法存入ShoppingCart: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Unexpected error: {ex.Message}");
            }
        }

        /// <summary>
        /// Delete Data
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="courseId"></param>
        public void DeleteCartItem(int memberId, int courseId)
        {
            try
            {
                var target = _repository.GetAll<ShoppingCart>()
                                        .FirstOrDefault(x => x.MemberId == memberId && x.CourseId == courseId);
                _repository.Delete(target);
                _repository.SaveChanges();
            }
            catch(ArgumentException ex)
            {
                throw new ArgumentException($"無法找到Shopping Cart Item: {ex.Message}");
            }
            catch (DbUpdateException ex)
            {
                throw new DbUpdateException($"無法刪除Shopping Cart: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public enum CourseTypes
        {
            TwentyFiveMinUnitPrice = 1,
            FiftyMinUnitPrice = 2,
        }
    }
}
