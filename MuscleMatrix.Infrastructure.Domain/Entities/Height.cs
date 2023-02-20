using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Infrastructure.Domain.Entities
{
    public class Height
    {
        public Height() { } 
        public int Id { get; set; }

        public string HeightValue { get; set; }
    }
}
