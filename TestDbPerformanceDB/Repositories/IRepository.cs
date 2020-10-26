using System.Collections.Generic;
using Core;

namespace TestDbPerformanceDB.Repositories
{
    public interface IRepository
    {
        IEnumerable<OrderDetails> GetOrderDetails();
    }
}