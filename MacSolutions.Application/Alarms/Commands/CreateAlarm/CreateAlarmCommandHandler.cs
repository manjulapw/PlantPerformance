using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MacSolutions.Domain.Entities;
using MacSolutions.Domain.Repositories;

namespace MacSolutions.Application.Alarms.Commands.CreateAlarm;

public class CreateAlarmCommandHandler(ILogger<CreateAlarmCommandHandler> logger,
    IMapper mapper,
    IAlarmRepository AlarmRepository) : IRequestHandler<CreateAlarmCommand, int>
{
    public async Task<int> Handle(CreateAlarmCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating a new Alarm");
        var Alarm = mapper.Map<AlarmZone>(request);
        int id = await AlarmRepository.Create(Alarm);
        return id;
    }
}
