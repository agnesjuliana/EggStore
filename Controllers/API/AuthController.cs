using EggStore.Domains.Users.Dto;
using EggStore.Infrastucture.Helpers.ResponseBuilders;
using EggStore.Infrastucture.Shareds.Constants;
using EggStore.Infrastucture.Shareds.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EggStore.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly DataContext _context;

        public AuthController(IConfiguration configuration, DataContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Login(AuthUsersDto param)
        {
            var user = await _context.UsersEntities
                .Where(x => x.Username == param.Username)
                .Where(x => x.Password == param.Password)
                .FirstOrDefaultAsync();

            if (user == null)
                return BadRequest(ResponseBuilder.ErrorResponse(400, "nvalid Username or Password", null));

            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Id", user.Id.ToString()),
                        new Claim("Name", user.Name),
                        new Claim("Username", user.Username),
                        new Claim("Email", user.Email),
                        new Claim("Role", user.Role)
             };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: signIn);

            var tokenJwt = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(ResponseBuilder.SuccessResponse("Success Login", tokenJwt));
        }
    }
}
