using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using Repository.Repository;
using WebService.ViewModels;
using WebService.ViewModels.PaymentType;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/payment-types")]
    public class PaymentTypeController : Controller
    {
        private readonly IPaymentTypeService _paymentTypeService;
        private readonly IMapper _mapper;
        
        public PaymentTypeController(IPaymentTypeService paymentTypeService, IMapper mapper)
        {
            _paymentTypeService = paymentTypeService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePaymentTypeViewModel vm)
        {
            var mappedPaymentType = _mapper.Map<PaymentType>(vm);
            await _paymentTypeService.SaveAsync(mappedPaymentType);
            return Ok(mappedPaymentType);
        }
        
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdatePaymentTypeViewModel vm)
        {
            var mappedPaymentType = _mapper.Map<PaymentType>(vm);
            await _paymentTypeService.SaveAsync(mappedPaymentType);
            return Ok(mappedPaymentType);
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<PreviewPaymentTypeViewModel>), 200)]
        public async Task<IActionResult> List([FromQuery]int eventId = 0, [FromQuery] int limit = 10, [FromQuery] int page = 0)
        {
            ICollection<PaymentType> paymentTypeList;
            int count = 0;
            int pages = 0;
            if (eventId != 0)
            {
                paymentTypeList = await _paymentTypeService.GetAsync(eventId, limit, page);
                count = await _paymentTypeService.CountAsync(eventId);
                pages = await _paymentTypeService.CountPagesAsync(eventId, limit);
            }
            else
            {
                paymentTypeList = await _paymentTypeService.GetAsync(limit, page);
                count = await _paymentTypeService.CountAsync();
                pages = await _paymentTypeService.CountPagesAsync(limit);
            }

            var mappedList = _mapper.Map<List<PreviewPaymentTypeViewModel>>(paymentTypeList);
            return Ok(new {data = mappedList, page, limit, count, pages});
        }
    }
}