using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MuscleMatrix.Core.Contract;
using MuscleMatrix.Core.Domain.RequestModels;

namespace Muscle_Matrix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MuscleMatrixMemberController : ControllerBase
    {
        private readonly IMemberService _memberService;

        public MuscleMatrixMemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpPost]
        public async Task<IActionResult> AddMember(MemberRequestModel memberRequestModel)
        {
            await _memberService.AddMemberAsync(memberRequestModel);

            return Ok(memberRequestModel);
        }
    }
}
