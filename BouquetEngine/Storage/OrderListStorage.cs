using System;
using System.Collections.Generic;
using BouquetEngine.Model;

namespace BouquetEngine.Storage
{
    public class OrderListStorage : IOrderStorage
    {
        private readonly List<Order> _orderList;
        public OrderListStorage()
        {
            _orderList = new List<Order>();
        }
        public void AddOrder(Order order)
        {
            _orderList.Add(order);
        }


    }

}