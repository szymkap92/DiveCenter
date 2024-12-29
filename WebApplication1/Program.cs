using Microsoft.EntityFrameworkCore;
using DiveCenter;

var builder = WebApplication.CreateBuilder(args);

// Pobierz ConnectionString z appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Zarejestruj AppDbContext w DI
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Dodaj obs³ugê MVC (kontrolery + widoki Razor)
builder.Services.AddControllersWithViews();

// Dodaj obs³ugê sesji
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Czas trwania sesji
});

var app = builder.Build();


app.UseStaticFiles();


app.UseSession();

app.UseRouting();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
