namespace ShopCars.Cars.DTO
{
    public class BrandDTO
    {
        public int BrandId { get; set; }
        public string? BrandName { get; set; }
        public ICollection<CarDTO>? Cars{ get; set; }
    }
}
