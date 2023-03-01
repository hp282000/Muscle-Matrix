using Microsoft.EntityFrameworkCore;
using MuscleMatrix.Infrastructure.Contract;
using MuscleMatrix.Infrastructure.Domain.Context;
using MuscleMatrix.Infrastructure.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Infrastructure.Repository
{
    public class MemberRepository : IMemberRepository
    {
        private readonly ProjectContext _projectContext;
        public MemberRepository(ProjectContext projectContext) {

            _projectContext = projectContext;
        }
        public async Task<int> AddMember(Member member)
        {
            var addMember = await _projectContext.Members.AddAsync(member);

            if (addMember == null)
            {
                throw new Exception("Member Not Add Successfully...");
            }
            return await _projectContext.SaveChangesAsync();   
        }
        public async Task<List<Member>> GetMember()
        {
            var getMembers = await _projectContext.Members.Include(x=> x.User).Include(x=> x.Height).Include(x=> x.Weight).Include(x=> x.Location).ToListAsync();


            return getMembers;
        }
    }
}
