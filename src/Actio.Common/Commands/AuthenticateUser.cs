using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Actio.Common.Commands.Interfaces;

namespace Actio.Common.Commands
{
    public class AuthenticateUser : ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
