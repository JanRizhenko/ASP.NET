using Microsoft.EntityFrameworkCore;
using SurveyPortal.Models;
using SurveyPortal.Models.Survey;
using SurveyPortal.Models.Survey.Survey;
using Microsoft.AspNetCore.Identity;
using SurveyPortal.Models.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddDbContext<SurveyDbContext>(opts =>
{
    var connectionString = builder.Configuration.GetConnectionString("SurveyPortalConnection");
    opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddDbContext<AppIdentityDbContext>(opts =>
{
    var connectionString = builder.Configuration.GetConnectionString("IdentityConnection");
    opts.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AppIdentityDbContext>()
    .AddDefaultTokenProviders();




builder.Services.AddScoped<ISurveyRepository, EFSurveyRepository>();

var app = builder.Build();

app.UseStaticFiles();

app.UseSession();



app.MapDefaultControllerRoute();

app.MapControllerRoute
    (
    name: "pagination",
    pattern: "Home/Index/{page:int}",
    defaults: new { Controller = "Home", action = "Index" }
    );

SeedData.EnsurePopulated(app);

app.Run();
