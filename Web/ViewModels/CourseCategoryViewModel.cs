namespace Web.ViewModels
{
    public class CourseCategoryViewModel
    {
        public int CourseCategoryId { get; set; }
        /// <summary>
        /// 課程種類
        /// </summary>
        public string CategoryName { get; set; }
        /// <summary>
        /// 課程科目
        /// </summary>
        public List<CourseSubjectViewModel> Subjects { get; set; }
    }

    public class CourseSubjectViewModel
    {
        public string SubjectName { get; set; }
    }
}
