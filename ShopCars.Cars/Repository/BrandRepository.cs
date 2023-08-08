using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopCars.Cars.Context;
using ShopCars.Cars.DTO;
using ShopCars.Cars.Models;
using ShopCars.Cars.Repository.Contracts;

namespace ShopCars.Cars.Repository
{
    public class BrandRepository : IBrandRepository
    {
        private readonly AppDbContext _context;
        private IMapper _mapper;

        public BrandRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BrandDTO>> GetAll()
        {
            List<Brand> brands = await _context.Brands.ToListAsync();
            return _mapper.Map<List<BrandDTO>>(brands);
        }

        public async Task<BrandDTO> GetById(int id)
        {
            Brand brand = await _context.Brands.Where(b => b.BrandId == id).FirstOrDefaultAsync();
            return _mapper.Map<BrandDTO>(brand);
        }
        public async Task<BrandDTO> Create(BrandDTO dto)
        {
            Brand brand = _mapper.Map<Brand>(dto);
            _context.Brands.Add(brand);
            await _context.SaveChangesAsync();
            return _mapper.Map<BrandDTO>(brand);
        }
        public async Task<BrandDTO> Update(BrandDTO dto)
        {
            Brand brand = _mapper.Map<Brand>(dto);
            _context.Brands.Update(brand);
            await _context.SaveChangesAsync();
            return _mapper.Map<BrandDTO>(brand);
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                Brand brand =
                await _context.Brands.Where(p => p.BrandId == id)
                    .FirstOrDefaultAsync();
                if (brand == null) return false;
                _context.Brands.Remove(brand);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
