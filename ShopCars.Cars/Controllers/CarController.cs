using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopCars.Cars.DTO;
using ShopCars.Cars.Repository;
using ShopCars.Cars.Repository.Contracts;

namespace ShopCars.Cars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _repository;

        public CarController(ICarRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarDTO>>> GetAll()
        {
            var Cars = await _repository.GetAll();
            return Ok(Cars);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CarDTO>> GetById(int id)
        {
            var Car = await _repository.GetById(id);
            return Ok(Car);
        }
        [HttpPost]
        public async Task<ActionResult<CarDTO>> Create(CarDTO dto)
        {
            if (dto == null) return BadRequest();
            var Car = await _repository.Create(dto);
            return Ok(Car);
        }
        [HttpPut]
        public async Task<ActionResult<CarDTO>> Update(CarDTO dto)
        {
            if (dto == null) return BadRequest();
            var Car = await _repository.Update(dto);
            return Ok(Car);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Car = await _repository.Delete(id);
            if (!Car) return BadRequest();
            return Ok(Car);
        }
    }
}
