using ShopCars.Web.Models;

namespace ShopCars.Web.Services.Contracts
{
    public interface ICarService
    {
        Task<IEnumerable<CarViewModel>> GetAllCars();
        Task<CarViewModel> FindCarById(int id);
        Task<CarViewModel> CreateCar(CarViewModel carDTO, string accessToken);
        Task<CarViewModel> UpdateCar(CarViewModel carDTO, string accessToken);
        Task<bool> DeleteCarById(int id, string accessToken);
    }
}
