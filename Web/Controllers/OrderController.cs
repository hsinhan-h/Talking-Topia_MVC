using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Antiforgery;
using System.Net;

namespace Web.Controllers
{
    //[Authorize]
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IAntiforgery _antiforgery;
        private readonly IOrderService _orderService;
        private readonly IMemberService _memberService;
        private readonly OrderViewModelService _orderVMService;
        private int _orderId;

        public OrderController(ILogger<OrderController> logger, IAntiforgery antiforgery, IOrderService orderService, IMemberService memberService, OrderViewModelService orderVMService)
        {
            _logger = logger;
            _antiforgery = antiforgery;
            _orderService = orderService;
            _memberService = memberService;
            _orderVMService = orderVMService;
        }

        /// <summary>
        /// 交易成功導回頁
        /// </summary>
        public IActionResult Index()
        {

            return View();
        }

        /// <summary>
        /// 原ShoppingCartInfo.cshtml頁面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetData()
        {

            var order = await _orderVMService.GetData(_orderId);
            if (order == null) return BadRequest("找不到訂單!!!!!!!?");

            return View(order);
        }

        /// <summary>
        /// 給ShoppingCart-Submit的方法
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="paymentType"></param>
        /// <param name="taxIdNumber"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmitToOrder(int memberId, string paymentType, string taxIdNumber)
        {
            //var user = HttpContext.User.Identity.Name;
            //var memberId = await _memberService.GetMemberId(user);
            if (!_memberService.IsMember(memberId))
            { return RedirectToAction(nameof(AccountController.Account), "Account"); }
            if (string.IsNullOrEmpty(paymentType))
            { return BadRequest("未選擇付款方式"); }
            if (string.IsNullOrEmpty(taxIdNumber))
            { taxIdNumber = ""; }

            _orderId = await _orderService.CreateOrderAsync(memberId, paymentType, taxIdNumber);

            if (_orderId > 0)
            {
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
                        { "__RequestVerificationToken", tokens.RequestToken },  // 添加防偽驗證令牌
                         { "OrderId", _orderId.ToString() }
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
            }
        }
    }
}
