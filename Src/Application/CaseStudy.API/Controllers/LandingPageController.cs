using CaseStudy.Core.Contracts.IUnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Serilog;
namespace CaseStudy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LandingPageController(ILandingPageServices landingPageServices) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetRandom10Cars()
        {
            try
            {
                var cars = await landingPageServices.Get10RandomCars();
                
                return Ok(cars);
            }
            catch (Exception ex){
                Log.Error(ex,"An error occured while loading landing page");
               return BadRequest(ex);
            }
        }

    }
}
