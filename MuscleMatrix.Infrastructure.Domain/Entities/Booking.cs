using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Infrastructure.Domain.Entities
{
    public class Booking
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int ClassId { get; set; }
        public Class Class { get; set; }

        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; }

        public string BookingName {  get; set; }  



    }
}
