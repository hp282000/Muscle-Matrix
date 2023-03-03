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
    public class PasswordChangeRepository :IPasswordChangeRepository
    {
        private readonly ProjectContext _projectContext;
        public PasswordChangeRepository(ProjectContext projectContext) 
        {
        _projectContext = projectContext;
        }

        public async Task<User> GetEmail(string email)
        {
            var checkUser = _projectContext.Users.FirstOrDefault(x => x.Email == email);

            if (checkUser == null)
            {
                throw new Exception("Email Is Not Available");
            }
            return checkUser;

        }
        
        public async Task<int> UpdatePasswordAsync()
        {
          return  await _projectContext.SaveChangesAsync();

        }
    }
}
