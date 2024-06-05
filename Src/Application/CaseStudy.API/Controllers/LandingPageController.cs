using CaseStudy.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseStudy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LandingPageController : ControllerBase
    {
        private readonly string Landing;
        PrjContext context;
        public LandingPageController(PrjContext prjContext)
        {
            context = prjContext;

        }
        [HttpGet]
        public IActionResult GetPageSettings(string Landing)
        {
            return Ok();
        }
        [HttpGet]
        public IActionResult GetRandom10Cars()
        {
            return Ok();
        }
    }
}
