using System.Collections.Generic;
using System.Linq;
using Core;
using Dapper;
using Microsoft.Data.SqlClient;

namespace TestDbPerformanceDB.Repositories
{
    public class DapperRepository : BaseRepository, IRepository
    {
        public DapperRepository(string connectionString) : base(connectionString)
        {
        }

        public IEnumerable<OrderDetails> GetOrderDetails()
        {
            var sql = "SELECT * FROM dbo.[Order Details]";

            using var connection = new SqlConnection(ConnectionString);
            return connection.Query<OrderDetails>(sql).ToList();
        }
    }
}
