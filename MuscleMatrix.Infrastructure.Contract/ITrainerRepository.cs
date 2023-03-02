using MuscleMatrix.Core.Domain.RequestModels;
using MuscleMatrix.Infrastructure.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Infrastructure.Contract
{
    public interface ITrainerRepository
    {
        Task<int> AddTrainer(Trainer trainer);

        Task<List<Trainer>> GetTrainer();

        Task<int> DeleteTrainer(int id);

        Task<Trainer> UpdateTrainer(TrainerRequestModel trainerRequestModel);
    }
}
