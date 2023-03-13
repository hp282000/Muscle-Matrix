using MuscleMatrix.Core.Domain.RequestModels;
using MuscleMatrix.Infrastructure.Domain.Entities;

namespace MuscleMatrix.Core.Builder
{
    public class UserBuilder
    {
        public static User Build(UserRequestModel userRequestModel , byte[] password , byte[] passwordSalt)
        {
            return new User(userRequestModel.Name, userRequestModel.Email, userRequestModel.ContactNo , userRequestModel.Gender, userRequestModel.DateOfBirth, password, passwordSalt);
        }
    }
}