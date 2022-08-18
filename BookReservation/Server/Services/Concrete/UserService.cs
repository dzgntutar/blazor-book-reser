using AutoMapper;
using BookReservation.Data.Context;
using BookReservation.Data.Entities;
using BookReservation.Server.Services.Abstract;
using BookReservation.Shared.Dtos;

namespace BookReservation.Server.Services.Concrete
{
    public class UserService: BaseService<User> ,IUserService
    {

        public UserService(ReservationDbContext reservationDbContext, IMapper mapper) : base(reservationDbContext)
        {
            base.mapper = mapper;
        }
    }
}
