using System.Data.Entity;
using System.Threading.Tasks;

namespace Data
{
    public interface IAppDbContext
    {
        Task SaveChanges();

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}