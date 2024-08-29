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
        /// <summary>
        /// 原ToTeacher.cshtml的頁面
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ToTeacherResume()
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
