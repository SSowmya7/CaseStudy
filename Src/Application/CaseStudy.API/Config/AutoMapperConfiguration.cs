using AutoMapper;
using CaseStudy.Application.VM;
using CaseStudy.Core.DTO;

namespace CaseStudy.API.Config
{
    public class AutoMapperConfiguration
    {
        public static IMapper IntializeMapper()
        {
            var mapper = new MapperConfiguration(cnfg =>
            {
                cnfg.CreateMap<MenuSettingsVM,MenuSettingsDTO>();
                
            });

            return mapper.CreateMapper();

        }
    }
}
