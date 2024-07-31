using CaseStudy.Application.VM;
using CaseStudy.Core.DTO;
using CaseStudy.Core.Models;
using CaseStudy.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace CaseStudy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PageSettingsController(PageSettingsServices services) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DealerPages>>> GetPageSettings()
        {
            try
            {
                var pageSettings = await services.GetPageSettings();
                if (pageSettings == null)
                {
                    return NoContent();
                }
                return Ok(pageSettings);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error while retrieving the records");
                return NoContent();
            }
        }
        [HttpGet("/{dealerId}")]
        public async Task<ActionResult<DealerPages>> GetPageSettingsById(int dealerId)
        {
            try
            {

                var menuSettings = await services.GetPageSettingsById(dealerId);
                if (menuSettings == null)
                {
                    return NotFound("Dealer Not Found");
                }
                return Ok(menuSettings);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Cannot Fetch MenuSettings of the Dealer");
                return NoContent();

            }
        }
        [HttpPost]
        public async Task<ActionResult<DealerPages>> AddMenuSettings(DealerPages pageSettings)
        {
            try
            {
                var add = await services.AddPageSettings(pageSettings);
                if (!add)
                {
                    return NotFound("Dealer Not Found");
                }
                return Ok(pageSettings);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Cannot Add Page Settings of the Dealer");
                return NoContent();

            }
        }
        [HttpPut("/{dealerId}")]

        public async Task<ActionResult<MenuSettings>> UpdateMenuSettings(DealerPages pageSetting)
        {
            try
            {
                //var menuSettings = _mapper.Map<MenuSettingsVM, MenuSettingsDTO>(menuSetting);
                var updateRecord = await services.UpdatePageSettings(pageSetting);
                if (updateRecord)
                {
                    return Ok(pageSetting);
                 
                }
                return NotFound("Record Not Found");

            }
            catch (Exception ex)
            {
                Log.Error(ex, "Cannot Update MenuSettings of the Dealer");
                return NoContent();
            }
        }

        [HttpDelete("/{dealerId}")]
        public async Task<ActionResult> DeletePageSettings(int dealerId,int pageId)
        {
            try
            {
                var deleteRecord = await services.DeletePageSettings(dealerId,pageId);
                if (!deleteRecord)
                {
                    return NotFound("Record Not Found");
                }
                return Ok($"Record with DealerId:- {dealerId} Successfully deleted");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Cannot Delete PageSettings of the Dealer");
                return NoContent();
            }
        }
    }
}
