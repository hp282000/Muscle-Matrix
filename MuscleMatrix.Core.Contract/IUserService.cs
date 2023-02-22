using MuscleMatrix.Core.Domain.RequestModels;
using MuscleMatrix.Core.Domain.ResponseModels;
using MuscleMatrix.Infrastructure.Domain.Entities;

namespace MuscleMatrix.Core.Contract
{
    public interface IUserService
    {
        Task<int> AddUserAsync(UserRequestModel userRequestModel);

        Task<List<UserResponseModel>> GetUserAsync();

        Task<int> DeleteUserAsync(int id);

        Task<User>  UpdateUserAsync(UserRequestModel userRequestModel);
    }
}