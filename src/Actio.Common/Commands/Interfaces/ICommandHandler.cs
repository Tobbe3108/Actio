using System.Threading.Tasks;

namespace Actio.Common.Commands.Interfaces
{
    public interface ICommandHandler<in T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}