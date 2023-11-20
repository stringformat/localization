using Microsoft.EntityFrameworkCore;

namespace Localization.Infrastructure;

public class LocalizationContext(DbContextOptions<LocalizationContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}