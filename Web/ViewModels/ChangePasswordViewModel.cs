namespace Web.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "目前密碼是必填的")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessage = "新密碼是必填的")]
        [StringLength(100, ErrorMessage = "密碼長度必須至少為 {2} 個字元。", MinimumLength = 6)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "請再次確認新密碼")]
        [Compare("NewPassword", ErrorMessage = "新密碼與確認新密碼不相符")]
        public string ConfirmNewPassword { get; set; }
    }



}
