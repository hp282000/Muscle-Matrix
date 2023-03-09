using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Infrastructure.Domain.Entities
{
    public class TrainerMemberMapping
    {
        public int Id { get; set; }

        public int MemberId { get; set; }
        public virtual Member Member { get; set; }
        public int TrainerId { get; set; }
        public virtual Trainer Trainer { get; set; }

        //public MemberTrainerMapping(int memberId, int trainerId)
        //{
        //    MemberId = memberId;
        //    TrainerId = trainerId;
        //}
    }
}
