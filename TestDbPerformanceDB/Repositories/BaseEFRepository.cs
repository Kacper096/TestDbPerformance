using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TestDbPerformanceDB.Models;

namespace TestDbPerformanceDB.Repositories
{
    public abstract class BaseEFRepository : BaseRepository
    {
        protected readonly DbContextOptions<NorthwindContext> dbContextOptions;
        protected BaseEFRepository(string connectionString) : base(connectionString)
        {
            dbContextOptions = new DbContextOptionsBuilder<NorthwindContext>().UseSqlServer(ConnectionString).Options;
        }

    }
}
