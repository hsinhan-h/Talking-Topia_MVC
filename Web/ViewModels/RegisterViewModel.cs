namespace Web.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "電子郵件是必填的")]
        [EmailAddress(ErrorMessage = "請輸入有效的電子郵件地址")]
        public string Email { get; set; }
        [Required(ErrorMessage = "密碼是必填的")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "確認密碼是必填的")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "兩次密碼不一致")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "名字是必填的")]
        [StringLength(50, ErrorMessage = "名字不得超過50字元")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "姓氏是必填的")]
        [StringLength(50, ErrorMessage = "名字不得超過50字元")]
        public string LastName { get; set; }

    }
}
