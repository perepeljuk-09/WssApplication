using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WssApplication.Infrastructure.Db;
using WssApplication.Infrastructure.ServiceInterfaces;
using WssApplication.Shared.Dtos.Division;

namespace WssApplication.Infrastructure.Services
{
    public class DivisionService : IDivisionService
    {
        private readonly ILogger<DivisionService> _logger;
        private readonly PgContext _pgContext;
        private readonly IMapper _mapper;

        public DivisionService(
            ILogger<DivisionService> logger,
            PgContext pgContext,
            IMapper mapper)
        {
            _logger = logger;
            _pgContext = pgContext;
            _mapper = mapper;
        }

        public async Task<ICollection<DivisionDto>> GetDivisionsByDepartmentId(int departmentId)
        {
            throw new NotImplementedException();
        }
        public async Task<DivisionDto> GetDivisionById(int divisionId)
        {
            throw new NotImplementedException();
        }

        public async Task<DivisionDto> CreateDivision(DivisionCreationDto divisionCreationDto)
        {
            throw new NotImplementedException();
        }
        public async Task<DivisionDto> UpdateDivision(DivisionUpdateDto divisionUpdateDto, int divisionId)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteDivision(int divisionId)
        {
            throw new NotImplementedException();
        }

        public async Task Move(DivisionMoveDto divisionMoveDto)
        {
            throw new NotImplementedException();
        }
    }
}
