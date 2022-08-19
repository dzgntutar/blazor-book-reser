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
            return Ok(new GResponse<List<UserGetAllDto>>("Success", users));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetSingle<UserGetByIdDto>(id);

            if (user == null)
                return NotFound("User not found");
            else
                return Ok(new GResponse<UserGetByIdDto>("Success", user));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            var serviceResult = await _userService.Login(userLoginDto);
            return serviceResult.IsSucces ? Ok(serviceResult) : BadRequest(serviceResult);
        }
    }
}
