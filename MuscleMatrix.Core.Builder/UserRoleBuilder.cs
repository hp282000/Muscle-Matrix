using MuscleMatrix.Core.Domain.RequestModels;
using MuscleMatrix.Infrastructure.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Core.Builder
{
    public class UserRoleBuilder
    {
        public static UserRoleMapping Build(UserRoleRequestModel userRoleRequestModel)
        {

            return new UserRoleMapping(userRoleRequestModel.UserId, userRoleRequestModel.RoleId);
        }
    }
}
