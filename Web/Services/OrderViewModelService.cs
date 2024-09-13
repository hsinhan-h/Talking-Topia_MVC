using ApplicationCore.Interfaces;

namespace Web.Services
{
    public class OrderViewModelService
    {
        private readonly IOrderService _orderService;

        public OrderViewModelService(IOrderService orderService)
        {
            _orderService = orderService;
        }
    }
}
