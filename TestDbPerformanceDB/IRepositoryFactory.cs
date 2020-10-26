using TestDbPerformanceDB.Repositories;

namespace TestDbPerformanceDB
{
    public interface IRepositoryFactory
    {
        IRepository CreateORMRepository();
        IRepository CreateDappeRepository();
        IRepository CreateAdoRepository();
        IRepository CreateEFCompiledRepository();
        IRepository CreateRawSQLRepository();
    }
}