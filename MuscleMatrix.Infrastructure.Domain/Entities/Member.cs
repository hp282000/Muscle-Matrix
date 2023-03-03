
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MuscleMatrix.Infrastructure.Domain.Entities
{
    public class Member
    {
        public int Id { get; set; }
        public string Photo { get; set; }
        public int WeightId { get; set; }
        public Weight? Weight { get; set; }
        public int HeightId { get; set; }
        public Height? Height { get; set; }
        public int LocationId { get; set; }
        public GymLocation? Location { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }


        public Member(string photo, int weightId, int heightId, int locationId, int userId)
        {
            Photo = photo;
            WeightId = weightId;
            HeightId = heightId;
            LocationId = locationId;
            UserId = userId;
        }

        public Member UpdateData(int userId , int locationId , int heightId , int weightId , string photo )
        {
            Photo = photo;
            WeightId = weightId;
            HeightId = heightId;
            LocationId = locationId;
            UserId = userId;

            return this;
        }
        

    }     
}
