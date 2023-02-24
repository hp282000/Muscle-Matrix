using Microsoft.EntityFrameworkCore;
using MuscleMatrix.Core.Domain.RequestModels;
using MuscleMatrix.Infrastructure.Contract;
using MuscleMatrix.Infrastructure.Domain.Context;
using MuscleMatrix.Infrastructure.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Infrastructure.Repository
{
    public class LocationRepository : ILocationRepository
    {
        private readonly ProjectContext _projectContext;

        public LocationRepository(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }

        public async Task<int> AddLocation(GymLocation gymLocation)
        {
            _projectContext.GymLocations.Add(gymLocation);

            return await _projectContext.SaveChangesAsync();
        }
        public async Task<List<GymLocation>> GetAllLocation()
        {
            var getLocation = await _projectContext.GymLocations.ToListAsync();

            return getLocation;
        }

        public async Task<int> DeleteLocation(int id)
        {
            var deleteLocation = _projectContext.GymLocations.FirstOrDefault(x => x.Id == id);

            _projectContext.GymLocations.Remove(deleteLocation);

            return await _projectContext.SaveChangesAsync();
        }


        public async Task<GymLocation> UpdateLocation(LocationRequestModel locationRequestModel)
        {
            var updateLocation = _projectContext.GymLocations.FirstOrDefault(x => x.Id == locationRequestModel.Id);

            if (updateLocation == null)
            {

                throw new Exception("No User Available");
            }
            updateLocation.LocationName= locationRequestModel.LocationName;

            _projectContext.GymLocations.Update(updateLocation);

            await _projectContext.SaveChangesAsync();

            return updateLocation;
        }

       
    }
}
