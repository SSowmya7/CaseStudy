using CaseStudy.Core.Contracts.IUnitOfWork;
using CaseStudy.Core.Models;
using CaseStudy.Infrastructure.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
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
            _connectionString = configuration.GetConnectionString("dbcn") ??"NoConnections";
        }
        public async Task<IEnumerable<Cars>> Get10RandomCars()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var sql = "SELECT TOP 10 * FROM Cars ";
                    var cars = await connection.QueryAsync<Cars>(sql);
                    return cars;
                }
            }
            catch(Exception ex) { 
            
                throw new Exception(ex.ToString());
            }
            

        }
        public async Task<IEnumerable<Cars>> GetAllCars()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {

                    var cars = await connection.QueryAsync<Cars>("GetAllCars", commandType: System.Data.CommandType.StoredProcedure);
                    return cars;
                }
            }
            catch
            {
                throw new Exception();
            }

        }
        public async Task<Cars> GetCarByVin(string vin)
        {
            return await context.Cars.FirstOrDefaultAsync(c => c.VIN == vin);
        }

        public async Task<IEnumerable<Cars>> GetSimilarCarsAsync(string vin)
        {
            try
            {
                // Find the car by VIN
                var car = await GetCarByVin(vin);
                if (car == null)
                {
                    return Enumerable.Empty<Cars>();
                }


                var cars = await context.Cars
                    .Where(c => c.Make == car.Make
                    //  && c.Model == car.Model 
                    && c.HomeNetVehicleId != car.HomeNetVehicleId)
                    .ToListAsync();

                return cars;
            }
            catch
            {
                throw new Exception();
            }
        }

        public async Task<IEnumerable<Cars>> GetFavouriteCarsByUserIdAsync(int userId)
        {
            try
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
            catch
            {
                throw new Exception();
            }
        }
        
        public async Task<IEnumerable<Cars>> GetCarsByFiltersAsync(string make = null, string model = null, int? year = null, string color = null)
        {
            try
            {
                IQueryable<Cars> query = context.Cars;

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
            catch
            {
                throw new Exception();
            }
        }





    }
}
