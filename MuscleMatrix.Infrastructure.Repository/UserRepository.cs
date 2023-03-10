using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MuscleMatrix.Core.Domain.RequestModels;
using MuscleMatrix.Core.Domain.ResponseModels;
using MuscleMatrix.Infrastructure.Contract;
using MuscleMatrix.Infrastructure.Domain.Context;
using MuscleMatrix.Infrastructure.Domain.Entities;
using System.Reflection;
using System.Xml.Linq;

namespace MuscleMatrix.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly ProjectContext _projectContext;
        public UserRepository(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }

        public async Task<User> UserLogin(UserLogin userLogin)
        {
            var checkUser = _projectContext.Users.FirstOrDefault(x=> x.Email == userLogin.Email);

            return checkUser;
        }


        public async Task<int> AddUser(User user)
        {

            await _projectContext.Users.AddAsync(user);

            return _projectContext.SaveChanges();
        }
        public async Task<List<User>> GetAllUsers()
        {

            var getUsers = await _projectContext.Users.ToListAsync();

            return getUsers;
        }
        public async Task<User> GetUserById(int id)
        {

            var getUserById = await _projectContext.Users.FirstOrDefaultAsync(x=> x.Id == id);

            return getUserById;
        }

        public async Task<int> DeleteUser(int id)
        {
            var deleteUser = _projectContext.Users.FirstOrDefault(x => x.Id == id);

            _projectContext.Users.Remove(deleteUser);

            return await _projectContext.SaveChangesAsync();
        }
        public async Task<User> UpdateUser(User user)
        {

             _projectContext.Users.Update(user);
            
           await _projectContext.SaveChangesAsync();
            
            return user;
        }
    }
}