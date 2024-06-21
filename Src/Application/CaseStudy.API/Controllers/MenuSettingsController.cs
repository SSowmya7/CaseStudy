using AutoMapper;
using CaseStudy.Application.VM;
using CaseStudy.Core.Contracts.IUnitOfWork;
using CaseStudy.Core.DTO;
using CaseStudy.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace CaseStudy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuSettingsController(IMenuSettingsServices _menuSettingsServices, IMapper _mapper) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuSettings>>> GetMenuSettings()
        {
            try
            {
                var menuSettings =  await _menuSettingsServices.GetMenuSettings();
                if (menuSettings == null)
                {
                    return NoContent();
                }
                return Ok(menuSettings);
            }
          catch (Exception ex)
            {
                Log.Error(ex,"An error while retrieving the records");
                return NoContent();
            }
        }
        [HttpGet("/{dealerId}")]
        public async Task<ActionResult<MenuSettings>> GetMenuSettingsById(int dealerId)
        {
            try
            {

                var menuSettings = await _menuSettingsServices.GetMenuSettingsById(dealerId);
                if (menuSettings == null)
                {
                    return NotFound("Dealer Not Found");
                }
                return Ok(menuSettings);
            }
            catch (Exception ex)
            {
                Log.Error(ex,"Cannot Fetch MenuSettings of the Dealer");
                return NoContent();

            }
        }
        [HttpPost]
        public async Task<ActionResult<MenuSettings>> AddMenuSettings(MenuSettings menuSettings)
        {
            try
            {
               var add =  await _menuSettingsServices.AddMenuSettings(menuSettings);
                if (!add)
                {
                    return NotFound("Dealer Not Found");
                }
                return Ok(menuSettings);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Cannot Add MenuSettings of the Dealer");
                return NoContent();

            }
        }
        [HttpPut("/{dealerId}")]

        public async Task<ActionResult<MenuSettings>> UpdateMenuSettings(int dealerId ,MenuSettingsVM menuSetting)
        {
            try
            {
                var menuSettings = _mapper.Map<MenuSettingsVM,MenuSettingsDTO>(menuSetting);
                var updateRecord =  await _menuSettingsServices.UpdateMenuSettings(menuSettings);
                if (!updateRecord)
                {
                    return NotFound("Record Not Found");
                }
                return Ok(menuSetting);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Cannot Update MenuSettings of the Dealer");
                return NoContent();
            }
        }

        [HttpDelete("/{dealerId}")]
        public async Task<ActionResult> DeleteMenuSettings(int dealerId)
        {
            try
            {
                var deleteRecord = await _menuSettingsServices.DeleteMenuSettings(dealerId);
                if (!deleteRecord)
                {
                    return NotFound("Record Not Found");
                }
                return Ok($"Record with DealerId:- {dealerId} Successfully deleted");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Cannot Delete MenuSettings of the Dealer");
                return NoContent();
            }
        }

    }
}
