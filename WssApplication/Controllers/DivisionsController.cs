using Microsoft.AspNetCore.Mvc;

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
        // GET: api/<DivisionsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DivisionsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DivisionsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            // Создание отдела
        }

        // PUT api/<DivisionsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DivisionsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
