using System.ComponentModel.DataAnnotations;

namespace ShopCars.Cars.Models
{
    public class Car
    {
        public int CarId { get; set; }
        [StringLength(150)]
        public string? CarName { get; set; }
        [StringLength(255)]
        public string? CarDescription { get; set; }
        [StringLength(255)]
        public string? ImageUrl { get; set; }
        [Range(1,10000000)]
        public double Price { get; set; }
        [Range(1,100)]
        public int Stock { get; set; }

        public int BrandId { get; set; }
        public Brand? Brand { get; set; }
    }
}
