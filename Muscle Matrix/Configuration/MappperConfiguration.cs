using AutoMapper;
using MuscleMatrix.Core.Domain.ResponseModels;
using MuscleMatrix.Infrastructure.Domain.Entities;

namespace Muscle_Matrix.Configuration
{
    public class MappperConfiguration : Profile
    {
        public MappperConfiguration()
        {
            CreateMap<User,UserResponseModel>();
        }
    }
}
