using Microsoft.AspNetCore.Mvc;
using TrackStockRestApi.Core.Utilities.Result;
using TrackStockRestApi.Models;
using TrackStockRestApi.Service.Abstract;
using TrackStockRestApi.Service.Concrete;
using IResult = TrackStockRestApi.Core.Utilities.Result.IResult;
namespace TrackStockRestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAll")]
        public IDataResult<List<Product>> GetAll()
        {
            return _productService.GetAll();
        }

        [HttpGet("GetById")]
        public IDataResult<Product> GetById(Guid id)
        {
            return _productService.GetById(id);
        }

        [HttpPost("Add")]
        public async Task<IResult> Add(Product entity)
        {
            return await _productService.Add(entity);
        }

        [HttpPost("Update")]
        public async Task<IResult> Update(Product entity)
        {
            return await _productService.Update(entity);
        }

        [HttpPost("Delete")]
        public async Task<IResult> Delete(Guid id)
        {
            return await _productService.Delete(id);
        }
    }
}
