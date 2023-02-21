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

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public Class_Schedule(int classId, DateTime day, DateTime startTime, DateTime endTime)
        {
            ClassId = classId;

            Day = day;
            StartTime = startTime;
            EndTime = endTime;
      //      LocationId = locationId;
       
        }

    }
}
