using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Infrastructure.Domain.Entities
{
    public class UserRoleMapping
    {
        public UserRoleMapping() { }

        public int Id { get; set; }
        public User user { get; set; }
        public int UserId { get; set; }          
        public Role role { get; set; }
        public int RoleId { get; set; }

    }
}
