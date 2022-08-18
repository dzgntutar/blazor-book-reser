using AutoMapper;
using BookReservation.Server.Services.Abstract;
using BookReservation.Shared.Dtos;
using BookReservation.Shared.Dtos.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookReservation.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.GetAll<UserGetAllDto>();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetSingle<UserGetByIdDto>(id);
            return Ok(user);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            var users = await _userService.Where<UserGetAllDto>(s => s.Email == userLoginDto.Email && s.Password == userLoginDto.Password && s.IsActive);

            if (users?.Count > 0)
            {
                var user = users[0];
                UserLoginResponseDTO result = new UserLoginResponseDTO();

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secretkey_duzgun_tutar_test_token"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var expiry = DateTime.Now.AddDays(1);
                var claims = new[]
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Name, user.FirstName),
                    new Claim(ClaimTypes.UserData, user.Id.ToString())
                    
                };
                var token = new JwtSecurityToken("AAA", "AAA", claims, null, expiry, creds);

                result.ApiToken = new JwtSecurityTokenHandler().WriteToken(token);
                result.User = user;

                return Ok(result);

            }
            else
                return BadRequest();
        }
    }
}
