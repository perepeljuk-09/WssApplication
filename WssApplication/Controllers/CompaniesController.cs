using Microsoft.AspNetCore.Mvc;

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

        public CompaniesController(
            ILogger<CompaniesController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            // Получаем по id компании,
            // Компанию с её департаментами и отделами


            return Ok();
        }
    }
}
