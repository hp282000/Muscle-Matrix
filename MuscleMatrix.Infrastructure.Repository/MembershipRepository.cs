using AutoMapper.Execution;
using Microsoft.EntityFrameworkCore;
using MuscleMatrix.Infrastructure.Contract;
using MuscleMatrix.Infrastructure.Domain.Context;
using MuscleMatrix.Infrastructure.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Infrastructure.Repository
{
    public class MembershipRepository : IMembershipRepository
    {
        private readonly ProjectContext _projectContext;
        public MembershipRepository(ProjectContext projectContext)
        {

            _projectContext = projectContext;
        }

        public async Task<int> AddMembership(Membership membership)
        {
            var addMembership = await _projectContext.Memberships.AddAsync(membership);

            if (addMembership == null)
            {
                throw new Exception("Membership Not Add Successfully...");
            }
            return await _projectContext.SaveChangesAsync();
        }

        public async Task<int> DeleteMembership(int id)
        {
            var deleteMembership = _projectContext.Memberships.FirstOrDefault(x => x.Id == id);

            _projectContext.Memberships.Remove(deleteMembership);

            return _projectContext.SaveChanges();
        }

        public async Task<List<Membership>> GetMembership()
        {
            var getMembership = await _projectContext.Memberships.Include(x=> x.Member).ThenInclude(x=> x.User).Include(x=>x.Member.Height).Include(x => x.Member.Weight).Include(x => x.Member.Location).ToListAsync();

            return getMembership;
        }

        public async Task<Membership> GetMembershipById(int id)
        {
            var getMembershipById = await _projectContext.Memberships.Include(x => x.Member).FirstOrDefaultAsync(x => x.Id == id);

            return getMembershipById;
        }

        public async Task<Membership> UpdateMembership(Membership membership)
        {
            _projectContext.Memberships.Update(membership);

            await _projectContext.SaveChangesAsync();

            return membership;
        }
    }
}
