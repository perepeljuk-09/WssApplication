using AutoMapper;
using WssApplication.Shared.Dtos.Company;

namespace WssApplication.Infrastructure.Mapper.Company
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<CompanyCreationDto, WssApplication.Domain.Entities.Company>();

            CreateMap<WssApplication.Domain.Entities.Company, CompanyDto>();
        }
    }
}
