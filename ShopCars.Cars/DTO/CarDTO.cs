using System.Text.Json.Serialization;

namespace ShopCars.Cars.DTO
{
    public class CarDTO
    {
        public int CarId { get; set; }
        public string? CarName { get; set; }
        public string? CarDescription { get; set; }
        public string? ImageUrl { get; set; }
        public double Price { get; set; }
        public int BrandId { get; set; }
        [JsonIgnore]
        public BrandDTO? Brand { get; set; }
    }
}
