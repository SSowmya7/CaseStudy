using CaseStudy.Core.Contracts.IUnitOfWork;
using Microsoft.AspNetCore.Mvc;
namespace CaseStudy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LandingPageController : ControllerBase
    {

       private readonly ILandingPageServices _services;
       
        public LandingPageController(ILandingPageServices landingPageServices)
        {
          
            _services = landingPageServices;

        }

        [HttpGet]
        public async Task<IActionResult> GetRandom10Cars()
        {
            try
            {
                var cars = await _services.Get10RandomCars();
                
                return Ok(cars);
            }
            catch (Exception ex){
               return BadRequest(ex);
            }
        }


       


    }
}
