using Actio.Common.Commands.Interfaces;
using Actio.Common.Events.Interfaces;
using Actio.Common.RabbitMQ;
using Microsoft.AspNetCore.Hosting;
using RawRabbit;

namespace Actio.Common.Services.Builders
{
    public class BusBuilder : BuilderBase
    {
        private readonly IBusClient _bus;
        private readonly IWebHost _webHost;

        public BusBuilder(IWebHost webHost, IBusClient bus)
        {
            _bus = bus;
            _webHost = webHost;
        }

        public BusBuilder SubscribeToCommand<TCommand>() where TCommand : ICommand
        {
            var handler = (ICommandHandler<TCommand>) _webHost.Services.GetService(typeof(ICommandHandler<TCommand>));
            _bus.WithCommandHandlerAsync(handler);

            return this;
        }

        public BusBuilder SubscribeToEvent<TEvent>() where TEvent : IEvent
        {
            var handler = (IEventHandler<TEvent>) _webHost.Services.GetService(typeof(IEventHandler<TEvent>));
            _bus.WithEventHandlerAsync(handler);

            return this;
        }

        public override ServiceHost Build()
        {
            return new ServiceHost(_webHost);
        }
    }
}