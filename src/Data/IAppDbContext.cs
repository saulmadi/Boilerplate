using System.Data.Entity;
using Domain.Entities;

namespace Data
{
    public interface IAppDbContext
    {
        DbSet<Test> Tests { get; set; }
    }
}