using Microsoft.AspNetCore.Mvc;
using Web.Entities;
using Web.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding;



namespace Web.Controllers
{
    public class TutorController : Controller
    {
        private readonly ResumeDataService _resumeDataService;
        private readonly BookingService _bookingService;
        private readonly TutorDataservice _tutorDataService;
        public TutorController(ResumeDataService resumeDataService, BookingService bookingService, TutorDataservice tutorDataservice)
        {
            _resumeDataService = resumeDataService;
            _bookingService = bookingService;
            _tutorDataService = tutorDataservice;
        }
        /// <summary>
        /// 原ToTeacher.cshtml的頁面
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> TutorData()
        {
            var tutorData = await _tutorDataService.GetAllInformationAsync();
            if (tutorData == null)
            {
                return RedirectToAction("Index", "Tutor");
            }
            return View(tutorData);
        }
        [HttpGet]
        public IActionResult TutorResume()
        {
            var qVM = new TutorResumeViewModel();
            return View(qVM);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> TutorResume(TutorResumeViewModel qVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _resumeDataService.AddResumeAsync(qVM);

                ViewData["Header"] = result.Success ? "履歷已新增" : "錯誤訊息";
                ViewData["Message"] = result.Message;

                return View("ShowMessage");
            }

            return View(qVM);
        }

        
        public async Task<IActionResult> PublishCourse(int MemberId)
        {
            MemberId = 3;
            var model = await _bookingService.GetPublishCourseList(MemberId);
            ViewData["HistoryList"]= await _bookingService.GetPublishCourseHistoryList(MemberId);
            
            return View(model);
        }
        public IActionResult RecommendedTutorAI()
        {
            return View();
        }

        public IActionResult GotoResume()
        {

            return RedirectToAction("TutorResume");
        }

        public IActionResult AppointmentDetails()
        {
            return View();
        }

       
    }
}
