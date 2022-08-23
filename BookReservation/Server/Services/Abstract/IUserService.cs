using BookReservation.Data.Entities;
using BookReservation.Shared.Dtos;
using BookReservation.Shared.Dtos.User;

namespace BookReservation.Server.Services.Abstract
{
    public interface IUserService : IRepository<User>
    {
        Task<GResponse<UserLoginResponseDTO>> Login(UserLoginRequestDto userLoginDto);
    }
}
