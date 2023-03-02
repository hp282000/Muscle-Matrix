using AutoMapper;
using MuscleMatrix.Core.Builder;
using MuscleMatrix.Core.Contract;
using MuscleMatrix.Core.Domain.RequestModels;
using MuscleMatrix.Core.Domain.ResponseModels;
using MuscleMatrix.Infrastructure.Contract;
using MuscleMatrix.Infrastructure.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Core.Service
{
    public class MemberService :IMemberService
    {
        private readonly IMemberRepository _imemberRepository;
        private readonly IMapper _mapper;

        public MemberService(IMemberRepository imemberRepository, IMapper mapper)
        {
            _imemberRepository = imemberRepository;
            _mapper = mapper;
        }

        public async Task<int> AddMemberAsync(MemberRequestModel memberRequestModel)
        {
            var addMember =  MemberBuilder.Build(memberRequestModel);
         
            var useMember = await _imemberRepository.AddMember(addMember);

            return useMember;
         
            
        }
        public async Task<List<MemberResponseModel>> GetMemberAsync()
        {
            var getMembers = await _imemberRepository.GetMember();

            var mapper = _mapper.Map<List<MemberResponseModel>>(getMembers);

            return mapper;
        }

        public async Task<int> DeleteMemberAsync(int id)
        {
            var deleteMember = await _imemberRepository.DeleteMember(id);

            if (deleteMember == null)
            {
                throw new ArgumentNullException("No Record Found");
            }
            return id;
        }

        public async Task<MemberResponseModel> UpdateMemberAsync(MemberRequestModel memberRequestModel, int id)
        {
           
            var getMember = await _imemberRepository.GetMemberById(id);
            if (getMember == null)
                throw new Exception("Member Not Found");
            getMember.UpdateData(memberRequestModel.UserId, memberRequestModel.LocationId, memberRequestModel.WeightId, memberRequestModel.HeightId, memberRequestModel.Photo.FileName);
         
            var updateMember = await _imemberRepository.UpdateMember(getMember);
            var mapping = _mapper.Map<MemberResponseModel>(updateMember);
           
            return mapping;
        }
    }
}
