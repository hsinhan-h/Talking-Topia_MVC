using ApplicationCore.Dtos;
using ApplicationCore.Entities;
using ApplicationCore.Enums;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IRepository<ShoppingCart> _shoppingCartRepository;
        private readonly IRepository<Course> _courseRepository;
        public ShoppingCartService(IRepository<ShoppingCart> shoppingCartRepository, IRepository<Course> courseRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _courseRepository = courseRepository;
        }
        public bool HasCartItem(int memberId)
        {
            return _shoppingCartRepository.Any(m => m.MemberId == memberId);
        }
        public bool HasCartItem(int memberId, int courseId)
        {
            return _shoppingCartRepository.Any(m => m.MemberId == memberId && m.CourseId == courseId);
        }
        public decimal GetUnitPrice(int courseId, int courseLength)
        {
            decimal price = _courseRepository.List(c => c.CourseId == courseId)
                                             .Select(x => courseLength == 25 ? x.TwentyFiveMinUnitPrice : x.FiftyMinUnitPrice)
                                             .FirstOrDefault();
            return price;
        }
        public async Task<GetAllShoppingCartResultDto> GetAllShoppingCartAsync(int memberId)
        {
            var items = await _shoppingCartRepository.ListAsync(item => item.MemberId == memberId);
            var getItem = new List<GetAllShoppingCartItem>();
            foreach (var item in items)
            {
                getItem.Add
                (new GetAllShoppingCartItem
                {
                    ShoppingCartId = item.ShoppingCartId,
                    CourseId = item.CourseId,
                    UnitPrice = item.UnitPrice,
                    Quantity = item.Quantity,
                    TotalPrice = item.TotalPrice,
                    MemberId = item.MemberId,
                    CourseType = item.CourseType,
                    BookingDate = item.BookingDate,
                    //BookingTime = item.BookingTime,
                }
                );
            }
            var result = new GetAllShoppingCartResultDto
            {
                GetShoppingCartItems = getItem,
            };
            return result;
        }
        /// <summary>
        /// 無預約時段，單純將課程加入購物車
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="courseId"></param>
        /// <param name="courseLength"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<int> CreateShoppingCartAsync(int memberId, int courseId, int courseLength, int quantity)
        {
            try
            {
                decimal unitPrice = GetUnitPrice(courseId, courseLength);
                if (memberId < 1 || courseId < 1 || courseLength < 1 || quantity < 1 || unitPrice < 1)
                {
                    throw new ArgumentException("Invalid input data");
                }
                var shoppingCartEntity = new ShoppingCart()
                {
                    CourseId = courseId,
                    UnitPrice = unitPrice,
                    Quantity = (short)quantity,
                    TotalPrice = unitPrice * quantity,
                    MemberId = memberId,
                    CourseType = courseLength == 25 ? (short)ECourseType.TwentyFiveMinUnitPrice : (short)ECourseType.FiftyMinUnitPrice,
                    Cdate = DateTime.Now,
                };
                var shoppingCart = await _shoppingCartRepository.AddAsync(shoppingCartEntity);
                if (shoppingCart is null)
                {
                    throw new Exception("Shopping Cart could not be created");
                }

                return shoppingCart.MemberId;
            }
            catch (Exception ex)
            {
                throw new Exception($"Unexpected error: {ex.Message}");
            }
        }
        public async Task<int> CreateShoppingCartAsync(int memberId, int courseId, int courseLength, int quantity, DateTime bookingDate, short bookingTime)
        {
            try
            {
                decimal unitPrice = GetUnitPrice(courseId, courseLength);
                if (memberId < 1 || courseId < 1 || courseLength < 1 || quantity < 1 || unitPrice < 1)
                {
                    throw new ArgumentException("Invalid input data");
                }
                var shoppingCartEntity = new ShoppingCart()
                {
                    CourseId = courseId,
                    UnitPrice = unitPrice,
                    Quantity = (short)quantity,
                    TotalPrice = unitPrice * quantity,
                    MemberId = memberId,
                    CourseType = courseLength == 25 ? (short)ECourseType.TwentyFiveMinUnitPrice : (short)ECourseType.FiftyMinUnitPrice,
                    Cdate = DateTime.Now,
                    BookingDate = bookingDate,
                    //BookingTime = bookingTime,
                };
                var shoppingCart = await _shoppingCartRepository.AddAsync(shoppingCartEntity);
                if (shoppingCart is null)
                {
                    throw new Exception("Shopping Cart could not be created");
                }

                return shoppingCart.MemberId;
            }
            catch (Exception ex)
            {
                throw new Exception($"Unexpected error: {ex.Message}");
            }
        }
        public void DeleteCartItem(int memberId, int courseId)
        {
            try
            {
                var target = _shoppingCartRepository.FirstOrDefault(x => x.MemberId == memberId && x.CourseId == courseId);
                _shoppingCartRepository.Delete(target);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"無法找到Shopping Cart Item: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<GetItemsToECStageDto> GetItemsToECStageDtoAsync(int memberId)
        {
            var items = await _shoppingCartRepository.ListAsync(item => item.MemberId == memberId);
            var result = new List<GetItemToECStage>();
            foreach (var item in items)
            {
                var course = await _courseRepository.GetByIdAsync(item.CourseId);
                result.Add(new GetItemToECStage
                {
                    CourseName = course.Title,
                    UnitPrice = item.UnitPrice,
                    Quantity = item.Quantity,
                    CourseType = item.CourseType,
                });
            }
            return new GetItemsToECStageDto { GetItemsToECStage = result };
        }
    }
}
