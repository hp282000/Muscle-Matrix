using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Infrastructure.Domain.Entities
{
    public class User:Audit
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Email { get; set; }
        public long ContactNo { get; set; }
        public byte[] Password { get; set; }

        public byte[] PasswordSalt { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
       
        public User() { }

        public User(string name, string email, long contactNo,string gender ,DateTime dateOfBirth, byte[] password, byte[] passwordSalt)
        {
            Name = name;
            Email = email;
            ContactNo = contactNo;
            Gender= gender;
            DateOfBirth = dateOfBirth;
            Password = password;
            PasswordSalt = passwordSalt;
            CreatedOn= DateTime.Now;
            CreatedBy = name;
            IsActive = true; 
            UpdatedBy= "Not Updated";
            UpdatedOn= DateTime.Now;
            
        }

        public User UpdateData(string name, string email, long contactNo, string gender, DateTime dateOfBirth)
        {
            Name = name;
            Email = email;
            ContactNo = contactNo;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            IsActive = true;
            UpdatedBy = name;
            UpdatedOn = DateTime.Now;

            return this;
        }
    }
}
