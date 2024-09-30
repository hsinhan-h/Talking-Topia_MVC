using ApplicationCore.Interfaces;
using ApplicationCore.Services;
using Infrastructure.Configurations.ECpay;
using Infrastructure.ECpay;
using Infrastructure.Enums.ECpay;
using Infrastructure.Interfaces.ECpay;
using Infrastructure.Service;
using System.Security.Claims;
using Web.Dtos;

namespace Web.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PaymentController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<PaymentController> _logger;
        private readonly ECpayService _eCpayService;
        private readonly IOrderService _orderService;
        private readonly IMemberService _memberService;
        //private int _memberId;

        public PaymentController(IConfiguration configuration,
                                 ECpayService eCpayService,
                                 IOrderService orderService,
                                 IMemberService memberService,
                                 ILogger<PaymentController> logger)
        {
            _configuration = configuration;
            _eCpayService = eCpayService;
            _orderService = orderService;
            _memberService = memberService;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult New([FromBody] OrderDto memberId)
        {
            if (memberId == null)
            {
                _logger.LogError($"memberId.MemberId就是{memberId.MemberId}");
                return BadRequest("Invalid data received.");
            }

            return RedirectToAction(nameof(CheckOut), "Payment");
            
        }


        // POST api/payment

        [HttpGet("checkout")]
        public async Task<IActionResult> CheckOut()
        {

            var memberIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (memberIdClaim == null)
            { _logger.LogWarning(DateTime.Now.ToLongTimeString() + $"memberIdClaim這王八是null!!!!!!"); }
            int memberId = int.Parse(memberIdClaim.Value);

            // 這裡抓到的是0
            _logger.LogWarning(DateTime.Now.ToLongTimeString() + $"memberIdR是 {memberId}");

            // 資料藏在appsettings.json及UserSecret
            var service = new
            {
                Url = _configuration["ECpay:Service:Url"],
                MerchantId = _configuration["ECpay:Service:MerchantId"],
                HashKey = _configuration["ECpay:Service:HashKey"],
                HashIV = _configuration["ECpay:Service:HashIV"],
                ServerUrl = _configuration["ECpay:Service:ServerUrl"],
                ClientUrl = _configuration["ECpay:Service:ClientUrl"]
            };

            _logger.LogWarning(DateTime.Now.ToLongTimeString() + $"service是 {service}");

            var transaction = new
            {
                No = "Ec" + DateTime.Now.ToString("yyyyMMddhhmmss"),
                Description = "測試購物系統",
                Date = DateTime.Now,
                Method = EPaymentMethod.Credit,
                Items = await _eCpayService.GetItemsToECStageDtoAsync(memberId)
            };

            _logger.LogWarning(DateTime.Now.ToLongTimeString() + $"transaction是 {transaction}");

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

            _logger.LogWarning(DateTime.Now.ToLongTimeString() + $"payment是 {payment}");

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
