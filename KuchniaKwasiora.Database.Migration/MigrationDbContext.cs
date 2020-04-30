using Microsoft.EntityFrameworkCore.Design;

namespace KuchniaKwasiora.Database.Migration
{

    public class MigrationDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var connectionString = "Server=.;Database=KK_DB;Trusted_Connection=true";

            var dbContext = new AppDbContext(connectionString, true);
            dbContext.Database.EnsureCreated();

            return dbContext;
        }
    }
}
