using MuscleMatrix.Core.Domain.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Core.Contract
{
    public interface IPasswordChangeService
    {
        Task<string> ChangePasswordAsync(PasswordchangeRequestModel passwordchangeRequestModel);
    }
}
