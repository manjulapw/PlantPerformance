using MediatR;
using Microsoft.Extensions.Logging;
using MacSolutions.Domain.Entities;
using MacSolutions.Domain.Exceptions;
using MacSolutions.Domain.Repositories;

namespace MacSolutions.Application.Alarms.Commands.DeleteAlarm;

public class DeleteAlarmCommandHandler(ILogger<DeleteAlarmCommandHandler> logger,
    IAlarmRepository AlarmRepository) : IRequestHandler<DeleteAlarmCommand>
{
    public async Task Handle(DeleteAlarmCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Deleting Alarm with id: {request.Id}");
        var Alarm = await AlarmRepository.GetByIdAsync(request.Id);

        if(Alarm is null)
            throw new NotFoundException(nameof(Alarm), request.Id.ToString());
        
        await AlarmRepository.Delete(Alarm);
    }
}
