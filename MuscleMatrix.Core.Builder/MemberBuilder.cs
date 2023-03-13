using MuscleMatrix.Core.Domain.RequestModels;
using MuscleMatrix.Infrastructure.Domain.Entities;

namespace MuscleMatrix.Core.Builder
{
    public static class MemberBuilder
    {
        public static Member Build(MemberRequestModel memberRequestModel , string image)
        {
            return new Member( memberRequestModel.WeightId, memberRequestModel.HeightId, memberRequestModel.LocationId, memberRequestModel.UserId, image);
        }
    }
}
