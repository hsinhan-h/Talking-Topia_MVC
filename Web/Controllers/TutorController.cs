using Microsoft.AspNetCore.Mvc;
using Web.Services;

namespace Web.Controllers
{
    public class TutorController : Controller
    {
        private readonly ResumeDataService _resumeDataService;
        public TutorController(ResumeDataService resumeDataService)
        {
            _resumeDataService = resumeDataService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Toteacher()
        {
            return View();
        }
        public async Task<IActionResult> ToteacherResume()
        {
            var ResumeSummaryData = await _resumeDataService.GetResumeData("tommy85");
            return View(ResumeSummaryData);
        }
        public IActionResult RecommendedTeachersAI()
        {
            return View();
        }
    }
}
