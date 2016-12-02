using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public interface IRepository
    {
        Task<TEntity> Create<TEntity>(TEntity entity) where TEntity : class;
        Task<IEnumerable<TEntity>> GetAll<TEntity>() where TEntity : class;
        Task<TEntity> GetById<TEntity>(object id) where TEntity : class;
        Task Update<TEntity>(TEntity entity) where TEntity : class;
    }
}