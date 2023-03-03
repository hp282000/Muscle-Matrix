using MuscleMatrix.Infrastructure.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Core.Domain.ResponseModels
{
    public class MembershipResponseModel
    {
        public MembershipType Type { get; set; }

        public long Cost { get; set; }

        public int DurationDay { get; set; }

        public MemberResponseModel Member { get; set; }



    }
}
