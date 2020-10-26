using System;
using TestDbPerformanceDB.Repositories;

namespace TestDbPerformanceDB
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private const string connectionString =
            "Server=LAPTOP-6SLD6J3M\\KAC_DATA;Database=Northwind;Trusted_Connection=True;";

        public IRepository CreateORMRepository()
            => BaseCreateRepository<ORMNorthwindRepository>();

        public IRepository CreateDappeRepository()
            => BaseCreateRepository<DapperRepository>();

        public IRepository CreateAdoRepository()
            => BaseCreateRepository<AdoRepository>();

        public IRepository CreateEFCompiledRepository()
            => BaseCreateRepository<EfCompiledQueryRepository>();

        public IRepository CreateRawSQLRepository()
            => BaseCreateRepository<RawSQLRepository>();

        private IRepository BaseCreateRepository<T>()
            where T : BaseRepository
            => Activator.CreateInstance(typeof(T), connectionString) as IRepository;
    }
}
