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
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly ProjectContext _projectContext;

        public UserRoleRepository(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }

        public async Task<int> AddUserRole(UserRoleMapping userRoleMapping)
        {
             await _projectContext.AddAsync(userRoleMapping);

            return await _projectContext.SaveChangesAsync();


        }

        public async Task<List<UserRoleMapping>> GetAllRoles()
        {
            var getUserRole = await _projectContext.userRoleMappings.Include(u=>u.User).Include(r=>r.Role).ToListAsync();

            return getUserRole;

        }


    }
}
