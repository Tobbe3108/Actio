using System;

namespace Actio.Common.Commands.Interfaces
{
    public interface IAuthenticatedCommand : ICommand
    {
        Guid UserId { get; set; }
    }
}
