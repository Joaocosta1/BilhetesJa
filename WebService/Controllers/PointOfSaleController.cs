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
    [Route("api/point-of-sale")]
    public class PointOfSaleController : Controller
    {
        private readonly IPointOfSaleService _pointService;
        private readonly IMapper _mapper;

        public PointOfSaleController(IPointOfSaleService pointService, IMapper mapper)
        {
            _pointService = pointService;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(PointOfSale), 200)]
        public async Task<IActionResult> Create([FromBody] CreatePointOfSaleViewModel m)
        {
            var @point = _mapper.Map<PointOfSale>(m);
            await _pointService.SaveAsync(@point);
            return Ok(@point);
        }

        [HttpPut]
        [ProducesResponseType(typeof(PointOfSale), 200)]
        public async Task<IActionResult> Update([FromBody] UpdatePointOfSaleViewModel m)
        {
            var @point = _mapper.Map<PointOfSale>(m);
            await _pointService.SaveAsync(@point);
            return Ok(@point);
        }

        [HttpGet]
        [ProducesResponseType(typeof(ICollection<PreviewPointOfSaleViewModel>), 200)]
        public async Task<IActionResult> List([FromQuery] int pointofsaleId, [FromQuery] int eventId ,[FromQuery] int limit = 10, [FromQuery] int page = 0)
        {

            if (pointofsaleId != 0)
            {
                var product = await _pointService.FindByIdAsync(pointofsaleId);
                var mappedProduct = _mapper.Map<PreviewPointOfSaleViewModel>(product);
                return Ok(mappedProduct);
            }

            var listPoint = await _pointService.GetAsync(eventId, limit, page);
            var count = await _pointService.CountAsync(eventId);
            var pages = await _pointService.CountPagesAsync(eventId ,limit);
            var mappList = _mapper.Map<List<PreviewEventViewModel>>(listPoint);
            return Ok(new { data = mappList, page, limit, count, pages });
        }

    }
}