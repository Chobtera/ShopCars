using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopCars.Web.Models;
using ShopCars.Web.Services;
using ShopCars.Web.Services.Contracts;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ShopCars.Web.Controllers
{
    public class HomeController : Controller
    {
        public string Json = string.Empty;
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

        [HttpGet("signout")]
        public async Task<IActionResult> Signout()
        {
            return SignOut("Cookies", "oidc");
        }
        
        [HttpGet("callapi")]
        public async Task<IActionResult> CallApi()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            var content = await client.GetStringAsync("https://localhost:5010/api/Car");

            var parsed = JsonDocument.Parse(content);
            var formatted = JsonSerializer.Serialize(parsed, new JsonSerializerOptions { WriteIndented = true });

            Json = formatted;
            return View(Json);
        }

    }
}