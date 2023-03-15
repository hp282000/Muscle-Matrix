using System.ComponentModel.DataAnnotations.Schema;

namespace MuscleMatrix.Infrastructure.Domain.Entities
{
    public class MemberTrainerMapping
    {
  
        public int Id { get; set; }
        public int MemberId { get; set; }
        public Member? Member { get; set; }
        public int TrainerId { get; set; }
        public Trainer? Trainer { get; set; }

        public MemberTrainerMapping(int memberId, int trainerId)
        {
            MemberId = memberId;
            TrainerId = trainerId;
        }

        public MemberTrainerMapping()
        {
        }
    }
}
