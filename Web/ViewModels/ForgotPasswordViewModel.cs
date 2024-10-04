namespace Web.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "請輸入電子郵件")]
        [EmailAddress(ErrorMessage = "無效的電子郵件格式")]
        public string Email { get; set; }
    }
}
