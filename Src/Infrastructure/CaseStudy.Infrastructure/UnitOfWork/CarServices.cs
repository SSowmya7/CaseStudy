using CaseStudy.Core.Contracts.IUnitOfWork;
using CaseStudy.Core.Models;
using CaseStudy.Infrastructure.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace CaseStudy.Infrastructure.UnitOfWork
{
    public class CarServices : ICarServices
    {
        private readonly PrjContext context;
        private readonly string _connectionString;
        public CarServices(PrjContext Context, IConfiguration configuration)
        {
            context = Context;
            _connectionString = configuration.GetConnectionString("dbcn");
        }
        public async Task<IEnumerable<Cars>> Get10RandomCars()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT TOP 10 * FROM Cars ";
                var cars = await connection.QueryAsync<Cars>(sql);
                return cars;
            }


        }
        public async Task<IEnumerable<Cars>> GetAllCars()
        {
            using (var connection = new SqlConnection(_connectionString))
            {

                var cars = await connection.QueryAsync<Cars>("GetAllCars", commandType: System.Data.CommandType.StoredProcedure);
                return cars;
            }


        }
        public async Task<Cars> GetCarByVin(string vin)
        {
            return await context.cars.FirstOrDefaultAsync(c => c.VIN == vin);
        }

        public async Task<IEnumerable<Cars>> GetSimilarCarsAsync(string vin)
        {
            // Find the car by VIN
            var car = await GetCarByVin(vin);
            if (car == null)
            {
                return Enumerable.Empty<Cars>();
            }


            var cars = await context.cars
                .Where(c => c.Make == car.Make
                //  && c.Model == car.Model 
                && c.HomeNetVehicleId != car.HomeNetVehicleId)
                .ToListAsync();

            return cars;
        }

        public async Task<IEnumerable<Cars>> GetFavouriteCarsByUserIdAsync(int userId)
        {

            using (var connection = new SqlConnection(_connectionString))
            {
                string sql = @$"
                SELECT c.*
                FROM UserFavourites uf
                JOIN Cars c ON uf.VIN = c.VIN
               
                WHERE uf.UserId = {userId}";



                return await connection.QueryAsync<Cars>(sql);
            }
        }

        public async Task<IEnumerable<Cars>> GetCarsByFiltersAsync(string make = null, string model = null, int? year = null, string color = null)
        {
            IQueryable<Cars> query = context.cars;

            if (!string.IsNullOrEmpty(make))
            {
                query = query.Where(c => c.Make == make);
            }

            if (!string.IsNullOrEmpty(model))
            {
                query = query.Where(c => c.Model == model);
            }

            if (year.HasValue)
            {
                query = query.Where(c => c.Year == year.Value);
            }

            if (!string.IsNullOrEmpty(color))
            {
                query = query.Where(c => c.InteriorColor == color);
            }

            return await query.ToListAsync();
        }





    }
}
