using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FruitManager.Models;
using FruitManager.Application.Abstraction;

namespace FruitManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IFruitManager fruitManager;

        public HomeController(ILogger<HomeController> logger, IFruitManager fruitManager)
        {
            this.logger = logger;
            this.fruitManager = fruitManager;
        }

        public IActionResult Index()
        {
            var fruit = fruitManager.GetFruitByName("Apple");
            return View(new FruitViewModel { Name = fruit.Name, Description = fruit.Description });
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
