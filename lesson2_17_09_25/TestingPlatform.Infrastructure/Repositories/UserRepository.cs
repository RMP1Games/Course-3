using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingPlatform.Application.Interfaces;
using TestingPlatform.Domain.Models;

namespace TestingPlatform.Infrastructure.Repositories
{
    public class UserRepository(AppDbContext appDbContext) : IUserRepository
    {
        List<User> IUserRepository.GetAll()
        {
            var users = appDbContext.Users.AsNoTracking().ToList();
            return users;
        }

        User IUserRepository.GetById(int id)
        {
            var user = appDbContext.Users.AsNoTracking().FirstOrDefault(g => g.Id == id);
            if (user == null)
                throw new Exception("Пользователь не найден.");

            return user;
        }

        int IUserRepository.Create(User user)
        {
            appDbContext.Users.Add(user);
            appDbContext.SaveChanges();
            
            return user.Id;
        }
        void IUserRepository.Update(User entity)
        {
            appDbContext.SaveChanges();
        }
        void IUserRepository.Delete(int id)
        {
            var user = appDbContext.Users.FirstOrDefault(g => g.Id == id);

            if (user == null)
                throw new Exception("Пользователь не найден.");

            appDbContext.Users.Remove(user);
            appDbContext.SaveChanges();
        }
    }
}
