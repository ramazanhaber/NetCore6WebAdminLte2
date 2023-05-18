using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using NetCore6WebAdminLte2.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<OgrenciContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon"));
});


// rol Kullanýcý
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(a =>
{
    a.Cookie.Name = "Cookie";
    a.LoginPath = "/Login/login";
    a.AccessDeniedPath = "/Login/login";
    a.Cookie.HttpOnly = false;
    a.ExpireTimeSpan = TimeSpan.FromMinutes(15);
    a.Cookie.SameSite = SameSiteMode.Lax;
    a.Cookie.SecurePolicy = CookieSecurePolicy.Always;
});




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

app.UseAuthentication();// auth için
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
