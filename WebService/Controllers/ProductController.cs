using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Repository.Interface;
using WebService.ViewModels;
using WebService.ViewModels.Product;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        
        public ProductController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductViewModel vm)
        {
            var mappedProduct = _mapper.Map<Product>(vm);
            await _productService.SaveAsync(mappedProduct);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateProductViewModel vm)
        {
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> List([FromQuery] int productId, [FromQuery] int eventId, [FromQuery] int limit = 10, [FromQuery] int page = 0)
        {
            if (productId != 0)
            {
                var product = await _productService.FindByIdAsync(productId);
                var mappedProduct = _mapper.Map<PreviewProductViewModel>(product);
                return Ok(mappedProduct);
            }

            var products = await _productService.GetAsync(eventId, limit, page);
            var mappedProducts = _mapper.Map<List<PreviewProductViewModel>>(products);
            return Ok(mappedProducts);
        }
    }
}