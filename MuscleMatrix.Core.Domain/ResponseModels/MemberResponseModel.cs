 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Core.Domain.ResponseModels
{
    public class MemberResponseModel
    {
        public string Name { get; set; }

        public string Email { get; set; }
        
        public long ContactNo { get; set; }
        
        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string photo  { get; set; }

        public string WeightValue { get; set; }

        public float HeightValue { get; set; }

        public string LocationName { get; set; }


    }
}
