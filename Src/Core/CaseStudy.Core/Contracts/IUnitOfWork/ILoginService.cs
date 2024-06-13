using CaseStudy.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Core.Contracts.IUnitOfWork
{
    public interface ILoginService
    {
        public string Login(Users user);
       
    }
}
