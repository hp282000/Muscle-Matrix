using MuscleMatrix.Core.Domain.RequestModels;
using MuscleMatrix.Infrastructure.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Core.Builder
{
    public static class MembershipBuilder
    {
        public static Membership Build(MembershipRequestModel membershipRequestModel)
        {
            return new Membership(membershipRequestModel.Type, membershipRequestModel.Cost, membershipRequestModel.DurationDay ,membershipRequestModel.MemberId);
        }
    }
}
