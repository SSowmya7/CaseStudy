using CaseStudy.Core.Contracts.IUnitOfWork;
using CaseStudy.Core.Models;
using CaseStudy.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CaseStudy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController(ILoginService _loginService) : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        public  IActionResult Post(Users user)
        {
                var Token =  _loginService.Login(user);
                return Ok(Token);
           
        }



    }
}
