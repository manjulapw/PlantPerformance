using Microsoft.EntityFrameworkCore;
using MacSolutions.Domain.Entities;
using MacSolutions.Domain.Repositories;
using MacSolutions.Infrastructure.Persistence;

namespace MacSolutions.Infrastructure.Repositories;

public class AlarmRepository(MacSolutionsDbContext dbContext) : IAlarmRepository
{
    public async Task<int> Create(AlarmZone alarm)
    {
        dbContext.Alarms.Add(alarm);
        await dbContext.SaveChangesAsync();
        return alarm.Id;
    }

    public async Task Delete(AlarmZone alarm)
    {
        dbContext.Remove(alarm);
        await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<AlarmZone>> GetAllAsync()
    {
        var Alarms = await dbContext.Alarms.ToListAsync();
        return Alarms;
    }

    public async Task<AlarmZone?> GetByIdAsync(int id)
    {
        var Alarm = await dbContext.Alarms.FirstOrDefaultAsync(x => x.Id == id);
        return Alarm;
    }

    public Task SaveChanges()
        => dbContext.SaveChangesAsync();
}
