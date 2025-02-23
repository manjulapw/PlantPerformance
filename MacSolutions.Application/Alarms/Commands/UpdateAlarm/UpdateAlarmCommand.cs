using MediatR;

namespace MacSolutions.Application.Alarms.Commands.UpdateAlarm;

public class UpdateAlarmCommand : IRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
}
