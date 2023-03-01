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
    public class AuthenticateRepository :IAuthenticateRepository
    {
        private readonly ProjectContext _projectContext;

        public AuthenticateRepository(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }
        
        public async Task<User> Authorization(string userLogin)
        {
            var checkUser =  _projectContext.Users.FirstOrDefault(x => x.Email == userLogin);

            if (checkUser == null)
            {
                throw new Exception("Email Is Not Available");
            }
            return checkUser;

        }
        public async Task<List<UserRoleMapping>> GetUserByEmail(string userLogin)
        {
            return await _projectContext.userRoleMappings.Include(x => x.User).Include(x => x.Role).Where(x => x.User.Email == userLogin).ToListAsync();

            }
           
        }
    }

