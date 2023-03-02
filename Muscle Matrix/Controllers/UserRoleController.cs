using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MuscleMatrix.Core.Contract;
using MuscleMatrix.Core.Domain.RequestModels;

namespace Muscle_Matrix.Controllers
{
    [Route("api/")]
    [ApiController]

    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;

        public UserRoleController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }


        [HttpPost("userrole")]
        public async Task<IActionResult> AddUserRole(UserRoleRequestModel userRoleRequestModel)
        {
            var adduserRole = await _userRoleService.AddUserRoleAsync(userRoleRequestModel);

            return Ok(adduserRole);
        }

        [HttpGet("userrole")]
        public async Task<IActionResult> GetUserRole()
        {
            var getUserRole = await _userRoleService.GetUserRoleAsync();

            return Ok(getUserRole);
        }
    }
}
