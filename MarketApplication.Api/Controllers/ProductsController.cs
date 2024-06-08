using MarketApplication.Core.DTOs;
using MarketApplication.Core.Models;
using MarketApplication.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketApplication.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
          Product NewProduct= await _unitOfWork.Products.AddNew(new Product
            {
                Name = product.Name,
                Price = product.Price,
                CategoryId = product.CategoryId
            });

            await _unitOfWork.Complete;
            return Ok(NewProduct);
        }
    }
}
