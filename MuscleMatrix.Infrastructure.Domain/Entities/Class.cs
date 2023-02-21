using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Infrastructure.Domain.Entities
{
    public class Class :Audit
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int TrainerId { get; set; }

        public Trainer Trainer { get; set;}

        public Class(string name, string description, int trainerId)
        {
            Name = name;
            Description = description;
            TrainerId = trainerId;
            CreatedOn = DateTime.Now;
            CreatedBy = name;
            IsActive = false;
        }

    }
}
