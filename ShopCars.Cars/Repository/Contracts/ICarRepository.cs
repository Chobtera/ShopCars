using Microsoft.AspNetCore.Mvc;
using ShopCars.Cars.DTO;

namespace ShopCars.Cars.Repository.Contracts
{
    public interface ICarRepository
    {
        Task<IEnumerable<CarDTO>> GetAll();
        Task<CarDTO> GetById(int id);
        Task<CarDTO> Create(CarDTO dto);
        Task<CarDTO> Update(CarDTO dto);
        Task<bool> Delete(int id);
    }
}
