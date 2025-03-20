using Microsoft.AspNetCore.Mvc;
using WssApplication.Infrastructure.ServiceInterfaces;
using WssApplication.Shared.Dtos.Company;

namespace WssApplication.Controllers
{
    /// <summary>
    /// Контроллер отвечающий за работу с компанией
    /// Получение, создание, обновление, удаление
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
            // Получаем все компании для отображения со всеми данными
            var result = await _companyService.GetCompanies();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // Получаем компанию с её департаментами и отделами
            var result = await _companyService.GetCompanyById(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CompanyCreationDto companyCreationDto)
        {
            // Создаём компанию
            var result = await _companyService.CreateCompany(companyCreationDto);

            return Ok(result);

            // после получения браузером ответа
            // с фронта отправляем запрос, что данные изменились, и надо запросить новую модель для всех
            // CatalogHub => NotifyWasChanged
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] CompanyUpdateDto companyUpdateDto, int id)
        {
            // Обновляем данные компании
            var result = await _companyService.UpdateCompany(companyUpdateDto, id);

            return Ok(result);

            // после получения браузером ответа
            // с фронта отправляем запрос, что данные изменились, и надо запросить новую модель для всех
            // CatalogHub => NotifyWasChanged
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Удаляем компанию
            await _companyService.DeleteCompany(id);

            return Ok();

            // после получения браузером ответа
            // с фронта отправляем запрос, что данные изменились, и надо запросить новую модель для всех
            // CatalogHub => NotifyWasChanged
        }
    }
}
