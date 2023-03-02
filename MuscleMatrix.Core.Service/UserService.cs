

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

        public async Task<string> UserLoginAsync(UserLogin userLogin)
        {
            var checkUser = await _userRepository.UserLogin(userLogin);

            var hsa = new HMACSHA256(checkUser.PasswordSalt);

            var userPassword = Encoding.ASCII.GetBytes(userLogin.Password);

            var computeuserPassword = hsa.ComputeHash(userPassword);

            if (checkUser.Password.SequenceEqual(computeuserPassword))
            {
                return "User Found";
            }
            return "User Not Found";

        }

        public async Task<int> AddUserAsync(UserRequestModel userRequestModel)
        {
            var userpassword = new User();
            var hsa = new HMACSHA256();
            var password = Encoding.ASCII.GetBytes(userRequestModel.Password);
            var computepassword = hsa.ComputeHash(password);

            userpassword.Password = computepassword;
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

        public async Task<UserResponseModel> UpdateUserAsync(UserRequestModel userRequestModel, int id)
        {
            var getUser = await _userRepository.GeUserById(id);
            getUser.UpdateData(userRequestModel.Name, userRequestModel.Email, userRequestModel.ContactNo, userRequestModel.Gender, userRequestModel.DateOfBirth);
            var updateUser = await _userRepository.UpdateUser(getUser);
            var mapping = _mapper.Map<UserResponseModel>(updateUser);

            return mapping;
        }
    }
}