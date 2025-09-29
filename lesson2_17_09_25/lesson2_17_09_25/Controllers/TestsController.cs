using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lesson2_17_09_25.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllTests()
        {
            return Ok("");
        }

        [HttpGet("{id:int}")]
        public IActionResult GetTestByID([FromRoute] int id)
        {
            if (id <= 0) return BadRequest("Id <= 0");
            if (id == 1) return Ok($"Тест 1");
            return NotFound();
        }

        [HttpPost]
        public IActionResult CreateTest()//пока ничего не принимает
        {
            return Created("/api/tests/1", "Test 1 created");
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateTest([FromRoute] int id)
        {
            if (id <= 0) return BadRequest("");
            if (id != 1) return NotFound($"");

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteTest([FromRoute] int id)
        {
            if (id <= 0) return BadRequest("");
            if (id != 1) return NotFound($"");

            return NoContent();
        }
    }
}
