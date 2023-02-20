
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Infrastructure.Domain.Entities
{
    public class Member:Audit
    {
        public int Id { get; set; }

        public string Photo { get; set; }
        public Weight Weight { get; set; }
        public int WeightId { get; set; }
        public Height Height { get; set; }
        public int HeightId { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
