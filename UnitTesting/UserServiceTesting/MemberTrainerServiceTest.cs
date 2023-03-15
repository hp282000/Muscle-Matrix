using AutoMapper;
using Moq;
using Muscle_Matrix.Configuration;
using MuscleMatrix.Core.Contract;
using MuscleMatrix.Core.Domain.RequestModels;
using MuscleMatrix.Core.Domain.ResponseModels;
using MuscleMatrix.Core.Service;
using MuscleMatrix.Infrastructure.Contract;
using MuscleMatrix.Infrastructure.Domain.Entities;
using MuscleMatrix.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.UserServiceTesting
{
    public class MemberTrainerServiceTest
    {
        private readonly Mock<IMemberTrainerRepository> _memberTrainerRepository;
        private readonly IMapper _mapper;
        private readonly MapperConfiguration _mapperConfiguration;

        private readonly MemberTrainerService _memberTrainerService;

        public MemberTrainerServiceTest()
        {
            _mapperConfiguration = new MapperConfiguration(x => x.AddProfile(new AddMapperProfile()));
            _memberTrainerRepository= new Mock<IMemberTrainerRepository>();
            _memberTrainerService = new MemberTrainerService(_memberTrainerRepository.Object, _mapper);
        }
        [Fact]
        public async void GetMemberTrainer_Test()
        {
            
            var memberTrainer = new List<MemberTrainerMapping>()
            {
               new MemberTrainerMapping()
               {
                   Id= 1,
                    MemberId= 1,
                   TrainerId= 1,
                   Member = new Member()
                   {
                       Id = 1,
                       Height = new Height()
                       {
                           Id= 1,
                           HeightValue= 1,
                       },
                       Weight= new Weight()
                       {
                           Id= 1,
                           WeightValue = "1"
                       },
                       Location = new GymLocation()
                       {

                           Id= 1,
                           LocationName = "Surat"
                       },
                       User= new User()
                       {
                            Id = 1,
                            Name = "Harsh",
                            Email = "hp@gmail.com",
                            ContactNo = 7801853061,
                            Gender = "Male",
                            DateOfBirth = DateTime.Now,
                            Password = Encoding.ASCII.GetBytes("123")

                       },
                       Photo="hp.jpg",
                        HeightId= 1,
                       WeightId= 1,
                       LocationId=1,
                       UserId= 1


                   },
                   Trainer = new Trainer()
                   {
                       Id = 1,
                       Height = new Height()
                       {

                           Id=1,
                           HeightValue= 1,
                       },
                       Weight= new Weight()
                       {

                             Id=1,
                           WeightValue = "1"
                       },
                       Location = new GymLocation()
                       {

                             Id=1,
                           LocationName = "Surat"
                       },
                       User= new User()
                       {
                            Id = 1,
                            Name = "Harsh",
                            Email = "hp@gmail.com",
                            ContactNo = 7801853061,
                            Gender = "Male",
                            DateOfBirth = DateTime.Now,
                            Password = Encoding.ASCII.GetBytes("123")

                       },
                       ProfilePhoto="hp.jpg",
                       ExperienceDiscription="abc",
                       Speciality="abc",
                       YearofExperience=1

                   },                 
                  
               },
                 new MemberTrainerMapping()
               {
                   Id= 2,
                   MemberId= 2,
                   TrainerId= 2,
                   Member = new Member()
                   {
                       Id = 1,
                       Height = new Height()
                       {
                           HeightValue= 1,
                       },
                       Weight= new Weight()
                       {
                           WeightValue = "1"
                       },
                       Location = new GymLocation()
                       {
                           LocationName = "Surat"
                       },
                       User= new User()
                       {
                            Id = 1,
                            Name = "Harsh",
                            Email = "hp@gmail.com",
                            ContactNo = 7801853061,
                            Gender = "Male",
                            DateOfBirth = DateTime.Now,
                            Password = Encoding.ASCII.GetBytes("123")

                       }, 
                       Photo="harsh.jpg",
                       HeightId= 1,
                       WeightId= 1,
                       LocationId=1,
                       UserId= 1


                   },
                   Trainer = new Trainer()
                   {
                       Id = 1,
                      
                       Height = new Height()
                       {
                           HeightValue= 1,
                       },
                       Weight= new Weight()
                       {
                           WeightValue = "1"
                       },
                       Location = new GymLocation()
                       {
                           LocationName = "Surat"
                       },
                       User= new User()
                       {
                            Id = 1,
                            Name = "Harsh",
                            Email = "hp@gmail.com",
                            ContactNo = 7801853061,
                            Gender = "Male",
                            DateOfBirth = DateTime.Now,
                            Password = Encoding.ASCII.GetBytes("123")

                       },
                       ProfilePhoto="hp.jpg",
                       ExperienceDiscription="abc",
                       Speciality="abc",
                       YearofExperience=1

                   },

                   
               }

            };

            _memberTrainerRepository.Setup(x => x.GetTrainerMember()).ReturnsAsync(memberTrainer);

            var getUserRole = await _memberTrainerService.GetMemberTrainersAsync();

            Assert.NotNull(getUserRole);

        }

        [Fact]
        public async void AddMemberTrainer_Test()
        {
            var memberTrainerRequestModel = new MemberTrainerRequestModel()
            {
                TrainerId=1,
                MemberId=1
            };
            _memberTrainerRepository.Setup(x => x.AddTrainerMember(It.IsAny<MemberTrainerMapping>())).ReturnsAsync(1);

            var addUserRole = _memberTrainerService.AddMemberTrainerAsync(memberTrainerRequestModel);

            Assert.NotNull(addUserRole);
        }
    }
}
