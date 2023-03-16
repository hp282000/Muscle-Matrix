using MuscleMatrix.Core.Domain.RequestModels;
using MuscleMatrix.Infrastructure.Domain.Context;
using MuscleMatrix.Infrastructure.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Infrastructure.Contract
{
    public interface IAuthenticateRepository
    {
        Task<User> Authorization(UserLogin userLogin);
        Task<List<UserRoleMapping>> GetUserByEmail(string  userLogin);
      //  Task<User> GetEmail(string email); ///////
    }
 
}
