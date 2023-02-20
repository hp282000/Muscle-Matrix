using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Infrastructure.Domain.Entities
{
    public class MembershipPayment
    {
        public int Id { get; set; }

        public long TransactionId { get; set; }

        public long TransactionAmount { get; set; }

        public DateTime TransactionDate { get; set; }

        public string Status { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int MembershipId { get; set; }

        public Membership Membership { get; set; }
    }
}
