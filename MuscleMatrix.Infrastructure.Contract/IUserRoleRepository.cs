using MuscleMatrix.Infrastructure.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Infrastructure.Contract
{
    public interface IUserRoleRepository
    {
        Task<int> AddUserRole(UserRoleMapping userRoleMapping);

        Task<List<UserRoleMapping>> GetAllRoles();
    }
}
