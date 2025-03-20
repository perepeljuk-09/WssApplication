using Microsoft.AspNetCore.Mvc;
using WssApplication.Infrastructure.ServiceInterfaces;
using WssApplication.Infrastructure.Services;
using WssApplication.Shared.Dtos.Department;
using WssApplication.Shared.Dtos.Division;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WssApplication.Api.Controllers
{
    /// <summary>
    /// Контроллер отвечающий за работу с отделом
    /// Получение, создание, обновление, удаление, перемещение
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DivisionsController : ControllerBase
    {

        private readonly ILogger<DivisionsController> _logger;
        private readonly IDivisionService _divisionsService;

        public DivisionsController(
            ILogger<DivisionsController> logger,
            IDivisionService divisionsService)
        {
            _logger = logger;
            _divisionsService = divisionsService;
        }

        [HttpGet("{departmentId}")]
        public async Task<IActionResult> GetByDepartmentId(int departmentId)
        {
            // Получаем все отделы департамента
            var result = await _divisionsService.GetDivisionsByDepartmentId(departmentId);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // Получаем отдел
            var result = await _divisionsService.GetDivisionById(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DivisionCreationDto departmentCreationDto)
        {
            // Создаём отдел
            var result = await _divisionsService.CreateDivision(departmentCreationDto);

            return Ok(result);

            // после получения браузером ответа
            // с фронта отправляем запрос, что данные изменились, и надо запросить новую модель для всех
            // CatalogHub => NotifyWasChanged
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] DivisionUpdateDto departmentUpdateDto, int id)
        {
            // Обновляем данные отдела
            var result = await _divisionsService.UpdateDivision(departmentUpdateDto, id);

            return Ok(result);

            // после получения браузером ответа
            // с фронта отправляем запрос, что данные изменились, и надо запросить новую модель для всех
            // CatalogHub => NotifyWasChanged
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Удаляем отдел
            await _divisionsService.DeleteDivision(id);

            return Ok();

            // после получения браузером ответа
            // с фронта отправляем запрос, что данные изменились, и надо запросить новую модель для всех
            // CatalogHub => NotifyWasChanged
        }

        [HttpPost("move")]
        public async Task<IActionResult> Move([FromBody] DivisionMoveDto divisionMoveDto)
        {
            // Перемещаем отдел
            await _divisionsService.Move(divisionMoveDto);

            return Ok();

            // после получения браузером ответа
            // с фронта отправляем запрос, что данные изменились, и надо запросить новую модель для всех
            // CatalogHub => NotifyWasChanged
        }
    }
}
