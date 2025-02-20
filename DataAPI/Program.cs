using DataAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();

    // Seed Industry Types
    if (!db.IndustryTypes.Any())
    {
        db.IndustryTypes.AddRange(
            new IndustryType { Name = "Technology" },
            new IndustryType { Name = "Healthcare" },
            new IndustryType { Name = "Finance" }
        );
        db.SaveChanges();
    }

    // Seed License Types
    if (!db.LicenseTypes.Any())
    {
        db.LicenseTypes.AddRange(
            new LicenseType { Name = "Business License" },
            new LicenseType { Name = "Professional License" },
            new LicenseType { Name = "Trade License" }
        );
        db.SaveChanges();
    }

    // Seed Filing Types
    if (!db.FilingTypes.Any())
    {
        db.FilingTypes.AddRange(
            new FilingType { Name = "Annual Report" },
            new FilingType { Name = "Tax Filing" },
            new FilingType { Name = "Compliance Filing" }
        );
        db.SaveChanges();
    }
}

app.UseRouting();
app.UseAuthorization();
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();