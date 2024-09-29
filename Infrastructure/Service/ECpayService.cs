using ApplicationCore.Dtos;
using ApplicationCore.Entities;
using ApplicationCore.Enums;
using ApplicationCore.Interfaces;
using Infrastructure.ECpay;
using Infrastructure.Interfaces.ECpay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public class ECpayService
    {

        private readonly IRepository<ShoppingCart> _shoppingCartRepository;
        private readonly IRepository<Course> _courseRepository;

        public ECpayService(IRepository<ShoppingCart> shoppingCartRepository, IRepository<Course> courseRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _courseRepository = courseRepository;
        }

        public async Task<List<Item>> GetItemsToECStageDtoAsync(int memberId)
        {
            var items = await _shoppingCartRepository.ListAsync(item => item.MemberId == memberId);
            var result = new List<Item>();
            foreach (var item in items)
            {
                var course = await _courseRepository.GetByIdAsync(item.CourseId);
                result.Add(new Item
                {
                    CourseName = course.Title,
                    UnitPrice = (int)item.UnitPrice,
                    SubPrice = (int)item.TotalPrice,
                    Quantity = item.Quantity,
                    CourseType = item.CourseType,
                });
            }
            return result;
        }
    }
}
