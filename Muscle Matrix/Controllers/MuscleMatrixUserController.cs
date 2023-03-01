using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MuscleMatrix.Core.Contract;
using MuscleMatrix.Core.Domain.RequestModels;

namespace Muscle_Matrix.Controllers
{
   // [Authorize(Roles = "Admin")]
    [Route("api/")] 
    [ApiController]
    public class MuscleMatrixUserController : ControllerBase
    {
        private readonly IUserService _userService;
        public MuscleMatrixUserController(IUserService muscleMatrixUserService)
        {
            _userService = muscleMatrixUserService;
        }

        [HttpPost("user-login")]

         public async Task<IActionResult> UserCheckLogin(UserLogin userLogin)
        {
            try
            {
            var checkLogin = await _userService.UserLoginAsync(userLogin);

            if (checkLogin == null)
            {
                return BadRequest("User Not Found");
            }
            else
                return Ok(checkLogin);

            }
            catch (Exception)
            {

                throw new Exception("User Not Found");
            }
        }


        
        [HttpPost("user")]
        public async Task<IActionResult> AddUser(UserRequestModel userRequestModel)
        {
             await _userService.AddUserAsync(userRequestModel);

            return Ok(userRequestModel);

        }

        [HttpGet("users")]
        public async Task<IActionResult> GetUser()
        {
            var getUser = await _userService.GetUserAsync();
            return Ok(getUser);
        }

        [HttpDelete("user")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var deleteUser = await _userService.DeleteUserAsync(id);

            return Ok(deleteUser);
        }

        [HttpPut("user")]
        public async Task<IActionResult> UpdateUser(UserRequestModel userRequestModel)
        {
            var updateUser =await _userService.UpdateUserAsync(userRequestModel);

            return Ok(updateUser);
        }
    }
}
