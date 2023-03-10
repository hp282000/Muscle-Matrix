using MuscleMatrix.Core.Domain.RequestModels;
using MuscleMatrix.Infrastructure.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Core.Builder
{
    public static class MemberTrainerBuilder
    {
        public static MemberTrainerMapping Build(MemberTrainerRequestModel memberTrainerRequestModel)
        {
            return new MemberTrainerMapping(memberTrainerRequestModel.MemberId, memberTrainerRequestModel.TrainerId);
        }
    }
}
