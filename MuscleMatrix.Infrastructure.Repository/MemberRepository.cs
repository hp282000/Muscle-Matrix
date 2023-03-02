using Microsoft.EntityFrameworkCore;
using MuscleMatrix.Core.Domain.RequestModels;
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
        public async Task<Member> GetMemberById(int id)
        {
            var getMemberById = await _projectContext.Members.Include(x => x.User).Include(x => x.Height).Include(x => x.Weight).Include(x => x.Location).FirstOrDefaultAsync(x => x.Id == id);


            return getMemberById;
        }
        public async Task<int> DeleteMember(int id)
        {
            var deleteMember = _projectContext.Members.FirstOrDefault(x => x.Id == id);

            _projectContext.Members.Remove(deleteMember);

            return _projectContext.SaveChanges();
        }
        public async Task<Member> UpdateMember(Member member)
        {

          //  var updateMember = _projectContext.Members.Include(x=> x.User).Include(x=> x.Location).Include(x=> x.Weight).Include(x=> x.Height).FirstOrDefault(x => x.Id == member.id);

            //if (updateMember == null)
            //{ 

            //    throw new Exception("No Member Available");
            //}

             _projectContext.Members.Update(member);

            await _projectContext.SaveChangesAsync();

            return member;
        }
    }
}
