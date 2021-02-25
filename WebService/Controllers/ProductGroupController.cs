using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using WebService.ViewModels;
using WebService.ViewModels.Event;
using WebService.ViewModels.PointOfSale;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/product-group")]
    public class ProductGroupController : Controller
    {
        private readonly IProductGroupService _productgroupService;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductGroupController(IProductGroupService productgroupService, IMapper mapper, IProductService productService)
        {
            _productgroupService = productgroupService;
            _mapper = mapper;
            _productService = productService;
        }


        [HttpPost]
        [ProducesResponseType(typeof(ProductGroup), 200)]
        public async Task<IActionResult> Create([FromBody] CreatePorductGroupViewModel pm)
        {
            var productgroup = _mapper.Map<ProductGroup>(pm);
            await _productgroupService.SaveAsync(productgroup);
            return Ok(productgroup);
        }

        [HttpPut]
        [ProducesResponseType(typeof(ProductGroup), 200)]
        public async Task<IActionResult> Update([FromBody] UpdateProductGroupViewModel pm)
        {
            var productgroup = _mapper.Map<ProductGroup>(pm);
            await _productgroupService.SaveAsync(productgroup);
            return Ok(productgroup);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ICollection<PreviewProductGroupViewModel>), 200)]
        public async Task<IActionResult> List([FromQuery] int productgroupId, [FromQuery] int eventId, [FromQuery] int limit = 10, [FromQuery] int page = 0)
        {

            if (productgroupId != 0)
            {
                var product = await _productgroupService.FindByIdAsync(productgroupId);
                var mappedProduct = _mapper.Map<PreviewPointOfSaleViewModel>(product);
                return Ok(mappedProduct);
            }

            var listGroup = await _productgroupService.GetAsync(eventId, limit, page);
            var count = await _productgroupService.CountAsync(eventId);
            var pages = await _productgroupService.CountPagesAsync(eventId, limit);
            var mappList = _mapper.Map<List<PreviewEventViewModel>>(listGroup);
            return Ok(new { data = mappList, page, limit, count, pages });
        }

        [HttpGet]
        [Route("ready-for-sale")]
        [ProducesResponseType(typeof(ICollection<PreviewReadForSaleViewModel>), 200)]
        public async Task<IActionResult> ReadForSale([FromQuery] int productgroupId, [FromQuery] int productId)
        {

            if (productgroupId != 0 && productId != 0)
            {
                var productRead = await _productgroupService.FindByIdAsync(productgroupId);
                var mappedProductRead = _mapper.Map<PreviewReadForSaleViewModel>(productRead);
                return Ok(mappedProductRead);
            }
            var productReads = await _productgroupService.GetAsync(productId);
            var mappedProductReads = _mapper.Map<List<PreviewReadForSaleViewModel>>(productReads);
            return Ok(mappedProductReads);
        }
    }
}