using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Data
{
    public class StoreContextFactory : IDesignTimeDbContextFactory<StoreContext>
    {
        public StoreContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<StoreContext>();
            optionsBuilder.UseSqlServer("Server=.;Database=Skinet;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");

            return new StoreContext(optionsBuilder.Options);
        }
    }
}

