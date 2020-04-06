using System.Threading.Tasks;

namespace Actio.Common.MongoDB
{
    public interface IDatabaseInitializer
    {
        Task InitializeAsync();
    }
}