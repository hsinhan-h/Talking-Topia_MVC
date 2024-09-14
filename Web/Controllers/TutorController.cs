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
       
        public IActionResult Index()
        {
            return View();
        }

        
        //Tutor Data Read and update
        public async Task<IActionResult> TutorData(int? memberId)
        {

            // Edit: 根據ID取得現有會員資料
            var tutorData = await _tutorDataService.GetAllInformationAsync(memberId);

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
            var model = await _bookingService.GetPublishCourseList(MemberId);
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
