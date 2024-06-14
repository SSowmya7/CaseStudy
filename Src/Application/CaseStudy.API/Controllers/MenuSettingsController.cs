using AutoMapper;
using CaseStudy.Application.VM;
using CaseStudy.Core.Contracts.IUnitOfWork;
using CaseStudy.Core.DTO;
using CaseStudy.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace CaseStudy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuSettingsController : ControllerBase
    {
        private IMenuSettingsServices menuSettingsServices;
        private IMapper mapper;
        public MenuSettingsController(IMenuSettingsServices imenuSettingsServices,IMapper _mapper)
        {

            menuSettingsServices = imenuSettingsServices;
            mapper = _mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<MenuSettings>>> GetMenuSettings()
        {
            try
            {
                var menuSettings =  await menuSettingsServices.GetMenuSettings();
                if (menuSettings == null)
                {
                    return BadRequest("No Records Found");
                }
                return Ok(menuSettings);
            }
            catch (Exception ex)
            {
                throw new Exception("Cannot Fetch MenuSettings", ex);

            }
        }
        [HttpGet("/{DealerId}")]
        public async Task<ActionResult<MenuSettings>> GetMenuSettingsById(int DealerId)
        {
            try
            {

                var menuSettings = await menuSettingsServices.GetMenuSettingsById(DealerId);
                if (menuSettings == null)
                {
                    return BadRequest("Record Not Found");
                }
                return Ok(menuSettings);
            }
            catch (Exception ex)
            {
                throw new Exception($"Cannot Fetch MenuSettings of the Dealer:- {DealerId}", ex);

            }
        }
        [HttpPost]
        public async Task<ActionResult<MenuSettings>> AddMenuSettings(MenuSettings menuSettings)
        {
            try
            {
               var add =  await menuSettingsServices.AddMenuSettings(menuSettings);
                if (!add)
                {
                    return NotFound("Dealer Not Found");
                }
                return Ok(menuSettings);
            }
            catch
            {
                throw new Exception();
            }
        }
        [HttpPut]

        public async Task<ActionResult<MenuSettings>> UpdateMenuSettings(MenuSettingsVM menuSetting)
        {
            try
            {
                var menuSettings = mapper.Map<MenuSettingsVM,MenuSettingsDTO>(menuSetting);
                var updateRecord =  await menuSettingsServices.UpdateMenuSettings(menuSettings);
                if (!updateRecord)
                {
                    return NotFound("Record Not Found");
                }
                return Ok(menuSetting);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the menu settings.", ex);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteMenuSettings(int DealerId)
        {
            try
            {
                var deleteRecord = await menuSettingsServices.DeleteMenuSettings(DealerId);
                if (deleteRecord == false)
                {
                    return NotFound("Record Not Found");
                }
                return Ok($"Record with DealerId:- {DealerId} Successfully deleted");
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the menu settings.", ex);
            }
        }

    }
}
