using System;
using System.Threading.Tasks;
using Actio.Common.Commands;
using Actio.Common.Commands.Interfaces;
using Actio.Common.Events;
using Actio.Common.Events.Rejected;
using Actio.Common.Exceptions;
using Actio.Services.Activities.Services;
using Microsoft.Extensions.Logging;
using RawRabbit;

namespace Actio.Services.Activities.Handlers
{
    public class CreateActivityHandler : ICommandHandler<CreateActivity>
    {
        private readonly IActivityService _activityService;
        private readonly IBusClient _busClient;
        private readonly ILogger _logger;

        public CreateActivityHandler(IBusClient busClient, IActivityService activityService,
            ILogger<CreateActivityHandler> logger)
        {
            _busClient = busClient;
            _activityService = activityService;
            _logger = logger;
        }

        public async Task HandleAsync(CreateActivity command)
        {
            _logger.LogInformation($"Creating activity: {command.Category} {command.Name}");
            try
            {
                await _activityService.AddAsync(command.Id, command.UserId, command.Category, command.Name,
                    command.Description, command.CreatedAt);

                await _busClient.PublishAsync(new ActivityCreated(command.Id, command.UserId, command.Category,
                    command.Name, command.Description, command.CreatedAt));
            }
            catch (ActioException e)
            {
                await _busClient.PublishAsync(new CreateActivityRejected(command.Id, e.Code, e.Message));
                _logger.LogError(e.Message);
            }
            catch (Exception e)
            {
                await _busClient.PublishAsync(new CreateActivityRejected(command.Id, "error", e.Message));
                _logger.LogError(e.Message);
            }
        }
    }
}