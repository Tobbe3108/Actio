using System.Threading.Tasks;
using Actio.Common.Events;
using Actio.Common.Services;

namespace Actio.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await ServiceHost.Create<Startup>(args)
                .UseRabbitMQ()
                .SubscribeToEvent<ActivityCreated>()
                .Build()
                .Run();
        }
    }
}