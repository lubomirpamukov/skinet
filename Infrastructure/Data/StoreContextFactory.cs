using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Data
{
    public class StoreContextFactory : IDesignTimeDbContextFactory<StoreContext>
    {
        public StoreContext CreateDbContext(string[] args)
        {
            //Todo use appsettings json.development string
            var optionsBuilder = new DbContextOptionsBuilder<StoreContext>();
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Skinet;User Id=SA;Password=Password@1;TrustServerCertificate=True;");

            return new StoreContext(optionsBuilder.Options);
        }
    }
}

