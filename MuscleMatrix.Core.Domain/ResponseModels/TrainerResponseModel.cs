using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Core.Domain.ResponseModels
{
    public class TrainerResponseModel
    {
        public int YearofExperience { get; set; }
        public string Speciality { get; set; }
        public string ExperienceDiscription { get; set; }
        public string ProfilePhoto { get; set; }

        public UserResponseModel User { get; set; }

        public string WeightValue { get; set; }

        public float HeightValue { get; set; }

        public string LocationName { get; set; }
    }
}
