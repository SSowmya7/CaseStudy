using CaseStudy.Core.Models;
using CaseStudy.Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CaseStudy.Core.Contracts.IUnitOfWork;
using CaseStudy.Infrastructure.Repositories;
using CaseStudy.Core.Contracts.IReposritories;

namespace CaseStudy.Infrastructure.UnitOfWork
{
    public class LoginService :ILoginService
    {
        private readonly ILoginRepo loginRepo;
 
        public LoginService(ILoginRepo _loginRepo) 
        {
            loginRepo = _loginRepo;
           
        }

        
        public string Login(Users user)
        {
            string userToken = loginRepo.Login(user);
            return userToken;
        }
        
    }
}
