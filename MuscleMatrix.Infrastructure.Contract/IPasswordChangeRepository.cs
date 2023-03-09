using MuscleMatrix.Infrastructure.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Infrastructure.Contract
{
    public interface IPasswordChangeRepository
    {
        Task<User> GetEmail(string email);

        Task<int> UpdatePasswordAsync();
    }
}
