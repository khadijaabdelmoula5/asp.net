using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ExamanApp.Data;
using ExamanApp.Areas.Identity.Data;
using ExamanApp.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ExamanAppContextConnection") ?? throw new InvalidOperationException("Connection string 'ExamanAppContextConnection' not found.");

builder.Services.AddDbContext<ExamanAppContext>(options =>options.UseSqlServer(connectionString));
builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ExamanAppContext>();
builder.Services.AddDbContext<Context>(options =>options.UseSqlServer(connectionString));


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireUppercase = false;
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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
