using System;
using MacSolutions.Application.Alarms.Dtos;
using MediatR;

namespace MacSolutions.Application.Alarms.Queries.GetZone;

public class GetZoneByAlarmRateAndOutsideTarget(double averageAlarmRate, double percentageOutsideTarget) : IRequest<AlarmZoneDto>
{
    public double AverageAlarmRate { get; } = averageAlarmRate;
    public double PercentageOutsideTarget { get; } = percentageOutsideTarget;
}
