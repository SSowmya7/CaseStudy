using CaseStudy.Core.Contracts.IUnitOfWork;
using CaseStudy.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CaseStudy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserFavController : ControllerBase
    {
        private IUserFavServices userFavServices;
        public UserFavController(IUserFavServices favServices)
        {
            userFavServices = favServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cars>>> GetFavCars(int userId)
        {
            try
            {
              IEnumerable<Cars> cars =  await userFavServices.GetFavCars(userId);
                return Ok(cars);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }




        [HttpPost]
        public async Task<ActionResult<UserFavourites>> AddFavCar(UserFavourites favourite)
        {
            try
            {
                await userFavServices.AddFavCar(favourite);
                return Ok(favourite);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("/{vin}")]
        public async Task<IActionResult> DeleteFavCar(int userId, string vin)
        {
            try
            {
                await userFavServices.DeleteFavCar(userId, vin);
                return NoContent();
            }
            catch { }
            {
                throw new Exception();
            }
        }
    }
}
