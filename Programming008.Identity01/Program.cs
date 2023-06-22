using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

using Programming008.Identity01.Domain.Abstract;
using Programming008.Identity01.Domain.DataAccess;
using Programming008.Identity01.Domain.Entities;
using Programming008.Identity01.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IUserRoleStore<Account>, UserStore>();
builder.Services.AddTransient<IUserStore<Account>, UserStore>();
builder.Services.AddTransient<IRoleStore<Role>, RoleStore>();

builder.Services.AddIdentity<Account, Role>();

builder.Services.ConfigureApplicationCookie(o =>
{
    o.LoginPath = "/Account/SignIn";
    o.Cookie.Expiration = TimeSpan.FromDays(1);
});

builder.Services.Configure<IdentityOptions>(opt =>
{
    opt.Password.RequiredUniqueChars = 0;
    opt.Password.RequiredLength = 4;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireDigit = false;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = false;
});

// Add services to the container.
//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie(o =>
//    {
//        o.LoginPath = "/Account/SignIn";
//    });

builder.Services.AddSingleton<IAccountRepository, InMemoryAccountRepository>();
builder.Services.AddSingleton<IAccountRoleRepository, InMemoryAccountRoleRepository>();
builder.Services.AddSingleton<IRoleRepository, InMemoryRoleRepository>();


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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
