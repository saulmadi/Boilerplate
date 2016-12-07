using System;
using System.Data.Entity.Infrastructure;
using Common;

namespace Data
{
    public class DatabaseContextFactory : IDbContextFactory<AppDbContext>
    {
        public AppDbContext Create()
        {
            var connectionString = Configuration.DataBase;
            Console.WriteLine(string.Format("Cadena {0}", connectionString));
            return new AppDbContext(connectionString);
        }
    }
}