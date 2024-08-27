using Microsoft.AspNetCore.Mvc;
using Web.Services;

namespace Web.Controllers
{
    public class WatchListController : Controller
    {
        private readonly IWatchListService _watchListService;

        public WatchListController(IWatchListService watchListService)
        {
            _watchListService = watchListService;
        }

        // GET: WatchList
        public IActionResult Index()
        {
            var watchList = _watchListService.GetWatchList();
            return View(watchList);
        }

        // POST: FollowTeacher
        [HttpPost]
        public IActionResult Follow(string teacherId)
        {
            _watchListService.FollowTeacher(teacherId);
            return RedirectToAction("Index");
        }

        // POST: UnfollowTeacher
        [HttpPost]
        public IActionResult Unfollow(string teacherId)
        {
            _watchListService.UnfollowTeacher(teacherId);
            return RedirectToAction("Index");
        }
        public IActionResult WatchList()
        {
            var watchList = _watchListService.GetWatchList(); // 假設這裡你有使用 service 層來獲取資料
            return View(watchList);  // 確保這裡有將 watchList 傳遞給 View
        }
    }
}
