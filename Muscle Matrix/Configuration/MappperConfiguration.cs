using AutoMapper;
using MuscleMatrix.Core.Domain.RequestModels;
using MuscleMatrix.Core.Domain.ResponseModels;
using MuscleMatrix.Infrastructure.Domain.Entities;

namespace Muscle_Matrix.Configuration
{
    public class MappperConfiguration : Profile
    {
        public MappperConfiguration()
        {

            CreateMap<User,UserResponseModel>();
            CreateMap<UserRoleMapping, UserRoleResponseModel>();
            CreateMap<UserRoleMapping, UserRoleResponseModel>()
                .ForMember(urrm => urrm.UserName, urm => urm.MapFrom(x => x.User.Name)).
                ForMember(urrm => urrm.Role , urm=> urm.MapFrom(x=> x.Role.Name));
            CreateMap<UserRequestModel,UserResponseModel>();

            CreateMap<GymLocation,LocationResponseModel>();
        }
    }
}

//.ForMember(e=>e.UserName,ex=>ex.MapFrom(ea=>ea.User.Name)).ForMember(e=>e.Role,ex=> ex.MapFrom(ea=>ea.Role.Name));