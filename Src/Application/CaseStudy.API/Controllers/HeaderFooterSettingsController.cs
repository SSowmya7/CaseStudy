using CaseStudy.Core.Contracts.IUnitOfWork;
using CaseStudy.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CaseStudy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeaderFooterSettingsController : ControllerBase
    {
        private IHeaderFooterSettingsServices services;
        public HeaderFooterSettingsController(IHeaderFooterSettingsServices headerFooterSettingsServices)
        {
            services = headerFooterSettingsServices;
        }
        [HttpGet]
        public async Task<IActionResult> GetHeaderFoooterSettings()
        {
            var settings =  await services.GetHeaderFooterSettings();
            if (settings == null)
            {
                return NotFound("No records Found");
            }
            return Ok(settings);
        }
        [HttpGet("/{DealerId}")]
        public async Task<IActionResult> GetHeaderFoooterSettingsById( int DealerId)
        {
            var settings = await services.GetHeaderFooterSettingsById(DealerId);
            if (settings == null)
            {
                return NotFound("No records Found");
            }
            return Ok(settings);
        }
        [HttpPost]
        public async Task<IActionResult> AddHeaderFooterSettings(HeaderAndFooterSettings headerAndFooterSettings)
        {
            var settings = await services.AddHeaderAndFooterSettings(headerAndFooterSettings);
            if (!settings)
            {
                return BadRequest("Dealer Not Found, Cannot add the record");
            }
            return Ok(headerAndFooterSettings);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateHeaderFooterSettings(HeaderAndFooterSettings headerAndFooterSettings)
        {
            var settings = await services.UpdateHeaderAndFooterSettings(headerAndFooterSettings);
            if (!settings)
            {
                return BadRequest("Dealer Not Found, Cannot update the record");
            }
            return Ok($"Record with Dealer Id :- {headerAndFooterSettings.DealerId} updated successfully ");

        }
        [HttpDelete]
        public async Task<IActionResult> DeleteHeaderFooterSettings(int DealerId)
        {
            var settings = await services.DeleteHeaderAndFooterSettings(DealerId);
            if (!settings)
            {
                return BadRequest("Dealer Not Found, Cannot delete the record");
            }
            return Ok($"Record with Dealer Id :- {DealerId} deleted successfully ");
        }
        
       

}
}
