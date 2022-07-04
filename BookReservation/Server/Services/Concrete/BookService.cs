using AutoMapper;
using BookReservation.Data.Context;
using BookReservation.Data.Entities;
using BookReservation.Server.Services.Abstract;
using BookReservation.Shared.Dtos;

namespace BookReservation.Server.Services.Concrete
{
    public class BookService : BaseService<Book>,IBookService
    {
        private readonly ReservationDbContext reservationDbContext;

        public BookService(ReservationDbContext reservationDbContext) : base(reservationDbContext)  
        {
            this.reservationDbContext = reservationDbContext;
        }
    }
}
