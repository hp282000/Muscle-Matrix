using AutoMapper;
using Microsoft.AspNetCore.Http;
using Moq;
using Muscle_Matrix.Configuration;
using MuscleMatrix.Core.Contract;
using MuscleMatrix.Core.Domain.RequestModels;
using MuscleMatrix.Core.Service;
using MuscleMatrix.Core.Service.Helper;
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
    public class TrainerServiceTest
    {
        private readonly Mock<ITrainerRepository> _trainerRepository;
        private readonly MapperConfiguration _mapperConfiguration;
        private readonly IMapper _mapper;
        private readonly Mock<IFileUploadHelper> _fileUploadHelper;

        private readonly TrainerService _trainerService;

        public TrainerServiceTest()
        {
            _trainerRepository= new Mock<ITrainerRepository>();
            _mapperConfiguration = new MapperConfiguration(config => config.AddProfile(new AddMapperProfile()));
            _mapper = _mapperConfiguration.CreateMapper();
            _fileUploadHelper = new Mock<IFileUploadHelper>();
            _trainerService = new TrainerService(_trainerRepository.Object, _mapper);
        }
        [Fact]
        public async void GetTrainer_Test()
        {
            var getTrainers = new List<Trainer>()
            { new Trainer(3, "Athelete", "2 yr", "abc.jpg", 1, 1, 1, 1)
            {
            YearofExperience = 2,
            Speciality = "Yoga",
            ExperienceDiscription = "at katargam",
            ProfilePhoto = "abc.jopg",
            WeightId = 1,
            HeightId = 1,
            UserId = 1,
            LocationId = 1

        },
        new Trainer(3, "Athelete", "2 yr", "abc.jpg", 1, 1, 1, 1)
        {
            YearofExperience = 3,
            Speciality = "Athelete",
            ExperienceDiscription = "at katargam",
            ProfilePhoto = "abc.jopg",
            WeightId = 1,
            HeightId = 1,
            UserId = 1,
            LocationId = 1
        }
            };

            _trainerRepository.Setup(x => x.GetTrainer()).ReturnsAsync(getTrainers);

            var getTrainer = await _trainerService.GetTrainerAsync();

            Assert.NotNull(getTrainer);
        }

        [Fact]
        public async void AddTrainer_MustPass()
        {
            //Trainer trainer = new Trainer(3, "Athelete", "2 yr", "abc.jpg", 1, 1, 1, 1);
            TrainerRequestModel trainerRequestModel = new TrainerRequestModel()
            {
                YearofExperience = 3,
                Speciality = "Athelete",
                ExperienceDiscription = "at katargam",
                HeightId = 1,
                WeightId = 1,
                LocationId = 1,
                UserId = 1,
            };

          
             _trainerRepository.Setup(x => x.AddTrainer(It.IsAny<Trainer>())).ReturnsAsync(1);

            var addTrainer = await _trainerService.AddTrainerAsync(Mock.Of<TrainerRequestModel>(), "test.jpg");
            Assert.NotNull(addTrainer);

        }

        [Fact]
        public async void Delete_Trainer_Test()
        {
            _trainerRepository.Setup(x=> x.DeleteTrainer(It.IsAny<int>())).ReturnsAsync(1);

            var deleteTrainer = _trainerService.DeleteTrainerAsync(It.IsAny<int>());

            Assert.NotNull(deleteTrainer);
        }

        [Fact]
        public async void Update_Trainer_Test()
        {
            var trainerRequestModel = new TrainerRequestModel()
            {
                YearofExperience = 3,
                Speciality = "Physio",
                ExperienceDiscription = "Excillent",
                HeightId = 1,
                WeightId = 1,
                LocationId = 1,
                UserId = 1,
            };

            _trainerRepository.Setup(x => x.GetTrainerById(It.IsAny<int>())).ReturnsAsync(Mock.Of<Trainer>());
            _trainerRepository.Setup(x => x.UpdateTrainer(It.IsAny<Trainer>())).ReturnsAsync(Mock.Of<Trainer>());

            var updateTrainer = _trainerService.UpdateTrainerAsync(trainerRequestModel, 1,"abc.jpg");

            Assert.NotNull(updateTrainer);
        }
    }
}
