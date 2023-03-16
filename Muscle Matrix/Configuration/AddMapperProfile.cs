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
                .ForMember(urrm => urrm.UserName, urm => urm.MapFrom(x => x.User.Email)).
                ForMember(urrm => urrm.Role , urm=> urm.MapFrom(x=> x.Role.Name));
            CreateMap<UserRequestModel,UserResponseModel>();

            CreateMap<Member, MemberResponseModel>()
                .ForMember(mrm => mrm.WeightValue, m => m.MapFrom(x => x.Weight.WeightValue))
                .ForMember(mrm => mrm.HeightValue, m => m.MapFrom(x => x.Height.HeightValue))
                .ForMember(mrm => mrm.LocationName, m => m.MapFrom(x => x.Location.LocationName)).ReverseMap();

            CreateMap<Trainer, TrainerResponseModel>()
                .ForMember(trm => trm.WeightValue, t => t.MapFrom(x => x.Weight.WeightValue))
                .ForMember(trm => trm.HeightValue, t => t.MapFrom(x => x.Height.HeightValue))
                .ForMember(trm => trm.LocationName, t => t.MapFrom(x => x.Location.LocationName));
                
                
            CreateMap<Membership, MembershipResponseModel>();
            //       .ForMember(mrm=> mrm)

            CreateMap<MemberTrainerMapping, MemberTrainerResponseModel>()
                //.ForMember(mtrm => mtrm.Member, m => m.MapFrom(x => x.Member))
                //.ForMember(mtrm => mtrm.Trainer, m => m.MapFrom(x => x.Trainer))
                //.ForMember(mtrm=> mtrm.Member.User , m=> m.MapFrom(x=> x.Member.UserId))
                //.ForMember(mtrm => mtrm.Trainer.User, m => m.MapFrom(x => x.Trainer.User.Id))
                ;

                //.ForMember(mtrm => mtrm.Member.User, m => m.MapFrom(x => x.Member.User))
                //.ForMember(mtrm => mtrm.Trainer.User, m => m.MapFrom(x => x.Trainer.User))

            // .ForMember(mtrm => mtrm.Member.HeightValue, m => m.MapFrom(x => x.Member.Height))
            //.ForMember(mtrm => mtrm.Trainer.HeightValue, m => m.MapFrom(x => x.Trainer.Height))

            // .ForMember(mtrm => mtrm.Member.WeightValue, m => m.MapFrom(x => x.Member.Weight))
            //.ForMember(mtrm => mtrm.Trainer.WeightValue, m => m.MapFrom(x => x.Trainer.Weight))

            // .ForMember(mtrm => mtrm.Member.LocationName, m => m.MapFrom(x => x.Member.Location))
            //.ForMember(mtrm => mtrm.Trainer.LocationName, m => m.MapFrom(x => x.Trainer.Location));

            //  .ForMember(mtrm => mtrm.Member.HeightValue, m => m.MapFrom(x => x.Member.Height.HeightValue));


        }
    }
}

//.ForMember(e=>e.UserName,ex=>ex.MapFrom(ea=>ea.User.Name)).ForMember(e=>e.Role,ex=> ex.MapFrom(ea=>ea.Role.Name));