using ApplicationCore.Interfaces;
using Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;
using Web.Controllers.Api;

namespace Web.Controllers
{
    //[Authorize]
    public class OrderController : Controller
    {
        private readonly ILogger _logger;
        private readonly IOrderService _orderService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly PaymentResultService _paymentResultService;
        private readonly ShoppingCartViewModelService _shoppingCartVMService;

        public OrderController(ILogger logger, IOrderService orderService, IShoppingCartService shoppingCartService, PaymentResultService paymentResultService, ShoppingCartViewModelService shoppingCartVMService)
        {
            _logger = logger;
            _orderService = orderService;
            _shoppingCartService = shoppingCartService;
            _paymentResultService = paymentResultService;
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
        public async Task<IActionResult> GetData(int orderId, int rtnCode)
        {
            var orderStatus = _paymentResultService.ValidatePaymentResult(rtnCode);
            var result = await _orderService.UpdateOrderAsync(orderId, orderStatus);
            var order = await _orderService.GetAllOrder(orderId);
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
        public async Task<IActionResult> SubmitToOrder(int memberId, string paymentType, string taxIdNumber)
        {
            //_logger.LogInformation("SubmitToOrder action triggered with memberId: {MemberId}, paymentType: {PaymentType}, taxIdNumber: {TaxIdNumber}",
            //                memberId, paymentType, taxIdNumber);
            if (memberId < 0 )
            {
                //_logger.LogWarning("SubmitToOrder: Invalid memberId: {MemberId}", memberId);
                return BadRequest("缺少必要的參數");
            }
            if (string.IsNullOrEmpty(paymentType))
            {
                //_logger.LogWarning("SubmitToOrder: Payment type not selected.");
                return BadRequest("未選擇付款方式");
            }
            if (string.IsNullOrEmpty(taxIdNumber))
            {
                //_logger.LogInformation("SubmitToOrder: taxIdNumber is empty, setting it to an empty string.");
                taxIdNumber = "";
            }

            //_logger.LogInformation("SubmitToOrder: Calling _orderService.CreateOrderAsync for memberId: {MemberId}", memberId);
            bool isOrderCreated = await _orderService.CreateOrderAsync(memberId, paymentType, taxIdNumber);
            if (isOrderCreated)
            {
                //_logger.LogInformation("SubmitToOrder: Order created successfully, redirecting to PaymentController.New.");
                 return Content("Order created successfully. Redirecting to PaymentController.New.");
                //return RedirectToAction(nameof(PaymentController.New), "Payment");
            }
            else
            {
                //_logger.LogWarning("SubmitToOrder: Order creation failed for memberId: {MemberId}", memberId);
                // todo: 可以帶訊息替換View內的訊息嗎？還是需要再做失敗頁面?
                 return Content($"Order creation failed. Redirecting to OrderFailed for memberId: {memberId}");
                //return RedirectToAction(nameof(OrderFailed), new { MemberId = memberId });
            }
        }

        public IActionResult OrderFailed()
        {
            return View();
        }
    }
}
