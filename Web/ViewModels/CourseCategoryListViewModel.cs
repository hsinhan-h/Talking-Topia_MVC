namespace Web.ViewModels
{
    public class CourseCategoryListViewModel
    {
        public List<CourseCategoryVM> CourseCategoryList { get; set; }
    }

    public class CourseCategoryVM
    {
        public int CourseCategoryId { get; set; }
        /// <summary>
        /// 課程種類
        /// </summary>
        public string CategoryName { get; set; }
        /// <summary>
        /// 課程科目
        /// </summary>
    }
}
