using CaseStudy.Core.Contracts.IUnitOfWork;
using CaseStudy.Core.Models;
using CaseStudy.Infrastructure.UnitOfWork;
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
            var settings = await headerFooterSettingsServices.GetHeaderFooterSettings();
            if (settings == null)
            {
                return NotFound("No records Found");
            }
            return Ok(settings);
        }
        [HttpGet("{dealerId:int}")]
        public async Task<IActionResult> GetHeaderFoooterSettingsById(int dealerId)
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
            if (headerAndFooterSettings == null)
            {

                return Content("Invalid data");
            }

            var result = await headerFooterSettingsServices.AddHeaderAndFooterSettings(headerAndFooterSettings);
            if (!result)
            {
                return Content("Dealer not found, cannot add the record");
            }
            return CreatedAtAction(nameof(GetHeaderFoooterSettingsById), new { dealerId = headerAndFooterSettings.DealerId }, headerAndFooterSettings);

        }
        [HttpPut("{dealerId:int}")]
        public async Task<IActionResult> UpdateHeaderFooterSettings(int dealerId, HeaderAndFooterSettings headerAndFooterSettings)
        {
            if (headerAndFooterSettings.DealerId != dealerId)
            {
                return Content("Invalid data");
            }

            var result = await headerFooterSettingsServices.UpdateHeaderAndFooterSettings(headerAndFooterSettings);
            if (!result)
            {
                return Content("Dealer not found, cannot update the record");
            }
            return Ok($"Record with Dealer Id: {headerAndFooterSettings.DealerId} updated successfully");

        }
        [HttpDelete("{dealerId:int}")]
        public async Task<IActionResult> DeleteHeaderFooterSettings(int dealerId)
        {
            var settings = await headerFooterSettingsServices.DeleteHeaderAndFooterSettings(dealerId);
            if (!settings)
            {
                return Content("Dealer Not Found, Cannot delete the record");
            }
            return Ok($"Record with Dealer Id :- {dealerId} deleted successfully ");
        }



    }
}
