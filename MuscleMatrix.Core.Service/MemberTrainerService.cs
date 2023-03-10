using AutoMapper;
using MuscleMatrix.Core.Builder;
using MuscleMatrix.Core.Contract;
using MuscleMatrix.Core.Domain.RequestModels;
using MuscleMatrix.Core.Domain.ResponseModels;
using MuscleMatrix.Infrastructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Core.Service
{
    public class MemberTrainerService : IMemberTrainerService
    {
        private readonly IMemberTrainerRepository _memberTrainerRepository;
        private readonly IMapper _mapper;
        public MemberTrainerService(IMemberTrainerRepository memberTrainerRepository,IMapper mapper)
        {
            _memberTrainerRepository = memberTrainerRepository;
            _mapper = mapper;
        }

        public async Task<int> AddMemberTrainerAsync(MemberTrainerRequestModel memberTrainerRequestModel)
        {
            var addMemberTrainer = MemberTrainerBuilder.Build(memberTrainerRequestModel);

            var useMemberTrainer = await _memberTrainerRepository.AddTrainerMember(addMemberTrainer);

            return useMemberTrainer;
        }

        public async Task<List<MemberTrainerResponseModel>> GetMemberTrainersAsync()
        {
            var getTrainerMember = await _memberTrainerRepository.GetTrainerMember();

            var mapper = _mapper.Map<List<MemberTrainerResponseModel>>(getTrainerMember);

            return mapper;
        }
    }
}
