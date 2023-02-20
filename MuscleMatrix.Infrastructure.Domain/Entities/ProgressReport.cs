using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Infrastructure.Domain.Entities
{
    public class ProgressReport:Audit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Member Member { get; set; }  
        public int MemberId { get; set; }   

    }
}
