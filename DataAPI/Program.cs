using DataAPI.Data;
using DataAPI.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

// Add DB Context
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Swagger for API Exploring
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register HttpClient
builder.Services.AddScoped<HttpClient>(sp =>
{
    var navigationManager = sp.GetRequiredService<NavigationManager>();
    return new HttpClient
    {
        BaseAddress = new Uri(navigationManager.BaseUri)
    };
});

var app = builder.Build();

// Seed database for testing
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
app.UseAntiforgery();
app.UseAuthorization();
app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();