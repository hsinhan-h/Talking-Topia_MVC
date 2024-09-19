using Microsoft.AspNetCore.Mvc;
using Web.Entities;
using Web.Services;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ApplicationCore.Entities;
using System.Security.Claims;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;



namespace Web.Controllers
{
    public class TutorController : Controller
    {

        private readonly ResumeDataService _resumeDataService;
        private readonly BookingService _bookingService;
        private readonly TutorDataservice _tutorDataService;
        private readonly AppointmentDetailService _appointmentDetailService;
        private readonly CourseCategoryService _courseCategoryService;
        private readonly IMemberService _memberService;
        public TutorController(ResumeDataService resumeDataService, BookingService bookingService, TutorDataservice tutorDataservice, AppointmentDetailService appointmentDetailService, CourseCategoryService courseCategoryService, IMemberService memberService)
        {
            _resumeDataService = resumeDataService;
            _bookingService = bookingService;
            _tutorDataService = tutorDataservice;
            _appointmentDetailService = appointmentDetailService;
            _courseCategoryService = courseCategoryService;
            _memberService = memberService;
        }



        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> IndexpostAsync()
        {
            var memberIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (memberIdClaim == null)
            { return RedirectToAction(nameof(AccountController.Account), "Account"); }
            int memberId = int.Parse(memberIdClaim.Value);
            var result = await _memberService.GetMemberId(memberId);

            if (!result)
            { return RedirectToAction(nameof(AccountController.Account), "Account"); }
            return RedirectToAction(nameof(TutorResume));
        }


        //Tutor Data Read and update
        [HttpGet]
        public async Task<IActionResult> TutorData(int? memberId)
        {
            var memberIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (memberIdClaim == null)
            {
                return RedirectToAction(nameof(AccountController.Account), "Account");
            }

            // 如果 memberId 是空的，從 Claim 取出，然後重定向以帶上 memberId
            if (!memberId.HasValue)
            {
                int parsedMemberId = int.Parse(memberIdClaim.Value);
                return RedirectToAction("TutorData", new { memberId = parsedMemberId });
            }

            // 確認服務能取得該 memberId
            var result = await _memberService.GetMemberId(memberId.Value);
            if (!result)
            {
                return RedirectToAction(nameof(AccountController.Account), "Account");
            }

            // 獲取 TutorData 資料
            var tutorData = await _tutorDataService.GetAllInformationAsync(memberId.Value);

            return View(tutorData);
        }


        [HttpPost]
        public async Task<IActionResult> TutorData(TutorDataViewModel qVM)
        {
            // 呼叫服務層的 CreateTutorData 方法
            var result = await _tutorDataService.CreateTutorData(qVM);

            // 檢查操作是否成功，並設置 ViewData 來顯示訊息
            ViewData["Header"] = result.Success ? "會員資料新增" : "錯誤訊息";
            ViewData["Message"] = result.Message;

            // 返回訊息視圖
            return View("_ShowMessage");
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

                ViewData["Header"] = result.Success ? "履歷已新增" : "履歷新增失敗請聯絡客服人員";
                ViewData["Message"] = result.Message;

                return View("ShowMessage");
            }

            return View(qVM);
        }

        [HttpGet]
        public async Task<IActionResult> PublishCourse()
        {
            //int memberId = 3;

            var memberIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (memberIdClaim == null)
            { return RedirectToAction(nameof(AccountController.Account), "Account"); }
            int memberId = int.Parse(memberIdClaim.Value);
            var result = await _memberService.GetMemberId(memberId);

            var model = await _bookingService.GetPublishCourseList(memberId);
            ViewData["HistoryList"] = await _bookingService.GetPublishCourseHistoryList(memberId);
            ViewData["CourseCategoryList"] = await _courseCategoryService.GetCourseCategoryListAsync();

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


        public async Task<IActionResult> Test()
        {
            int MemberId = 3;
            var model = await _bookingService.GetPublishCourseList(MemberId);
            ViewData["HistoryList"] = await _bookingService.GetPublishCourseHistoryList(MemberId);

            return View(model);
        }
    }
}
