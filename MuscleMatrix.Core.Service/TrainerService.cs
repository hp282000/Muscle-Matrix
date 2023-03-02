using AutoMapper;
using MuscleMatrix.Core.Builder;
using MuscleMatrix.Core.Contract;
using MuscleMatrix.Core.Domain.RequestModels;
using MuscleMatrix.Core.Domain.ResponseModels;
using MuscleMatrix.Infrastructure.Contract;
using MuscleMatrix.Infrastructure.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Core.Service
{
    public class TrainerService : ITrainerService
    {
        private readonly ITrainerRepository _itrainerRepository;
        private readonly IMapper _mapper;

        public TrainerService(ITrainerRepository itrainerRepository, IMapper mapper)
        {
            _itrainerRepository = itrainerRepository;
            _mapper = mapper;
        }

        public async Task<int> AddTrainerAsync(TrainerRequestModel trainerRequestModel)
        {
            var addTrainer = TrainerBuilder.Build(trainerRequestModel);

            var useTrainer = await _itrainerRepository.AddTrainer(addTrainer);

            return useTrainer;
        }

        public async Task<List<TrainerResponseModel>> GetTrainerAsync()
        {
            var getTrainers = await _itrainerRepository.GetTrainer();

            var mapper = _mapper.Map<List<TrainerResponseModel>>(getTrainers);

            return mapper;
        }


       

        public async Task<int> DeleteTrainerAsync(int id)
        {
            var deleteTrainer = await _itrainerRepository.DeleteTrainer(id);

            if (deleteTrainer == null)
            {
                throw new ArgumentNullException("No Record Found");
            }
            return id;
        }

        public async Task<TrainerResponseModel> UpdateTrainerAsync(TrainerRequestModel trainerRequestModel, int id)
        {
            var getTrainer = await _itrainerRepository.GetTrainerById(id);

            getTrainer.UpdateData(trainerRequestModel.YearofExperience, trainerRequestModel.ExperienceDiscription, trainerRequestModel.Speciality, trainerRequestModel.ProfilePhoto.FileName, trainerRequestModel.UserId, trainerRequestModel.LocationId, trainerRequestModel.HeightId, trainerRequestModel.WeightId);

            var updateTrainer = await _itrainerRepository.UpdateTrainer(getTrainer);
            var mapping = _mapper.Map<TrainerResponseModel>(updateTrainer);

            return mapping;
        }
    }
}
