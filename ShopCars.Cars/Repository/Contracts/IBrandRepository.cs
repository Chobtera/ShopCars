using Microsoft.AspNetCore.Mvc;
using ShopCars.Cars.DTO;

namespace ShopCars.Cars.Repository.Contracts
{
    public interface IBrandRepository
    {
        Task<IEnumerable<BrandDTO>> GetAll();
        Task<BrandDTO> GetById(int id);
        Task<BrandDTO> Create(BrandDTO dto);
        Task<BrandDTO> Update(BrandDTO dto);
        Task<bool> Delete(int id);

    }
}
