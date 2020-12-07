using System.Collections.Generic;
using BouquetEngine.Model;
namespace BouquetEngine.Storage
{
    public interface IBouquetStorage
    {
        List<Bouquet> GetAll();
        Bouquet FindById(string bouquetId);
    }
}