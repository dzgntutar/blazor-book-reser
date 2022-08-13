using AutoMapper;
using BookReservation.Data.Entities;
using BookReservation.Server.Services.Abstract;
using System.Linq.Expressions;

namespace BookReservation.Server.Services
{
    public class ServiceManager<T,D> where T : BaseEntity
    {
        private readonly IBaseService<T> baseService;
        private readonly IMapper mapper;

        public ServiceManager(IBaseService<T> baseService, IMapper mapper)
        {
            this.baseService = baseService;
            this.mapper = mapper;
        }
        

        public async Task<List<T>> GetAll()
        {
            List<T> data = await baseService.GetAll();

            return mapper.Map<List<T>,List<T>>(data);
        }

        public async Task<D> GetSingle(int id)
        {
            var data = await baseService.GetSingle(id);

            return mapper.Map<T, D>(data);
        }

        public async Task<List<D>> Where(Expression<Func<T, bool>> predicate)
        {
            var data = await baseService.Where(predicate);

            return mapper.Map<List<T>, List<D>>(data);
        }

        //public Task<T> Create(T entity)
        //{

        //}

        //public Task<T> Update(T entity)
        //{

        //}

        //public Task Delete(int id)
        //{

        //}
    }
}
