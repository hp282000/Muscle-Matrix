using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Infrastructure.Domain.Entities
{
    public class Trainer:Audit
    {
        public Trainer()
        {
        }

        public int Id { get; set; } 
        public int Experience { get; set; }    
        public string Speciality { get; set; }
        public string ExperienceLetter { get; set; }
        public  string ProfilePhoto { get; set; }
        public User User { get; set; }  
        public int UserId { get; set; }


        public Trainer(int experience, string speciality, string experienceLetter, string profilePhoto, User user, int userId)
        {
            Experience = experience;
            Speciality = speciality;
            ExperienceLetter = experienceLetter;
            ProfilePhoto = profilePhoto;
            User = user;
            UserId = userId;
            CreatedOn= DateTime.Now;
            IsDeleted= false;
        }
    }
}
