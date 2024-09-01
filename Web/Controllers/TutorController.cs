using Microsoft.AspNetCore.Mvc;
using Web.Entities;
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
        public IActionResult TutorData()
        {

            return View();
        }

        public async Task<IActionResult> TutorResume(int MemberId)
        {
            var model = await _resumeDataService.GetEducationAsync(1);
            return View(model);
        }
        
        public async Task<IActionResult> PublishCourse(int MemberId)
        {
            var model = await _bookingService.GetPublishCourseList(MemberId);
            return View(model);
        }
        public IActionResult RecommendedTutorAI()
        {
            return View();
        }
    }
}
