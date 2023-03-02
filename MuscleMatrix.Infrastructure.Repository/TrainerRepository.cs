using Microsoft.EntityFrameworkCore;
using MuscleMatrix.Core.Domain.RequestModels;
using MuscleMatrix.Infrastructure.Contract;
using MuscleMatrix.Infrastructure.Domain.Context;
using MuscleMatrix.Infrastructure.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Infrastructure.Repository
{
    public class TrainerRepository : ITrainerRepository
    {
        private readonly ProjectContext _projectContext;

        public TrainerRepository(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }
        public async Task<int> AddTrainer(Trainer trainer)
        {
            var addTrainer = await _projectContext.Trainers.AddAsync(trainer);

            if (addTrainer == null)
            {
                throw new Exception("Trainer Not Add Successfully...");
            }
            return await _projectContext.SaveChangesAsync();
        }
        public async Task<List<Trainer>> GetTrainer()
        {
            var getTrainers = await _projectContext.Trainers.Include(x => x.User).Include(x => x.Height).Include(x => x.Weight).Include(x => x.Location).ToListAsync();
           
            return getTrainers;
        }
        public async Task<int> DeleteTrainer(int id)
        {
            var deleteTrainer = _projectContext.Trainers.FirstOrDefault(x => x.Id == id);

            _projectContext.Trainers.Remove(deleteTrainer);

            return _projectContext.SaveChanges();
        }
        public async Task<Trainer> UpdateTrainer(TrainerRequestModel trainerRequestModel)
        {

            var updateTrainer = _projectContext.Trainers.Include(x => x.User).Include(x => x.Location).Include(x => x.Weight).Include(x => x.Height).FirstOrDefault(x => x.Id == trainerRequestModel.Id);


            if (updateTrainer == null)
            {

                throw new Exception("No Trainer Available");
            }

            updateTrainer.UpdateData(trainerRequestModel.YearofExperience, trainerRequestModel.ExperienceDiscription,trainerRequestModel.Speciality , trainerRequestModel.ProfilePhoto.FileName , trainerRequestModel.UserId , trainerRequestModel.LocationId,trainerRequestModel.HeightId , trainerRequestModel.WeightId);

      
            _projectContext.Trainers.Update(updateTrainer);

            _projectContext.SaveChanges();

            return updateTrainer;
        }
    }
}
