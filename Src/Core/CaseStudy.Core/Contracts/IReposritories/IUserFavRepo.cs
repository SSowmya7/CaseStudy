using CaseStudy.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Core.Contracts.IReposritories
{
    public interface IUserFavRepo
    {
        public Task<IEnumerable<Cars>> GetFavCars(int userId);

        public Task<bool> AddFavCar(UserFavourites favourite);
        public  Task<bool> DeleteFavCar(int userId, string vin);
    }
}
