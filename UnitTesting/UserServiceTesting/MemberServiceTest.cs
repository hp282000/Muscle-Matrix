using AutoMapper;
using AutoMapper.Execution;
using Moq;
using Muscle_Matrix.Configuration;
using MuscleMatrix.Core.Contract;
using MuscleMatrix.Core.Service;
using MuscleMatrix.Core.Service.Helper;
using MuscleMatrix.Infrastructure.Contract;
using MuscleMatrix.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MuscleMatrix.Infrastructure.Domain.Entities;
using MuscleMatrix.Core.Domain.RequestModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UnitTesting.UserServiceTesting
{
    public class MemberServiceTest
    {

        private readonly Mock<IMemberRepository> _memberRepository;

        private readonly MapperConfiguration _mapperConfiguration;
        private readonly IMapper _mapper;

        private readonly Mock<IFileUploadHelper> _fileUploadHelper;

        private readonly MemberService _memberService;

        public MemberServiceTest()
        {
            _memberRepository = new Mock<IMemberRepository>();
            _mapperConfiguration = new MapperConfiguration(config=> config.AddProfile(new AddMapperProfile()));
            _mapper = _mapperConfiguration.CreateMapper();
            _fileUploadHelper = new Mock<IFileUploadHelper>();
            _memberService = new MemberService(_memberRepository.Object, _mapper, _fileUploadHelper.Object);
        }

        [Fact]
        public async void GetMember_Test()
        {
            var getMembers = GetMembers();

            _memberRepository.Setup(x => x.GetMember()).ReturnsAsync(getMembers);

            var getMember = await _memberService.GetMemberAsync();

            Assert.NotNull(getMember);
        }

        [Fact]
        public async void AddMember_MustPass()
        {
            MemberRequestModel member = new MemberRequestModel()
            {
                HeightId = 1,
                WeightId = 1,
                LocationId = 1,
                UserId = 1,
            };

            _fileUploadHelper.Setup(x => x.UploadImage(It.IsAny<IFormFile>())).ReturnsAsync("abc.jpg");
            _memberRepository.Setup(x => x.AddMember(It.IsAny<MuscleMatrix.Infrastructure.Domain.Entities.Member>())).ReturnsAsync(1);

            var addUser = await _memberService.AddMemberAsync(member,"test.jpg");
            Assert.NotNull(addUser);

        }


        [Fact]
        public async void DeleteMember_Successfull()
        {

            _memberRepository.Setup(x => x.DeleteMember(It.IsAny<int>())).ReturnsAsync(1);

            var deleteMember = await _memberService.DeleteMemberAsync(1);
            //Assert.InRange(deleteUser,1,5);
            Assert.NotNull(deleteMember);
        }

        [Fact]
        public async void UpdateMember_Successfull()
        {
            MuscleMatrix.Infrastructure.Domain.Entities.Member member = new MuscleMatrix.Infrastructure.Domain.Entities.Member()
            {
                Photo = "abc.jpg",
                HeightId = 1,
                WeightId = 1,
                LocationId = 1,
                UserId = 1,

            };


            MemberRequestModel memberRequest = new MemberRequestModel()
            {
                HeightId = 1,
                  WeightId = 1,
                LocationId = 1,
                UserId = 1,
            };


            _memberRepository.Setup(x => x.GetMemberById(It.IsAny<int>())).ReturnsAsync(member);
            _memberRepository.Setup(x => x.UpdateMember(member)).ReturnsAsync(member);
            var updateMember = _memberService.UpdateMemberAsync(memberRequest, 1);
            Assert.NotNull(updateMember);

        }

        [NonAction]
        public List<MuscleMatrix.Infrastructure.Domain.Entities.Member> GetMembers()
        {
            var getMembers = new List<MuscleMatrix.Infrastructure.Domain.Entities.Member>()
            {
               new MuscleMatrix.Infrastructure.Domain.Entities.Member
               { 
                    Photo = "abc.jpg",
                    HeightId=1,
                    WeightId=1,
                    LocationId=1,
                    UserId=1,

               },
                 new MuscleMatrix.Infrastructure.Domain.Entities.Member
               {
                    Photo = "xyz.jpg",
                    HeightId=1,
                    WeightId=1,
                    LocationId=1,
                    UserId=1,

               }
            };
            return getMembers;
        }
    }   

}
