using Microsoft.AspNetCore.Mvc;
using WssApplication.Infrastructure.ServiceInterfaces;
using WssApplication.Shared.Dtos.Company;

namespace WssApplication.Controllers
{
    /// <summary>
    /// ���������� ���������� �� ������ � ���������
    /// ���������, ��������, ����������, ��������
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesController : ControllerBase
    {

        private readonly ILogger<CompaniesController> _logger;
        private readonly ICompanyService _companyService;

        public CompaniesController(
            ILogger<CompaniesController> logger,
            ICompanyService companyService)
        {
            _logger = logger;
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            // �������� ��� �������� ��� ����������� �� ����� �������
            var result = await _companyService.GetCompanies();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // �������� �������� � � �������������� � ��������
            var result = await _companyService.GetCompanyById(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CompanyCreationDto companyCreationDto)
        {
            // ������ ��������
            var result = await _companyService.CreateCompany(companyCreationDto);

            return Ok(result);

            // ����� ��������� ��������� ������
            // � ������ ���������� ������, ��� ������ ����������, � ���� ��������� ����� ������ ��� ����
            // CatalogHub => NotifyWasChanged
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] CompanyUpdateDto companyUpdateDto, int id)
        {
            // ��������� ������ ��������
            var result = await _companyService.UpdateCompany(companyUpdateDto, id);

            return Ok(result);

            // ����� ��������� ��������� ������
            // � ������ ���������� ������, ��� ������ ����������, � ���� ��������� ����� ������ ��� ����
            // CatalogHub => NotifyWasChanged
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // ������� ��������
            await _companyService.DeleteCompany(id);

            return Ok();

            // ����� ��������� ��������� ������
            // � ������ ���������� ������, ��� ������ ����������, � ���� ��������� ����� ������ ��� ����
            // CatalogHub => NotifyWasChanged
        }
    }
}
