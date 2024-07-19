using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Library_Management.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Configure DbContext
builder.Services.AddDbContext<Library_ManagementContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Library_ManagementContext") ?? throw new InvalidOperationException("Connection string 'Library_ManagementContext' not found.")));

// Configure authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => options.LoginPath = "/User/Login");

// Add services to the container
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Authentication middleware
app.UseAuthentication();
app.UseAuthorization();

// Custom middleware for redirection based on authentication status
app.Use(async (context, next) =>
{
    // If the user is logged in and the request is for the root URL, redirect to Home
    if (context.Request.Path == "/" && context.User.Identity.IsAuthenticated)
    {
        context.Response.Redirect("/Home/Index");
        return;
    }
    await next();
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Login}/{id?}");

app.Run();
