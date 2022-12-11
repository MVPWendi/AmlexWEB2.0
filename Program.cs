using AmlexWEB;
using AmlexWEB.Models.User;
using AmlexWEB.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddSteam().AddCookie(options =>
{
    options.LoginPath = "/Auth/SignIn";
    options.LogoutPath = "/Auth/SignOutUser";
});
builder.Services.AddSingleton<DatabaseUsers>();
builder.Services.AddTransient<UserModel>();
builder.Services.AddSingleton<ServerMonitoring>();
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
app.UseWhen(context => context.Request.Path.ToString().Contains("api"),
    app => app.UseMiddleware<BasicAuthenticationMiddleware>()
    );
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
