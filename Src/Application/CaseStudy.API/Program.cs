
using AutoMapper;
using CaseStudy.API.Config;
using CaseStudy.Core.Contracts.IReposritories;
using CaseStudy.Core.Contracts.IUnitOfWork;
using CaseStudy.Infrastructure.Data;
using CaseStudy.Infrastructure.rep;
using CaseStudy.Infrastructure.Repositories;
using CaseStudy.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;


namespace CaseStudy.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add _services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<PrjContext>(opt => opt.UseSqlServer(
              builder.Configuration.GetConnectionString("connectionString")));
            builder.Services.AddScoped<IMenuSettingsRepo, MenuSettingsRepo>();
            builder.Services.AddScoped<IMenuSettingsServices,MenuSettingsServices>();
            builder.Services.AddScoped<ILandingPageServices,LandingPageServices>();
            var mapper = AutoMapperConfiguration.IntializeMapper();
            builder.Services.AddSingleton(mapper);
            builder.Services.AddScoped<ICarRepo,CarRepo>();
            builder.Services.AddScoped<IUserFavRepo, UserFavRepo>();
            builder.Services.AddScoped<IUserFavServices, UserFavServices>();
            builder.Services.AddScoped<IHeaderFooterSettingsRepo, HeaderFooterSettingsRepo>();
            builder.Services.AddScoped<IHeaderFooterSettingsServices , HeaderFooterSettingsServices>();
            builder.Services.AddScoped<IPageSettingsRepo,PageSettingsRepo>();
            builder.Services.AddScoped<IPageSettingsServices , PageSettingsServices>();
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
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("AllowSpecificOrigin");


            app.MapControllers();

            app.Run();
        }
    }
}
