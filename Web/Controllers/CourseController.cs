using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CourseList()
        {
            return View();
        }
    }
}
