using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    //[Authorize]
    public class OrderController : Controller
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IOrderService _orderService;
        private readonly ShoppingCartViewModelService _shoppingCartService;

        public OrderController(IRepository<Order> orderRepository, IOrderService orderService, ShoppingCartViewModelService shoppingCartService)
        {
            _orderRepository = orderRepository;
            _orderService = orderService;
            _shoppingCartService = shoppingCartService;
        }

        // 還要注入PaymentService



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
        /// Index應傳入金流API回應的參數
        /// </summary>
        /// <returns></returns>
        //[HttpGet]
        //public async Task<IActionResult> GetData(int memberId)
        //{
        //    // todo: 從Orders抓資料渲染頁面
        //    var order = await _orderService.GetData(memberId);
        //    if (order == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(order);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> SubmitOrder(int memberId, string paymentType, short orderStatusId)
        //{
        //    bool isOrderCreated = await _orderService.CreateOrder(memberId,paymentType,orderStatusId);
        //    if (isOrderCreated)
        //    {
        //        return RedirectToAction(nameof(GetData), new { MemberId = memberId });
        //    }
        //    else
        //    {
        //        // todo: 可以帶訊息替換View內的訊息嗎？還是需要再做失敗頁面?
        //        return RedirectToAction(nameof(OrderFailed), new { MemberId = memberId });
        //    }
        //}

        public IActionResult OrderFailed()
        {
            return View();
        }
    }
}
