using System.Collections.Generic;
using System.Linq;
using Core;
using Microsoft.EntityFrameworkCore;
using TestDbPerformanceDB.Models;

namespace TestDbPerformanceDB.Repositories
{
    public class RawSQLRepository : BaseEFRepository, IRepository
    {
        public RawSQLRepository(string connectionString) : base(connectionString)
        {
        }

        public IEnumerable<OrderDetails> GetOrderDetails()
        {
            using var context = new NorthwindContext(dbContextOptions);
            return context.OrderDetails.FromSqlRaw("SELECT * FROM dbo.[Order Details]").ToList();
        }
    }
}
