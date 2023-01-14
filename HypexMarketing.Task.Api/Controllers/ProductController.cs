using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.DTOs;

namespace HypexMarketing.Task.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductCore _productCore;
        public ProductController(IProductCore productCore)
        {
            _productCore = productCore;
        }

        [HttpPost]
        public IActionResult Post(ProductDto request)
        {
            var product = _productCore.AddProduct(request);

            return StatusCode((int)product.StatusCode, product);
        }


        [HttpGet]
        public IActionResult Get(int id)
        {
            var product = _productCore.GetById(id);

            return StatusCode((int)product.StatusCode, product);
        }


        [HttpGet]
        [Route("Search")]
        public IActionResult Search(string keyword, int page = 1, int pageSize = 10)
        {
            var products = _productCore.Search(keyword, page, pageSize);

            return StatusCode((int)products.StatusCode, products);
        }
    }
}
