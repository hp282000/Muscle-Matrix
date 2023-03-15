using AutoMapper;
using Moq;
using Muscle_Matrix.Configuration;
using MuscleMatrix.Core.Domain.RequestModels;
using MuscleMatrix.Core.Domain.ResponseModels;
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
    public class MembershipServiceTest
    {
        private readonly Mock<IMembershipRepository>  _membershipRepositoryMock;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _mapperConfiguration;

        private readonly MembershipService _membershipService;


        public MembershipServiceTest() 
        {
            _membershipRepositoryMock= new Mock<IMembershipRepository>();
            _mapperConfiguration = new MapperConfiguration(config => config.AddProfile(new AddMapperProfile()));
            _mapper = _mapperConfiguration.CreateMapper();
            _membershipService = new MembershipService(_membershipRepositoryMock.Object, _mapper);

        }

        [Fact]
        public async void GetMembership_Test()
        {

            var getmemberships = new List<Membership>()
            {   
                new Membership()
                {
                      Id =1,
                      Type=MembershipType.OneMonth,
                      Cost=5000,
                      DurationDay=1,
                      MemberId=1,
                },
                new Membership()
                {
                     Id =2,
                      Type=MembershipType.OneMonth,
                      Cost=4000,
                      DurationDay=30,
                      MemberId=1,
                }
            };

            _membershipRepositoryMock.Setup(x => x.GetMembership()).ReturnsAsync(getmemberships);

            var getMembership = await _membershipService.GetMembershipAsync();

            Assert.NotNull(getMembership);


        }
        [Fact]
        public async void AddMembership_Test()
        {
            var membershipRequestModel = new MembershipRequestModel()
            {
                Type = MembershipType.OneMonth,
                DurationDay = 1,
                Cost = 2000,
                MemberId = 1,
            };
            _membershipRepositoryMock.Setup(x => x.AddMembership(It.IsAny<Membership>())).ReturnsAsync(1);

            var addMembership = _membershipService.AddMembershipAsync(membershipRequestModel);

            Assert.NotNull(addMembership);
        }
        [Fact]
        public async void DeleteMembership_Test()
        {
            _membershipRepositoryMock.Setup(x=> x.DeleteMembership(It.IsAny<int>())).ReturnsAsync(1);

            var deleteMembership = _membershipService.DeleteMembershipAsync(1);

            Assert.NotNull(deleteMembership);
        }

        [Fact]
        public async void UpdateMembership_Test()
        {
            var membershipRequestModel = new MembershipRequestModel()
            {
                Type = MembershipType.OneMonth,
                DurationDay = 1,
                Cost = 2000,
                MemberId = 1,
            };

            _membershipRepositoryMock.Setup(x => x.GetMembershipById(It.IsAny<int>())).ReturnsAsync(Mock.Of<Membership>());
            _membershipRepositoryMock.Setup(x => x.UpdateMembership(It.IsAny<Membership>())).ReturnsAsync(Mock.Of<Membership>());

            var updateMembership = _membershipService.UpdateMembershipAsync(membershipRequestModel, 1);

            Assert.NotNull(updateMembership);
        }
    }   
}
