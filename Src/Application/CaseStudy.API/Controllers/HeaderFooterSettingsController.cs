using CaseStudy.Core.Contracts.IUnitOfWork;
using CaseStudy.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CaseStudy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeaderFooterSettingsController(IHeaderFooterSettingsServices headerFooterSettingsServices) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetHeaderFoooterSettings()
        {
            var settings =  await headerFooterSettingsServices.GetHeaderFooterSettings();
            if (settings == null)
            {
                return NotFound("No records Found");
            }
            return Ok(settings);
        }
        [HttpGet("/{dealerId}")]
        public async Task<IActionResult> GetHeaderFoooterSettingsById( int dealerId)
        {
            var settings = await headerFooterSettingsServices.GetHeaderFooterSettingsById(dealerId);
            if (settings == null)
            {
                return NotFound("No records Found");
            }
            return Ok(settings);
        }
        [HttpPost]
        public async Task<IActionResult> AddHeaderFooterSettings(HeaderAndFooterSettings headerAndFooterSettings)
        {
            var settings = await headerFooterSettingsServices.AddHeaderAndFooterSettings(headerAndFooterSettings);
            if (!settings)
            {
                return BadRequest("Dealer Not Found, Cannot add the record");
            }
            return Ok(headerAndFooterSettings);
        }
        [HttpPut("/{dealerId}")]
        public async Task<IActionResult> UpdateHeaderFooterSettings(int dealerId ,HeaderAndFooterSettings headerAndFooterSettings)
        {
            var settings = await headerFooterSettingsServices.UpdateHeaderAndFooterSettings(headerAndFooterSettings);
            if (!settings)
            {
                return BadRequest("Dealer Not Found, Cannot update the record");
            }
            return Ok($"Record with Dealer Id :- {headerAndFooterSettings.DealerId} updated successfully ");

        }
        [HttpDelete("/{dealerId}")]
        public async Task<IActionResult> DeleteHeaderFooterSettings(int dealerId)
        {
            var settings = await headerFooterSettingsServices.DeleteHeaderAndFooterSettings(dealerId);
            if (!settings)
            {
                return BadRequest("Dealer Not Found, Cannot delete the record");
            }
            return Ok($"Record with Dealer Id :- {dealerId} deleted successfully ");
        }
        
       

}
}
