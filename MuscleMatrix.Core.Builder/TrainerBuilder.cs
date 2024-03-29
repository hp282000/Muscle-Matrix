﻿using MuscleMatrix.Core.Domain.RequestModels;
using MuscleMatrix.Infrastructure.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Core.Builder
{
    public static class TrainerBuilder
    {
        public static Trainer Build(TrainerRequestModel trainerRequestModel, string image)
        { 
            return new Trainer(trainerRequestModel.YearofExperience, trainerRequestModel.Speciality, trainerRequestModel.ExperienceDiscription, image, trainerRequestModel.UserId, trainerRequestModel.LocationId, trainerRequestModel.HeightId, trainerRequestModel.WeightId);
        }
    }
}
