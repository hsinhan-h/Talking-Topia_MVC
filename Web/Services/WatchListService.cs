using System.Collections.Generic;
using Web.ViewModels;

namespace Web.Services
{
    public interface IWatchListService
    {
        List<WatchListViewModel> GetWatchList();
        void FollowTeacher(string teacherId);
        void UnfollowTeacher(string teacherId);
    }

    public class WatchListService : IWatchListService
    {
        // 假設這裡使用的是模擬資料庫
        private readonly List<WatchListViewModel> _watchList;

        public WatchListService()
        {
            // 初始化一些測試資料
            _watchList = new List<WatchListViewModel>
            {
                new WatchListViewModel
                {
                    HeadShotImageUrl = "teacher1.jpg",
                    NationImage = "flag1.png",
                    Title = "English 101",
                    SubTitle = "Introduction to English",
                    TeacherIntroduction = "I have been teaching English for 10 years.",
                    TrialPriceNTD = 200,
                    FiftyMinPriceNTD = 500,
                    Rating = 4.8,
                    IsFollowed = true
                },
                new WatchListViewModel
                {
                    HeadShotImageUrl = "teacher2.jpg",
                    NationImage = "flag2.png",
                    Title = "Math 101",
                    SubTitle = "Basic Mathematics",
                    TeacherIntroduction = "Expert in teaching Mathematics.",
                    TrialPriceNTD = 150,
                    FiftyMinPriceNTD = 400,
                    Rating = 4.5,
                    IsFollowed = false
                }
            };
        }

        public List<WatchListViewModel> GetWatchList()
        {
            return _watchList ?? new List<WatchListViewModel>(); // 確保不會返回 null
        }

        public void FollowTeacher(string teacherId)
        {
            var teacher = _watchList.Find(t => t.HeadShotImageUrl == teacherId);
            if (teacher != null)
            {
                teacher.IsFollowed = true;
            }
        }

        public void UnfollowTeacher(string teacherId)
        {
            var teacher = _watchList.Find(t => t.HeadShotImageUrl == teacherId);
            if (teacher != null)
            {
                teacher.IsFollowed = false;
            }
        }
    }
}
