using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Actio.Common.Events.Interfaces;

namespace Actio.Common.Events
{
    public class UserCreated : IEvent
    {
        public string Email { get; }
        public string Name { get; }

        protected UserCreated()
        {

        }

        public UserCreated(string email, string name)
        {
            Email = email;
            Name = name;
        }
    }
}
