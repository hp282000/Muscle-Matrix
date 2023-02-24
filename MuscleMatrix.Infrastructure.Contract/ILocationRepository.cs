using MuscleMatrix.Core.Domain.RequestModels;
using MuscleMatrix.Infrastructure.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Infrastructure.Contract
{
    public interface ILocationRepository
    {
        Task<int> AddLocation(GymLocation gymLocation);

        Task<List<GymLocation>> GetAllLocation();

        Task<int> DeleteLocation(int id);

        Task<GymLocation> UpdateLocation(LocationRequestModel locationRequestModel);
    }
}
