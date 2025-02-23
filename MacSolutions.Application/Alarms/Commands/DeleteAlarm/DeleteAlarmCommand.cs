using MediatR;

namespace MacSolutions.Application.Alarms.Commands.DeleteAlarm;

public class DeleteAlarmCommand(int id) : IRequest
{
    public int Id { get; } = id;
}
