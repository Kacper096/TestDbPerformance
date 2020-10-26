using System.Collections.Generic;
using Core;
using Microsoft.Data.SqlClient;

namespace TestDbPerformanceDB.Repositories
{
    public class AdoRepository : BaseRepository, IRepository
    {
        public AdoRepository(string connectionString) : base(connectionString)
        {
        }

        public IEnumerable<OrderDetails> GetOrderDetails()
        {
            IList<OrderDetails> list = new List<OrderDetails>();
            const string sql = "SELECT * FROM dbo.[Order Details]";
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(sql, connection);
                connection.Open();

                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new OrderDetails()
                    {
                        OrderId = (int)reader.GetValue(reader.GetOrdinal(nameof(OrderDetails.OrderId))),
                        ProductId = (int)reader.GetValue(reader.GetOrdinal(nameof(OrderDetails.ProductId))),
                        UnitPrice = (decimal)reader.GetValue(reader.GetOrdinal(nameof(OrderDetails.UnitPrice))),
                        Quantity = (short)reader.GetValue(reader.GetOrdinal(nameof(OrderDetails.Quantity))),
                        Discount = (float)reader.GetValue(reader.GetOrdinal(nameof(OrderDetails.Discount)))
                    });
                }

                reader.Close();
            }

            return list;
        }
    }
}
