using ApplicationCore.Dtos;
using ApplicationCore.Entities;
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
        // Create，預設OrderStatus為待付款
        public Task<int> CreateOrderAsync(int memberId, string paymentType, string taxIdNumber);
        //public void CreateBookingAsync();
        // Update，依rtnCode更新OrderStatus
        public Task UpdateOrderTransactionAndStatus(int orderId, string merchantTradeNo, string tradeNo, EOrderStatus rtnCode);
        //public void DeliverId(int orderId);
        public TimeSpan ConvertSmallintToTime(short timeValue);
        public int GetLatestOrder(int memberId);
    }
}
