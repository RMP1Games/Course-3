using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingPlatform.Domain.Models;

namespace TestingPlatform.Application.Interfaces
{
    public interface IGroupRepository
    {
        List<Group> GetAll();
        Group GetById(int id);
        int Create(Group group);
        void Update(Group entity);
        void Delete(int id);
    }
}
