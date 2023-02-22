using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MuscleMatrix.Core.Contract;
using MuscleMatrix.Core.Domain.RequestModels;

namespace Muscle_Matrix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MuscleMatrixUserController : ControllerBase
    {
        private readonly IUserService _userService;
        public MuscleMatrixUserController(IUserService muscleMatrixUserService)
        {
            _userService = muscleMatrixUserService;
        }

        [HttpPost("Add-User")]
        public async Task<IActionResult> AddUser(UserRequestModel userRequestModel)
        {
            var addUser = await _userService.AddUserAsync(userRequestModel);

            return Ok(userRequestModel);

        }

        [HttpGet("Get-Users")]
        public async Task<IActionResult> GetUser()
        {
            var getUser = await _userService.GetUserAsync();
            return Ok(getUser);
        }

        [HttpDelete("Delete-User")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var deleteUser = await _userService.DeleteUserAsync(id);

            return Ok(deleteUser);
        }

        [HttpPut("Update-User")]
        public async Task<IActionResult> UpdateUser(UserRequestModel userRequestModel)
        {
            var updateUser =await _userService.UpdateUserAsync(userRequestModel);

            return Ok(updateUser);
        }
    }
}
