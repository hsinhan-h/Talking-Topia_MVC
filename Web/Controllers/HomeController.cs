namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CourseService _courseService;

        public HomeController(ILogger<HomeController> logger, CourseService courseService)
        {
            _logger = logger;
            _courseService = courseService;
        }

        public async Task <IActionResult> Index()
        {
            var course = await _courseService.GetCourseList();
            return View(course);
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
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
