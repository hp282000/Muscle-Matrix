using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MuscleMatrix.Core.Contract;
using MuscleMatrix.Core.Domain.RequestModels;
using MuscleMatrix.Core.Service;

namespace Muscle_Matrix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipController : ControllerBase
    {
        private readonly IMembershipService _membershipService;

        public MembershipController(IMembershipService membershipService)
        {
            _membershipService = membershipService;
        }

        [HttpPost("membership")]
        public async Task<IActionResult> AddMembership([FromForm] MembershipRequestModel membershipRequestModel)
        {
            await _membershipService.AddMembershipAsync(membershipRequestModel);

            return Ok(membershipRequestModel);
        }
        [HttpGet("memberships")]
        public async Task<IActionResult> GetMemberships()
        {
            var getMemberships = await _membershipService.GetMembershipAsync();

            return Ok(getMemberships);
        }

        [HttpDelete("membership")]
        public async Task<IActionResult> DeleteMemberhip(int id)
        {
            var deleteMembership = await _membershipService.DeleteMembershipAsync(id);

            return Ok(deleteMembership);
        }

        [HttpPut("membership")]
        public async Task<IActionResult> UpdateMemberhip([FromForm] MembershipRequestModel membershipRequestModel, int id)
        {
            var updateMembership = await _membershipService.UpdateMembershipAsync(membershipRequestModel, id);

            return Ok(updateMembership);
        }

    }
}
