using AutoMapper;
using MarketApplication.Core.DTOs;
using MarketApplication.Core.Models;
using MarketApplication.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MarketApplication.Core.Mapping;

namespace MarketApplication.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductsController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet("GetAllProducts")]
        public async Task<ActionResult> Get()
        {
            return Ok(await _unitOfWork.Products.GetAll());
        }


        [HttpGet("GetActiveProducts")]
        public async Task<ActionResult> GetActive()
        {
           return Ok(await _unitOfWork.Products.Get(p => p.IsActive == true));
        }


        [HttpPost("InsertNewEntity")]
        public async Task<ActionResult> InsertNewEntity(ProductDTO product)
        {

            Product NewProductObject = _mapper.Map<Product>(product);
            Product NewProduct = await _unitOfWork.Products.AddNew(NewProductObject);

            await _unitOfWork.Complete();
            return Ok(NewProduct);
        }
    }
}
