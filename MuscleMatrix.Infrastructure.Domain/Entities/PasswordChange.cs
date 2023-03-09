using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Infrastructure.Domain.Entities
{
    public class PasswordChange
    {
        public byte[] oldPassword { get; set; }

        public byte[] OldPasswordKey { get; set;}

        public byte[] NewPassword { get; set;}

        public byte[] NewPasswordKey { get;set;}

        public byte[] ConfirmPassword { get; set;}

       

    }
}
