using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BouquetMvc.Models;
using BouquetEngine.Storage;
using BouquetEngine.Model;

namespace BouquetMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBouquetStorage _bouquetStorage;

        public HomeController(ILogger<HomeController> logger, IBouquetStorage bouquetStorage)
        {
            _logger = logger;
            _bouquetStorage = bouquetStorage;
        }


        public IActionResult Index()
        {
            List<Bouquet> bouquets = _bouquetStorage.GetAll();
            return View(bouquets);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
