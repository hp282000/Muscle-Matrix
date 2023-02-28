using MuscleMatrix.Core.Domain.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Core.Contract
{
    public interface IMemberService
    {
        Task<int> AddMemberAsync(MemberRequestModel memberRequestModel);


        
    }
}
