using Actio.Common.Commands.Interfaces;

namespace Actio.Common.Commands
{
    public class AuthenticateUser : ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}