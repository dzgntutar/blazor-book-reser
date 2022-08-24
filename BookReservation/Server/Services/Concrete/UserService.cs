using AutoMapper;
using BookReservation.Data.Context;
using BookReservation.Data.Entities;
using BookReservation.Server.Services.Abstract;
using BookReservation.Shared.Dtos;
using BookReservation.Shared.Dtos.User;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookReservation.Server.Services.Concrete
{
    public class UserService : Repository<User>, IUserService
    {

        public UserService(ReservationDbContext reservationDbContext, IMapper mapper) : base(reservationDbContext)
        {
            base.mapper = mapper;
        }

        public async Task<UserLoginResponseDTO> Login(UserLoginRequestDto userLoginDto)
        {
            var users = await this.Where<UserGetAllResponseDto>(s => s.Email == userLoginDto.Email && s.Password == userLoginDto.Password && s.IsActive);

            if (users == null || users.Count == 0)
                throw new Exception("User not found");


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

            return  result;
        }
    }
}
