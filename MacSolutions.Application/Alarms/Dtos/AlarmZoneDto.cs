using System;

namespace MacSolutions.Application.Alarms.Dtos;

public class AlarmZoneDto
{
    public double alarmRate { get; set; }
    public double percentageOutsideTarget { get; set; }
}
