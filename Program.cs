using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SWProducts.Data;
using SWProducts.Models;
// using SWProducts.Areas.Identity.Pages;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddIdentity<SuperUser, IdentityRole>(options => {
options.Password.RequireDigit = true;
options.Password.RequireUppercase = true;
options.Password.RequireNonAlphanumeric = true;
}).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders().AddDefaultUI();    


builder.Services.AddControllersWithViews();

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
app.MapRazorPages();
// app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
