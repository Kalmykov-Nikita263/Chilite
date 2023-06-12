using Chilite.Domain.Repository.Abstractions;
using Chilite.Domain.Repository.EntityFramework;
using Chilite.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Chilite.Services;
using Chilite.Hubs;

namespace Chilite;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddTransient<IAnswersRepository, EFAnswersRepository>();
        builder.Services.AddTransient<IQuestionsRepository, EFQuestionsRepository>();
        builder.Services.AddTransient<IInterviewsRepository, EFInterviewsRepository>();

        builder.Services.AddTransient<DataManager>();

        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseLazyLoadingProxies()
            .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
        });

        builder.Services.AddIdentity<IdentityUser, IdentityRole>(settings =>
        {
            settings.User.RequireUniqueEmail = true;
            settings.Password.RequiredLength = 6;
            settings.Password.RequireNonAlphanumeric = false;
            settings.Password.RequireUppercase = true;
            settings.Password.RequireLowercase = false;
            settings.Password.RequireDigit = false;
        }).AddEntityFrameworkStores<ApplicationDbContext>()
        .AddDefaultTokenProviders();

        builder.Services.ConfigureApplicationCookie(cookieOptions =>
        {
            cookieOptions.ExpireTimeSpan = TimeSpan.FromDays(14);

            cookieOptions.Cookie.SameSite = SameSiteMode.None;
            cookieOptions.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            cookieOptions.Cookie.Name = "ChiliteAuth";
            cookieOptions.Cookie.HttpOnly = true;

            cookieOptions.LoginPath = "/account/login";
            cookieOptions.AccessDeniedPath = "/account/accessdenied";
            cookieOptions.SlidingExpiration = true;
        });

        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("AdminArea", policy => policy.RequireRole("admin"));
        });

        builder.Services.AddControllersWithViews(options =>
        {
            options.Conventions.Add(new AdminAreaAuthorizationService("Admin", "AdminArea"));
        });

        builder.Services.AddSignalR();

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHsts();
        app.UseHttpsRedirection();
        
        app.UseStaticFiles();

        app.UseRouting();

        app.UseCookiePolicy();
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapHub<ChatHub>("/chatHub");

        app.MapControllerRoute(
            name: "admin",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
        );

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}"
        );

        app.Run();
    }
}