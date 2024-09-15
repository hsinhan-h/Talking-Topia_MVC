namespace Web.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email為必填")]
        public string Email { get; set; }

        [Display(Name = "密碼")]
        [Required(ErrorMessage = "密碼為必填")]
        public string? Password { get; set; }

        [Display(Name = "登入後導向(框架處理，該欄位通常會藏起來)")]
        public string? ReturnUrl { get; set; }
    }
}
