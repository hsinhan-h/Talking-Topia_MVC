using Microsoft.AspNetCore.Mvc;
using Web.Services;

namespace Web.Controllers
{
    public class TutorController : Controller
    {
        private readonly ResumeDataService _resumeDataService;
        private readonly BookingService _bookingService;
        public TutorController(ResumeDataService resumeDataService, BookingService bookingService)
        {
            _resumeDataService = resumeDataService;
            _bookingService = bookingService;
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
        public async Task<IActionResult> PublishCourse()
        {
            var model = await _bookingService.GetPublishCourseList();
            return View(model);
        }
        public IActionResult RecommendedTeachersAI()
        {
            return View();
        }
    }
}
