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
    public class CartController : Controller
    {
        private readonly IBouquetStorage _bouquetStorage;
        private readonly SessionCartStorage _sessionCartStorage;
        public CartController(IBouquetStorage bouquetStorage, SessionCartStorage sessionCartStorage)
        {
            _bouquetStorage = bouquetStorage;
            _sessionCartStorage = sessionCartStorage;
        }

        public IActionResult Index()
        {
            ISession session = HttpContext.Session;
            CartViewModel cart = this._sessionCartStorage.GetCartFromSession(session);
            return View(cart);
        }

        [HttpPost]
        public IActionResult AddToCart(string bouquetId)
        {
            ISession session = HttpContext.Session;
            Bouquet bouquet = _bouquetStorage.FindById(bouquetId);
            _sessionCartStorage.AddToSessionCart(session, bouquet);
            return RedirectToAction("Index", "Cart");
        }
        public IActionResult RemoveBouquet(string bouquetId)
        {
            ISession session = HttpContext.Session;
            Bouquet bouquet = _bouquetStorage.FindById(bouquetId);
            _sessionCartStorage.RemoveItemFromSessionCart(session, bouquet);
            return RedirectToAction("Index", "Cart");
        }
    }
}