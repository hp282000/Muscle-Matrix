using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Infrastructure.Domain.Entities
{
    public class Class_Schedule
    {
        public int Id { get; set; }

        public int ClassId { get; set; }

        public Class Class { get; set; }

        public DateTime Day { get; set; }   

        public TimeOnly StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int LocationId { get; set; }

        public GymLocation Location { get; set; }

    }
}
