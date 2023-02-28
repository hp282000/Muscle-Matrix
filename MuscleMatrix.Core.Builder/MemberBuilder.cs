using MuscleMatrix.Core.Domain.RequestModels;
using MuscleMatrix.Infrastructure.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Core.Builder
{
    public static class MemberBuilder
    {
        public static Member Build(MemberRequestModel memberRequestModel)
        {
            return new Member(memberRequestModel.photo ,memberRequestModel.WeightId, memberRequestModel.HeightId, memberRequestModel.LocationId,memberRequestModel.UserId);
        }
    }
}
