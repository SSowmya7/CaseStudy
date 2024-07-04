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
    public class LoginController : ControllerBase
    {
        private readonly ILoginService loginService;
        public LoginController(ILoginService _loginService)
        {
            loginService = _loginService;

        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post(Users user)
        {
                var Token =  loginService.Login(user);
                return Ok(Token);
           
        }



    }
}
