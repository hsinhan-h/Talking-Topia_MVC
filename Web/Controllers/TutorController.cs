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
            if (!memberId.HasValue)
            {
                int parsedMemberId = int.Parse(memberIdClaim.Value);
                return RedirectToAction("TutorData", new { memberId = parsedMemberId });
            }
            var result = await _memberService.GetMemberId(memberId.Value);
            if (!result)
            {
                return RedirectToAction(nameof(AccountController.Account), "Account");
            }
            var tutorData = await _tutorDataService.GetAllInformationAsync(memberId.Value);

            ViewData["MemberId"] = memberId;
            return View(tutorData);
        }


        [HttpPost]
        public async Task<IActionResult> TutorData(TutorDataViewModel qVM)
        {
            var memberIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (memberIdClaim == null)
            { return RedirectToAction(nameof(AccountController.Account), "Account"); }
            int memberId = int.Parse(memberIdClaim.Value);
            // 呼叫服務層的 CreateTutorData 方法
            var result = await _tutorDataService.CreateTutorData(qVM, memberId);

            if (result.Success)
            {
                // 成功後，重新提取會員完整資料
                var tutorData = await _tutorDataService.GetAllInformationAsync(memberId);

                ViewData["Header"] = "會員資料新增";
                ViewData["Message"] = "會員資料新增成功";
                return View("TutorData", tutorData); // 使用完整資料重新渲染 TutorData 頁面
            }
            else
            {
                ViewData["Header"] = "錯誤訊息";
                ViewData["Message"] = result.Message;
                return View("_ShowMessage");
            }
        }

        [HttpPost]
        public async Task<IActionResult> TutorTimeData(TutorDataViewModel qVM)
        {
            var memberIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (memberIdClaim == null)
            {
                return RedirectToAction(nameof(AccountController.Account), "Account");
            }

            int memberId = int.Parse(memberIdClaim.Value);

            // 呼叫服務層的 CreateTutorTimeData 方法
            var resultTime = await _tutorDataService.CreateTutorTimeData(qVM, memberId);

            // 檢查操作是否成功
            if (resultTime.Success)
            {
                // 成功後，重新提取會員完整資料
                var tutorData = await _tutorDataService.GetAllInformationAsync(memberId);

                ViewData["Header"] = "會員資料新增";
                ViewData["Message"] = "會員資料新增成功";
                return View("TutorData", tutorData); // 使用完整資料重新渲染 TutorData 頁面
            }
            else
            {
                ViewData["Header"] = "錯誤訊息";
                ViewData["Message"] = resultTime.Message;
                return View("_ShowMessage");
            }
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
            var memberIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (memberIdClaim == null)
            { return RedirectToAction(nameof(AccountController.Account), "Account"); }
            int memberId = int.Parse(memberIdClaim.Value);
            // 呼叫服務層的 CreateTutorData 方法
            var result = await _resumeDataService.AddResumeAsync(qVM, memberId);
            // 檢查操作是否成功
            if (result.Success)
            {
                // 成功後，重新提取會員完整資料
                var tutorData = await _tutorDataService.GetAllInformationAsync(memberId);

                ViewData["Header"] = "會員資料新增";
                ViewData["Message"] = "會員資料新增成功";
                return View("TutorData", tutorData); // 使用完整資料重新渲染 TutorData 頁面
            }
            else
            {
                ViewData["Header"] = "錯誤訊息";
                ViewData["Message"] = result.Message;
                return View("_ShowMessage");
            }
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


        public async Task<IActionResult> Test()
        {
            int MemberId = 3;
            var model = await _bookingService.GetPublishCourseList(MemberId);
            ViewData["HistoryList"] = await _bookingService.GetPublishCourseHistoryList(MemberId);

            return View(model);
        }
         public async Task<IActionResult> AppointmentDetails(int memberId)
        {
          
            // 獲取預約詳細信息
            var appointmentDetails = await _appointmentDetailService.GetAppointmentData(memberId=47);

            // 返回視圖並傳遞預約數據
            return View(appointmentDetails);
        }
    }
}
