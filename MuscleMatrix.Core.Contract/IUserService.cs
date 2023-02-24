using MuscleMatrix.Core.Domain.RequestModels;
using MuscleMatrix.Core.Domain.ResponseModels;

namespace MuscleMatrix.Core.Contract
{
    public interface IUserService
    {
        Task<string> UserLoginAsync(UserLogin userLogin);

        Task<int> AddUserAsync(UserRequestModel userRequestModel);

        Task<List<UserResponseModel>> GetUserAsync();

        Task<int> DeleteUserAsync(int id);

        Task<UserResponseModel>  UpdateUserAsync(UserRequestModel userRequestModel);
    }
}