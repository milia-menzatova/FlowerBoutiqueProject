using System;
using System.Collections.Generic;
using BouquetEngine.Model;
using Npgsql;

namespace BouquetEngine.Storage
{
    public class BouquetDBStorage : IBouquetStorage
    {
        private readonly NpgsqlConnection _connection;
        public BouquetDBStorage(NpgsqlConnection connection)
        {
            _connection = connection;
        }
        public List<Bouquet> GetAll()
        {
            var bouquets = new List<Bouquet>();
            using (var cmd = new NpgsqlCommand(@"SELECT * FROM bouquets", _connection))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var bouquet = readBouquet(reader);
                        bouquets.Add(bouquet);
                    }
                }
            }
            return bouquets;
        }

        public Bouquet FindById(string bouquetId)
        {
            using (var cmd = new NpgsqlCommand("SELECT * FROM bouquets WHERE id = @a", _connection))
            {
                cmd.Parameters.AddWithValue("a", Guid.Parse(bouquetId));
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return readBouquet(reader);
                    }
                    return null;
                }
            }
        }

        private Bouquet readBouquet(NpgsqlDataReader reader)
        {
            return new Bouquet()
            {
                Id = Guid.Parse(Convert.ToString(reader["id"])),
                Name = Convert.ToString(reader["name"]),
                Price = Convert.ToDouble(reader["price"]),
                Description = Convert.ToString(reader["description"]),
                PictureUrl = Convert.ToString(reader["picture_url"])
            };
        }



    }
}