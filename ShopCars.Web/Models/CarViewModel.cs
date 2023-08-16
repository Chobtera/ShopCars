using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ShopCars.Web.Models
{
    public class CarViewModel
    {
        public int CarId { get; set; }
        public string? CarName { get; set; }
        public string? CarDescription { get; set; }
        [Display(Name = "Image Url")]
        public string? ImageUrl { get; set; }
        public double Price { get; set; }
        [Display(Name = "Brand")]
        public int BrandId { get; set; }
    }
}
