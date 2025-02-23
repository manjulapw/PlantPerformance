using Microsoft.EntityFrameworkCore;
using MacSolutions.Domain.Entities;

namespace MacSolutions.Infrastructure.Persistence;

public class MacSolutionsDbContext : DbContext
{
    public MacSolutionsDbContext(DbContextOptions<MacSolutionsDbContext> options)
            : base(options)
    {
    }

    internal DbSet<AlarmZone> Alarms { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}
