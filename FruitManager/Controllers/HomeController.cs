using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FruitManager.Models;
using FruitManager.Application.Abstraction;
using AutoMapper;
using FruitManager.Application.Abstraction.Model;

namespace FruitManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IFruitManager fruitManager;
        private readonly IMapper mapper;

        public HomeController(ILogger<HomeController> logger, IFruitManager fruitManager, IMapper mapper)
        {
            this.logger = logger;
            this.fruitManager = fruitManager;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var fruits = fruitManager.GetFruits();
            return View(mapper.Map<IEnumerable<FruitModel>,IEnumerable<FruitViewModel>>(fruits));
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
