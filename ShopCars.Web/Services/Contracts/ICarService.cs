using ShopCars.Web.Models;

namespace ShopCars.Web.Services.Contracts
{
    public interface ICarService
    {
        Task<IEnumerable<CarViewModel>> GetAllCars();
        Task<CarViewModel> FindCarById(int id);
        Task<CarViewModel> CreateCar(CarViewModel carDTO);
        Task<CarViewModel> UpdateCar(CarViewModel carDTO);
        Task<bool> DeleteCarById(int id);
    }
}
