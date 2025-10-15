using Microsoft.AspNetCore.Mvc;
using TestingPlatform.Domain.Models;
using TestingPlatform.Infrastructure;
using TestingPlatform.Infrastructure.Repositories;

namespace lesson2_17_09_25.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly GroupRepository _repository;
        public GroupsController(AppDbContext db)
        {
            _repository = new GroupRepository(db);
        }

        [HttpGet]
        public IActionResult GetAllGroups()
        {
            var groups = _repository.GetAll();
            return Ok(groups);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetGroupByID([FromRoute] int id)
        {
            var group = _repository.GetById(id);
            return Ok(group);
        }

        [HttpPost]
        public IActionResult CreateGroup([FromBody] Group group)
        {
           var groupid = _repository.Create(group);
            return StatusCode(StatusCodes.Status201Created, new { Id = groupid });
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateGroup([FromBody] Group group)
        {
            _repository.Update(group);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteGroup([FromRoute] int id)
        {
            _repository.Delete(id);
            return NoContent();
        }
    }
}
