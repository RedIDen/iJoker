using iJoker.DataAccess;
using iJoker.DataAccess.EntityFramework;
using iJoker.Service;
using iJoker.Service.Default;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IJokesRepository, EFJokesRepository>();

var connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<JokesDbContext>(options => options.UseSqlServer(connection, b => b.MigrationsAssembly("iJoker.DataAccess.EntityFramework")));

builder.Services.AddTransient<IJokesService, JokesDefautService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
