using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels
{
    public class MemberProfileListViewModel
    {
        public List<MemberProfileViewModel> MemberDataList { get; set; }
    }

    public class MemberProfileViewModel
    {
        /// <summary>
        /// 大頭貼
        /// </summary>
        public string ImageUrl { get; set; }

        /// <summary>
        /// 帳號(若為第三方登入則帶第三方登入產生的帳號代碼)
        /// </summary>
        public string Account { get; set; }

        /// <summary>
        /// 名字
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// 姓氏
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// 暱稱
        /// </summary>
        public string Nickname { get; set; }

        /// <summary>
        /// 性別
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// 信箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 電話
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 複數欄位 
        /// </summary>
        public List<CourseListViewModel> CoursePrefer { get; set; }
    }
    public class CourseListViewModel
    {
        /// <summary>
        /// 課程類別
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// 課程科目
        /// </summary>
        public string SubjectName { get; set; }
        public int MemberId { get; internal set; }
    }

}
