using BookReservation.Data.Entities;
using System.Linq.Expressions;

namespace BookReservation.Server.Services.Abstract
{
    public interface IBaseService<T> where T : BaseEntity
    {
        public Task<List<T>> GetAll();

        public Task<T> GetSingle(int Id);

        public Task<T> Create(T entity);
                    
        public Task<T> Update(T entity);

        public Task Delete(int id);

        public Task<List<T>> Where(Expression<Func<T, bool>> predicate = null);
    }
}
