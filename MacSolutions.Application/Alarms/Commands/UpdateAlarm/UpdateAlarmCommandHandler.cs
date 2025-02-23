using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MacSolutions.Domain.Entities;
using MacSolutions.Domain.Exceptions;
using MacSolutions.Domain.Repositories;

namespace MacSolutions.Application.Alarms.Commands.UpdateAlarm;

public class UpdateAlarmCommandHandler(ILogger<UpdateAlarmCommandHandler> logger,
    IAlarmRepository AlarmRepository,
    IMapper mapper) : IRequestHandler<UpdateAlarmCommand>
{
    public async Task Handle(UpdateAlarmCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Deleting Alarm with id: {request.Id}");
        var Alarm = await AlarmRepository.GetByIdAsync(request.Id);
        if(Alarm is null)
            throw new NotFoundException(nameof(Alarm), request.Id.ToString());

        mapper.Map(request, Alarm);
        await AlarmRepository.SaveChanges();
    }
}
