namespace Web.ViewModels
{
    public class WatchListViewModel
    {
        public List<WatchListViewModel> WatchList { get; set; }
    }
    public class WatchViewModel
    {
        /// <summary>
        /// 關注ID
        /// </summary>
        public int WatchListId { get; set; }
        /// <summary>
        /// 送出關注的人
        /// </summary>
        public int FollowerId { get; set; }

        /// <summary>
        /// 關注的課程
        /// </summary>
        public int FollowedCourseId { get; set; }
    }
}
