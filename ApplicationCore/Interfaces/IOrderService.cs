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
        public Task<GetAllOrderResultDto> GetAllOrder(int memberId);
        // Create，預設OrderStatus為待付款
        public Task<int> CreateOrderAsync(int memberId, string paymentType, string taxIdNumber);
        //public void CreateBookingAsync();
        // Update，依rtnCode更新OrderStatus
        public void UpdateOrderTransactionAndStatus(int orderId, EOrderStatus rtnCode, string transactionNo);
        //public void DeliverId(int orderId);
        public TimeSpan ConvertSmallintToTime(short timeValue);
    }
}
