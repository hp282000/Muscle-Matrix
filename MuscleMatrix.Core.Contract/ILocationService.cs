using MuscleMatrix.Core.Domain.RequestModels;
using MuscleMatrix.Core.Domain.ResponseModels;
using MuscleMatrix.Infrastructure.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Core.Contract
{
    public interface ILocationService
    {
        Task<int> AddLocationAsync(LocationRequestModel locationRequestModel);

        Task<List<LocationResponseModel>> GetLocationAsync();

        Task<int> DeleteLocationAsync(int id);

        Task<GymLocation> UpdateLocationAsync(LocationRequestModel locationRequestModel);
    }
}
