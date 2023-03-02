using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MuscleMatrix.Core.Contract;
using MuscleMatrix.Core.Domain.RequestModels;
using MuscleMatrix.Core.Service;

namespace Muscle_Matrix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpPost("member")]
        public async Task<IActionResult> AddMember([FromForm]MemberRequestModel memberRequestModel)
        {
            await _memberService.AddMemberAsync(memberRequestModel);

            return Ok(memberRequestModel);
        }
        [HttpGet("members")]
        public async Task<IActionResult> GetMembers()
        {
            var getMembers = await _memberService.GetMemberAsync();

            return Ok(getMembers);
        }

        [HttpDelete("member")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            var deleteMember = await _memberService.DeleteMemberAsync(id);

            return Ok(deleteMember);
        }

        [HttpPut("member")]
        public async Task<IActionResult> UpdateMember(MemberRequestModel memberRequestModel)
        {
            var updateMember = await _memberService.UpdateMemberAsync(memberRequestModel);

            return Ok(updateMember);
        }
    }
}
