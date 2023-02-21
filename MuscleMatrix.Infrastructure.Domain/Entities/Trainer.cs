﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Infrastructure.Domain.Entities
{
    public class Trainer
    {
        public Trainer()
        {
        }
        public int Id { get; set; } 
        public int YearofExperience { get; set; }    
        public string Speciality { get; set; }
        public string ExperienceDiscription { get; set; }
        public  string ProfilePhoto { get; set; }
        public int WeightId { get; set; }
        public Weight Weight { get; set; }
        public int HeightId { get; set; }
        public Height Height { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }  

        public int LocationId { get; set; }

        public GymLocation Location { get; set; }


        public Trainer(int experience, string speciality, string experienceLetter, string profilePhoto,  int userId)
        {
            YearofExperience = experience;
            Speciality = speciality;
            ExperienceDiscription = experienceLetter;
            ProfilePhoto = profilePhoto;
            
            UserId = userId;
            User.CreatedOn = DateTime.Now;
            User.CreatedBy = User.Name;
            User.IsActive = true;


        }
    }
}
