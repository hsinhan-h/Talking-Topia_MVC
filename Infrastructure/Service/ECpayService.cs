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

        /// <summary>
        /// 驗證綠界API回傳的結果
        /// </summary>
        /// <param name="rtnCode"></param>
        /// <returns></returns>
        public EOrderStatus ValidatePaymentResult(int rtnCode)
        {
            //todo: int rtnCode = 2(ATM) || 10100073(CVS / BARCODE)為成功，其餘皆為失敗
            //是否先判斷rtnCodeType為ATM或CVS/BARCODE
            //todo: 訂單加密、解密由EC API端實作，但ServerSide要考慮傳送與接收相同檢查碼的問題
            if (rtnCode == 2 || rtnCode == 10100073)
            {
                return EOrderStatus.Success;
            }
            else
            {
                return EOrderStatus.Failed;
            }
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
                    Quantity = item.Quantity,
                    CourseType = item.CourseType,
                });
            }
            return result;
        }
    }
}
