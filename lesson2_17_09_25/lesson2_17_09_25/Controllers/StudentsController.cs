using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using lesson2_17_09_25.Models;

namespace lesson2_17_09_25.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly AppDbContext _db;
        
        public StudentsController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = _db.Students.ToList();
            return Ok(students);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetStudentByID([FromRoute]int id)
        {
            if (id <= 0) return BadRequest("Некорректный id.");

            var student = _db.Students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound($"Студент с id {id} не найден");

            return Ok(student);
        }

        [HttpPost]
        public IActionResult CreateStudent([FromBody] Student student)
        {
            var emailExists = _db.Students.FirstOrDefault(s => s.User.Email == student.User.Email);
            if (emailExists != null)
                return Conflict($"Пользователь с таким Email'ом уже существует.");

            _db.Students.Add(student);
            _db.SaveChanges();

            return CreatedAtAction(nameof(GetStudentByID), new {id = student.Id}, student);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateStudent([FromRoute] int id, [FromBody] Student student)
        {
            if (id <= 0) return BadRequest("Некорректный id.");
            if (id != student.Id) return BadRequest($"Не совпадают id");

            var exists = _db.Students.Any(s => s.Id == id);
            if (!exists)
                 return NotFound();

            var emailExists = _db.Students.FirstOrDefault(s => s.User.Email == student.User.Email && s.Id == id);
            if (emailExists != null)
                return Conflict($"Пользователь с таким email'ом уже существует.");

            _db.Students.Update(student);
            _db.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteStudent([FromRoute]int id)
        {
            if (id <= 0) return BadRequest("Некорректный id.");

            var student = _db.Students.Find(id);
            if (student == null) return NotFound($"Студент с id {id} не найден");

            _db.Students.Remove(student);
            _db.SaveChanges();

            return NoContent();
        }
    }
}
