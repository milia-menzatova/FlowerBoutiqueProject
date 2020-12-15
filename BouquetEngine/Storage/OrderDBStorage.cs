using System;
using System.Collections.Generic;
using BouquetEngine.Model;
using Npgsql;

namespace BouquetEngine.Storage
{
    public class OrderDBStorage : IOrderStorage
    {
        private readonly NpgsqlConnection _connection;

        public OrderDBStorage(NpgsqlConnection connection)
        {
            _connection = connection;
        }
        public void AddOrder(Order order)
        {
            using (var transaction = _connection.BeginTransaction())
            {
                using (var cmd = new NpgsqlCommand(
                    @"INSERT INTO orders (id, created_at) VALUES (@a, @b)",
                    _connection))
                {
                    cmd.Parameters.AddWithValue("a", order.Id);
                    cmd.Parameters.AddWithValue("b", order.OrderDateCreated);
                    cmd.ExecuteNonQuery();
                }


                foreach (var bouquet in order.Bouquets)
                {
                    using (var cmd = new NpgsqlCommand(
                        @"INSERT INTO order_bouquets (order_id, bouquet_id) VALUES (@a, @b)",
                        _connection))
                    {
                        cmd.Parameters.AddWithValue("a", order.Id);
                        cmd.Parameters.AddWithValue("b", bouquet.Id);
                        cmd.ExecuteNonQuery();
                    }
                }
                transaction.Commit();
            }
        }
    }

}