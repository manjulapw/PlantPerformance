using System;
using MacSolutions.Application.Alarms.Queries.GetZone;
using MacSolutions.Domain.Enums;
using Microsoft.Extensions.Options;

namespace MacSolutions.Application.Services;

public class PerformanceZoneService(IOptions<PerformanceZoneSettings> settings)
{
    public PerformanceZone DetermineZone(GetZoneByAlarmRateAndOutsideTarget request)
    {
        if (request.PercentageOutsideTarget < 0 
            || request.PercentageOutsideTarget > settings.Value.MaxPercentageOutsideTarget)
            return PerformanceZone.NotDefined;

        //averageAlarmRate 0 to 1
        if (request.AverageAlarmRate >= 0 && request.AverageAlarmRate <= settings.Value.RobustMaxAlarmRate)
        {
          
            // Check if the point is below the line from (0,25) to (1,10)
            double yValue = settings.Value.RobustSlope 
                * request.AverageAlarmRate + settings.Value.RobustYIntercept;

            if (request.PercentageOutsideTarget <= yValue)
            {
                return PerformanceZone.Robust;
            }
            else
            {
                return PerformanceZone.Stable;
            }
        }

        //averageAlarmRate 1 to 2
        if (request.AverageAlarmRate > settings.Value.RobustMaxAlarmRate 
            && request.AverageAlarmRate <= settings.Value.StableMaxAlarmRate)
        {
            // Check if the point is below the line from (1,50) to (2,25)
            double yValue = settings.Value.StableSlope * request.AverageAlarmRate + settings.Value.StableYIntercept;

            if (request.PercentageOutsideTarget <= yValue)
            {
                return PerformanceZone.Stable;
            }
            else
            {
                return PerformanceZone.Reactive;
            }
        }

        //averageAlarmRate 2 to 10
        if (request.AverageAlarmRate > settings.Value.StableMaxAlarmRate 
            && request.AverageAlarmRate <= settings.Value.ReactiveMaxAlarmRate)
        {
            // Check if the point is below the line from (2,50) to (10,25)
           double yValue = settings.Value.ReactiveSlope * request.AverageAlarmRate + settings.Value.ReactiveYIntercept;

            if (request.PercentageOutsideTarget <= yValue)
            {
                return PerformanceZone.Reactive;
            }
            else
            {
                return PerformanceZone.Overloaded;
            }
        }

        //averageAlarmRate 10 to 100 Overloaded Zone
        if (request.AverageAlarmRate > settings.Value.ReactiveMaxAlarmRate 
            && request.AverageAlarmRate <= settings.Value.OverloadedMaxAlarmRate)
        {
            return PerformanceZone.Overloaded;
        }

        // If no zone is matched
        return PerformanceZone.NotDefined;
    }
}
