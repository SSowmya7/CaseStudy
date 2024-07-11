using CaseStudy.Core.Contracts.IUnitOfWork;
using CaseStudy.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace CaseStudy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserFavController(IUserFavServices _favServices) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cars>>> GetFavCars(int userId)
        {
            try
            {
                IEnumerable<Cars> cars = await _favServices.GetFavCars(userId);
                return Ok(cars);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error while retriveing cars at controller level");
                return Content(ex.ToString());
            }
        }




        [HttpPost]
        public async Task<ActionResult<UserFavourites>> AddFavCar(UserFavourites favourite)
        {
            try
            {
                await _favServices.AddFavCar(favourite);
                return Ok(favourite);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error while adding cars at controller level");
                return Content(ex.ToString());
            }
        }

        [HttpDelete("{userId}/{vin}")]
        public async Task<IActionResult> DeleteFavCar(int userId, string vin)
        {
            try
            {
                await _favServices.DeleteFavCar(userId, vin);
                return Ok("Deleted Successfully");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error while deleting cars at controller level");
                return Content(ex.ToString());
            }
        }
    }
}
