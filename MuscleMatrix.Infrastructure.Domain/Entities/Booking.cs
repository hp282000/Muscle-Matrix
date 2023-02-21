namespace MuscleMatrix.Infrastructure.Domain.Entities
{
    public class Booking: Audit
    {

        public int Id { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }

        public int PaymentId { get; set; }
        public Payment Payment { get; set; }

        //public int UserId { get; set; }
        //public User User { get; set; }
        public string BookingName {  get; set; }  

        public Booking( int classId, string bookingName)
        {
        
      
            ClassId = classId;
        
            BookingName = bookingName;
            CreatedOn = DateTime.Now;
            IsActive = false;
        }


    }
}
