using Serilog;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjektHaushaltsbuch.Data;
using ProjektHaushaltsbuch.SeedData;
using ProjektHaushaltsbuch.Web.Mappings;
using Microsoft.AspNetCore.Identity;
using ProjektHaushaltsbuch.Data.Identity;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;
builder.Services.AddDbContext<ProjektHaushaltsbuchContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProjektHaushaltsbuchContext") ?? throw new InvalidOperationException("Connection string 'ProjektHaushaltsbuchContext' not found.")));
builder.Services.AddDbContext<ApplicationIdentityContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));
builder.Services
    .AddDefaultIdentity<IdentityUser>(options =>
        {
            options.SignIn.RequireConfirmedAccount = false; // For production change to true
            // options.User.RequireUniqueEmail = true;
        }
    )
    .AddEntityFrameworkStores<ApplicationIdentityContext>();

builder.Services.AddSerilog();
builder.Services.AddAutoMapper(typeof(UserProfile));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddAuthentication()
    .AddGoogle(options =>
    {
        IConfigurationSection googleAuthNSection =
            config.GetSection("Authentication:Google");
        options.ClientId = googleAuthNSection["ClientId"];
        options.ClientSecret = googleAuthNSection["ClientSecret"];

        // options.ClientId = config["Authentication__Google__ClientId"];
        // options.ClientSecret = config["Authentication__Google__ClientSecret"];
    });

var app = builder.Build();

// Seeding DB
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
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseDeveloperExceptionPage();
    Console.WriteLine("Running in Development mode");
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapRazorPages();

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