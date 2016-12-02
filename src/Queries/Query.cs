using System.Data;
using Dapper;
using Domain.Entities;

namespace Queries
{
    public class Query
    {
        private readonly IDbConnection _dbConnection;

        public Query(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public void QueryTo()
        {
            
            
        }
    }
}