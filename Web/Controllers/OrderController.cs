using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    //[Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly ShoppingCartViewModelService _shoppingCartVMService;

        public OrderController(IOrderService orderService, IShoppingCartService shoppingCartService, ShoppingCartViewModelService shoppingCartVMService)
        {
            _orderService = orderService;
            _shoppingCartService = shoppingCartService;
            _shoppingCartVMService = shoppingCartVMService;
        }

        /// <summary>
        /// 交易成功導回頁
        /// </summary>
        /// <param name="memberId"></param>
        /// <returns></returns>
        public IActionResult Index(int memberId)
        {
            return View();
        }

        /// <summary>
        /// 原ShoppingCartInfo.cshtml頁面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetData(int memberId)
        {
            var order = await _orderService.GetAllOrder(memberId);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        /// <summary>
        /// 給ShoppingCart-Submit的方法
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="paymentType"></param>
        /// <param name="orderStatusId"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmitOrder(int memberId, string paymentType, short orderStatusId)
        {
            var cartItem = await _shoppingCartService.GetAllShoppingCartAsync(memberId);
            bool isOrderCreated = await _orderService.CreateOrderAsync(memberId, paymentType);
            if (isOrderCreated)
            {
                return RedirectToAction(nameof(GetData), new { MemberId = memberId });
            }
            else
            {
                // todo: 可以帶訊息替換View內的訊息嗎？還是需要再做失敗頁面?
                return RedirectToAction(nameof(OrderFailed), new { MemberId = memberId });
            }
        }

        public IActionResult OrderFailed()
        {
            return View();
        }
    }
}
