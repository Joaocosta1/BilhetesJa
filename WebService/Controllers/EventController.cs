using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using WebService.ViewModels;
using WebService.ViewModels.Event;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/events")]
    public class EventController : Controller
    {
        private readonly IEventService _eventService;
        private readonly IMapper _mapper;
        
        public EventController(IEventService eventService, IMapper mapper)
        {
            _eventService = eventService;
            _mapper = mapper;
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(Event), 200)]
        public async Task<IActionResult> Create([FromBody] CreateEventViewModel vm)
        {
            var @event = _mapper.Map<Event>(vm);
            await _eventService.SaveAsync(@event);
            return Ok(@event);
        }
        
        [HttpPut]
        [ProducesResponseType(typeof(Event), 200)]
        public async Task<IActionResult> Update([FromBody] UpdateEventViewModel vm)
        {
            var @event = _mapper.Map<Event>(vm);
            await _eventService.SaveAsync(@event);
            return Ok(@event);
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<PreviewEventViewModel>), 200)]
        public async Task<IActionResult> List([FromQuery] int limit = 10, [FromQuery] int page = 0)
        {
            var eventList = await _eventService.GetAsync(limit, page);
            var count = await _eventService.CountAsync();
            var pages = await _eventService.CountPagesAsync(limit);
            var mappedList = _mapper.Map<List<PreviewEventViewModel>>(eventList);
            return Ok(new {data = mappedList, page, limit, count, pages});
        }
    }
}  