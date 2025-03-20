using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.ComponentModel.Design;
using WssApplication.Domain.Entities;
using WssApplication.Infrastructure.Db;
using WssApplication.Infrastructure.ServiceInterfaces;
using WssApplication.Shared.Dtos.Company;

namespace WssApplication.Infrastructure.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ILogger<CompanyService> _logger;
        private readonly PgContext _pgContext;
        private readonly IMapper _mapper;

        public CompanyService(
            ILogger<CompanyService> logger,
            PgContext pgContext,
            IMapper mapper)
        {
            _logger = logger;
            _pgContext = pgContext;
            _mapper = mapper;
        }

        public async Task<ICollection<CompanyDto>> GetCompanies()
        {
            var companiesFromDb = await _pgContext.Companies
                .Include(x => x.Departments)
                .ThenInclude(x => x.Divisions)
                .ToListAsync();

            var result = _mapper.Map<ICollection<Company>, ICollection<CompanyDto>>(companiesFromDb);

            return result;
        }

        public async Task<CompanyDto> GetCompanyById(int companyId)
        {
            var companyFromDb = GetCompany(companyId);

            if (companyFromDb == null) throw new Exception($"Not found company with id {companyId}");

            var result = _mapper.Map<Company, CompanyDto>(companyFromDb);

            return result;
        }

        public async Task<CompanyDto> CreateCompany(CompanyCreationDto companyCreationDto)
        {
            var newCompany = _mapper.Map<CompanyCreationDto, Company>(companyCreationDto);

            await _pgContext.AddAsync(newCompany);
            await _pgContext.SaveChangesAsync();

            var result = _mapper.Map<Company,CompanyDto>(newCompany);

            return result;
        }

        public async Task<CompanyDto> UpdateCompany(CompanyUpdateDto companyUpdateDto, int companyId)
        {
            var companyToUpdate = await _pgContext.Companies.FirstOrDefaultAsync(x => x.Id == companyId);

            if (companyToUpdate == null) throw new Exception($"Not found company with id {companyId}");


            companyToUpdate.Name = companyUpdateDto.Name;
            _pgContext.Companies.Update(companyToUpdate);
            await _pgContext.SaveChangesAsync();

            var companyFromDb = GetCompany(companyId);

            var result = _mapper.Map<Company, CompanyDto>(companyFromDb);

            return result;
        }

        public async Task DeleteCompany(int companyId)
        {
            var company = await _pgContext.Companies.FirstOrDefaultAsync(x => x.Id == companyId);

            if (company == null)
            {
                throw new Exception($"Can't be delete company with id {companyId}");
            }

            _pgContext.Companies.Remove(company);
            await _pgContext.SaveChangesAsync();
        }

        private Company? GetCompany(int companyId)
        {
            return _pgContext.Companies
                .Where(x => x.Id == companyId)
                .Select(x => new
                {
                    Company = x,
                    Departments = x.Departments
                    .OrderBy(x => x.Position)
                    .Select(y => new
                    {
                        Department = y,
                        Divisions = y.Divisions
                        .OrderBy(x => x.Position).ToList()
                    }).ToList()
                })
                .AsEnumerable()
                .Select(x =>
                {
                    x.Company.Departments = x.Departments
                        .Select(y =>
                        {
                            y.Department.Divisions = y.Divisions;
                            return y.Department;
                        }).ToList();
                    return x.Company;
                })
                .FirstOrDefault();
        }
    }
}
