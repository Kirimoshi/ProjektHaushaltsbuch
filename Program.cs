using System.Threading.RateLimiting;
using Serilog;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjektHaushaltsbuch.Data;
using ProjektHaushaltsbuch.SeedData;
using ProjektHaushaltsbuch.Web.Mappings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.RateLimiting;
using ProjektHaushaltsbuch.Data.Identity;
using Scalar.AspNetCore;

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
        options.ClientId = googleAuthNSection["ClientId"] ?? throw new InvalidOperationException("Authentication:Google:ClientId not found.");
        options.ClientSecret = googleAuthNSection["ClientSecret"] ?? throw new InvalidOperationException("Authentication:Google:ClientSecret not found.");
    });

builder.Services.AddRateLimiter(rateLimiterOptions =>
{
    rateLimiterOptions.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
    
    rateLimiterOptions.AddSlidingWindowLimiter("GlobalEndpointPolicy", options =>
    {
        options.PermitLimit = 15;
        options.Window = TimeSpan.FromMinutes(1);
        options.SegmentsPerWindow = 6;
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        options.QueueLimit = 10;
    });
    rateLimiterOptions.AddSlidingWindowLimiter("GetPolicy", options =>
    {
        options.PermitLimit = 60;
        options.Window = TimeSpan.FromMinutes(1);
        options.SegmentsPerWindow = 6;
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        options.QueueLimit = 10;
    });
    rateLimiterOptions.OnRejected = (context, cancellationToken) =>
    {
        Log.Warning("Rate limit exceeded for {EndPoint} from {IP}", 
            context.HttpContext.Request.Path, 
            context.HttpContext.Connection.RemoteIpAddress);
    
        return new ValueTask();
    };
});

builder.Services.AddOpenApi();

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
    app.UseDeveloperExceptionPage();
    Console.WriteLine("Running in Development mode");
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.Title = "Deine Haushaltsbuch API";
        options.Theme = ScalarTheme.Purple; // Verschiedene Themes verfügbar
    });
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

app.UseRateLimiter();

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