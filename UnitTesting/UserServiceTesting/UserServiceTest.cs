using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Muscle_Matrix.Configuration;
using MuscleMatrix.Core.Domain.RequestModels;
using MuscleMatrix.Core.Service;
using MuscleMatrix.Infrastructure.Contract;
using MuscleMatrix.Infrastructure.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.UserServiceTesting
{
    public class UserServiceTest
    {
        //Create Mock of irepository and then make object of service which one is used for testing 

        private readonly Mock<IUserRepository> _userRepository;
        private readonly MapperConfiguration _mapperConfiguration;
        private readonly IMapper _mapper;

        private readonly UserService _userService;

        public UserServiceTest()
        {
            _userRepository = new Mock<IUserRepository>();
            _mapperConfiguration = new MapperConfiguration(config => config.AddProfile(new AddMapperProfile()));
            _mapper = _mapperConfiguration.CreateMapper();
            _userService = new UserService(_userRepository.Object, _mapper);
        }

        //GetUserTest
        [Fact]
        public async void GetUser_Test()
        {
            var getUsers = GetUsers();

            _userRepository.Setup(x=> x.GetAllUsers()).ReturnsAsync(getUsers);

            var getUser = await _userService.GetUserAsync();

            Assert.NotNull(getUser);
        }

        [Fact]
        public async void AddUser_MustPass()

        {
            UserRequestModel user = new UserRequestModel()
            {
                Id = 1,
                Name = "Harsh",
                Email = "hp@gmail.com",
                ContactNo = 7801853061,
                Gender = "Male",
                DateOfBirth = DateTime.Now,
                Password = "fsf"
            };

            _userRepository.Setup(x => x.AddUser(Mock.Of<User>())).ReturnsAsync(1);

            var addUser = await _userService.AddUserAsync(user);
            Assert.NotNull(addUser);

        }

        [Fact]
        public async void AddUser_NullException()
        {

            UserRequestModel user = new UserRequestModel()
            {
                Id = 1,
                Name = "Harsh",
                Email = "hp@gmail.com",
                ContactNo = 7801853061,
                Gender = "Male",
                DateOfBirth = DateTime.Now,
                Password = "fsf"
            };

            
            _userRepository.Setup(x=> x.AddUser(null as User)).ReturnsAsync(1);

            var addUser = _userService.AddUserAsync(user);   

            await Assert.ThrowsAsync<ArgumentNullException>(async ()=> await addUser);

        }
            [Fact]
        public async void DeleteUser_Successfull()
        {

            _userRepository.Setup(x=> x.DeleteUser(It.IsAny<int>())).ReturnsAsync(1);

            var deleteUser = await _userService.DeleteUserAsync(1);
            //Assert.InRange(deleteUser,1,5);
            Assert.NotNull(deleteUser);
        }

        [Fact]
        public async void UpdateUser_Successfull()
        {
            User user = new User()
            {
                Id = 1,
                Name = "Harsh",
                Email = "hp@gmail.com",
                ContactNo = 7801853061,
                Gender = "Male",
                DateOfBirth = DateTime.Now,
                Password = Encoding.ASCII.GetBytes("123"),
                PasswordSalt = Encoding.ASCII.GetBytes("123")

            };

            UserRequestModel userRequestModel = new UserRequestModel()
            {
                Id = 1,
                Name = "Harsh",
                Email = "hp@gmail.com",
                ContactNo = 7801853061,
                Gender = "Male",
                DateOfBirth = DateTime.Now,
                Password = "fsf"
            };

            _userRepository.Setup(x=> x.GetUserById(It.IsAny<int>())).ReturnsAsync(user);
            _userRepository.Setup(x => x.UpdateUser(Mock.Of<User>())).ReturnsAsync(user);
            var updateUser = _userService.UpdateUserAsync(userRequestModel, 1);
            Assert.NotNull(updateUser);

        }
        [NonAction]
        private List<User> GetUsers()   
        {
            var getUsers = new List<User>()
            {
            new User
            {
            Name = "Harsh",
            Email = "hp@gmail.com",
            ContactNo = 7801853061,
            Gender= "Male",
            DateOfBirth = DateTime.Now,
            Password = Encoding.ASCII.GetBytes("123"),
            PasswordSalt = Encoding.ASCII.GetBytes("123")
            },
            new User
            {
            Name = "Shubham",
            Email = "sd@gmail.com",
            ContactNo = 9104709779,
            Gender= "Male",
            DateOfBirth = DateTime.Now,
            Password = Encoding.ASCII.GetBytes("123"),
            PasswordSalt = Encoding.ASCII.GetBytes("123")
            }
            };
            return getUsers;
        }
    }
}
