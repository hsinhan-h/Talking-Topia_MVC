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
        /// 帳號
        /// </summary>
        public string Account { get; set; }

        [Display(Name = "名字")]
        public string FirstName { get; set; }

        [Display(Name = "姓氏")]
        public string LastName { get; set; }

        /// <summary>
        /// 暱稱
        /// </summary>
        public string Nickname { get; set; }

        [Display(Name = "生日")]
        public DateTime Birthday { get; set; }

        [Display(Name = "性別")]
        public string Gender { get; set; }




        [Display(Name = "信箱")]
        public string Email { get; set; }

        [Display(Name = "電話")]
        public string Phone { get; set; }

        [Display(Name = "地址")]
        public string Address { get; set; }

        [Display(Name ="課程偏好")]//複數欄位
        //public List<CouseListViewModel> CousePrefer { get; set; }
        public string CousePrefer { get; set; }
    }
    public class CouseListViewModel
    {
        [Display(Name = "課程種類名稱")]
        public string CategorytName { get; set; }

        [Display(Name = "科目名稱")]
        public string SubjectName { get; set; }
    }

}
