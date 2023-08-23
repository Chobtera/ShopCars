using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopCars.Cars.Context;
using ShopCars.Cars.DTO;
using ShopCars.Cars.Repository;
using ShopCars.Cars.Repository.Contracts;

namespace ShopCars.Cars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandRepository _repository;

        public BrandController(IBrandRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BrandDTO>>> GetAll()
        {
            var brands = await _repository.GetAll();
            return Ok(brands);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<BrandDTO>> GetById(int id)
        {
            var brand = await _repository.GetById(id);
            return Ok(brand);
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<BrandDTO>> Create(BrandDTO dto)
        {
            if (dto == null) return BadRequest();
            var brand = await _repository.Create(dto);
            return Ok(brand);
        }
        [Authorize]
        [HttpPut]
        public async Task<ActionResult<BrandDTO>> Update(BrandDTO dto)
        {
            if (dto == null) return BadRequest();
            var brand = await _repository.Update(dto);
            return Ok(brand);
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var brand = await _repository.Delete(id);
            if (!brand) return BadRequest();
            return Ok(brand);
        }
    }
}
