using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MuscleMatrix.Core.Contract;
using MuscleMatrix.Core.Domain.RequestModels;

namespace Muscle_Matrix.Controllers
{
    [Route("api/")]
    [ApiController]
    public class MemberTrainerController : ControllerBase
    {
        private readonly IMemberTrainerService _memberTrainerService;

        public MemberTrainerController(IMemberTrainerService memberTrainerService)
        {
            _memberTrainerService = memberTrainerService;
        }

        [HttpGet("member-trainers")]
        public async Task<IActionResult> GetMemberTrainer() 
        {
            var getMemberTrainer = await _memberTrainerService.GetMemberTrainersAsync();

            return Ok(getMemberTrainer);
        }
        [HttpPost("member-trainer")]
        public async Task<IActionResult> AddMemberTrainer(MemberTrainerRequestModel memberTrainerRequestModel)
        {
            var addMemberTrainer = await _memberTrainerService.AddMemberTrainerAsync(memberTrainerRequestModel);

            return Ok(addMemberTrainer);

        }
    }
}
