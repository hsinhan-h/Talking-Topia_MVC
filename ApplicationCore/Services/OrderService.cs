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

        public async Task<GetAllOrderResult> GetAllOrder(int memberId)
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
            var result = new GetAllOrderResult
            {
                GetOrderItems = getOrderItem,
            };
            return result;
        }

        // 創建訂單並處理交易(需刷新交易狀態/OrderStatusId，另外invice尚未考慮)
        public async Task<bool> CreateOrderAsync(int memberId,string paymentType)
        {
            using var transaction = _transaction.BeginTransActionAsync();
            {
                try
                {
                    // 如果購物車為空，則無需處理
                    if (!_shoppingCartService.HasCartItem(memberId))
                    {
                        throw new InvalidOperationException("購物車為空，無法生成訂單。");
                    }
                    //todo: 新增Orders資料列，OrderStatus為待付款
                    var order = await _shoppingCartRepository.ListAsync(x => x.MemberId == memberId);
                    var totalPrice = order.Sum(x => x.Quantity * x.UnitPrice);
                    //todo: 成功或失敗都應先寫入資料庫，由訂單狀態去判定成功與否就好
                    var orders = new Order
                    {
                        MemberId = memberId,
                        PaymentType = paymentType,
                        TotalPrice = totalPrice,
                        TransactionDate = DateTime.Now,
                        InvoiceType = 1,
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
        /// <summary>
        /// 驗證綠界API回傳的結果
        /// </summary>
        /// <param name="rtnCode"></param>
        /// <returns></returns>
        public TimeSpan ConvertSmallintToTime(short timeValue)
        {
            int hours = timeValue / 100;
            int minutes = timeValue % 100;

            return new TimeSpan(hours, minutes, 0);
        }

    }
}
