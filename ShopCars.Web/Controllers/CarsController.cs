using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopCars.Web.Models;
using ShopCars.Web.Services.Contracts;
using System.Reflection;

namespace ShopCars.Web.Controllers
{
    [Authorize]
    public class CarsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICarService _carService;
        //private readonly IBrandService _brandService;
        public CarsController(ILogger<HomeController> logger,
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

        public async Task<IActionResult> CarCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CarCreate(CarViewModel car)
        {
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            if (ModelState.IsValid)
            {
                var response = await _carService.CreateCar(car, accessToken);
                if (response != null) return RedirectToAction(
                nameof(Index));
            }
            return View(car);
        }

        public async Task<IActionResult> CarUpdate(int id)
        {
            var car = await _carService.FindCarById(id);
            return View(car);
        }

        [HttpPost]
        public async Task<IActionResult> CarUpdate(CarViewModel car)
        {
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            if (ModelState.IsValid)
            {
                var response = await _carService.UpdateCar(car, accessToken);
                if (response != null) return RedirectToAction(
                     nameof(Index));
            }
            return View(car);
        }

        public async Task<IActionResult> CarDelete(int id)
        {
            var car = await _carService.FindCarById(id);
            if (car != null) return View(car);
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CarDelete(CarViewModel car)
        {
            string accessToken = await HttpContext.GetTokenAsync("access_token");
            var response = await _carService.DeleteCarById(car.CarId, accessToken);
            if (response) return RedirectToAction(
                    nameof(Index));
            return View();
        }

    }
}
