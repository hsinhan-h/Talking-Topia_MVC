using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Infrastructure.Configurations.ECpay;
using Infrastructure.ECpay;
using Infrastructure.Enums.ECpay;
using Infrastructure.Interfaces.ECpay;
using Infrastructure.Service;
using System.Security.Claims;

namespace Web.Controllers.Api
{
    [Route("[controller]")]
    [ApiController]
    public class PaymentController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ECpayService _eCpayService;
        private readonly IOrderService _orderService;
        private readonly IMemberService _memberService;
        private int _memberId;

        public PaymentController(IConfiguration configuration, ECpayService eCpayService, IOrderService orderService, IMemberService memberService)
        {
            _configuration = configuration;
            _eCpayService = eCpayService;
            _orderService = orderService;
            _memberService = memberService;
        }

        [HttpPost]
        public IActionResult New([FromForm] string memberId)
        {
            if (string.IsNullOrEmpty(memberId) || !int.TryParse(memberId, out _memberId))
            {
                return BadRequest("memberId 不存在或無效");
            }

            return RedirectToAction("checkout", new { memberId = _memberId });
        }


        // POST api/payment

        [HttpGet("checkout")]
        public async Task<IActionResult> CheckOut(int memberId)
        {

            // 資料藏在appsettings.json及UserSecret(目前註解中)
            var service = new
            {
                Url = _configuration["ECpay:Service:Url"],
                MerchantId = _configuration["ECpay:Service:MerchantId"],
                HashKey = _configuration["ECpay:Service:HashKey"],
                HashIV = _configuration["ECpay:Service:HashIV"],
                ServerUrl = _configuration["ECpay:Service:ServerUrl"],
                ClientUrl = _configuration["ECpay:Service:ClientUrl"]
            };

            var transaction = new
            {
                No = "Ec" + DateTime.Now.ToString("yyyyMMddhhmmss"),
                Description = "測試購物系統",
                Date = DateTime.Now,
                Method = EPaymentMethod.Credit,
                Items = await _eCpayService.GetItemsToECStageDtoAsync(memberId)
            };

            IPayment payment = new PaymentConfiguration()
                .Send.ToApi(url: service.Url)
                .Send.ToMerchant(service.MerchantId)
                .Send.UsingHash(key: service.HashKey, iv: service.HashIV)
                .Return.ToServer(url: service.ServerUrl)
                .Return.ToClient(url: service.ClientUrl)
                .Transaction.New(no: transaction.No, description: transaction.Description, date: transaction.Date)
                .Transaction.UseMethod(method: transaction.Method)
                .Transaction.WithItems(items: transaction.Items)
                .Generate();

            return View(payment);
        }

        [HttpPost("callback")]
        public IActionResult Callback(PaymentResult result)
        {
            var hashKey = _configuration["ECpay:Service:HashKey"];
            var hashIV = _configuration["ECpay:Service:HashIV"];
            EOrderStatus orderStatus;
            // 務必判斷檢查碼是否正確。
            if (!CheckMac.PaymentResultIsValid(result, hashKey, hashIV))
            {
                orderStatus = EOrderStatus.Failed;
                return BadRequest();
            }

            var memberIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (memberIdClaim == null)
            { return RedirectToAction(nameof(AccountController.Account), "Account"); }
            int memberId = int.Parse(memberIdClaim.Value);

            orderStatus = EOrderStatus.Success;
            var orderId = _orderService.GetLatestOrder(memberId);
            _orderService.UpdateOrderTransactionAndStatus(orderId, result.MerchantTradeNo, result.TradeNo, orderStatus);

            return Ok("1|OK");
        }

        [HttpGet]
        public IActionResult Success()
        {

            return Redirect("Order/Index");

        }
    }
}
