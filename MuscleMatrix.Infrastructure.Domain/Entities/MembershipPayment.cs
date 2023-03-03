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

        public MembershipPayment()
        {
        }

        public MembershipPayment(long transactionId, long transactionAmount, DateTime transactionDate, string status)
        {
            TransactionId = transactionId;
            TransactionAmount = transactionAmount;
            TransactionDate = transactionDate;
            Status = status;
          
            //MembershipId = membershipId;
        }

    }
}
