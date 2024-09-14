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
        public Task<GetAllOrderResult> GetAllOrder(int memberId);
        public Task<bool> CreateOrderAsync(int memberId, string paymentType);
        // Create預設訂單為待付款
        // 另外要寫Update去更新訂單狀態
        public EOrderStatus ValidatePaymentResult(int rtnCode);
        public TimeSpan ConvertSmallintToTime(short timeValue);
    }
}
