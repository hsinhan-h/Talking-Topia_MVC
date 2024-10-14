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
        [Required(ErrorMessage = "名字是必填的")]
        [StringLength(50, ErrorMessage = "名字不得超過50字元")]
        public string FirstName { get; set; }

        /// <summary>
        /// 姓氏
        /// </summary>
        [Required(ErrorMessage = "姓氏是必填的")]
        [StringLength(50, ErrorMessage = "姓氏不得超過50字元")]
        public string LastName { get; set; }

        /// <summary>
        /// 暱稱
        /// </summary>
        [Required(ErrorMessage = "暱稱是必填的")]
        [StringLength(50, ErrorMessage = "暱稱不得超過50字元")]
        public string Nickname { get; set; }

        /// <summary>
        /// 性別
        /// </summary>
        [Required(ErrorMessage = "性別是必填的")]
        public string Gender { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// 信箱
        /// </summary>
        [Required(ErrorMessage = "信箱是必填的")]
        [EmailAddress(ErrorMessage = "請輸入有效的電子郵件地址")]
        public string Email { get; set; }

        /// <summary>
        /// 電話
        /// </summary>
        [Required(ErrorMessage = "電話是必填的")]
        [Phone(ErrorMessage = "請輸入有效的電話號碼")]
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
