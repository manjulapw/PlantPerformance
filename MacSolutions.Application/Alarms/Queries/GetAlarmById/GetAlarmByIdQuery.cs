using MediatR;
using MacSolutions.Application.Alarms.Dtos;

namespace MacSolutions.Application.Alarms.Queries.GetAlarmById;

public class GetAlarmByIdQuery(int id) : IRequest<AlarmDto>
{
    public int Id { get; } = id;
}
