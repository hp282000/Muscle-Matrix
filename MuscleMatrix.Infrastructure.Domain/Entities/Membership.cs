using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Infrastructure.Domain.Entities
{
    public class Membership :Audit
    {
        public int Id { get; set; }

        public MembershipType Type { get; set; }

        public long Cost { get; set; }  

        public int DurationDay { get; set; }

        public int MemberId { get; set; }

        public Member Member { get; set; }

        public Membership() { }
        public Membership(MembershipType type, long cost, int durationDay, int memberId)
        {
            Type = type;
            Cost = cost;
            DurationDay = durationDay;
            MemberId = memberId;
            CreatedOn = DateTime.Now;
            CreatedBy = "Admin";
            IsActive= true;
            UpdatedOn= DateTime.Now;
            UpdatedBy = "Not Updated";
        }
        public Membership UpdateData(MembershipType type , long cost , int durationDay , int memberId)
        {
            Type= type;
            Cost = cost;
            DurationDay = durationDay;
            MemberId = memberId;
            return this;
        }
    }
}

