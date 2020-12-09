using System.Collections.Generic;
using System;
namespace BouquetEngine.Model
{
    public class Order
    {
        public Guid Id { get; set; }
        public List<Bouquet> Bouquets { get; set; }
        public DateTime OrderDateCreated { get; set; }



    }
}