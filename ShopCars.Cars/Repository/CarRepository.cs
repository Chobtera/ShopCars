using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopCars.Cars.Context;
using ShopCars.Cars.DTO;
using ShopCars.Cars.Models;
using ShopCars.Cars.Repository.Contracts;

namespace ShopCars.Cars.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly AppDbContext _context;
        private IMapper _mapper;

        public CarRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CarDTO>> GetAll()
        {
            List<Car> Cars = await _context.Cars.ToListAsync();
            return _mapper.Map<List<CarDTO>>(Cars);
        }

        public async Task<CarDTO> GetById(int id)
        {
            Car Car = await _context.Cars.Where(b => b.CarId == id).FirstOrDefaultAsync();
            return _mapper.Map<CarDTO>(Car);
        }
        public async Task<CarDTO> Create(CarDTO dto)
        {
            Car Car = _mapper.Map<Car>(dto);
            _context.Cars.Add(Car);
            await _context.SaveChangesAsync();
            return _mapper.Map<CarDTO>(Car);
        }
        public async Task<CarDTO> Update(CarDTO dto)
        {
            Car Car = _mapper.Map<Car>(dto);
            _context.Cars.Update(Car);
            await _context.SaveChangesAsync();
            return _mapper.Map<CarDTO>(Car);
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                Car Car =
                await _context.Cars.Where(p => p.CarId == id)
                    .FirstOrDefaultAsync();
                if (Car == null) return false;
                _context.Cars.Remove(Car);
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
