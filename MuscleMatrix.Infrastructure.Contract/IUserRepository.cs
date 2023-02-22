using MuscleMatrix.Core.Domain.RequestModels;
using MuscleMatrix.Infrastructure.Domain.Entities;

namespace MuscleMatrix.Infrastructure.Contract
{
    public interface IUserRepository
    {
        Task<int> AddUser(User user);

        Task<List<User>> GetAllUsers();

        Task<int> DeleteUser(int id);

        Task<User> UpdateUser(UserRequestModel userRequestModel);
    }
}