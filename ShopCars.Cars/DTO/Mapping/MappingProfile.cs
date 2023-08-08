using AutoMapper;
using ShopCars.Cars.Models;

namespace ShopCars.Cars.DTO.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Brand, BrandDTO>().ReverseMap();
            CreateMap<Car, CarDTO>().ReverseMap();
        }
    }
}
