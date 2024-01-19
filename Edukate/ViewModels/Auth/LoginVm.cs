namespace Edukate.ViewModels.Auth
{
    public class LoginVm
    {
        public string UserNameOrEmail { get; set; }
        public string Password { get; set; }
        public bool Remember { get; set; }
    }
}
