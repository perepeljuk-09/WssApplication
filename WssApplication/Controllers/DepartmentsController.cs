using Microsoft.AspNetCore.Mvc;
using WssApplication.Controllers;
using WssApplication.Infrastructure.ServiceInterfaces;
using WssApplication.Shared.Dtos.Company;
using WssApplication.Shared.Dtos.Department;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WssApplication.Api.Controllers
{
    /// <summary>
    /// Контроллер отвечающий за работу с департаментом
    /// Получение, создание, обновление, удаление, перемещение
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {

        private readonly ILogger<DepartmentsController> _logger;
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(
            ILogger<DepartmentsController> logger,
            IDepartmentService departmentService)
        {
            _logger = logger;
            _departmentService = departmentService;
        }

        [HttpGet("{companyId}")]
        public async Task<IActionResult> GetByCompanyId(int companyId)
        {
            // Получаем все департаменты компании
            var result = await _departmentService.GetDepartmentsByCompanyId(companyId);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            // Получаем департамент с его отделами
            var result = await _departmentService.GetDepartmentById(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DepartmentCreationDto departmentCreationDto)
        {
            // Создаём департамент
            var result = await _departmentService.CreateDepartment(departmentCreationDto);

            return Ok(result);

            // после получения браузером ответа
            // с фронта отправляем запрос, что данные изменились, и надо запросить новую модель для всех
            // CatalogHub => NotifyWasChanged
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] DepartmentUpdateDto departmentUpdateDto, int id)
        {
            // Обновляем данные департамента
            var result = await _departmentService.UpdateDepartment(departmentUpdateDto, id);

            return Ok(result);

            // после получения браузером ответа
            // с фронта отправляем запрос, что данные изменились, и надо запросить новую модель для всех
            // CatalogHub => NotifyWasChanged
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Удаляем департамент
            await _departmentService.DeleteDepartment(id);

            return Ok();

            // после получения браузером ответа
            // с фронта отправляем запрос, что данные изменились, и надо запросить новую модель для всех
            // CatalogHub => NotifyWasChanged
        }

        [HttpPost("move")]
        public async Task<IActionResult> Move([FromBody] DepartmentMoveDto departmentMoveDto)
        {
            // Перемещаем департамент
            await _departmentService.Move(departmentMoveDto);

            return Ok();

            // после получения браузером ответа
            // с фронта должен быть выполнен новый запрос
            // за новой моделью Компании для отображения со всеми данными
        }
    }
}
