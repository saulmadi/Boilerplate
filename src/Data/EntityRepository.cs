using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Domain.Services;

namespace Data
{
    public class EntityRepository : IRepository
    {
        private readonly IAppDbContext _appDbContext;

        public EntityRepository(IAppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<TEntity> Create<TEntity>(TEntity entity) where TEntity : class
        {
            _appDbContext.Set<TEntity>().Add(entity);

            await _appDbContext.SaveChanges();

            return entity;
        }

        public async Task<IEnumerable<TEntity>> GetAll<TEntity>() where TEntity : class
        {
            return await _appDbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetById<TEntity>(object id) where TEntity : class
        {
            var findAsync = await _appDbContext.Set<TEntity>().FindAsync(id);
            if (findAsync != null) return findAsync;

            throw new EntityNotFoundException(string.Format("The entity with Id: {0} was not found", id));
        }

        public Task Update<TEntity>(TEntity entity) where TEntity : class
        {
            return _appDbContext.SaveChanges();
        }
    }
}