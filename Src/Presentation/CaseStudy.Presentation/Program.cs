using CaseStudy.Core.Contracts.IReposritories;
using CaseStudy.Core.Contracts.IUnitOfWork;
using CaseStudy.Infrastructure.Data;
using CaseStudy.Infrastructure.rep;
using CaseStudy.Infrastructure.Repositories;
using CaseStudy.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy.Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<PrjContext>(opt => opt.UseSqlServer(
             builder.Configuration.GetConnectionString("connectionString")));
            builder.Services.AddScoped<IMenuSettingsRepo, MenuSettingsRepo>();
            builder.Services.AddScoped<IMenuSettingsServices, MenuSettingsServices>();
            builder.Services.AddScoped<ILandingPageServices, LandingPageServices>();
            builder.Services.AddScoped<ICarRepo, CarRepo>();
            builder.Services.AddScoped<IUserFavRepo, UserFavRepo>();
            builder.Services.AddScoped<IUserFavServices, UserFavServices>();
            builder.Services.AddScoped<IHeaderFooterSettingsRepo, HeaderFooterSettingsRepo>();
            builder.Services.AddScoped<IHeaderFooterSettingsServices, HeaderFooterSettingsServices>();
            builder.Services.AddScoped<IPageSettingsRepo, PageSettingsRepo>();
            builder.Services.AddScoped<IPageSettingsServices, PageSettingsServices>();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:5173")
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
