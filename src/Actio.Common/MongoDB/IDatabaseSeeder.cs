using System.Threading.Tasks;

namespace Actio.Common.MongoDB
{
    public interface IDatabaseSeeder
    {
        Task SeedAsync();
    }
}