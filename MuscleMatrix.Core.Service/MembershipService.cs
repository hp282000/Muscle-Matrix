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
    public class MembershipService : IMembershipService
    {
        private readonly IMembershipRepository _iMembershipRepository;
        private readonly IMapper _mapper;

        public MembershipService(IMembershipRepository iMembershipRepository, IMapper mapper)
        {
            _iMembershipRepository = iMembershipRepository;
            _mapper = mapper;
        }

        public async Task<int> AddMembershipAsync(MembershipRequestModel membershipRequestModel)
        {
            var addMembership = MembershipBuilder.Build(membershipRequestModel);

            var useMembership = await _iMembershipRepository.AddMembership(addMembership);

            return useMembership;

        }

        public async Task<int> DeleteMembershipAsync(int id)
        {
            var deleteMembership = await _iMembershipRepository.DeleteMembership(id);

            if (deleteMembership == null)
            {
                throw new ArgumentNullException("No Record Found");
            }
            return id;
        }

        public async Task<List<MembershipResponseModel>> GetMembershipAsync()
        {
            var getMemberships = await _iMembershipRepository.GetMembership();
            
            var mapper = _mapper.Map<List<MembershipResponseModel>>(getMemberships);

            return mapper;
        }

        public async Task<MembershipResponseModel> UpdateMembershipAsync(MembershipRequestModel membershipRequestModel, int id)
        {
            var getMembership = await _iMembershipRepository.GetMembershipById(id);
            if (getMembership == null)
                throw new Exception("Member Not Found");
            getMembership.UpdateData(membershipRequestModel.Type , membershipRequestModel.Cost , membershipRequestModel.DurationDay ,membershipRequestModel.MemberId);

            var updateMembership = await _iMembershipRepository.UpdateMembership(getMembership);
            var mapping = _mapper.Map<MembershipResponseModel>(updateMembership);

            return mapping;
        }
    }
}
