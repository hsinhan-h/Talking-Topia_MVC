using ApplicationCore.Interfaces;
using Infrastructure.Configurations.ECpay;
using Infrastructure.ECpay;
using Infrastructure.Enums.ECpay;
using Infrastructure.Interfaces.ECpay;
using Infrastructure.Service;

namespace Web.Controllers.Api
{
    [Route("[controller]")]
    [ApiController]
    public class PaymentController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ECpayService _eCpayService;
        private readonly IOrderService _orderService;
        //private readonly IPaymentTransactionConfiguration _paymentTransactionConfiguration;
        private int _orderId;

        public PaymentController(IConfiguration configuration, ECpayService eCpayService, IOrderService orderService)
        {
            _configuration = configuration;
            _eCpayService = eCpayService;
            _orderService = orderService;
            //_paymentTransactionConfiguration = paymentTransactionConfiguration;
        }



        // POST api/payment
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult New([FromForm] string orderId)
        {
            if (string.IsNullOrEmpty(orderId) || !int.TryParse(orderId, out _orderId))
            {
                return BadRequest("OrderId 不存在或無效");
            }

            return RedirectToAction("checkout");
        }

        [HttpGet("checkout")]
        public async Task<IActionResult> CheckOut()
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
                Items = await _eCpayService.GetItemsToECStageDtoAsync(1)
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

            // 務必判斷檢查碼是否正確。
            if (!CheckMac.PaymentResultIsValid(result, hashKey, hashIV)) return BadRequest();

            var orderStatus = EOrderStatus.Success;
            _orderService.UpdateOrderTransactionAndStatus(_orderId, result.MerchantTradeNo, result.TradeNo ,orderStatus);

            return Ok("1|OK");
        }

        [HttpGet]
        public IActionResult Success()
        {

            return Redirect("Order/Index");

        }
    }
}
