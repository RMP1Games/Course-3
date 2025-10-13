//using lesson2_17_09_25.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System.Text.RegularExpressions;

//namespace lesson2_17_09_25.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class GroupsController : ControllerBase
//    {
//        private readonly AppDbContext _db;

//        public GroupsController(AppDbContext db)
//        {
//            _db = db;
//        }

//        [HttpGet]
//        public IActionResult GetAllGroups()
//        {
//            var groups = _db.Groups.ToList();
//            return Ok(groups);
//        }

//        [HttpGet("{id:int}")]
//        public IActionResult GetGroupByID([FromRoute] int id)
//        {
//            if (id <= 0) return BadRequest("Некорректный id.");

//            var group = _db.Groups.FirstOrDefault(s => s.Id == id);
//            if (group == null) return NotFound($"Группа с id {id} не найденa");

//            return Ok(group);
//        }

//        [HttpPost]
//        public IActionResult CreateGroup([FromBody] Models.Group group)
//        {
//            var nameExists = _db.Groups.FirstOrDefault(s => s.Name == group.Name);
//            if (nameExists != null)
//                return Conflict($"Группа с именем уже существует.");

//            _db.Groups.Add(group);
//            _db.SaveChanges();

//            return CreatedAtAction(nameof(GetGroupByID), new { id = group.Id }, group);
//        }

//        [HttpPut("{id:int}")]
//        public IActionResult UpdateGroup([FromRoute] int id, [FromBody] Models.Group group)
//        {
//            if (id <= 0) return BadRequest("Некорректный id.");
//            if (id != group.Id) return BadRequest($"Не совпадают id");

//            var exists = _db.Groups.Any(s => s.Id == id);
//            if (!exists)
//                return NotFound();

//            var nameExists = _db.Groups.FirstOrDefault(s => s.Name == group.Name && s.Id == id);
//            if (nameExists != null)
//                return Conflict($"Группа с именем уже существует.");

//            _db.Groups.Update(group);
//            _db.SaveChanges();

//            return NoContent();
//        }

//        [HttpDelete("{id:int}")]
//        public IActionResult DeleteGroup([FromRoute] int id)
//        {
//            if (id <= 0) return BadRequest("Некорректный id.");

//            var group = _db.Groups.Find(id);
//            if (group == null) return NotFound($"Группа с id {id} не найдена");

//            _db.Groups.Remove(group);
//            _db.SaveChanges();

//            return NoContent();
//        }
//    }
//}
