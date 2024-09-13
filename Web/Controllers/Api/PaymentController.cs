using ApplicationCore.Interfaces;
using Infrastructure.ECpay;
using Infrastructure.Enums.ECpay;
using Infrastructure.Interfaces.ECpay;
using System.Collections.Generic;
using System.Security.Policy;

namespace Web.Controllers.Api
{
    [Route("[controller]")]
    [ApiController]
    public class PaymentController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IRepository<ShoppingCart> _shoppingCartRepository;

        public PaymentController(IConfiguration configuration, IRepository<ShoppingCart> shoppingCartRepository)
        {
            _configuration = configuration;
            _shoppingCartRepository = shoppingCartRepository;
        }

        // POST api/payment
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New()
        {
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


            //var shoppingCart = await _shoppingCartRepository.ListAsync(member => member.MemberId == memberId);

            var transaction = new
            {
                // todo: 調整參數及串接專案資料庫
                No = "Ec" + DateTime.Now.ToString("yyyyMMddhhmmss"),
                Description = "測試購物系統",
                Date = DateTime.Now,
                Method = EPaymentMethod.Credit,
                Items = new List<Item>{
                    new Item{
                        CourseName = "手機",
                        UnitPrice = 14000,
                        Quantity = 2
                    },
                    new Item{
                        CourseName = "隨身碟",
                        UnitPrice = 900,
                        Quantity = 10
                    }
                }
            };
            IPayment payment = new PaymentConfiguration()
                .Send.ToApi(
                    url: service.Url)
                .Send.ToMerchant(
                    service.MerchantId)
                .Send.UsingHash(
                    key: service.HashKey,
                    iv: service.HashIV)
                .Return.ToServer(
                    url: service.ServerUrl)
                .Return.ToClient(
                    url: service.ClientUrl)
                .Transaction.New(
                    no: transaction.No,
                    description: transaction.Description,
                    date: transaction.Date)
                .Transaction.UseMethod(
                    method: transaction.Method)
                .Transaction.WithItems(
                    items: transaction.Items)
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

            // 處理後續訂單狀態的更動等等...。

            return Ok("1|OK");
        }

        [HttpGet]
        public IActionResult Success()
        {

            return Redirect("Order/Index");

        }
    }
}
