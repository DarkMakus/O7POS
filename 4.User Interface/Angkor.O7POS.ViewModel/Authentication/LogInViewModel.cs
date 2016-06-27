using Angkor.O7Framework.ServiceClient.SecurityClient;

namespace Angkor.O7POS.Model.Authentication
{
    public class LogInViewModel
    {
        public string NickName { get; set; }
        public string Password { get; set; }
        public Company Company { get; set; }
        public Branch Branch { get; set; }
    }
}