using BookReservation.Data.Entities;
using BookReservation.Shared.Dtos.User;

namespace BookReservation.Server.Services.Abstract
{
    public interface IBookService : IBaseService<Book>
    {
        public User UserGetByUserNameAndPass(string email,string password);
    }
}
