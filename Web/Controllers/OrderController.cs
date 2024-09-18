using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using System.Security.Claims;

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
            //_orderId = 29;
            var order = await _orderVMService.GetOrderResultViewModelAsync(_orderId);
            if (order == null) return BadRequest("找不到訂單!!!!!!!?");
            var result = new OrderResultListViewModel
            {
                OrderResult = order,
            };

            return View(result);
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
        public async Task<IActionResult> SubmitToOrder(string paymentType, string taxIdNumber, List<CartItemUpdateViewModel> Items)
        {
            var memberIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (memberIdClaim == null)
            { return RedirectToAction(nameof(AccountController.Account), "Account"); }
            int memberId = int.Parse(memberIdClaim.Value);
            var result = await _memberService.GetMemberId(memberId);

            if (!result)
            { return RedirectToAction(nameof(AccountController.Account), "Account"); }
            if (string.IsNullOrEmpty(paymentType))
            { return BadRequest("未選擇付款方式"); }

            taxIdNumber ??= string.Empty;

            foreach (var item in Items)
            {
                
                _shoppingCartService.UpdateItem(memberId, item.CourseId, item.CourseQuantity, item.CourseLength, item.SubtotalNTD);
            }

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
