using AutoMapper;
using WssApplication.Shared.Dtos.Division;

namespace WssApplication.Infrastructure.Mapper.Division
{
    public class DivisionProfile : Profile
    {
        public DivisionProfile()
        {
            CreateMap<DivisionCreationDto, WssApplication.Domain.Entities.Division>();

            CreateMap<WssApplication.Domain.Entities.Division, DivisionDto>();
        }
    }
}
