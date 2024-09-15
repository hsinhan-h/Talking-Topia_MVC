namespace Web.ViewModels
{
    public class AccountViewModel
    {
        public LoginViewModel LoginViewModel { get; set; }
        public RegisterViewModel RegisterViewModel { get; set; }
        public bool IsAuthenticated { get; internal set; }
    }
}
