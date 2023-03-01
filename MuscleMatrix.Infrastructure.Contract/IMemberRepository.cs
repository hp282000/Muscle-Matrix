using MuscleMatrix.Core.Domain.RequestModels;
using MuscleMatrix.Infrastructure.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Infrastructure.Contract
{
    public interface IMemberRepository
    {
        Task<int> AddMember(Member member);

        Task<List<Member>> GetMember();

        Task<int> DeleteMember(int id);

        Task<Member> UpdateMember(MemberRequestModel memberRequestModel);
    }
}
