using AutoMapper;
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
    public class UserRoleServiceTest
    {
        private readonly Mock<IUserRoleRepository> _userroleRepository;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _mapperConfiguration;

        private readonly UserRoleService _userRoleService;

        public UserRoleServiceTest()
        {
            _userroleRepository = new Mock<IUserRoleRepository>();
            _mapperConfiguration = new MapperConfiguration(x => x.AddProfile(new AddMapperProfile()));
            _mapper = _mapperConfiguration.CreateMapper();
            _userRoleService = new UserRoleService(_userroleRepository.Object, _mapper);
        }

        [Fact]
        public async void GetUserRole_Test()
        {
            var userRole = new UserRoleRequestModel()
            {
                UserId = 1,
                RoleId = 1,
            };
            _userroleRepository.Setup(x => x.GetAllRoles()).ReturnsAsync(Mock.Of<List<UserRoleMapping>>());

            var getUserRole = await _userRoleService.GetUserRoleAsync();

            Assert.NotNull(getUserRole);


        }

        [Fact]
        public async void AddUserRole_Test()
        {
            var userRoleRequestModel = new UserRoleRequestModel()
            {
                UserId = 1,
                RoleId = 1,

            };
            _userroleRepository.Setup(x => x.AddUserRole(It.IsAny<UserRoleMapping>())).ReturnsAsync(1);

            var addUserRole = _userRoleService.AddUserRoleAsync(userRoleRequestModel);

            Assert.NotNull(addUserRole);
        }
    }

}
