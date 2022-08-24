using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookReservation.Data.Context;
using BookReservation.Data.Entities;
using BookReservation.Server.Services.Abstract;
using BookReservation.Shared.Dtos;
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

        public async Task<Res> Create<Req,Res>(Req req)
        {
            T entity = mapper.Map<Req, T>(req);

            entity.CreateDate = DateTime.Now;
            entity.CreateBy = 1;
            entity.IsActive = true;

            await reservationDbContext.Set<T>().AddAsync(entity);
            await reservationDbContext.SaveChangesAsync();

            return mapper.Map<T,Res>(entity);
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await reservationDbContext.Set<T>().FirstOrDefaultAsync(s => s.Id == id);
            if (entity == null)
                return false;

            reservationDbContext.Set<T>().Remove(entity);
            int result = await reservationDbContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<List<D>> Where<D>(Expression<Func<T,bool>> predicate = null) where D : BaseDto
        {
            var resultList =  predicate != null 
                                                ? await reservationDbContext.Set<T>()
                                                                                    .Where(predicate)
                                                                                    .Where(s => s.IsActive)
                                                                                    .ProjectTo<D>(mapper.ConfigurationProvider)
                                                                                    .ToListAsync() 
                                                : await reservationDbContext.Set<T>()
                                                                                    .Where(s => s.IsActive)
                                                                                    .ProjectTo<D>(mapper.ConfigurationProvider)
                                                                                    .ToListAsync();

            return resultList;
        }

        public async Task<List<D>> GetAll<D>()  where D : BaseDto
        {
            var resultList =  await reservationDbContext.Set<T>()
                                                                       .Where(s => s.IsActive)
                                                                       .ProjectTo<D>(mapper.ConfigurationProvider)
                                                                       .ToListAsync();
            return resultList;
        }

        public async Task<D> GetSingle<D>(int Id) where D : BaseDto
        {
            var entity =  await reservationDbContext.Set<T>()
                                                               .Where(s => s.Id == Id)
                                                               .ProjectTo<D>(mapper.ConfigurationProvider)
                                                               .FirstOrDefaultAsync();
            return entity;
        }

        public async Task<Res> Update<Req,Res>(Req req, int Id)
        {
            var entity = await reservationDbContext.Set<T>().FirstOrDefaultAsync(s => s.Id == Id);
            if (entity == null)
                throw new Exception("Entity not found!");

            mapper.Map(req,entity);
            entity.UpdateDate = DateTime.Now;
            entity.UpdateBy = 1;

            await reservationDbContext.SaveChangesAsync();

            return mapper.Map<T, Res>(entity);
        }
    }
}
