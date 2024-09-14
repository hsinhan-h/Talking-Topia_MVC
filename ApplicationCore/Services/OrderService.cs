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
    public class OrderService : IOrderService
    {

        private readonly ITransaction _transaction;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<OrderDetail> _orderDetailRepository;
        private readonly IRepository<ShoppingCart> _shoppingCartRepository;
        private readonly IShoppingCartService _shoppingCartService;
        public OrderService(ITransaction transaction, IRepository<Order> orderRepository, IRepository<OrderDetail> orderDetailRepository, IRepository<ShoppingCart> shoppingCartRepository, IShoppingCartService shoppingCartService)
        {
            _transaction = transaction;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _shoppingCartRepository = shoppingCartRepository;
            _shoppingCartService = shoppingCartService;
        }

        public async Task<GetAllOrderResultDto> GetAllOrder(int memberId)
        {
            var orders = await _orderRepository.ListAsync(item => item.MemberId == memberId);
            var getOrderItem = new List<GetOrderItem>();
            foreach (var order in orders)
            {
                getOrderItem.Add
                (new GetOrderItem
                {
                    OrderId = order.OrderId,
                    MemberId = order.MemberId,
                    PaymentType = order.PaymentType,
                    TotalPrice = order.TotalPrice,
                    TransactionDate = order.TransactionDate,
                    CouponPrice = order.CouponPrice,
                    TaxIdNumber = order.TaxIdNumber,
                    InvoiceType = order.InvoiceType,
                    VATNumber = order.VATNumber,
                    SentVatemail = order.SentVatemail,
                    OrderStatusId = order.OrderStatusId,
                }
                );
            }
            var result = new GetAllOrderResultDto
            {
                GetOrderItems = getOrderItem,
            };
            return result;
        }

        /// <summary>
        /// 建單並串至綠界(callback後會再呼叫Update刷新OrderStatusId)
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="paymentType"></param>
        /// <param name="taxIdNumber"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> CreateOrderAsync(int memberId, string paymentType, string taxIdNumber)
        {
            Console.WriteLine($"memberId: {memberId}, paymentType: {paymentType}, taxIdNumber: {taxIdNumber}");
            using var transaction = _transaction.BeginTransActionAsync();
            {
                try
                {
                    if (!_shoppingCartService.HasCartItem(memberId))
                    {
                        throw new InvalidOperationException("購物車為空，無法生成訂單。");
                    }
                    var shoppingCartItem = await _shoppingCartRepository.ListAsync(m => m.MemberId == memberId);
                    var totalPrice = shoppingCartItem.Sum(item => item.Quantity * item.UnitPrice);

                    // 成功或失敗都應先寫入資料庫，由訂單狀態去判定成功與否就好
                    var orders = new Order
                    {
                        MemberId = memberId,
                        PaymentType = paymentType,
                        TotalPrice = totalPrice,
                        TransactionDate = DateTime.Now,
                        TaxIdNumber = taxIdNumber,
                        InvoiceType = taxIdNumber == null ? (short)EInvoiceType.NormalInvoice : (short)EInvoiceType.GUIInvoice,
                        // VATNumber要等綠界交易完成回來才會有紀錄
                        // SentVATEmail預設為Member的Email?
                        OrderStatusId = (short)EOrderStatus.Outstanding,
                        Cdate = DateTime.Now,
                    };
                    var result = await _orderRepository.AddAsync(orders);
                    if (await _orderRepository.FirstOrDefaultAsync(x => x.OrderId == result.OrderId) != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Unexpected error: {ex.Message}");
                }
            }
        }

        public async Task<bool> UpdateOrderAsync(int orderId, EOrderStatus orderStatus)
        {
            using var transaction = _transaction.BeginTransActionAsync();
            {
                try
                {
                    var order = await _orderRepository.GetByIdAsync(orderId);
                    
                    if (orderStatus == EOrderStatus.Success)
                    {
                        order.OrderStatusId = (short)EOrderStatus.Success;
                        await _orderRepository.UpdateAsync(order);
                        return true;
                    }
                    else if (orderStatus == EOrderStatus.Failed) { return false; }
                    else { return false; }
                }
                catch (Exception ex)
                {
                    throw new Exception($"UpDate error: {ex.Message}");
                }
            }
        }

        public TimeSpan ConvertSmallintToTime(short timeValue)
        {
            int hours = timeValue / 100;
            int minutes = timeValue % 100;

            return new TimeSpan(hours, minutes, 0);
        }
    }
}
