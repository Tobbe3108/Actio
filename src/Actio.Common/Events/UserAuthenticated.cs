using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Actio.Common.Events.Interfaces;

namespace Actio.Common.Events
{
    public class UserAuthenticated : IEvent
    {
        public string Email { get; }

        protected UserAuthenticated()
        {

        }

        public UserAuthenticated(string email)
        {
            Email = email;
        }
    }
}
