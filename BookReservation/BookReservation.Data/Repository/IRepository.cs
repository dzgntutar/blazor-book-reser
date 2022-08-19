using BookReservation.Data.Entities;
using BookReservation.Shared.Dtos;
using System.Linq.Expressions;

namespace BookReservation.Server.Services.Abstract
{
    public interface IRepository<T> where T : BaseEntity
    {
        public Task<List<D>> GetAll<D>() where D : BaseDto;

        public Task<D> GetSingle<D>(int Id) where D : BaseDto;

        public Task<D> Create<D>(T entity);
                    
        public Task<D> Update<D>(T entity);

        public Task Delete(int id);

        public Task<List<D>> Where<D>(Expression<Func<T, bool>> predicate = null) where D : BaseDto;
    }
}
