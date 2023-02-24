using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Infrastructure.Domain.Entities
{
    public class UserRoleMapping
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }


        public UserRoleMapping(int userId, int roleId)
        {
          
            UserId = userId;
            RoleId= roleId;
            
            

        }

        public UserRoleMapping()
        {
        }
    }
}
