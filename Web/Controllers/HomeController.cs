using Web.Services;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CourseService _courseService;
        private readonly MemberDataService _memberDataService;
        private readonly IRepository _repository;

        public HomeController(ILogger<HomeController> logger, CourseService courseService, MemberDataService memberDataService, IRepository repository)
        {
            _logger = logger;
            _courseService = courseService;
            _memberDataService = memberDataService;
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var course = await _courseService.GetCourseList();
            return View(course);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Questions()
        {
            return View();
        }
    }
}
