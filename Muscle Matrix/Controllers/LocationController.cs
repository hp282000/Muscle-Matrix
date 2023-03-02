using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MuscleMatrix.Core.Contract;
using MuscleMatrix.Core.Domain.RequestModels;

namespace Muscle_Matrix.Controllers
{
    [Route("api/")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;
        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpPost("location")]
        public async Task<IActionResult> AddLocation(LocationRequestModel locationRequestModel)
        {
            var addLocation = await _locationService.AddLocationAsync(locationRequestModel);

            return Ok(addLocation);

        }

        [HttpGet("location")]
        public async Task<IActionResult> GetLocation()
        {
            var getLocation = await _locationService.GetLocationAsync();
            return Ok(getLocation);
        }

        [HttpDelete("location")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            var deleteLocation = await _locationService.DeleteLocationAsync(id);

            return Ok(deleteLocation);
        }

        [HttpPut("location")]
        public async Task<IActionResult> UpdateLocation(LocationRequestModel LocationRequestModel)
        {
            var updateLocation = await _locationService.UpdateLocationAsync(LocationRequestModel);

            return Ok(updateLocation);
        }
    }
}
