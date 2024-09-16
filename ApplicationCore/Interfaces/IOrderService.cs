using ApplicationCore.Dtos;
using ApplicationCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IOrderService
    {
        public Task<GetAllOrderResultDto> GetAllOrder(int memberId);
        // Create，預設OrderStatus為待付款
        public Task<bool> CreateOrderAsync(int memberId, string paymentType, string taxIdNumber);
        // Update，依rtnCode更新OrderStatus
        public Task<bool> UpdateOrderAsync(int OrderId, EOrderStatus rtnCode);
        public TimeSpan ConvertSmallintToTime(short timeValue);
    }
}
