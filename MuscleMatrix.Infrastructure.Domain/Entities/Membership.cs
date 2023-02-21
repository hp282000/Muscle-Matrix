using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Infrastructure.Domain.Entities
{
    public class Membership :Audit
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public long Cost { get; set; }  

        public int DurationDay { get; set; }

        public Membership(string type, long cost, int durationDay)
        {
            Type = type;
            Cost = cost;
            DurationDay = durationDay;
            CreatedOn = DateTime.Now;
            IsActive= true;
        }


    }
}

