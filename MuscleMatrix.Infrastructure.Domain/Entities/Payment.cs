using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Infrastructure.Domain.Entities
{
    public class Payment
    {
        public int Id { get; set; }

        public long TransactionId { get; set; }

        public long TransactionAmount { get; set; }

        public DateTime TransactionDate { get; set; }

        public string Status { get; set; }

        public int BookingId { get; set; }

        public Booking Booking { get; set; }

    }
}
