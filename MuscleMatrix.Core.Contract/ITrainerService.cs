using MuscleMatrix.Core.Domain.RequestModels;
using MuscleMatrix.Core.Domain.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Core.Contract
{
    public interface ITrainerService
    {
        Task<int> AddTrainerAsync(TrainerRequestModel trainerRequestModel, string image);

        Task<List<TrainerResponseModel>> GetTrainerAsync();

        Task<int> DeleteTrainerAsync(int id);

        Task<TrainerResponseModel> UpdateTrainerAsync(TrainerRequestModel trainerRequestModel, int id, string image);
    }
}
