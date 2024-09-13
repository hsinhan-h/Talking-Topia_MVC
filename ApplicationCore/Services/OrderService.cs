using ApplicationCore.Dtos;
using ApplicationCore.Entities;
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
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<OrderDetail> _orderDetailRepository;
        private readonly IRepository<ShoppingCart> _shoppingCartRepository;

        public OrderService(IRepository<ShoppingCart> shoppingCartRepository, IRepository<Order> orderRepository, IRepository<OrderDetail> orderDetailRepository)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _shoppingCartRepository = shoppingCartRepository;
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
    }
}
