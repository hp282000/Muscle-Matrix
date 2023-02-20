using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Infrastructure.Domain.Entities
{
    public class Attendance
    {
        public int Id { get; set; } 

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

    }
}
