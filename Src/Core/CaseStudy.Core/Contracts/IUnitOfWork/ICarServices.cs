using CaseStudy.Core.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Core.Contracts.IUnitOfWork
{
    public interface ICarServices
    {
        public Task<IEnumerable<Cars>> Get10RandomCars();

        public Task<IEnumerable<Cars>> GetAllCars();

        public Task<Cars> GetCarByVin(string vin);

        public Task<IEnumerable<Cars>> GetSimilarCarsAsync(string vin);


        public Task<IEnumerable<Cars>> GetFavouriteCarsByUserIdAsync(int userId);

        public Task<IEnumerable<Cars>> GetCarsByFiltersAsync(string make = null, string model = null, int? year = null, string color = null);


    }
}
