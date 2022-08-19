using AutoMapper;
using BookReservation.Data.Context;
using BookReservation.Data.Entities;
using BookReservation.Server.Services.Abstract;
using Microsoft.EntityFrameworkCore;

using System.Linq.Expressions;

namespace BookReservation.Server.Services.Concrete
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ReservationDbContext reservationDbContext;
        public IMapper mapper;

        public Repository(ReservationDbContext reservationDbContext)
        {
            this.reservationDbContext = reservationDbContext;
        }

        public async Task<D> Create<D>(T entity)
        {
            await reservationDbContext.Set<T>().AddAsync(entity);
            await reservationDbContext.SaveChangesAsync();

            return mapper.Map<T,D>(entity);
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<D>> Where<D>(Expression<Func<T,bool>> predicate = null)
        {
            var resultList =  predicate != null ? await reservationDbContext.Set<T>().Where(predicate).ToListAsync() : await reservationDbContext.Set<T>().ToListAsync();

            return mapper.Map<List<T>, List<D>>(resultList);
        }

        public async Task<List<D>> GetAll<D>()
        {
            var resultList =  await reservationDbContext.Set<T>().Where(s => s.IsActive).ToListAsync();
            return mapper.Map<List<T>, List<D>>(resultList);
        }

        public async Task<D> GetSingle<D>(int Id)
        {
            var entity =  await reservationDbContext.Set<T>().Where(s => s.Id == Id).FirstOrDefaultAsync();
            return mapper.Map<T, D>(entity);
        }

        public Task<D> Update<D>(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
