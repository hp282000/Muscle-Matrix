using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Infrastructure.Domain.Entities
{
    public class GymLocation : Audit
    {
        public int Id { get; set; }

        public string LocationName { get; set; }

        public GymLocation()
        {
        }

        public GymLocation(string locationName)
        {
            LocationName = locationName;
            CreatedOn = DateTime.Now;
            IsActive = false;

        }

    }

}
