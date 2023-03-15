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
    public class MemberTrainerRepository : IMemberTrainerRepository
    {
        private readonly ProjectContext _projectContext;

        public MemberTrainerRepository(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }

        public async Task<int> AddTrainerMember(MemberTrainerMapping memberTrainerMapping)
        {
            await _projectContext.AddAsync(memberTrainerMapping);

            return await _projectContext.SaveChangesAsync();
        }

        public async Task<List<MemberTrainerMapping>> GetTrainerMember()
        {
            var getTrainerMember = await _projectContext.memberTrainerMappings
                .Include(x => x.Member).ThenInclude(x => x.Height).Include(x => x.Member.Weight).Include(x => x.Member.Location).Include(x=>x.Member.User)
                .Include(x=> x.Trainer).ThenInclude(x => x.Height).Include(x => x.Trainer.Weight).Include(x => x.Trainer.Location).Include(x => x.Trainer.User)
                .ToListAsync();
            
            return getTrainerMember;
         
        }
        
    }
}
