using MediatR;

namespace MacSolutions.Application.Alarms.Commands.CreateAlarm;

public class CreateAlarmCommand : IRequest<int>
{
        public double alarmRate { get; set; }
        public double percentageOutsideTarget { get; set; }
}
