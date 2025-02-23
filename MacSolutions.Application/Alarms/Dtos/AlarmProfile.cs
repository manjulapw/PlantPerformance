using AutoMapper;
using MacSolutions.Application.Alarms.Commands.CreateAlarm;
using MacSolutions.Application.Alarms.Commands.UpdateAlarm;
using MacSolutions.Domain.Entities;

namespace MacSolutions.Application.Alarms.Dtos;

public class AlarmsProfile : Profile
{
    public AlarmsProfile()
    {
        CreateMap<AlarmZone, AlarmDto>();
        CreateMap<AlarmZone, AlarmZoneDto>();
        CreateMap<CreateAlarmCommand, AlarmZone>();
        CreateMap<UpdateAlarmCommand, AlarmZone>();
    }

}
