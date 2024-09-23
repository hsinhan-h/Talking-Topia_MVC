namespace Web.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "電子郵件是必填欄位")]
        [EmailAddress(ErrorMessage = "請輸入有效的電子郵件地址")]
        public string Email { get; set; }
        [Required(ErrorMessage = "密碼是必填欄位")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "請確認您的密碼")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "兩次密碼不一致")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "名字是必填欄位")]
        [StringLength(50, ErrorMessage = "名字不得超過50字元")]
        public string FirstName { get; set; }

    }
}
