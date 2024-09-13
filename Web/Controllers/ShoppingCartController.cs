using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Runtime.InteropServices;
using Web.Entities;

namespace Web.Controllers
{
    //[Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _shoppingCartService;
        private readonly ShoppingCartViewModelService _shoppingCartViewModelService;

        public ShoppingCartController(IShoppingCartService shoppingCartService, ShoppingCartViewModelService shoppingCartViewModelService)
        {
            _shoppingCartService = shoppingCartService;
            _shoppingCartViewModelService = shoppingCartViewModelService;
        }

        /// <summary>
        /// ShoppingCart頁面
        /// </summary>
        public async Task<IActionResult> Index([FromQuery] int memberId)
        {
            if (!_shoppingCartService.IsMember(memberId))
            { return RedirectToAction(nameof(HomeController.Account), "Home"); }
            var cartData = await _shoppingCartViewModelService.GetShoppingCartViewModelsAsync(memberId);
            var result = new ShoppingCartListViewModel
            {
                MemberId = memberId,
                ShoppingCartList = cartData
            };
            return View(result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> AddToCart([FromForm] int memberId, [FromForm] int courseId, [FromForm] int courseLength, [FromForm] int quantity)
        {
            if (!_shoppingCartService.IsMember(memberId))
            { return RedirectToAction(nameof(HomeController.Account), "Home"); }
            if (!_shoppingCartService.IsCourse(courseId))
            { return RedirectToAction(nameof(HomeController.Index), "Home", new { memberId }); }
            if (!_shoppingCartService.HasCartItem(memberId, courseId))
            { memberId = await _shoppingCartService.CreateShoppingCartAsync(memberId, courseId, courseLength, quantity); }
            await _shoppingCartService.GetAllShoppingCartAsync(memberId);
            return RedirectToAction(nameof(Index), "ShoppingCart", new { memberId });
        }

        public IActionResult Delete([FromForm] int memberId, [FromForm] int courseId)
        {
            _shoppingCartService.DeleteCartItem(memberId, courseId);
            return RedirectToAction(nameof(Index), "ShoppingCart", new { memberId });
        }

    }
}
