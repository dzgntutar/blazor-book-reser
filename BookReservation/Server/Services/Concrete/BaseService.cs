using BookReservation.Data.Context;
using BookReservation.Data.Entities;
using BookReservation.Server.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;
using AutoMapper;
using BookReservation.Shared.Dtos;
using System.Linq.Expressions;

namespace BookReservation.Server.Services.Concrete
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        private readonly ReservationDbContext reservationDbContext;

        public BaseService(ReservationDbContext reservationDbContext )
        {
            this.reservationDbContext = reservationDbContext;
        }

        public async Task<T> Create(T entity)
        {
            await reservationDbContext.Set<T>().AddAsync(entity);
            await reservationDbContext.SaveChangesAsync();

            return entity;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> Where(Expression<Func<T,bool>> predicate = null)
        {
            return  predicate != null ? await reservationDbContext.Set<T>().Where(predicate).ToListAsync() : await reservationDbContext.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetAll()
        {
            return await reservationDbContext.Set<T>().Where(s => s.IsActive).ToListAsync();
        }

        public async Task<T> GetSingle(int Id)
        {
            return await reservationDbContext.Set<T>().Where(s => s.Id == Id).FirstOrDefaultAsync();
        }

        public Task<T> Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
