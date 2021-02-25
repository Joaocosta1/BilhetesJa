using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using WebService.ViewModels;
using WebService.ViewModels.Warehouse;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/warehouses")]
    public class WarehouseController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IWarehouseService _warehouseService;

        public WarehouseController(IMapper mapper, IWarehouseService warehouseService)
        {
            _mapper = mapper;
            _warehouseService = warehouseService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateWarehouseViewModel vm)
        {
            var mappedWarehouse = _mapper.Map<Warehouse>(vm);
            await _warehouseService.SaveAsync(mappedWarehouse);
            return Ok();
        }
        
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateWarehouseViewModel vm)
        {
            var mappedWarehouse = _mapper.Map<Warehouse>(vm);
            await _warehouseService.SaveAsync(mappedWarehouse);
            return Ok();
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Warehouse>), 200)]
        public async Task<IActionResult> List([FromQuery] int? warehouseId,[FromQuery] int eventId, [FromQuery] int limit = 10, [FromQuery] int page = 0)
        {
            if (warehouseId != null && warehouseId > 0)
            {
                var warehouse = await _warehouseService.FindByIdAsync(warehouseId??0);
                var mappedWarehouse = _mapper.Map<DetailWarehouseViewModel>(warehouse);
                return Ok(mappedWarehouse);
            }
            var list = await _warehouseService.GetAsync(eventId, limit, page);
            var count = await _warehouseService.CountAsync(eventId);
            var pages = await _warehouseService.CountPagesAsync(eventId);
            var mappedList = _mapper.Map<List<PreviewWarehouseViewModel>>(list);
            return Ok(new {data = mappedList, page, limit, count, pages});
        }
    }
}