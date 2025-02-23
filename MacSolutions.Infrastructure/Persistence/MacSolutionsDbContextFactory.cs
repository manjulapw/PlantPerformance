using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MacSolutions.Infrastructure.Persistence
{
    public class MacSolutionsDbContextFactory : IDesignTimeDbContextFactory<MacSolutionsDbContext>
    {
        public MacSolutionsDbContext CreateDbContext(string[] args)
        {
            // Set the base path to the MacSolutions.Api directory
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../MacSolutions.Api");

            // Build configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Get the connection string
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Configure DbContext options
            var optionsBuilder = new DbContextOptionsBuilder<MacSolutionsDbContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new MacSolutionsDbContext(optionsBuilder.Options);
        }
    }
}
