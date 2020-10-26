using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core;
using Microsoft.EntityFrameworkCore;
using TestDbPerformanceDB.Models;

namespace TestDbPerformanceDB.Repositories
{
    public class EfCompiledQueryRepository : BaseEFRepository, IRepository
    {
        public EfCompiledQueryRepository(string connectionString) : base(connectionString)
        {
        }

        public IEnumerable<OrderDetails> GetOrderDetails()
        {
            using var context = new NorthwindContext(dbContextOptions);
            return CompiledQuery().Invoke(context);
        }

        private Func<NorthwindContext, IEnumerable<OrderDetails>> CompiledQuery()
            => EF.CompileQuery((NorthwindContext context) =>
                context.OrderDetails.ToList());
    }
}
