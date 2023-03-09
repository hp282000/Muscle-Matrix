using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Core.Domain.ResponseModels
{
    public class MemberTrainerResponseModel
    {
        public MemberResponseModel Member { get; set; }

        public TrainerResponseModel Trainer { get; set;}   


    }
}
