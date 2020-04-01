using System.Threading.Tasks;
using Actio.Common.Commands;
using Actio.Common.Services;

namespace Actio.Services.Activities
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await ServiceHost.Create<Startup>(args)
                .UseRabbitMQ()
                .SubscribeToCommand<CreateActivity>()
                .Build()
                .Run();
        }
    }
}