using CaseStudy.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Core.Contracts.IReposritories
{
    public interface ILoginRepo
    {
        public string Login(Users user);
       
        public bool ValidateUser(Users LoginUser);
    }
}
