using BouquetEngine.Model;

namespace BouquetEngine.Storage
{
    public interface IOrderStorage
    {
        public void AddOrder(Order order);
    }
}