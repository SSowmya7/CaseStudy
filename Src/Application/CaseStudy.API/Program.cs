
using CaseStudy.Core.Contracts.IReposritories;
using CaseStudy.Core.Contracts.IUnitOfWork;
using CaseStudy.Infrastructure.Data;
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

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<PrjContext>(opt => opt.UseSqlServer(
              builder.Configuration.GetConnectionString("dbcn")));
            builder.Services.AddScoped<ILandingPageServices ,LandingPageServices>();
            builder.Services.AddScoped<ILandingPageRepo ,LandingPageRepo>();
            builder.Services.AddScoped<ICarServices,CarServices>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
