using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    //[Authorize]
    public class OrderController : Controller
    {
        private readonly OrderService _orderService;
        private readonly ShoppingCartService _shoppingCartService;
        // 還要注入PaymentService

        public OrderController(OrderService orderService, ShoppingCartService shoppingCartService)
        {
            _orderService = orderService;
            _shoppingCartService = shoppingCartService;
        }

        /// <summary>
        /// 原ShoppingCartInfo.cshtml頁面
        /// Index應傳入金流API回應的參數
        /// 串金流前先直接從ShoppingCart串過來
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index(int memberId)
        {
            // todo: 從Orders抓資料渲染頁面
            var order = await _orderService.GetData(memberId);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmitOrder(int memberId, string paymentType, short orderStatusId)
        {
            bool isOrderCreated = await _orderService.CreateOrder(memberId,paymentType,orderStatusId);
            if (isOrderCreated)
            {
                return RedirectToAction(nameof(Index), new { MemberId = memberId });
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
