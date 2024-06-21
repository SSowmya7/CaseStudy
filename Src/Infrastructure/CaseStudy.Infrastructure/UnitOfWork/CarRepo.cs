using CaseStudy.Core.Contracts.IUnitOfWork;
using CaseStudy.Core.Models;
using CaseStudy.Infrastructure.Constants;
using CaseStudy.Infrastructure.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
using System.Data;

namespace CaseStudy.Infrastructure.UnitOfWork
{
    public class CarRepo(PrjContext Context, IConfiguration configuration) : ICarRepo
    {
        private readonly string _connectionString = configuration.GetConnectionString("connectionString") ?? "NoConnections";

        public async Task<IEnumerable<Cars>> Get10RandomCars()
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                var sql = QueryConstants.randomCarsQuery; 
                var cars = await connection.QueryAsync<Cars>(sql);
                return cars;
            }
            catch(Exception ex) {

                Log.Error(ex, "An error occured while retrieving Cars");
                return [];
            }
            

        }
        public async Task<IEnumerable<Cars>> GetAllCars()
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);

                var cars = await connection.QueryAsync<Cars>("GetAllCars", commandType: System.Data.CommandType.StoredProcedure);
                return cars;
            }
            catch (Exception ex)
            {

                Log.Error(ex, "An error occured while retrieving Cars");
                return [];
            }

        }
        public async Task<Cars?> GetCarByVin(string vin)
        {
            try
            {
                return await Context.Cars.FirstOrDefaultAsync(c => c.VIN == vin);
            }
            catch (Exception ex) {
                Log.Error(ex, "An error occured while retrieving car");
                return null ;
            }



        }

        public async Task<IEnumerable<Cars>> GetSimilarCarsAsync(string vin)
        {
            try
            {
                // Find the car by VIN
                var car = await GetCarByVin(vin);
                if (car == null)
                {
                    return [];
                }


                var cars = await Context.Cars
                    .Where(c => c.Make == car.Make
                    //  && c.Model == car.Model 
                    && c.HomeNetVehicleId != car.HomeNetVehicleId)
                    .ToListAsync();

                return cars;
            }
            catch (Exception ex)
            {

                Log.Error(ex, "An error occured while retrieving Cars");
                return [];
            }
        }

        public async Task<IEnumerable<Cars>> GetFavouriteCarsByUserIdAsync(int userId)
        {
            try
            {

                using var connection = new SqlConnection(_connectionString);
                string sql = QueryConstants.carByUserId;



                return await connection.QueryAsync<Cars>(sql);
            }
            catch (Exception ex)
            {

                Log.Error(ex, "An error occured while retrieving Cars");
                return [];
            }
        }
        
        public async Task<IEnumerable<Cars>> GetCarsByFiltersAsync(string make = null, string model = null, int? year = null, string color = null)
        {
            try
            {
                IQueryable<Cars> query = Context.Cars;

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
            catch (Exception ex)
            {

                Log.Error(ex, "An error occured while retrieving Cars");
                return [];
            }
        }





    }
}
