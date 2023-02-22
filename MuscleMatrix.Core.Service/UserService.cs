

using AutoMapper;
using MuscleMatrix.Core.Builder;
using MuscleMatrix.Core.Contract;
using MuscleMatrix.Core.Domain.RequestModels;
using MuscleMatrix.Core.Domain.ResponseModels;
using MuscleMatrix.Infrastructure.Contract;
using MuscleMatrix.Infrastructure.Domain.Entities;
using System.Security.Cryptography;
using System.Text;

namespace MuscleMatrix.Core.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<int> AddUserAsync(UserRequestModel userRequestModel)
        {
            User userpassword = new User();

            userpassword.Password = Encoding.ASCII.GetBytes(userRequestModel.Password);
            var hsa = new HMACSHA256();

            userpassword.PasswordSalt = hsa.Key;

            var addUser = UserBuilder.Build(userRequestModel, userpassword);
       
               var user = await _userRepository.AddUser(addUser);

            if(user == null)
            {
                throw   new ArgumentNullException("User is not created Successfully Make sure that your repository works properly");
            }

                return user;
           
        }

        public async Task<List<UserResponseModel>> GetUserAsync()
        {
 
            var getUsers = await _userRepository.GetAllUsers();
            var mapping = _mapper.Map<List<UserResponseModel>>(getUsers);


            return mapping;
        }

        public async Task<int> DeleteUserAsync(int id)
        {
            var deleteUser = await _userRepository.DeleteUser(id);

            if(deleteUser == null)
            {
                throw new ArgumentNullException("No Record Found");
            }
            return id;
        }

        public async Task<User> UpdateUserAsync(UserRequestModel userRequestModel)
        {
            var updateUser = await _userRepository.UpdateUser(userRequestModel);

            return updateUser;
        }
    }
}