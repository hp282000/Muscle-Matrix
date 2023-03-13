using MuscleMatrix.Core.Domain.RequestModels;
using MuscleMatrix.Infrastructure.Domain.Entities;

namespace MuscleMatrix.Core.Builder
{
    public static class MemberBuilder
    {
        public static Member Build(MemberRequestModel memberRequestModel)
        {
            return new Member(memberRequestModel.Photo.FileName, memberRequestModel.WeightId, memberRequestModel.HeightId, memberRequestModel.LocationId, memberRequestModel.UserId);
        }
    }
}
