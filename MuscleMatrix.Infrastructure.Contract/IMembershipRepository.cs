using MuscleMatrix.Infrastructure.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Infrastructure.Contract
{
    public interface IMembershipRepository
    {
        Task<int> AddMembership(Membership membership);

        Task<List<Membership>> GetMembership();

        Task<int> DeleteMembership(int id);

        Task<Membership> UpdateMembership(Membership membership);
        Task<Membership> GetMembershipById(int id);
    }
}
