using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Core;
using TestDbPerformanceDB;
using TestDbPerformanceDB.Repositories;

namespace TestDbPerformance
{
    public class PerformanceService
    {
        private const string title = "Test wydajności";
        private readonly IRepositoryFactory _repositoryFactory;
        private readonly List<KeyValuePair<string, IRepository>> _list;

        public PerformanceService()
        {
            _repositoryFactory = new RepositoryFactory();
            _list = ConfigureList();
        }

        public void Test()
        {
            foreach (var titleWithRepo in _list)
            {
                Console.WriteLine(titleWithRepo.Key);
                var watch = System.Diagnostics.Stopwatch.StartNew();

                var orderDetails = titleWithRepo.Value.GetOrderDetails();
                var count = orderDetails.Count();
                using var streamWriter = File.CreateText($"./Test_{titleWithRepo.Value.GetType().Name}_{Guid.NewGuid()}.txt");
                WriteOrderDetails(streamWriter, orderDetails);

                watch.Stop();
                Console.WriteLine($" Czas odczytu danych i zapis do pliku w ilości: {count} wynosi: {watch.ElapsedMilliseconds} milisekund.");
                Console.WriteLine();
            }
        }

        private List<KeyValuePair<string, IRepository>> ConfigureList()
        {
            return new List<KeyValuePair<string, IRepository>>()
            {
                new KeyValuePair<string, IRepository>($"{title} ADO", _repositoryFactory.CreateAdoRepository()),
                new KeyValuePair<string, IRepository>($"{title} Dapper", _repositoryFactory.CreateDappeRepository()),
                new KeyValuePair<string, IRepository>($"{title} Raw SQL EF Core", _repositoryFactory.CreateRawSQLRepository()),
                new KeyValuePair<string, IRepository>($"{title} Compiled query EF Core", _repositoryFactory.CreateEFCompiledRepository()),
                new KeyValuePair<string, IRepository>($"{title} ORM EF Core", _repositoryFactory.CreateORMRepository()),
            };
        }

        private void WriteOrderDetails(StreamWriter writer, IEnumerable<OrderDetails> orderDetails)
        {
            foreach (var orderDetail in orderDetails)
            {
                writer.WriteLine(orderDetail.ToString());
            }
        }
    }
}
