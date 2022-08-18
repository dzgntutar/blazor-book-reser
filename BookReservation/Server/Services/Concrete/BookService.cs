using AutoMapper;
using BookReservation.Data.Context;
using BookReservation.Data.Entities;
using BookReservation.Server.Services.Abstract;
using BookReservation.Shared.Dtos;
using BookReservation.Shared.Dtos.User;

namespace BookReservation.Server.Services.Concrete
{
    public class BookService : BaseService<Book>, IBookService
    {
        private readonly ReservationDbContext reservationDbContext;

        public BookService(ReservationDbContext reservationDbContext) : base(reservationDbContext)
        {
            this.reservationDbContext = reservationDbContext;
        }

        public User UserGetByUserNameAndPass(string email, string password)
        {
            var user = reservationDbContext.Set<User>().FirstOrDefault(s => s.Email.Equals(email) && s.Password.Equals(password));
            return user;
        }
    }
}
