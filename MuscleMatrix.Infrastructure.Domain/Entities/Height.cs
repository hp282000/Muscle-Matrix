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
    public class Height
    {
        public Height() { } 
        public int Id { get; set; }
        public string HeightValue { get; set; }
    }
}
