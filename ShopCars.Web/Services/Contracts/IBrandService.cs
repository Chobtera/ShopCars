using ShopCars.Web.Models;

namespace ShopCars.Web.Services.Contracts
{
    public interface IBrandService
    {
        Task<IEnumerable<BrandViewModel>> GetAllBrands();
    }
}
