using Actio.Common.Events.Interfaces;

namespace Actio.Common.Events.Rejected
{
    public class AuthenticateUserRejected : IRejectedEvent
    {
        protected AuthenticateUserRejected()
        {
        }

        public AuthenticateUserRejected(string email, string reason, string code)
        {
            Email = email;
            Reason = reason;
            Code = code;
        }

        public string Email { get; set; }
        public string Reason { get; }
        public string Code { get; }
    }
}