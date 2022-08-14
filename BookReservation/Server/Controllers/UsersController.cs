using BookReservation.Server.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookReservation.Server.Services;
using AutoMapper;
using BookReservation.Data.Entities;
using BookReservation.Shared.Dtos.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace BookReservation.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var manager = new ServiceManager<User, UserGetAllDto>(_userService, _mapper);
            var users = await manager.GetAll();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var manager = new ServiceManager<User, UserGetByIdDto>(_userService, _mapper);
            var user = await manager.GetSingle(id);

            return Ok(user);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            var manager = new ServiceManager<User, UserGetAllDto>(_userService, _mapper);
            var users = await manager.Where(s => s.Email == userLoginDto.Email && s.Password == userLoginDto.Password && s.IsActive);

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
