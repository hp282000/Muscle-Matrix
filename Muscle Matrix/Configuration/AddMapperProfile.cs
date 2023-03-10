using AutoMapper;
using MuscleMatrix.Core.Domain.RequestModels;
using MuscleMatrix.Core.Domain.ResponseModels;
using MuscleMatrix.Infrastructure.Domain.Entities;

namespace Muscle_Matrix.Configuration
{
    public class AddMapperProfile : Profile
    {
        public AddMapperProfile()
        {

            CreateMap<User,UserResponseModel>();
      
            CreateMap<UserRoleMapping, UserRoleResponseModel>()
                .ForMember(urrm => urrm.UserName, urm => urm.MapFrom(x => x.User.Name)).
                ForMember(urrm => urrm.Role , urm=> urm.MapFrom(x=> x.Role.Name));
            CreateMap<UserRequestModel,UserResponseModel>();

            CreateMap<Member, MemberResponseModel>()
                .ForMember(mrm => mrm.WeightValue, m => m.MapFrom(x => x.Weight.WeightValue))
                .ForMember(mrm => mrm.HeightValue, m => m.MapFrom(x => x.Height.HeightValue))
                .ForMember(mrm => mrm.LocationName, m => m.MapFrom(x => x.Location.LocationName)).ReverseMap();

            CreateMap<Trainer, TrainerResponseModel>()
                .ForMember(trm => trm.WeightValue, t => t.MapFrom(x => x.Weight.WeightValue))
                .ForMember(trm => trm.HeightValue, t => t.MapFrom(x => x.Height.HeightValue))
                .ForMember(trm => trm.LocationName,t => t.MapFrom(x => x.Location.LocationName));

            CreateMap<Membership, MembershipResponseModel>();
         //       .ForMember(mrm=> mrm)
             
        
        }
    }
}

//.ForMember(e=>e.UserName,ex=>ex.MapFrom(ea=>ea.User.Name)).ForMember(e=>e.Role,ex=> ex.MapFrom(ea=>ea.Role.Name));