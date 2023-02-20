using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Infrastructure.Domain.Entities
{
    public class Membership
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public long Cost { get; set; }  

        public int DurationDay { get; set; }

    }
}
}
