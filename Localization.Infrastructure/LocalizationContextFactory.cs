using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Localization.Infrastructure;

public class LocalizationContextFactory : IDesignTimeDbContextFactory<LocalizationContext>
{
    public LocalizationContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<LocalizationContext>();
        optionsBuilder.UseSqlServer("Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=Localization");

        return new LocalizationContext(optionsBuilder.Options);
    }
}