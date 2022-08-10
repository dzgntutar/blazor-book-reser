using BookReservation.Data.Context;
using BookReservation.Data.Entities;
using BookReservation.Server.Services.Abstract;

namespace BookReservation.Server.Services.Concrete
{
    public class UserService : BaseService<User> , IUserService
    {
        public UserService(ReservationDbContext reservationDbContext) : base(reservationDbContext)
        {
        }
    }
}
