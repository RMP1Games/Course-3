//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace lesson2_17_09_25.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class QuestionsController : ControllerBase
//    {
//        [HttpGet]
//        public IActionResult GetAllQuestions()
//        {
//            return Ok("123");
//        }

//        [HttpGet("{id:int}")]
//        public IActionResult GetQuestionByTestID([FromRoute] int testId)
//        {
//            if (testId <= 0) return BadRequest("Id <= 0");
//            if (testId == 1) return Ok($"Тест 1");
//            return NotFound();
//        }

//        [HttpPost]
//        public IActionResult CreateQuestion()//пока ничего не принимает
//        {
//            return Created("/api/tests/1/question/1", "Question 1 created");
//        }

//        [HttpPut("{id:int}")]
//        public IActionResult UpdateQuestion([FromRoute] int id)
//        {
//            if (id <= 0) return BadRequest("123");
//            if (id != 1) return NotFound($"312");

//            return NoContent();
//        }

//        [HttpDelete("{id:int}")]
//        public IActionResult DeleteQuestion([FromRoute] int id)
//        {
//            if (id <= 0) return BadRequest("123");
//            if (id != 1) return NotFound($"321");

//            return NoContent();
//        }
//    }
//}
