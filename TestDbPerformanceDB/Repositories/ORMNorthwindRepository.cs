using System.Collections.Generic;
using System.Linq;
using Core;
using Microsoft.EntityFrameworkCore;
using TestDbPerformanceDB.Models;

namespace TestDbPerformanceDB.Repositories
{
    public class ORMNorthwindRepository : BaseEFRepository, IRepository
    {
        public ORMNorthwindRepository(string connectionString)
            : base(connectionString)
        {
        }

        public IEnumerable<OrderDetails> GetOrderDetails()
        {
            using var context = new NorthwindContext(dbContextOptions);
            return context.OrderDetails.ToList();
        }
    }
}
