using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Infrastructure.Domain.Entities
{    
    /// <summary>
     /// this table is created for give user dropdown to select value
     /// </summary>
    public class Weight
    {
        public Weight() { }
        public int Id { get; set; }

        public string WeightValue { get; set; }//range
    }
}
