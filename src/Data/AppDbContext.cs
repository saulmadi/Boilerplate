using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Data
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(string connectionString) : base(connectionString)
        {
        }

        public new Task SaveChanges()
        {
            return SaveChangesAsync();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var entityTypes =
                typeof(Entity).Assembly.GetTypes()
                    .Where(type => typeof(Entity).IsAssignableFrom(type) && !type.IsAbstract);

            foreach (var entityType in entityTypes)
                modelBuilder.RegisterEntityType(entityType);


            base.OnModelCreating(modelBuilder);
        }
    }
}