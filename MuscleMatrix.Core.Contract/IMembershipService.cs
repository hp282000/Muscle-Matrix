using MuscleMatrix.Core.Domain.RequestModels;
using MuscleMatrix.Core.Domain.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Core.Contract
{
    public interface IMembershipService
    {
        Task<int> AddMembershipAsync(MembershipRequestModel membershipRequestModel);

        Task<List<MembershipResponseModel>> GetMembershipAsync();

        Task<int> DeleteMembershipAsync(int id);

        Task<MembershipResponseModel> UpdateMembershipAsync(MembershipRequestModel membershipRequestModel, int id);

    }
}
