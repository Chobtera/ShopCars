using System.ComponentModel.DataAnnotations;

namespace ShopCars.Cars.Models
{
    public class Brand
    {
        public int BrandId { get; set; }
        [StringLength(50)]
        public string? BrandName { get; set; }
        public ICollection<Car>? Cars{ get; set; }
    }
}
