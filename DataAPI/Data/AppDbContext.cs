namespace DataAPI.Data;

using Microsoft.EntityFrameworkCore;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<IndustryType> IndustryTypes { get; set; }
    public DbSet<LicenseType> LicenseTypes { get; set; }
    public DbSet<FilingType> FilingTypes { get; set; }
}
