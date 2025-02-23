using MacSolutions.Domain.Entities;

namespace MacSolutions.Domain.Repositories;

public interface IAlarmRepository
{
    Task<IEnumerable<AlarmZone>> GetAllAsync();
    Task<AlarmZone?> GetByIdAsync(int id);
    Task<int> Create(AlarmZone alarm);
    Task Delete(AlarmZone alarm);
    Task SaveChanges();
}
