using ApplicationCore.Interfaces;
using Infrastructure.Service;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Web.Controllers.Api;

namespace Web.Controllers
{
    //[Authorize]
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IAntiforgery _antiforgery;
        private readonly IOrderService _orderService;
        private readonly IMemberService _memberService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly OrderViewModelService _orderVMService;
        private readonly ECpayService _paymentResultService;
        private readonly ShoppingCartViewModelService _shoppingCartVMService;

        public OrderController(ILogger<OrderController> logger, IAntiforgery antiforgery, IOrderService orderService, IMemberService memberService, IShoppingCartService shoppingCartService, OrderViewModelService orderVMService, ECpayService paymentResultService, ShoppingCartViewModelService shoppingCartVMService)
        {
            _logger = logger;
            _antiforgery = antiforgery;
            _orderService = orderService;
            _memberService = memberService;
            _shoppingCartService = shoppingCartService;
            _orderVMService = orderVMService;
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
            //var user = HttpContext.User.Identity.Name;
            //var member = _memberService.GetMemberId(user);
            return View();
        }

        /// <summary>
        /// 原ShoppingCartInfo.cshtml頁面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetData(int rtnCode, int orderId = 20)
        {
            var orderStatus = _paymentResultService.ValidatePaymentResult(rtnCode);
            var result = await _orderService.UpdateOrderAsync(orderId, orderStatus);
            //var order = await _orderService.GetAllOrder(orderId);
            var order = await _orderVMService.GetData(orderId);
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
            //var user = HttpContext.User.Identity.Name;
            //var member = _memberService.GetMemberId(user);
            if (memberId < 0)
            { return BadRequest("缺少必要的參數"); }
            if (string.IsNullOrEmpty(paymentType))
            { return BadRequest("未選擇付款方式"); }
            if (string.IsNullOrEmpty(taxIdNumber))
            { taxIdNumber = ""; }

            bool isOrderCreated = await _orderService.CreateOrderAsync(memberId, paymentType, taxIdNumber);
            if (isOrderCreated)
            {
                //return RedirectToAction(nameof(PaymentController.New), "Payment");

                // 使用 HttpClientHandler 來處理 Cookies，確保 AntiForgeryToken 和 Session 被維護
                var handler = new HttpClientHandler
                {
                    UseCookies = true,
                    CookieContainer = new CookieContainer()
                };

                using (var client = new HttpClient(handler))
                {
                    // 生成要請求的 URL，指向 PaymentController 的 New Action
                    var requestUrl = Url.Action("New", "Payment", null, Request.Scheme);

                    // 生成防偽驗證令牌
                    var tokens = _antiforgery.GetAndStoreTokens(HttpContext);

                    // 構建 POST 請求的表單資料，包括防偽驗證令牌
                    var values = new Dictionary<string, string>
                    {
                        { "__RequestVerificationToken", tokens.RequestToken }  // 添加防偽驗證令牌
                    };

                    // 將表單資料編碼成 x-www-form-urlencoded 格式
                    var content = new FormUrlEncodedContent(values);

                    // 發送 POST 請求到 PaymentController.New
                    var response = await client.PostAsync(requestUrl, content);

                    // 檢查回應狀態
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("CheckOut", "Payment");
                    }
                    else
                    {
                        // 讀取回應的錯誤訊息
                        var errorResponse = await response.Content.ReadAsStringAsync();
                        return BadRequest($"發送請求到 PaymentController.New 失敗，狀態碼：{response.StatusCode}, 錯誤訊息: {errorResponse}");
                    }
                }
            }
            else
            {
                // 如果訂單創建失敗，返回 BadRequest 錯誤訊息
                return BadRequest("發送請求到 PaymentController.New 失敗。");
                // todo: 可以帶訊息替換View內的訊息嗎？還是需要再做失敗頁面?
                //return RedirectToAction(nameof(OrderFailed), new { MemberId = memberId });
            }
        }

        public IActionResult OrderFailed()
        {
            return View();
        }
    }
}
