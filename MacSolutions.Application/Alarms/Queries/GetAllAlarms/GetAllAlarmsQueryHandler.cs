using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MacSolutions.Application.Alarms.Dtos;
using MacSolutions.Domain.Repositories;

namespace MacSolutions.Application.Alarms.Queries.GetAllAlarms;

public class GetAllAlarmsQueryHandler(IAlarmRepository AlarmRepository,
 ILogger<GetAllAlarmsQueryHandler> logger,
 IMapper mapper) : IRequestHandler<GetAllAlarmsQuery, IEnumerable<AlarmDto>>
{
    public async Task<IEnumerable<AlarmDto>> Handle(GetAllAlarmsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Get all Alarms");
        var Alarms = await AlarmRepository.GetAllAsync();
        var AlarmDtos = mapper.Map<IEnumerable<AlarmDto>>(Alarms);
        return AlarmDtos;
    }
}
