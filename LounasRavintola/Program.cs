
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using LounasRavintola.Data;
using Microsoft.EntityFrameworkCore;
using LounasRavintola.Services;
using Microsoft.AspNetCore.Identity;
using LounasRavintola.Areas.Identity.Data;
using Microsoft.AspNetCore.Components.Authorization;
using LounasRavintola.Areas.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<WeekMenuContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("MenuDb")));

builder.Services.AddDefaultIdentity<LounasRavintolaUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<UserContext>();builder.Services.AddDbContext<UserContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("UserDb")));

builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<LounasRavintolaUser>>();

builder.Services.AddScoped<WeekMenuService>();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
