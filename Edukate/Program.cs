using Edukate.Context;
using Edukate.Helpers;
using Edukate.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<EdukateDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("MsSql"));
}).AddIdentity<AppUser,IdentityRole>(opt => 
{
    opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_";
    opt.Password.RequireNonAlphanumeric = true;
    opt.Password.RequiredLength = 6;
    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    opt.Lockout.MaxFailedAccessAttempts = 5;
}).AddDefaultTokenProviders().AddEntityFrameworkStores<EdukateDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
           name: "areas",
           pattern: "{area:exists}/{controller=Instructor}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

PathConstant.RootPath = app.Environment.WebRootPath;

app.Run();
