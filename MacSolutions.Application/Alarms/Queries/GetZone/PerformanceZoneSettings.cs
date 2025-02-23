using System;

namespace MacSolutions.Application.Alarms.Queries.GetZone;

public class PerformanceZoneSettings
{
    public double MaxPercentageOutsideTarget { get; set; }
    public double RobustMaxAlarmRate { get; set; }
    public double StableMaxAlarmRate { get; set; }
    public double ReactiveMaxAlarmRate { get; set; }
    public double OverloadedMaxAlarmRate { get; set; }
    public double RobustSlope { get; set; }
    public double RobustYIntercept { get; set; }
    public double StableSlope { get; set; }
    public double StableYIntercept { get; set; }
    public double ReactiveSlope { get; set; }
    public double ReactiveYIntercept { get; set; }
}
