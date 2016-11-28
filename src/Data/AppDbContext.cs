using System.Data.Entity;
using Domain.Entities;

namespace Data
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(string connectionString) :base (connectionString)
        {
            
        }
        public DbSet<Test> Tests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}