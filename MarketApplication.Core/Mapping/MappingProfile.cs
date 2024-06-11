using AutoMapper;
using MarketApplication.Core.DTOs;
using MarketApplication.Core.Models;
namespace MarketApplication.Core.Mapping;


public class MappingProfile: Profile
{

    public MappingProfile()
    {
        //map productDto to product object
        CreateMap<ProductDTO, Product>();

    }
}


