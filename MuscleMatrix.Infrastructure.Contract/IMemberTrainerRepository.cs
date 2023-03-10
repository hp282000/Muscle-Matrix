using MuscleMatrix.Infrastructure.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Infrastructure.Contract
{
    public interface IMemberTrainerRepository
    {
        Task<int> AddTrainerMember(MemberTrainerMapping memberTrainerMapping);

        Task<List<MemberTrainerMapping>> GetTrainerMember();
    }
}
