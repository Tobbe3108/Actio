using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actio.Common.MongoDB
{
    public interface IDatabaseSeeder
    {
        Task SeedAsync();
    }
}