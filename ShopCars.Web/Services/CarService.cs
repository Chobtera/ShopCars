using ShopCars.Web.Models;
using ShopCars.Web.Services.Contracts;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ShopCars.Web.Services
{
    public class CarService : ICarService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly JsonSerializerOptions _options;
        private const string apiEndPoint = "/api/car/";
        private CarViewModel carDTO;
        private IEnumerable<CarViewModel> carsDTO;

        public CarService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<IEnumerable<CarViewModel>> GetAllCars()
        {
            var client = _clientFactory.CreateClient("CarsApi");

            using (var response = await client.GetAsync(apiEndPoint))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    carsDTO = await JsonSerializer.DeserializeAsync<IEnumerable<CarViewModel>>(apiResponse, _options);
                }
                else
                {
                    return null;
                }
            }
            return carsDTO;
        }

        public async Task<CarViewModel> FindCarById(int id)
        {
            var client = _clientFactory.CreateClient("CarsApi");

            using (var response = await client.GetAsync(apiEndPoint + id))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    carDTO = await JsonSerializer.DeserializeAsync<CarViewModel>(apiResponse, _options);
                }
                else
                {
                    return null;
                }
            }
            return carDTO;

        }

        public async Task<CarViewModel> CreateCar(CarViewModel car)
        {
            var client = _clientFactory.CreateClient("CarsApi");

            StringContent content = new StringContent(JsonSerializer.Serialize(car), Encoding.UTF8, "application/json");
        
            using (var response = await client.PostAsync(apiEndPoint, content))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    carDTO = await JsonSerializer.DeserializeAsync<CarViewModel>(apiResponse, _options);
                }
                else
                {
                    return null;
                }
            }
            return carDTO;
        }

        public async Task<CarViewModel> UpdateCar(CarViewModel car)
        {
            var client = _clientFactory.CreateClient("CarsApi");

            CarViewModel carUpdated = new CarViewModel();

            using (var response = await client.PutAsJsonAsync(apiEndPoint, car))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    carUpdated = await JsonSerializer
                                      .DeserializeAsync<CarViewModel>(apiResponse, _options);
                }
                else
                {
                    return null;
                    //throw new HttpRequestException(response.ReasonPhrase);
                }
            }
            return carUpdated;
        }

        public async Task<bool> DeleteCarById(int id)
        {
            var client = _clientFactory.CreateClient("CarsApi");

            using (var response = await client.DeleteAsync(apiEndPoint + id))
            {
                if (response.IsSuccessStatusCode)
                {
                    //var apiResponse = await response.Content.ReadAsStreamAsync();
                    return true;
                }
            }
            return false;
        }
    }
}
