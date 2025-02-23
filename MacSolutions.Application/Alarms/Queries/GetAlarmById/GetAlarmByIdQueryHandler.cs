using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using MacSolutions.Application.Alarms.Dtos;
using MacSolutions.Domain.Exceptions;
using MacSolutions.Domain.Repositories;
using MacSolutions.Domain.Entities;

namespace MacSolutions.Application.Alarms.Queries.GetAlarmById;

public class GetAlarmByIdQueryHandler(IAlarmRepository AlarmRepository,
 ILogger<GetAlarmByIdQueryHandler> logger,
 IMapper mapper) : IRequestHandler<GetAlarmByIdQuery, AlarmDto>
{
    public async Task<AlarmDto> Handle(GetAlarmByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Getting Alarm {request.Id}");
        var alarm = await AlarmRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException(nameof(AlarmZone), request.Id.ToString());
        var AlarmDto = mapper.Map<AlarmDto>(alarm);
        return AlarmDto;
    }
}
