using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
using Web.Services;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CourseService _courseService;
        private readonly MemberDataService _memberDataService;
        private readonly IRepository _repository;
        private readonly CourseCategoryService _courseCategoryService;


        public HomeController(ILogger<HomeController> logger, CourseService courseService, MemberDataService memberDataService, IRepository repository, CourseCategoryService courseCategoryService)
        {
            _logger = logger;
            _courseService = courseService;
            _memberDataService = memberDataService;
            _repository = repository;
            _courseCategoryService = courseCategoryService;
        }

        public async Task<IActionResult> Index()
        {

            // �w�]�[���u�y���ǲߡv�����
            var defaultCategory = "�y���ǲ�";
            var courses = await _courseCategoryService.GetCoursesByCategoryAsync(defaultCategory);

            // �N��ƶǻ��� View
            return View(courses);
        }

        [HttpGet]
        public async Task<IActionResult> GetCoursesByCategory(string categoryName)
        {
            var courses = await _courseCategoryService.GetCoursesByCategoryAsync(categoryName);

            if (courses == null || courses.Count == 0)
            {
                Console.WriteLine("No data found for category: " + categoryName);
                return NotFound();  // �p�G�䤣��ƾڡA��^ 404
            }

            Console.WriteLine($"Data for {categoryName}: {JsonConvert.SerializeObject(courses)}");

            return Json(courses);  // ��^ JSON ���
        }

        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new Models.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Questions()
        {
            return View();
        }
    }
}
