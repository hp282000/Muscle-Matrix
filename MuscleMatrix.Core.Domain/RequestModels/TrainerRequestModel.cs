using Microsoft.AspNetCore.Http;
using MuscleMatrix.Core.Domain.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Core.Domain.RequestModels
{
    public class TrainerRequestModel
    {
        public int Id { get; set; }
        public int YearofExperience { get; set; }
        public string Speciality { get; set; }
        public string ExperienceDiscription { get; set; }
        public IFormFile ProfilePhoto { get; set; }
        public int WeightId { get; set; }
        public int HeightId { get; set; }
        public int LocationId { get; set; }
        public int UserId { get; set; }

    }
}
