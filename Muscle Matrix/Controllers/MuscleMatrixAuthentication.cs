using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MuscleMatrix.Core.Domain.RequestModels;
using MuscleMatrix.Infrastructure.Contract;
using MuscleMatrix.Infrastructure.Domain.Context;
using MuscleMatrix.Infrastructure.Domain.Entities;
using MuscleMatrix.Infrastructure.Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Muscle_Matrix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MuscleMatrixAuthentication : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IAuthenticateRepository _authenticateRepository;


        public MuscleMatrixAuthentication(IConfiguration config, IAuthenticateRepository authenticateRepository)
        {
            _config = config;
            _authenticateRepository = authenticateRepository;
      
        }
        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] string userLogin)
        {
            var user = await _authenticateRepository.Authorization(userLogin);
            if (user != null)
            {
                var token =await GenerateToken(userLogin);
                return Ok(token);
            }

            return Ok(user);
        }

        [NonAction]
        public async Task<string> GenerateToken(string userLogin)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var userRoles = await _authenticateRepository.GetUserByEmail(userLogin);


            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email,userLogin),
            };
            foreach (var item in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, item.Role.Name));
            }

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(90),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
      

    }
}
