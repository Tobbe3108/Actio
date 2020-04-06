using System;
using System.Threading.Tasks;
using Actio.Common.Commands;
using Actio.Common.Commands.Interfaces;
using Actio.Common.Events;
using Actio.Common.Events.Rejected;
using Actio.Common.Exceptions;
using Actio.Services.Identity.Services;
using Microsoft.Extensions.Logging;
using RawRabbit;

namespace Actio.Services.Identity.Handlers
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IBusClient _busClient;
        private readonly ILogger _logger;
        private readonly IUserService _userService;

        public CreateUserHandler(IBusClient busClient, IUserService userService, ILogger<CreateUserHandler> logger)
        {
            _busClient = busClient;
            _userService = userService;
            _logger = logger;
        }

        public async Task HandleAsync(CreateUser command)
        {
            _logger.LogInformation($"Creating user: '{command.Email}' with name: '{command.Name}'.");
            try
            {
                await _userService.RegisterAsync(command.Email, command.Password, command.Name);

                await _busClient.PublishAsync(new UserCreated(command.Email, command.Name));
                _logger.LogInformation($"User: '{command.Email}' was created with name: '{command.Name}'.");
            }
            catch (ActioException e)
            {
                await _busClient.PublishAsync(new CreateUserRejected(command.Email, e.Code, e.Message));
                _logger.LogError(e.Message);
            }
            catch (Exception e)
            {
                await _busClient.PublishAsync(new CreateUserRejected(command.Email, "error", e.Message));
                _logger.LogError(e.Message);
            }
        }
    }
}