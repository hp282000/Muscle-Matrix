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
        public string ContactNo { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
       

        public User() { }

        public User(string name, string email, string contactNo, string password)
        {
            Name = name;
            Email = email;
            ContactNo = contactNo;
            Password = password;
            CreatedOn= DateTime.Now;
            IsActive = false;
        }
    }
}
