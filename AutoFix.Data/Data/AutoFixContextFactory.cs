using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AutoFix.Data
{
    public class AutoFixContextFactory : IDesignTimeDbContextFactory<AutoFixContext>
    {
        public AutoFixContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AutoFixContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AutoFixDb;Trusted_Connection=True;");

            return new AutoFixContext(optionsBuilder.Options);
        }
    }
}
