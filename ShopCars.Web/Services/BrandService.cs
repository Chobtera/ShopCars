using ShopCars.Web.Models;
using ShopCars.Web.Services.Contracts;
using System.Net.Http.Headers;
using System.Text.Json;

namespace ShopCars.Web.Services
{
    public class BrandService : IBrandService
    {
        private readonly IHttpClientFactory? _clientFactory;
        private readonly JsonSerializerOptions _options;
        private const string apiEndpoint = "/api/brand/";

        public BrandService(IHttpClientFactory? clientFactory)
        {
            _clientFactory = clientFactory;
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<IEnumerable<BrandViewModel>> GetAllBrands()
        {
            var client = _clientFactory.CreateClient("CarsApi");

            IEnumerable<BrandViewModel> brands;

            using (var response = await client.GetAsync(apiEndpoint))
            {

                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();
                    brands = await JsonSerializer
                              .DeserializeAsync<IEnumerable<BrandViewModel>>(apiResponse, _options);
                }
                else
                {
                    throw new HttpRequestException(response.ReasonPhrase);
                }
            }
            return brands;
        }
    }
}
