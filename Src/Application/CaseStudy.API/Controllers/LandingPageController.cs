using CaseStudy.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using CaseStudy.Infrastructure;
using CaseStudy.Infrastructure.UnitOfWork;
using CaseStudy.Core.Contracts.IUnitOfWork;
using CaseStudy.Core.Models;
using Microsoft.Data.SqlClient;
namespace CaseStudy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LandingPageController : ControllerBase
    {

        ILandingPageServices services;
       // ICarServices carServices;
        public LandingPageController(ILandingPageServices landingPageServices)
        {
           // carServices = Carservices;
            services = landingPageServices;

        }

        [HttpGet]
        public async Task<IActionResult> GetRandom10Cars()
        {
            try
            {
                var cars = await services.Get10RandomCars();
                return Ok(cars);
            }
            catch{
                throw new Exception();
            }
        }


        //------------WROTE TO CHECK CARSERVICES ENDPOINTS---------
        //[HttpGet("/allCars")]
        //public async Task<IEnumerable<Cars>> GetAllCars()
        //{
        //    return await carServices.GetAllCars();



        //}
        //[HttpGet("/{vin}")]
        //public async Task<Cars> GetCarByVin(string vin)
        //{
        //    return await carServices.GetCarByVin(vin);
        //}


        //[HttpGet("/similarCars{vin}")]
        //public async Task<IEnumerable<Cars>> GetSimilarCars(string vin)
        //{
        //    return await carServices.GetSimilarCarsAsync(vin);
        //}
        //[HttpGet("/favCars{userId}")]
        //public async Task<IEnumerable<Cars>> GetfavouriteCars(int userId)
        //{
        //    return await carServices.GetFavouriteCarsByUserIdAsync(userId);
        //}
        //[HttpGet("/filterCars")]
        //public async Task<IEnumerable<Cars>> GetfilteredCars(string make = null, string model = null, int? year = null, string color = null)
        //{
        //    return await carServices.GetCarsByFiltersAsync(make,model,year,color);
        //}


    }
}
