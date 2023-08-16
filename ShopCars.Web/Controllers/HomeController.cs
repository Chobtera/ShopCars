using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopCars.Web.Models;
using ShopCars.Web.Services;
using ShopCars.Web.Services.Contracts;
using System.Diagnostics;

namespace ShopCars.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICarService _carService;
        //private readonly IBrandService _brandService;
        public HomeController(ILogger<HomeController> logger,
    ICarService CarService)
        {
            _logger = logger;
            _carService = CarService;
        }

        public async Task<IActionResult> Index()
        {
            var Cars = await _carService.GetAllCars();

            if (Cars is null)
            {
                return View("Error");
            }

            return View(Cars);
        }

        [HttpGet("privacy")]
        public async Task<IActionResult> Privacy()
        {
            return View();
        }
    }
}