using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;
using System.Reflection.Metadata;
using System.Security.Claims;
using Web.Controllers.Api;
using Web.Dtos;
using Web.ViewModels;

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

        public OrderController(ILogger<OrderController> logger,
                               IAntiforgery antiforgery,
                               IOrderService orderService,
                               IMemberService memberService,
                               IShoppingCartService shoppingCartService,
                               OrderViewModelService orderVMService)
        {
            _logger = logger;
            _antiforgery = antiforgery;
            _orderService = orderService;
            _memberService = memberService;
            _shoppingCartService = shoppingCartService;
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
            var memberIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (memberIdClaim == null)
            { return RedirectToAction(nameof(AccountController.Account), "Account"); }
            int memberId = int.Parse(memberIdClaim.Value);
            var result = await _memberService.GetMemberId(memberId);
            if (!result)
            { return RedirectToAction(nameof(AccountController.Account), "Account"); }

            var isDelete = await _shoppingCartService.DeleteCartItemsAsync(memberId);
            if (isDelete == 200) { _logger.LogError("Delete!!!!"); }

            var order = await _orderVMService.GetOrderResultViewModelAsync(memberId);
            if (order == null) return BadRequest("找不到訂單!!!!!!!?");
            var oVM = new OrderResultListViewModel
            {
                OrderResult = order,
            };

            return View(oVM);
        }

        /// <summary>
        /// 給ShoppingCart-Submit的方法
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="paymentType"></param>
        /// <param name="taxIdNumber"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SubmitToOrder([FromBody] ShoppingCartDtos scDto)
        {

            if (scDto == null) return BadRequest("Invalid data received.");

            var memberIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (memberIdClaim == null)
            { return RedirectToAction(nameof(AccountController.Account), "Account"); }
            int memberId = int.Parse(memberIdClaim.Value);
            var result = await _memberService.GetMemberId(memberId);
            if (!result)
            { return RedirectToAction(nameof(AccountController.Account), "Account"); }

            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(scDto.Payment)) scDto.Payment = "CreditCard";

                scDto.TaxIdNumber ??= string.Empty;

                if (scDto.scVM.Count > 0)
                {
                    for (var i = 0; i < scDto.scVM.Count; i++)
                    {
                        var updateResult = await _shoppingCartService.UpdateItem(memberId, scDto.scVM[i].CourseId,
                                                                    scDto.scVM[i].CourseQuantity,
                                                                    scDto.scVM[i].CourseLength,
                                                                    scDto.scVM[i].SubtotalNTD);
                        if (!updateResult) return BadRequest("更新失敗");
                    }
                }
            }

            _orderId = await _orderService.CreateOrderAsync(memberId, scDto.Payment, scDto.TaxIdNumber);

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
                    var requestUrl = Url.Action("New", "Payment", null, Request.Scheme);
                    var tokens = _antiforgery.GetAndStoreTokens(HttpContext);
                    var values = new Dictionary<string, string>
                    {
                          { "_RequestVerificationToken", tokens.RequestToken },
                          { "MemberId",memberId.ToString()}
                    };

                    var content = new FormUrlEncodedContent(values);

                    var response = await client.PostAsync(requestUrl, content);

                    // 這是測試response有沒有成功的區塊
                    if (response.IsSuccessStatusCode)
                    {
                        return Redirect("/api/payment/checkout");
                    }
                    else
                    {
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
