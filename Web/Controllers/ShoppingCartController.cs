using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShoppingCartInfo()
        {
            return View(); 
        }
    }
}
