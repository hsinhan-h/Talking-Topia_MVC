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
        private readonly IRepository<Member> _memberRepository;
        private readonly IRepository<Course> _courseRepository;
        private readonly IRepository<ShoppingCart> _shoppingCartRepository;
        public ShoppingCartService(IRepository<Member> memberRepository, IRepository<Course> courseRepository, IRepository<ShoppingCart> shoppingCartRepository)
        {
            _memberRepository = memberRepository;
            _courseRepository = courseRepository;
            _shoppingCartRepository = shoppingCartRepository;
        }
        public bool IsMember(int memberId)
        {
            return _memberRepository.Any(m => m.MemberId == memberId);
        }
        public bool IsCourse(int courseId)
        {
            return _courseRepository.Any(c => c.CourseId == courseId);
        }
        public bool HasCartItem(int memberId, int courseId)
        {
            return _shoppingCartRepository.Any(m => m.MemberId == memberId &&  m.CourseId == courseId);
        }
        public decimal GetUnitPrice(int courseId, int courseLength)
        {
            decimal price = _courseRepository.List(c => c.CourseId == courseId)
                                             .Select(x => courseLength == 25 ? x.TwentyFiveMinUnitPrice : x.FiftyMinUnitPrice)
                                             .FirstOrDefault();
            return price;
        }
        public async Task<GetAllShoppingCartResult> GetAllShoppingCartAsync(int memberId)
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
                    BookingTime = item.BookingTime,
                }
                );
            }
            var result = new GetAllShoppingCartResult
            {
                GetShoppingCartItems = getItem,
            };
            return result;
        }
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
                        throw new Exception("Order could not be created");
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
    }
}
