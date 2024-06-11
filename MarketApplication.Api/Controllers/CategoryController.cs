using MarketApplication.Core.Models;
using MarketApplication.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketApplication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("")]
        public async Task<IActionResult> InsertNew()
        {
           await _unitOfWork.Categories.AddNew(new Category
            {
                Name="Accessories",
                Description=""
            });

            return Ok(await _unitOfWork.Complete());
        }
    }
}
