using AutoMapper;
using WssApplication.Shared.Dtos.Department;

namespace WssApplication.Infrastructure.Mapper.Department
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<DepartmentCreationDto, WssApplication.Domain.Entities.Department>();

            CreateMap<WssApplication.Domain.Entities.Department, DepartmentDto>();
        }
    }
}
