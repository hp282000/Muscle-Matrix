using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MuscleMatrix.Core.Contract;
using MuscleMatrix.Core.Domain.RequestModels;
using MuscleMatrix.Core.Service;

namespace Muscle_Matrix.Controllers
{
    [Authorize(Roles ="Trainer , Admin")]
    [Route("api/")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        private readonly ITrainerService _trainerService;

        public TrainerController(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        [HttpPost("trainer")]
        public async Task<IActionResult> AddTrainer([FromForm] TrainerRequestModel trainerRequestModel)
        {
            string image = "hp.jpg";
            await _trainerService.AddTrainerAsync(trainerRequestModel, image);

            return Ok(trainerRequestModel);
        }
        [HttpGet("trainers")]
        public async Task<IActionResult> GetTrainers()
        {
            var getTrainers = await _trainerService.GetTrainerAsync();

            return Ok(getTrainers);
        }
        [HttpDelete("trainer")]
        public async Task<IActionResult> DeleteTrainer(int id)
        {
            var deleteTrainer = await _trainerService.DeleteTrainerAsync(id);

            return Ok(deleteTrainer);
        }
        [HttpPut("trainer")]
        public async Task<IActionResult> UpdateTrainer([FromForm] TrainerRequestModel trainerRequestModel,int id , string image)
        {
            var updateTrainer = await _trainerService.UpdateTrainerAsync(trainerRequestModel,id,image);

            return Ok(updateTrainer);
        }

    }
}