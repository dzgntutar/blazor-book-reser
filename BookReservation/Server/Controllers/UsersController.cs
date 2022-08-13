using BookReservation.Server.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookReservation.Server.Services;
using AutoMapper;
using BookReservation.Data.Entities;
using BookReservation.Shared.Dtos.User;

namespace BookReservation.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            var manager = new ServiceManager<User, UserGetAllDto>(_userService, _mapper);
            var users = await manager.Where(s => s.Email == userLoginDto.Email && s.Password == userLoginDto.Password && s.IsActive);

            if (users?.Count > 0)
                return Ok(users[0]);
            else
                return BadRequest();
        }
    }
}
