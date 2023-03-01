 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Core.Domain.ResponseModels
{
    public class MemberResponseModel
    {

        public DateTime DateOfBirth { get; set; }

        public string photo  { get; set; }

        public string WeightValue { get; set; }

        public float HeightValue { get; set; }

        public string LocationName { get; set; }

        /// <summary>
        /// it get data from User response model {name , email , contact no , etc}
        /// </summary>
        public UserResponseModel User { get; set; }

    }
}
