using Microsoft.AspNetCore.Mvc;

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

        public CompaniesController(
            ILogger<CompaniesController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            // �������� �� id ��������,
            // �������� � � �������������� � ��������


            return Ok();
        }
    }
}
