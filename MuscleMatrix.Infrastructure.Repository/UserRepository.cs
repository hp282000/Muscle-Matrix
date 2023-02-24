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
        public async Task<int> DeleteUser(int id)
        {
            var deleteUser = _projectContext.Users.FirstOrDefault(x => x.Id == id);

            _projectContext.Users.Remove(deleteUser);

            return _projectContext.SaveChanges();
        }
        public async Task<User> UpdateUser(UserRequestModel userRequestModel)
        {

            var updateUser = _projectContext.Users.FirstOrDefault(x=> x.Id == userRequestModel.Id);


            if(updateUser == null) {

                throw new Exception("No User Available");
            }
            updateUser.UpdateData(userRequestModel.Name, userRequestModel.Email , userRequestModel.ContactNo , userRequestModel.Gender , userRequestModel.DateOfBirth);

            //updateUser.Name = userRequestModel.Name;
            //updateUser.Email = userRequestModel.Email;
            //updateUser.ContactNo = userRequestModel.ContactNo;
            //updateUser.Gender = userRequestModel.Gender;
            //updateUser.DateOfBirth = userRequestModel.DateOfBirth;

             _projectContext.Users.Update(updateUser);
            
           _projectContext.SaveChanges();
            
            return updateUser;
        }
    }
}