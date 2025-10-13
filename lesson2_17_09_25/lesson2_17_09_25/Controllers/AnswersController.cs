//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace lesson2_17_09_25.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class AnswersController : ControllerBase
//    {
//        [HttpGet]
//        public IActionResult GetAnswersByTestID([FromRoute] int testId)
//        {
//            if (testId <= 0) return BadRequest("Test Id <= 0");
//            if (testId == 1) return Ok($"Все ответы теста номер {testId}");
//            return NotFound();
//        }

//        [HttpGet("{id:int}")]
//        public IActionResult GetAnswersByQuestionID([FromRoute] int testId, int questionId)
//        {
//            if (testId <= 0) return BadRequest("Test Id <= 0");
//            if (testId == 1)
//            {
//                if (questionId <= 0) return BadRequest("Question Id <= 0");
//                if (questionId == 1) return Ok($"Ответ(-ы) на вопрос номер {questionId} теста номер {testId}.");
//            }
//            return NotFound();
//        }

//        [HttpPost]
//        public IActionResult CreateAnswers()//пока ничего не принимает
//        {
//            return Created("/api/tests/1/questions/1/answers/1", "Answer 1 created");
//        }

//        //Я бы сделал доп. функции для Upd и Del, которые затрагивали ответы конкретного вопроса конкретного теста
//        //+ Посмотрев CQuestions, я бы его тоже чуть переделал, но решил не трогать
//        [HttpPut("{id:int}")]
//        public IActionResult UpdateAnswersByTestId([FromRoute] int testId)
//        {
//            if (testId <= 0) return BadRequest("Test Id <=0");
//            if (testId != 1) return NotFound($"Не существует теста с id {testId}");

//            return NoContent();
//        }

//        [HttpDelete("{id:int}")]
//        public IActionResult DeleteAnswersByTestId([FromRoute] int testId)
//        {
//            if (testId <= 0) return BadRequest("Test Id <=0");
//            if (testId != 1) return NotFound($"Не существует теста с id {testId}");

//            return NoContent();
//        }
//    }
//}
