using MediatR;
using MacSolutions.Application.Alarms.Dtos;

namespace MacSolutions.Application.Alarms.Queries.GetAllAlarms;

public class GetAllAlarmsQuery : IRequest<IEnumerable<AlarmDto?>>
{
    public int id { get; set; }
}
