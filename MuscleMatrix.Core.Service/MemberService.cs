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
            addMember.CreatedBy = addMember.User.Name;
            var useMember = await _imemberRepository.AddMember(addMember);

            return useMember;
         
            
        }
    }
}
