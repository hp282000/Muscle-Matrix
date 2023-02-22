using MuscleMatrix.Core.Domain.RequestModels;
using MuscleMatrix.Infrastructure.Domain.Entities;

namespace MuscleMatrix.Core.Builder
{
    public class UserBuilder
    {
        public static User Build(UserRequestModel userRequestModel , User user)
        {
            return new User(userRequestModel.Name, userRequestModel.Email, userRequestModel.ContactNo , userRequestModel.Gender, userRequestModel.DateOfBirth,user.Password , user.PasswordSalt );
        }
    }
}