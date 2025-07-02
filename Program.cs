using Serilog;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjektHaushaltsbuch.Data;
using ProjektHaushaltsbuch.SeedData;
using ProjektHaushaltsbuch.Web.Mappings;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProjektHaushaltsbuchContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProjektHaushaltsbuchContext") ?? throw new InvalidOperationException("Connection string 'ProjektHaushaltsbuchContext' not found.")));

builder.Services.AddSerilog();
builder.Services.AddAutoMapper(typeof(UserProfile));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
SeedData.Initialize(services);
    }
    catch (Exception e)
    {
        Log.Fatal(e, "An error occurred seeding the DB.");
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

try
{
    Log.Information("Starting web application");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}