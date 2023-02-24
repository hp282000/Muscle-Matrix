using AutoMapper;
using MuscleMatrix.Core.Builder;
using MuscleMatrix.Core.Contract;
using MuscleMatrix.Core.Domain.RequestModels;
using MuscleMatrix.Core.Domain.ResponseModels;
using MuscleMatrix.Infrastructure.Contract;
using MuscleMatrix.Infrastructure.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuscleMatrix.Core.Service
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly IMapper _mapper;


        public async Task<int> AddLocationAsync(LocationRequestModel locationRequestModel)
        {
             var addLocation = LocationBuilder.Build(locationRequestModel);
            //var addLocation = new GymLocation();
            //addLocation.LocationName = locationRequestModel.LocationName;

            var location = await _locationRepository.AddLocation(addLocation);

            if (location == 0)
            {
                throw new ArgumentNullException("location is not Added Successfully Make sure that your repository works properly");
            }
            return location;
        }
        public async Task<List<LocationResponseModel>> GetLocationAsync()
        {
            var getLocations = await _locationRepository.GetAllLocation();

            var mapping = _mapper.Map<List<LocationResponseModel>>(getLocations);


            return mapping;
        }

        public async Task<int> DeleteLocationAsync(int id)
        {
            var deleteLocation = await _locationRepository.DeleteLocation(id);

            if (deleteLocation == null)
            {
                throw new ArgumentNullException("No Record Found");
            }
            return id;
        }


        public async Task<GymLocation> UpdateLocationAsync(LocationRequestModel locationRequestModel)
        {
            var updateUser = await _locationRepository.UpdateLocation(locationRequestModel);

            return updateUser;
        }
    }
}
