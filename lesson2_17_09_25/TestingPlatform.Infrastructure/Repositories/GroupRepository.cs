using System.Security.Cryptography.X509Certificates;
using TestingPlatform.Application.Interfaces;
using TestingPlatform.Domain.Models;

namespace TestingPlatform.Infrastructure.Repositories
{
    public class GroupRepository(AppDbContext appDbContext) : IGroupRepository
    {
        public List<Group> GetAll()
        {
            var group = appDbContext.Groups.ToList();
            return group;
        }

        public Group GetById(int id)
        {
            var group = appDbContext.Groups.FirstOrDefault(g => g.Id == id);
            if (group == null)
                throw new Exception("Группа не найдена.");

            return group;
        }

        public int Create(Group group)
        {
            var direction = appDbContext.Directions.Any(d => d.Id == group.DirectionId);
            var course = appDbContext.Directions.Any(c => c.Id == group.CourseId);
            var project = appDbContext.Directions.Any(p => p.Id == group.ProjectId);

            if (!direction || !course || !project)
                throw new Exception("Убедитесь, что направление, курс и проект существуют.");

            if (group.Students.Any())
            {
                var ids = group.Students.Select(s => s.Id).ToList();
                var students = appDbContext.Students.Where(s => ids.Contains(s.Id)).ToList();

                if (students.Count != ids.Count)
                    throw new Exception("Некоторые студенты не найдены");

                group.Students = students;
            }

            var groupId = appDbContext.Add(group);
            appDbContext.SaveChanges();

            return groupId.Entity.Id;
        }

        public void Update(Group group)
        {
            var exists = appDbContext.Groups.FirstOrDefault(g => g.Id == group.Id);
            if (exists == null)
                throw new Exception("Группа не найдена.");

            var direction = appDbContext.Directions.Any(d => d.Id == group.DirectionId);
            var course = appDbContext.Directions.Any(c => c.Id == group.CourseId);
            var project = appDbContext.Directions.Any(p => p.Id == group.ProjectId);

            if (!direction || !course || !project)
                throw new Exception("Убедитесь, что направление, курс и проект существуют.");

            if (group.Students.Any())
            {
                var ids = group.Students.Select(s => s.Id).ToList();
                var students = appDbContext.Students.Where(s => ids.Contains(s.Id)).ToList();

                if (students.Count != ids.Count)
                    throw new Exception("Некоторые студенты не найдены");

                exists.Students = group.Students;
            }
            exists.Name = group.Name;
            exists.DirectionId = group.DirectionId;
            exists.CourseId = group.CourseId;
            exists.ProjectId = group.ProjectId;

            appDbContext.SaveChanges();
        }
            public void Delete(int id)
            {
                var group = appDbContext.Groups.Find(id);
                if (group == null)
                    throw new Exception("Группа не найдена.");

                appDbContext.Groups.Remove(group);
                appDbContext.SaveChanges();
            }
    }
}
