using System.Runtime.InteropServices;

namespace Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ShoppingCartService _shoppingCartService;
        public ShoppingCartController(ShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }
        /// <summary>
        /// ShoppingCart頁面
        /// Course頁面應回傳時長與堂數的值
        /// 我要怎麼從前端的時長、堂數或價格去對應db內的時長與價格
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Index(int memberId, int courseId, int courseLength, int quantity)
        {
            //todo: 確認是否為有效member及course
            var member = await _shoppingCartService.GetMemberData(memberId);
            var course = await _shoppingCartService.GetCourseData(courseId);

            //todo: 確認ShoppingCart是否有資料
            var cartData = await _shoppingCartService.GetShoppingCartData(member, course, courseLength, quantity);

            //todo: 新增課程至購物車

            return View(cartData);

        }
        [HttpPost]
        public async Task<IActionResult> GetCart(int memberId, int courseId)
        {
            //todo: 確認是否為有效member
            var member = await _shoppingCartService.GetMemberData(memberId);

            //todo: 確認ShoppingCart是否有資料

            return View("Index");

        }
    }
}
