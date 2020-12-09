using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using BouquetMvc.Models;
using BouquetEngine.Model;
using BouquetEngine.Storage;
using BouquetMvc.Servises;


namespace BouquetMvc.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderStorage _orderStorage;
        private readonly SessionCartStorage _sessionCartStorage;

        public OrderController(IOrderStorage orderStorage, SessionCartStorage sessionCartStorage)
        {
            _orderStorage = orderStorage;
            _sessionCartStorage = sessionCartStorage;
        }

        [HttpPost]
        public IActionResult PlaceOrder()
        {
            ISession session = HttpContext.Session;
            CartViewModel cart = this._sessionCartStorage.GetCartFromSession(session);
            Order order = new Order();
            order.Id = Guid.NewGuid();
            order.OrderDateCreated = new DateTime();
            order.Bouquets = cart.items;
            _orderStorage.AddOrder(order);

            OrderViewModel viewModel = new OrderViewModel();
            viewModel.orderNumber = order.Id.ToString();
            _sessionCartStorage.RemoveCartFromSession(session);
            return View("Index", viewModel);
        }

    }
}