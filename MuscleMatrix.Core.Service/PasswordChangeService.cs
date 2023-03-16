using MuscleMatrix.Core.Contract;
using MuscleMatrix.Core.Domain.RequestModels;
using MuscleMatrix.Infrastructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;
using MuscleMatrix.Infrastructure.Domain.Entities;

namespace MuscleMatrix.Core.Service
{
    public class PasswordChangeService : IPasswordChangeService
    {
        private readonly IPasswordChangeRepository _passwordChangeRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        
         public PasswordChangeService(IPasswordChangeRepository passwordChangeRepository,IHttpContextAccessor httpContextAccessor) 
        {
           _passwordChangeRepository = passwordChangeRepository;
            _httpContextAccessor = httpContextAccessor;
            
        }

        public async Task<string> ChangePasswordAsync(PasswordchangeRequestModel passwordchangeRequestModel)
        {
            var getEmailFromAuthentication = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;
        

            var getUser = await _passwordChangeRepository.GetEmail(getEmailFromAuthentication);

            if (getUser != null) 
            {
                var hsa = new HMACSHA256(getUser.PasswordSalt);

                var encryptPassword = hsa.ComputeHash(Encoding.ASCII.GetBytes(passwordchangeRequestModel.OldPassword)); //oldpass
              //  var computePassword = (encryptPassword);


                if(getUser.Password.SequenceEqual(encryptPassword))

              //  if(getUser.Password.SequenceEqual(encryptPassword))
                {
                    //go to database and update password

                    if( passwordchangeRequestModel.NewPassword == passwordchangeRequestModel.ConfirmPassword)
                    {
                        var newhsa = new HMACSHA256();

                        var newPassword = Encoding.ASCII.GetBytes(passwordchangeRequestModel.NewPassword);
                        var computeNewPassword = hsa.ComputeHash(newPassword);

                        getUser.Password = computeNewPassword;
                        getUser.PasswordSalt = newhsa.Key;

                        await _passwordChangeRepository.UpdatePasswordAsync();
                        return "Change Password";
                    }
                    
                


                    //  var changePassword = await _passwordChangeRepository.UpdatePasswordAsync();

                    //  getUser.UpdatePassword()

                    
                }

                
            }
                return "Old Password Not Match";
           
           
        }
    }
}
