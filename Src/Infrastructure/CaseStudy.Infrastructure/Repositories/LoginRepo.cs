using CaseStudy.Core.Contracts.IReposritories;
using CaseStudy.Core.Models;
using CaseStudy.Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CaseStudy.Infrastructure.Repositories
{
    public class LoginRepo:ILoginRepo
    {
        private readonly IConfiguration _configuration;
        public PrjContext context;
        public LoginRepo(IConfiguration configuration, PrjContext PrjContext) 
        {
            _configuration = configuration;
            context = PrjContext;
        }

        public bool  ValidateUser(Users LoginUser)
        {
            var user = context.Users.SingleOrDefault(u => u.FirstName == LoginUser.FirstName);
            if (user != null && user.FirstName == LoginUser.FirstName && user.Password == LoginUser.Password)
            {
                return true;
            }
            return false;
        }
        public string Login(Users user)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JWTSECRET:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.FirstName),


                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            string userToken = tokenHandler.WriteToken(token);
            return userToken;
        }
      
    }
}
